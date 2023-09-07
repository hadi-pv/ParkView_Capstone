﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ParkView_Capstone.Models;

#nullable disable

namespace ParkView_Capstone.Migrations
{
    [DbContext(typeof(ParkViewDbContext))]
    partial class ParkViewDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("ParkView_Capstone.Models.Bookings.BookingCartItem", b =>
                {
                    b.Property<int>("BookingCartItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookingCartItemId"), 1L, 1);

                    b.Property<DateTime>("BookedDate")
                        .HasColumnType("date");

                    b.Property<string>("BookingCartId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BookingRoomDetailsId")
                        .HasColumnType("int");

                    b.Property<decimal>("RoomPriceFee")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BookingCartItemId");

                    b.HasIndex("BookingRoomDetailsId");

                    b.ToTable("BookingCartItems");
                });

            modelBuilder.Entity("ParkView_Capstone.Models.Bookings.BookingRoomDetails", b =>
                {
                    b.Property<int>("BookingRoomDetailsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookingRoomDetailsId"), 1L, 1);

                    b.Property<int>("AdultNo")
                        .HasColumnType("int");

                    b.Property<DateTime>("BookedDate")
                        .HasColumnType("date");

                    b.Property<string>("BookingCartId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CheckInDate")
                        .HasColumnType("date");

                    b.Property<DateTime>("CheckOutDate")
                        .HasColumnType("date");

                    b.Property<int>("ChildrenNo")
                        .HasColumnType("int");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.Property<decimal>("RoomPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("RoomQuantity")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BookingRoomDetailsId");

                    b.HasIndex("RoomId");

                    b.ToTable("BookingRoomDetails");
                });

            modelBuilder.Entity("ParkView_Capstone.Models.Bookings.BookingServiceDetails", b =>
                {
                    b.Property<int>("BookingServiceDetailsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookingServiceDetailsId"), 1L, 1);

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.Property<decimal>("ServicePriceAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ServiceQuantity")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BookingServiceDetailsId");

                    b.HasIndex("ServiceId");

                    b.ToTable("BookingServiceDetails");
                });

            modelBuilder.Entity("ParkView_Capstone.Models.Bookings.BookingServiceItem", b =>
                {
                    b.Property<int>("BookingServiceItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookingServiceItemId"), 1L, 1);

                    b.Property<DateTime>("BookedDate")
                        .HasColumnType("date");

                    b.Property<string>("BookingCartId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BookingServiceDetailsId")
                        .HasColumnType("int");

                    b.Property<decimal>("SericePriceFee")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BookingServiceItemId");

                    b.HasIndex("BookingServiceDetailsId");

                    b.ToTable("BookingServiceItem");
                });

            modelBuilder.Entity("ParkView_Capstone.Models.Facilities.FacilityApply", b =>
                {
                    b.Property<int>("FacilityApplyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FacilityApplyId"), 1L, 1);

                    b.Property<int>("FacilityTypeId")
                        .HasColumnType("int");

                    b.Property<int>("RoomTypeId")
                        .HasColumnType("int");

                    b.HasKey("FacilityApplyId");

                    b.HasIndex("FacilityTypeId");

                    b.HasIndex("RoomTypeId");

                    b.ToTable("FacilityApply");
                });

            modelBuilder.Entity("ParkView_Capstone.Models.Facilities.FacilityType", b =>
                {
                    b.Property<int>("FacilityTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FacilityTypeId"), 1L, 1);

                    b.Property<string>("FacilityDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FacilityImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FacilityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FacilityTypeId");

                    b.ToTable("FacilityType");

                    b.HasData(
                        new
                        {
                            FacilityTypeId = 1,
                            FacilityDescription = "It is a infinity pool",
                            FacilityImage = "",
                            FacilityName = "Pool"
                        },
                        new
                        {
                            FacilityTypeId = 2,
                            FacilityDescription = "High Speed Wi Fi",
                            FacilityImage = "",
                            FacilityName = "Wifi"
                        },
                        new
                        {
                            FacilityTypeId = 3,
                            FacilityDescription = "Very Spacious Parking Space",
                            FacilityImage = "",
                            FacilityName = "Parking"
                        },
                        new
                        {
                            FacilityTypeId = 4,
                            FacilityDescription = "World Class Room Service",
                            FacilityImage = "",
                            FacilityName = "Room Service"
                        },
                        new
                        {
                            FacilityTypeId = 5,
                            FacilityDescription = "Can manage any types of fabrics and cloth types.",
                            FacilityImage = "",
                            FacilityName = "Laundry"
                        },
                        new
                        {
                            FacilityTypeId = 6,
                            FacilityDescription = "World Class Gym",
                            FacilityImage = "",
                            FacilityName = "Gym"
                        },
                        new
                        {
                            FacilityTypeId = 7,
                            FacilityDescription = "Cab Services to most of tourist and transport places.",
                            FacilityImage = "",
                            FacilityName = "Cab Service"
                        });
                });

            modelBuilder.Entity("ParkView_Capstone.Models.Hotels.Hotel", b =>
                {
                    b.Property<int>("HotelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HotelId"), 1L, 1);

                    b.Property<string>("HotelDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HotelImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HotelLocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HotelName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HotelId");

                    b.ToTable("Hotel");

                    b.HasData(
                        new
                        {
                            HotelId = 1,
                            HotelDescription = "In the center of city",
                            HotelImage = "/images/hotel2.png",
                            HotelLocation = "Mumbai",
                            HotelName = "ParkView Bombay"
                        },
                        new
                        {
                            HotelId = 2,
                            HotelDescription = "In the center of city",
                            HotelImage = "/images/hotel3.jpeg",
                            HotelLocation = "Bengaluru",
                            HotelName = "ParkView Bangalore"
                        },
                        new
                        {
                            HotelId = 3,
                            HotelDescription = "In the center of city",
                            HotelImage = "/images/hotell1.jpeg",
                            HotelLocation = "Chennai",
                            HotelName = "ParkView Chennai"
                        });
                });

            modelBuilder.Entity("ParkView_Capstone.Models.Rooms.Room", b =>
                {
                    b.Property<int>("RoomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoomId"), 1L, 1);

                    b.Property<int>("HotelId")
                        .HasColumnType("int");

                    b.Property<decimal>("RoomPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("RoomQuantity")
                        .HasColumnType("int");

                    b.Property<int>("RoomTypeId")
                        .HasColumnType("int");

                    b.HasKey("RoomId");

                    b.HasIndex("HotelId");

                    b.HasIndex("RoomTypeId");

                    b.ToTable("Room");
                });

            modelBuilder.Entity("ParkView_Capstone.Models.Rooms.RoomLocked", b =>
                {
                    b.Property<int>("RoomLockedId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoomLockedId"), 1L, 1);

                    b.Property<DateTime>("RoomCheckIn")
                        .HasColumnType("date");

                    b.Property<DateTime>("RoomCheckOut")
                        .HasColumnType("date");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.Property<int>("RoomQuantity")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoomLockedId");

                    b.HasIndex("RoomId");

                    b.ToTable("RoomLocked");
                });

            modelBuilder.Entity("ParkView_Capstone.Models.Rooms.RoomOccupied", b =>
                {
                    b.Property<int>("RoomOccupiedId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoomOccupiedId"), 1L, 1);

                    b.Property<int>("BookingRoomDetailsId")
                        .HasColumnType("int");

                    b.Property<bool>("IsCancelled")
                        .HasColumnType("bit");

                    b.Property<string>("RP_Payment_id")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RP_Signature_id")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RoomCheckIn")
                        .HasColumnType("date");

                    b.Property<DateTime>("RoomCheckOut")
                        .HasColumnType("date");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.Property<int>("RoomQuantity")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoomOccupiedId");

                    b.HasIndex("RoomId");

                    b.ToTable("RoomOccupied");
                });

            modelBuilder.Entity("ParkView_Capstone.Models.Rooms.RoomType", b =>
                {
                    b.Property<int>("RoomTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoomTypeId"), 1L, 1);

                    b.Property<int>("MaxAdult")
                        .HasColumnType("int");

                    b.Property<int>("MaxChildren")
                        .HasColumnType("int");

                    b.Property<int>("MaxPeople")
                        .HasColumnType("int");

                    b.Property<string>("RoomDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("RoomGst")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("RoomName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoomTypeImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoomTypeId");

                    b.ToTable("RoomType");

                    b.HasData(
                        new
                        {
                            RoomTypeId = 1,
                            MaxAdult = 6,
                            MaxChildren = 3,
                            MaxPeople = 9,
                            RoomDescription = "It is a Presidential Suite",
                            RoomGst = 18m,
                            RoomName = "Presidential Suite",
                            RoomTypeImage = "/images/room-1.png"
                        },
                        new
                        {
                            RoomTypeId = 2,
                            MaxAdult = 5,
                            MaxChildren = 2,
                            MaxPeople = 7,
                            RoomDescription = "It is a Executive",
                            RoomGst = 18m,
                            RoomName = "Executive",
                            RoomTypeImage = "/images/room-2.png"
                        },
                        new
                        {
                            RoomTypeId = 3,
                            MaxAdult = 4,
                            MaxChildren = 2,
                            MaxPeople = 6,
                            RoomDescription = "It is a Super Deluxe",
                            RoomGst = 12m,
                            RoomName = "Super Deluxe",
                            RoomTypeImage = "/images/room-3.png"
                        },
                        new
                        {
                            RoomTypeId = 4,
                            MaxAdult = 2,
                            MaxChildren = 2,
                            MaxPeople = 4,
                            RoomDescription = "It is a Deluxe",
                            RoomGst = 12m,
                            RoomName = "Deluxe",
                            RoomTypeImage = "/images/room-5.png"
                        });
                });

            modelBuilder.Entity("ParkView_Capstone.Models.Servicess.Services", b =>
                {
                    b.Property<int>("ServiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ServiceId"), 1L, 1);

                    b.Property<string>("ServiceDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ServiceImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ServiceName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("ServicePrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ServiceId");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ParkView_Capstone.Models.Bookings.BookingCartItem", b =>
                {
                    b.HasOne("ParkView_Capstone.Models.Bookings.BookingRoomDetails", "BookingRoomDetails")
                        .WithMany()
                        .HasForeignKey("BookingRoomDetailsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BookingRoomDetails");
                });

            modelBuilder.Entity("ParkView_Capstone.Models.Bookings.BookingRoomDetails", b =>
                {
                    b.HasOne("ParkView_Capstone.Models.Rooms.Room", "Room")
                        .WithMany()
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Room");
                });

            modelBuilder.Entity("ParkView_Capstone.Models.Bookings.BookingServiceDetails", b =>
                {
                    b.HasOne("ParkView_Capstone.Models.Servicess.Services", "Service")
                        .WithMany()
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Service");
                });

            modelBuilder.Entity("ParkView_Capstone.Models.Bookings.BookingServiceItem", b =>
                {
                    b.HasOne("ParkView_Capstone.Models.Bookings.BookingServiceDetails", "BookingServiceDetails")
                        .WithMany()
                        .HasForeignKey("BookingServiceDetailsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BookingServiceDetails");
                });

            modelBuilder.Entity("ParkView_Capstone.Models.Facilities.FacilityApply", b =>
                {
                    b.HasOne("ParkView_Capstone.Models.Facilities.FacilityType", "FacilityType")
                        .WithMany()
                        .HasForeignKey("FacilityTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ParkView_Capstone.Models.Rooms.RoomType", "RoomType")
                        .WithMany()
                        .HasForeignKey("RoomTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FacilityType");

                    b.Navigation("RoomType");
                });

            modelBuilder.Entity("ParkView_Capstone.Models.Rooms.Room", b =>
                {
                    b.HasOne("ParkView_Capstone.Models.Hotels.Hotel", "Hotel")
                        .WithMany()
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ParkView_Capstone.Models.Rooms.RoomType", "RoomType")
                        .WithMany()
                        .HasForeignKey("RoomTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");

                    b.Navigation("RoomType");
                });

            modelBuilder.Entity("ParkView_Capstone.Models.Rooms.RoomLocked", b =>
                {
                    b.HasOne("ParkView_Capstone.Models.Rooms.Room", "Room")
                        .WithMany()
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Room");
                });

            modelBuilder.Entity("ParkView_Capstone.Models.Rooms.RoomOccupied", b =>
                {
                    b.HasOne("ParkView_Capstone.Models.Rooms.Room", "Room")
                        .WithMany()
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Room");
                });
#pragma warning restore 612, 618
        }
    }
}
