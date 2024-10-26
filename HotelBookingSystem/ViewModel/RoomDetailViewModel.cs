using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelBookingSystem.ViewModel
{
    public class RoomDetailViewModel
    {
        public int RoomId { get; set; }

        public string RoomNumber { get; set; }
        [Display(Name = "Room Image")]
        public string RoomImage { get; set; }
        [Display(Name = "Room Price")]
        public Decimal RoomPrice { get; set; }

        public string BookingStatus { get; set; }

        public string RoomType { get; set; }

        public int RoomCapcity { get; set; }

        public string RoomDescription { get; set; }
    }
}