using System;
using System.Collections.Generic;
using System.Text;

namespace API.Data
{
    public class RoomViewModel
    {
        public int Id { get; set; }
        public int HotelID { get; set; }
        public string Name { get; set; }
        public string RoomName { get; set; }
        public string RoomCategory { get; set; }
        public Nullable<int> RoomPrice { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }

        public virtual HotelViewModel Hotel { get; set; }
    }
}
