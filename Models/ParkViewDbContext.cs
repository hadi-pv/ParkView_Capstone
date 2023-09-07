using Microsoft.EntityFrameworkCore;
using ParkView_Capstone.Models.Servicess;
using ParkView_Capstone.Models.Bookings;
using ParkView_Capstone.Models.Facilities;
using ParkView_Capstone.Models.Rooms;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ParkView_Capstone.Models.Hotels;



namespace ParkView_Capstone.Models
{
    public class ParkViewDbContext : IdentityDbContext
    {
        public ParkViewDbContext(DbContextOptions<ParkViewDbContext> options) : base(options) { }



        public DbSet<Services> Services { get; set; }
        public DbSet<BookedService> BookedServices { get; set; }

        public DbSet<Hotel> Hotel { get; set; }

        public DbSet<BookingCartItem> BookingCartItems { get; set; }
        public DbSet<BookingRoomDetails> BookingRoomDetails { get; set; }
        public DbSet<BookingServiceDetails> BookingServiceDetails { get; set; }

        public DbSet<BookingServiceItem> BookingServiceItem { get; set; }

        public DbSet<FacilityApply> FacilityApply { get; set; }
        public DbSet<FacilityType> FacilityType { get; set; }



        public DbSet<Room> Room { get; set; }
        public DbSet<RoomType> RoomType { get; set; }
        public DbSet<RoomOccupied> RoomOccupied { get; set; }
        public DbSet<RoomLocked> RoomLocked { get; set; }





        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);



            //RoomTypes
            modelBuilder.Entity<RoomType>().HasData(
                new RoomType()
                {
                    RoomTypeId = 1,
                    RoomName = "Presidential Suite",
                    RoomDescription = "It is a Presidential Suite",
                    RoomTypeImage = "/images/room-1.png",
                    MaxAdult = 6,
                    MaxChildren = 3,
                    MaxPeople = 9,
                    RoomGst=18
                });
            modelBuilder.Entity<RoomType>().HasData(
                new RoomType()
                {
                    RoomTypeId = 2,
                    RoomName = "Executive",
                    RoomDescription = "It is a Executive",
                    RoomTypeImage = "/images/room-2.png",
                    MaxAdult = 5,
                    MaxChildren = 2,
                    MaxPeople = 7,
                    RoomGst = 18
                });
            modelBuilder.Entity<RoomType>().HasData(
                new RoomType()
                {
                    RoomTypeId = 3,
                    RoomName = "Super Deluxe",
                    RoomDescription = "It is a Super Deluxe",
                    RoomTypeImage = "/images/room-3.png",
                    MaxAdult = 4,
                    MaxChildren = 2,
                    MaxPeople = 6,
                    RoomGst = 12
                });
            modelBuilder.Entity<RoomType>().HasData(
                new RoomType()
                {
                    RoomTypeId = 4,
                    RoomName = "Deluxe",
                    RoomDescription = "It is a Deluxe",
                    RoomTypeImage = "/images/room-5.png",
                    MaxAdult = 2,
                    MaxChildren = 2,
                    MaxPeople = 4,
                    RoomGst = 12
                });



            //Hotels
            modelBuilder.Entity<Hotel>().HasData(
                new Hotel()
                {
                    HotelId = 1,
                    HotelName = "ParkView Bombay",
                    HotelLocation = "Mumbai",
                    HotelDescription = "In the center of city",
                    HotelImage = "/images/hotel2.png"
                });
            modelBuilder.Entity<Hotel>().HasData(
                new Hotel()
                {
                    HotelId = 2,
                    HotelName = "ParkView Bangalore",
                    HotelLocation = "Bengaluru",
                    HotelDescription = "In the center of city",
                    HotelImage = "/images/hotel3.jpeg"
                });
            modelBuilder.Entity<Hotel>().HasData(
                new Hotel()
                {
                    HotelId = 3,
                    HotelName = "ParkView Chennai",
                    HotelLocation = "Chennai",
                    HotelDescription = "In the center of city",
                    HotelImage = "/images/hotell1.jpeg"
                });



            //Facilities
            modelBuilder.Entity<FacilityType>().HasData(
                new FacilityType()
                {
                    FacilityTypeId = 1,
                    FacilityName = "Pool",
                    FacilityDescription = "It is a infinity pool",
                    FacilityImage = ""
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