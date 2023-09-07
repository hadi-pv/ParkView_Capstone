using Microsoft.AspNetCore.Mvc;
using ParkView_Capstone.Models;
using ParkView_Capstone.Models.Bookings;
using ParkView_Capstone.ViewModels;

namespace ParkView_Capstone.Components
{
    public class CartIcon:ViewComponent
    {
        private readonly BookingCart _bookingcart;
        private readonly IServiceRepo _serviceRepo;

        public CartIcon(BookingCart bookingCart,IServiceRepo serviceRepo)
        {
            _bookingcart = bookingCart;
            _serviceRepo = serviceRepo;
        }

        public IViewComponentResult Invoke()
        {
            var items = _bookingcart.GetBookingCartItems();
            var servitem = _serviceRepo.GetCartServiceItems().ToList();

            var bookingcartviewmodal = new BookingCartViewModel()
            {
                bookingCart = items,
                servicecart = servitem,
            };

            return View(bookingcartviewmodal);
        }
    }
}
