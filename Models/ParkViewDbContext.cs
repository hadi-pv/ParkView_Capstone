using Microsoft.EntityFrameworkCore;
using ParkView_Capstone.Models.Services;
using ParkView_Capstone.Models.Bookings;
using ParkView_Capstone.Models.Facilities;
using ParkView_Capstone.Models.Room;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ParkView_Capstone.Models
{
    public class ParkViewDbContext:IdentityDbContext
    {
        public ParkViewDbContext(DbContextOptions<ParkViewDbContext> options) : base(options) { }

        public DbSet<Service> Services { get; set; }

        public DbSet<Booking> Bookings { get; set; }
        public DbSet<BookingRoomDetails> BookingRoomDetails { get; set; }
        public DbSet<BookingServiceDetails> BookingServiceDetails { get; set; }

        public DbSet<FacilityApply> FacilityApply { get; set;}
        public DbSet<FacilityType> FacilityType { get; set;}

        public DbSet<RoomType> RoomType { get; set;}
        public DbSet<RoomOccupied> RoomOccupied { get; set;}
        public DbSet<RoomLocked> RoomLocked { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder builder)
        {
            builder.Properties<DateOnly>()
                .HaveConversion<DateOnlyConverter>()
                .HaveColumnType("date");
        }  
    }

    public class DateOnlyConverter : ValueConverter<DateOnly, DateTime>
    {
        /// <summary>
        /// Creates a new instance of this converter.
        /// </summary>
        public DateOnlyConverter() : base(
                d => d.ToDateTime(TimeOnly.MinValue),
                d => DateOnly.FromDateTime(d))
        { }
    }
}
