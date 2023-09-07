using Microsoft.AspNetCore.Mvc.ModelBinding;
using ParkView_Capstone.Models.Servicess;

namespace ParkView_Capstone.Models.Bookings
{
    public class BookingServiceDetails
    {
        public int BookingServiceDetailsId { get; set; }
        public int ServiceId { get; set; }
        public int ServiceQuantity { get; set; }
        public decimal ServicePriceAmount { get; set; }
        public string UserId { get; set; }
        public DateOnly BookedDate => new DateOnly(DateTime.Now.Date.Year, DateTime.Now.Date.Month, DateTime.Now.Date.Day);

        public Services? Service{ get; set; }
        [BindNever]
        public string? BookingCartId { get; set; }
    }
}
