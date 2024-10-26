using HotelBookingSystem.Models;
using HotelBookingSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelBookingSystem.Controllers
{
    public class BookingController : Controller
    {
        private HotelDbEntities objHotelDbEntities;
        public BookingController()
        {
            objHotelDbEntities= new HotelDbEntities();
        }
        [HttpGet]
        public ActionResult Index()
        {
            BookingViewModel objBookingViewModel= new BookingViewModel();
            objBookingViewModel.ListOfRooms = (from objRoom in objHotelDbEntities.Rooms
                                               where objRoom.BookingStatusId == 2
                                               select new SelectListItem()
                                               {
                                                   Text = objRoom.RoomNumber,
                                                   Value=objRoom.RoomId.ToString()
                                               }).ToList();
            objBookingViewModel.BookingFrom=DateTime.Now;
            objBookingViewModel.BookingTo=DateTime.Now.AddDays(1);
            return View(objBookingViewModel);
        }
        [HttpPost]
        public ActionResult Index(BookingViewModel objBookingViewModel)
        {
           int numberofdays=Convert.ToInt32((objBookingViewModel.BookingTo - objBookingViewModel.BookingFrom).TotalDays);
            Room objRoom=objHotelDbEntities.Rooms.Single(model=>model.RoomId==objBookingViewModel.AssignRoomId);
            decimal RoomPrice=objRoom.RoomPrice;

            decimal TotalAmount=RoomPrice*numberofdays;

            RoomBooking roomBooking = new RoomBooking()
            {
                BookingFrom = objBookingViewModel.BookingFrom,
                BookingTo = objBookingViewModel.BookingTo,
                AssignRoomId = objBookingViewModel.AssignRoomId,
                CustomerAddress = objBookingViewModel.CustomerAddress,
                CustomerName = objBookingViewModel.CustomerName,
                CustomerMobileNo = objBookingViewModel.CustomerMobileNo,
                NoOfMembers = objBookingViewModel.NoOfMembers,
                TotalAmount = TotalAmount
            };
            objHotelDbEntities.RoomBookings.Add(roomBooking);
            objHotelDbEntities.SaveChanges();
            objRoom.BookingStatusId = 3;
            objHotelDbEntities.SaveChanges();

            
            return Json(data: new {message="Hotel Booking is Successfully Created.",success=true},JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public PartialViewResult GetAllBookingHistory()
        {
            List<RoomBookingModel> listroomBookingModel=new List<RoomBookingModel>();
            listroomBookingModel = (from objHotelBooking in objHotelDbEntities.RoomBookings
                                    join objRoom in objHotelDbEntities.Rooms
                                    on objHotelBooking.AssignRoomId equals objRoom.RoomId
                                    select new RoomBookingModel()
                                    {
                                        BookingFrom = objHotelBooking.BookingFrom,
                                        BookingTo = objHotelBooking.BookingTo,
                                        CustomerMobileNo = objHotelBooking.CustomerMobileNo,
                                        Customername = objHotelBooking.CustomerName,
                                        TotalAmount = objHotelBooking.TotalAmount,
                                        CustomerAddress = objHotelBooking.CustomerAddress,
                                        NoOfMembers = objHotelBooking.NoOfMembers,
                                        BookingId = objHotelBooking.BookingId,
                                        RoomNumber = objRoom.RoomNumber,
                                        NoOfDays = System.Data.Entity.DbFunctions.DiffDays(objHotelBooking.BookingFrom,objHotelBooking.BookingTo).Value
                                  }).ToList();
            return PartialView("_BookingHistoryPartialView",listroomBookingModel);
        }

    }
}