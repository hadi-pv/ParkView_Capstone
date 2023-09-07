using Microsoft.AspNetCore.Mvc;
using ParkView_Capstone.Models;
using ParkView_Capstone.Models.Bookings;
using ParkView_Capstone.Models.Rooms;
using ParkView_Capstone.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using ParkView_Capstone.Models.Hotels;
using ParkView_Capstone.Models.Servicess;
using Razorpay.Api;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow.ValueContentAnalysis;

namespace ParkView_Capstone.Controllers
{
    [Authorize]
    public class BookingCartController : Controller
    {
        private readonly IRoomRepo _roomRepo;
        private readonly BookingCart _bookingCart;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ParkViewDbContext _dbcontext;
        private readonly IServiceRepo _serviceRepo;
        public IServiceProvider services { get; set; }

        public BookingCartController(IServiceRepo serviceRepo,IRoomRepo roomRepo, BookingCart bookingCart,UserManager<IdentityUser> userManager,ParkViewDbContext parkViewDbContext,IServiceProvider services)
        {
            _roomRepo = roomRepo;
            _bookingCart = bookingCart;
            _userManager = userManager;
            _dbcontext = parkViewDbContext;
            this.services = services;
            _serviceRepo = serviceRepo;
        }

        public IActionResult Index()
        {
            var items = _bookingCart.GetBookingCartItems();
            _bookingCart.BookingCartItems = items;
            var serviceitems=_serviceRepo.GetCartServiceItems().ToList();

            var bookingcartviewmodel = new BookingCartViewModel()
            {
                bookingCart = items,
                servicecart = serviceitems
            };

            return View(bookingcartviewmodel);
        }


        public RedirectToActionResult AddRoomQuantity(int bookingdetailsid,int quantity)
        {
            var bookingcartitem = _bookingCart.GetBookingCartItems().SingleOrDefault(m => m.BookingCartItemId == bookingdetailsid);
            if (quantity == 0)
            {
                _bookingCart.RemoveFromCart(bookingcartitem);
            }
            else
            {
                bookingcartitem.BookingRoomDetails.RoomQuantity = quantity;
            }
            _dbcontext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public RedirectToActionResult AddToBookingCart(BookingRoomDetails bookingRoomDetails,string cidate,string codate)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>().HttpContext.Session;
            Console.WriteLine(ModelState);
            if(ModelState.IsValid)
            {
                Room room = _roomRepo.GetAllRooms.First(r => r.RoomId == bookingRoomDetails.RoomId);
                Console.WriteLine(bookingRoomDetails.CheckInDate);

                var selectedroom = new BookingRoomDetails()
                {
                    RoomId = bookingRoomDetails.RoomId,
                    Room = room,
                    RoomQuantity = bookingRoomDetails.RoomQuantity,
                    RoomPrice = room.RoomPrice,
                    AdultNo = bookingRoomDetails.AdultNo,
                    ChildrenNo = bookingRoomDetails.ChildrenNo,
                    CheckInDate = bookingRoomDetails.CheckInDate== new DateOnly(0001,01,01) ? DateOnly.ParseExact(cidate,"yyyy-MM-dd", null) : bookingRoomDetails.CheckInDate,
                    CheckOutDate = bookingRoomDetails.CheckOutDate==new DateOnly(0001,01,01)? DateOnly.ParseExact(codate, "yyyy-MM-dd", null) : bookingRoomDetails.CheckOutDate
                    /*DateOnly.ParseExact(bookingRoomDetails.CheckOutDate.ToString("yyyy-MM-dd"), "yyyy-MM-dd", null)*/,
                    BookedDate = new DateOnly(DateTime.Now.Date.Year, DateTime.Now.Date.Month, DateTime.Now.Date.Day),
                    UserId = _userManager.GetUserId(HttpContext.User),
                    BookingCartId = session.GetString("CartId")
                };
                _bookingCart.AddToBookingCart(selectedroom);
            }
            else
            {
                Console.WriteLine("Error in AddToBookingCart");
            }

            return RedirectToAction("Index");
        }


        public IActionResult CompleteBooking(decimal total)
        {
            var bookingcartitems=_bookingCart.GetBookingCartItems();
            var servicecartitems = _serviceRepo.GetCartServiceItems();
            if (bookingcartitems == null && servicecartitems==null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                //_bookingCart.CompleteBooking(bookingcartitems);
                decimal gstamt=0;
                foreach (var item in bookingcartitems)
                {
                    gstamt = item.RoomPriceFee * item.BookingRoomDetails.Room.RoomType.RoomGst/100;
                }
                CheckOut checkOut = new CheckOut()
                {
                    BookingCartId = bookingcartitems.First().BookingCartId,
                    Items = bookingcartitems,
                    BookedDate = new DateOnly(DateTime.Now.Date.Year, DateTime.Now.Date.Month, DateTime.Now.Date.Day),
                    Total = total+gstamt+servicecartitems.Select(s=>s.ServicePriceAmount).Sum()*118/100,
                    User = _dbcontext.Users.SingleOrDefault(s=>s.Id==bookingcartitems.First().UserId),
                    Services=servicecartitems
                };
                var key = "rzp_test_HUUxPpsvhCwwbi";
                var secret = "fIEMLCIeIOR4oU5I0NPWq7xe";
                RazorpayClient client = new RazorpayClient(key, secret);
                Dictionary<string, object> options = new Dictionary<string, object>();
                options.Add("amount", Convert.ToDecimal(checkOut.Total / 100) * 100);
                options.Add("currency", "INR");
                Order order = client.Order.Create(options);
                ViewBag.orderId = order["id"].ToString();
                return View(checkOut);
            }
        }

        public IActionResult ShowPrevOrders()
        {
            var userid = _userManager.GetUserId(HttpContext.User);
            var result = _bookingCart.GetAllPrevorders(userid);
            var result2 = _serviceRepo.GetPrevServices(userid);

            List<CheckOut> checkOutList = new List<CheckOut>();

            foreach (var item in result)
            {
                Console.WriteLine(result2);
                checkOutList.Add(
                    new CheckOut()
                    {
                        BookingCartId = item.Value.First().BookingCartId,
                        Items = item.Value,
                        BookedDate = item.Value.First().BookedDate,
                        Total = item.Value.Select(r => r.RoomPriceFee).Sum(),
                        User = _dbcontext.Users.SingleOrDefault(s => s.Id == userid),
                        Services = result2.Where(r=>r.BookingCartId== item.Value.First().BookingCartId)
                    }) ;
            }
            return View(checkOutList);
        }

        public RedirectToActionResult DeleteBooking(int bookingid)
        {
            _bookingCart.DeleteBooking(bookingid);
            return RedirectToActionPermanent("ShowPrevOrders");
        }

        public RedirectToActionResult DeleteService(int serviceid)
        {
            _bookingCart.DeleteService(serviceid);
            return RedirectToActionPermanent("ShowPrevOrders");
        }

        public IActionResult SuccessfulPayment(string payid,string orderid,string sigid)
        {
            var bookingcartitems = _bookingCart.GetBookingCartItems();
            var servicecartitems = _serviceRepo.GetCartServiceItems();
            _bookingCart.CompleteBooking(bookingcartitems, servicecartitems,payid, orderid,sigid);
            return View();
        }

            
    }
}
