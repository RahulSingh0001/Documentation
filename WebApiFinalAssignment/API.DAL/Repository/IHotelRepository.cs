using API.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.DAL.Repository
{
    public interface IHotelRepository
    {
        string CreateHotel(HotelViewModel hotel);
        string CreateRoom(RoomViewModel room);
        List<HotelViewModel> GetHotel();
        List<RoomViewModel> GetRooms();
        List<RoomViewModel> GetRoomsByCity(string City);
        List<RoomViewModel> GetRoomsByPincode(string Pincode);
        List<RoomViewModel> GetRoomsByPrice(string price);
        List<RoomViewModel> GetRoomsByCategory(string Category);
        bool AvailRooms(DateTime date);
        string BookRoom(BookingViewModel booking);
        string UpdateBookingDate(int id, BookingViewModel booking);
        string UpdateBookingStauts(int id, BookingViewModel booking);
        string DeleteBooking(int id);
    }
}
