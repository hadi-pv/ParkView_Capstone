using Microsoft.EntityFrameworkCore;
using ParkView_Capstone.Models.Bookings;

namespace ParkView_Capstone.Models
{
    public class BookingDbRepo : IBookingRepo
    {
        private readonly ParkViewDbContext _dbcontext;

        public BookingDbRepo(ParkViewDbContext dbcontext)
        {
            _dbcontext= dbcontext;
        }
        public IEnumerable<BookingRoomDetails> BookingRoomDetails => _dbcontext.BookingRoomDetails.Include(b=>b.Room).Include(b=>b.Room.RoomType).Include(b=>b.Room.Hotel);

        public void AddBookingRoomDetails(BookingRoomDetails bookingRoomDetails)
        {
            if (_dbcontext.BookingRoomDetails.Any(b => b.RoomId == bookingRoomDetails.RoomId))
            {
                BookingRoomDetails.First(b => b.RoomId == bookingRoomDetails.RoomId).RoomQuantity = bookingRoomDetails.RoomQuantity;
            }
            else
            {
                BookingRoomDetails.Append(bookingRoomDetails);
            }
        }

        public BookingRoomDetails GetBookingRoomDetails(int bookingroomdetailsid)
        {
            return _dbcontext.BookingRoomDetails.FirstOrDefault(b => b.BookingRoomDetailsId == bookingroomdetailsid);
        }
    }
}
