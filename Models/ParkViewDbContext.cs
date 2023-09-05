using Microsoft.EntityFrameworkCore;
using ParkView_Capstone.Models.Services;
using ParkView_Capstone.Models.Bookings;
using ParkView_Capstone.Models.Facilities;
using ParkView_Capstone.Models.Rooms;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ParkView_Capstone.Models.Hotels;

namespace ParkView_Capstone.Models
{
    public class ParkViewDbContext:IdentityDbContext
    {
        public ParkViewDbContext(DbContextOptions<ParkViewDbContext> options) : base(options) { }

        public DbSet<Service> Services { get; set; }

        public DbSet<Hotel> Hotel { get; set; }

        public DbSet<BookingCartItem> BookingCartItems { get; set; }
        public DbSet<BookingRoomDetails> BookingRoomDetails { get; set; }
        public DbSet<BookingServiceDetails> BookingServiceDetails { get; set; }

        public DbSet<FacilityApply> FacilityApply { get; set;}
        public DbSet<FacilityType> FacilityType { get; set;}

        public DbSet<Room> Room { get; set; }
        public DbSet<RoomType> RoomType { get; set;}
        public DbSet<RoomOccupied> RoomOccupied { get; set;}
        public DbSet<RoomLocked> RoomLocked { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //RoomTypes
            modelBuilder.Entity<RoomType>().HasData(
                new RoomType()
                {
                    RoomTypeId=1,
                    RoomName="Presidential Suite",
                    RoomDescription="It is a Presidential Suite",
                    RoomTypeImage="",
                    MaxAdult=6,
                    MaxChildren=3,
                    MaxPeople=9
                });
            modelBuilder.Entity<RoomType>().HasData(
                new RoomType()
                {
                    RoomTypeId=2,
                    RoomName = "Executive",
                    RoomDescription = "It is a Executive",
                    RoomTypeImage = "",
                    MaxAdult = 5,
                    MaxChildren = 2,
                    MaxPeople = 7
                });
            modelBuilder.Entity<RoomType>().HasData(
                new RoomType()
                {
                    RoomTypeId=3,
                    RoomName = "Super Deluxe",
                    RoomDescription = "It is a Super Deluxe",
                    RoomTypeImage = "",
                    MaxAdult = 4,
                    MaxChildren = 2,
                    MaxPeople = 6
                });
            modelBuilder.Entity<RoomType>().HasData(
                new RoomType()
                {
                    RoomTypeId=4,
                    RoomName = "Deluxe",
                    RoomDescription = "It is a Deluxe",
                    RoomTypeImage = "",
                    MaxAdult = 2,
                    MaxChildren = 2,
                    MaxPeople = 4
                });

            //Hotels
            modelBuilder.Entity<Hotel>().HasData(
                new Hotel()
                {
                    HotelId=1,
                    HotelName="ParkView Bombay",
                    HotelLocation="Mumbai",
                    HotelDescription="In the center of city",
                    HotelImage=""
                });
            modelBuilder.Entity<Hotel>().HasData(
                new Hotel()
                {
                    HotelId = 2,
                    HotelName = "ParkView Bangalore",
                    HotelLocation = "Bengaluru",
                    HotelDescription = "In the center of city",
                    HotelImage = ""
                });
            modelBuilder.Entity<Hotel>().HasData(
                new Hotel()
                {
                    HotelId = 3,
                    HotelName = "ParkView Chennai",
                    HotelLocation = "Chennai",
                    HotelDescription = "In the center of city",
                    HotelImage = ""
                });

            //Facilities
            modelBuilder.Entity<FacilityType>().HasData(
                new FacilityType()
                {
                    FacilityTypeId=1,
                    FacilityName="Pool",
                    FacilityDescription="It is a infinity pool",
                    FacilityImage=""
                });
            modelBuilder.Entity<FacilityType>().HasData(
                new FacilityType()
                {
                    FacilityTypeId = 2,
                    FacilityName = "Wifi",
                    FacilityDescription = "High Speed Wi Fi",
                    FacilityImage = ""
                });
            modelBuilder.Entity<FacilityType>().HasData(
                new FacilityType()
                {
                    FacilityTypeId = 3,
                    FacilityName = "Parking",
                    FacilityDescription = "Very Spacious Parking Space",
                    FacilityImage = ""
                });
            modelBuilder.Entity<FacilityType>().HasData(
                new FacilityType()
                {
                    FacilityTypeId = 4,
                    FacilityName = "Room Service",
                    FacilityDescription = "World Class Room Service",
                    FacilityImage = ""
                });
            modelBuilder.Entity<FacilityType>().HasData(
                new FacilityType()
                {
                    FacilityTypeId = 5,
                    FacilityName = "Laundry",
                    FacilityDescription = "Can manage any types of fabrics and cloth types.",
                    FacilityImage = ""
                });
            modelBuilder.Entity<FacilityType>().HasData(
                new FacilityType()
                {
                    FacilityTypeId = 6,
                    FacilityName = "Gym",
                    FacilityDescription = "World Class Gym",
                    FacilityImage = ""
                });
            modelBuilder.Entity<FacilityType>().HasData(
                new FacilityType()
                {
                    FacilityTypeId = 7,
                    FacilityName = "Cab Service",
                    FacilityDescription = "Cab Services to most of tourist and transport places.",
                    FacilityImage = ""
                });


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
