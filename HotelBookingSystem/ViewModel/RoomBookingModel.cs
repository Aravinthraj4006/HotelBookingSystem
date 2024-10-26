using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelBookingSystem.ViewModel
{
    public class RoomBookingModel
    {
        public int BookingId { get; set; }

        public string Customername { get; set; }

        public string CustomerAddress { get; set; }

        public int NoOfMembers { get; set; }

        public string CustomerMobileNo { get; set; }

        public DateTime BookingFrom { get; set; }

        public DateTime BookingTo { get; set; }

        public string RoomNumber { get; set; }

        public decimal TotalAmount { get; set; }

        public int NoOfDays { get; set; }
    }
}