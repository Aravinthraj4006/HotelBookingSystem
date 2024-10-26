using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelBookingSystem.ViewModel
{
    public class BookingViewModel
    {
        [Display(Name ="Customer Name")]
        [Required(ErrorMessage ="Customer Name is Required")]
        public string CustomerName { get; set; }

        [Display(Name = "Customer Address")]
        [Required(ErrorMessage = "Customer Address is Required")]
        public string CustomerAddress { get; set; } = string.Empty;

        [Display(Name = "Customer Mobile Number")]
        [Required(ErrorMessage ="Customer Mobile Number is required")]
        public string CustomerMobileNo { get; set; }

        [Display(Name = "Booking From")]
        [DisplayFormat(DataFormatString ="{0:dd-MMM-yyyy}",ApplyFormatInEditMode =true)]
        [Required(ErrorMessage = "Booking From Field is required")]
        public DateTime BookingFrom {  get; set; }

        [Display(Name = "Booking To")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Booking To Field is required")]
        public DateTime BookingTo { get; set; }

        [Display(Name = "Assign Room")]
        [Required(ErrorMessage ="Room is required")]
        public int AssignRoomId { get; set; }

        [Display(Name = "Number Of Members")]
        [Required(ErrorMessage = "No of Member is required")]
        public int NoOfMembers { get; set; }

        

        public IEnumerable<SelectListItem>ListOfRooms { get; set; }
    }
}