using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelBookingSystem.ViewModel
{
    public class RoomViewModel
    {
        public int RoomId { get; set; }
        [Display(Name ="Room No")]

        [Required(ErrorMessage ="Room Number is required")]
        public string RoomNumber { get; set; }
        [Display(Name = "Room Image")]
        public string RoomImage { get; set; }
        [Display(Name = "Room Price")]

        [Required(ErrorMessage = "Room Price is required")]
        [Range(500,10000,ErrorMessage ="Room Price is Equal and greater than {0}")]
        public Decimal RoomPrice {  get; set; }

        [Required(ErrorMessage = "Room Status is required")]
        public int BookingStatusId { get; set; }

        [Required(ErrorMessage = "Room Type is required")]
        public int RoomTypeId { get; set; }

        [Required(ErrorMessage = "Room Capacity is required")]
        [Range(1,8,ErrorMessage ="Room Capacity should be equal and greater than {0}")]
        [Display(Name = "Room Capacity")]
        public int RoomCapacity {  get; set; }

        [Required(ErrorMessage = "Room Description is required")]
        [Display(Name = "Room Description")]
        public string RoomDescription { get; set; }

        public HttpPostedFileBase Image { get; set; }

        public List<SelectListItem> ListOfBookingStatus { get; set; }

        public List<SelectListItem> ListOfRoomType { get; set; }
    }
}