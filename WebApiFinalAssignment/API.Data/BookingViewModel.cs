using System;
using System.Collections.Generic;
using System.Text;

namespace API.Data
{
    public class BookingViewModel
    {
        public int Id { get; set; }
        public Nullable<System.DateTime> BookingDate { get; set; }
        public Nullable<int> RoomId { get; set; }
        public string StautsOfBooking { get; set; }
    }
}
