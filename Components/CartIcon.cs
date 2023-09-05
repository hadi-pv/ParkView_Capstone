using Microsoft.AspNetCore.Mvc;
using ParkView_Capstone.Models.Bookings;
using ParkView_Capstone.ViewModels;

namespace ParkView_Capstone.Components
{
    public class CartIcon:ViewComponent
    {
        private readonly BookingCart _bookingcart;

        public CartIcon(BookingCart bookingCart)
        {
            _bookingcart = bookingCart;
        }

        public IViewComponentResult Invoke()
        {
            var items = _bookingcart.GetBookingCartItems();

            var bookingcartviewmodal = new BookingCartViewModel()
            {
                bookingCart = items
            };

            return View(bookingcartviewmodal);
        }
    }
}
