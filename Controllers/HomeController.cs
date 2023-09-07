﻿using Microsoft.AspNetCore.Mvc;
using ParkView_Capstone.Models;
using ParkView_Capstone.Models.Bookings;
using ParkView_Capstone.Models.Rooms;
using ParkView_Capstone.ViewModels;
using System.Diagnostics;

namespace PageView_Capstone.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRoomRepo _roomRepo;
        public HomeController(ILogger<HomeController> logger, IRoomRepo roomRepo)
        {
            _logger = logger;
            _roomRepo = roomRepo;
        }

        public IActionResult Index()
        {
            IEnumerable<Room> rooms = _roomRepo.GetAllRooms;

            RoomListViewModal roomListViewModal = new RoomListViewModal()
            {
                Rooms = rooms,
                BookingRoomDetails = new BookingRoomDetails()
            };

            return View(roomListViewModal);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Aboutus()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}