using API.BAL.Interface;
using API.Data;
using System;
using System.Collections.Generic;
using System.Text;
using API.DAL.Repository;
using System.Linq;

namespace API.BAL
{
    public class HotelBooking : IHotelBooking
    {
        private readonly IHotelRepository _hotelRepository;
        public HotelBooking(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        public bool AvailRooms(DateTime date)
        {
            return _hotelRepository.AvailRooms(date);
        }

        public string BookRoom(BookingViewModel booking)
        {
            return _hotelRepository.BookRoom(booking);
        }

        public string CreateHotel(HotelViewModel hotel)
        {
            return _hotelRepository.CreateHotel(hotel);
        }

        public string CreateRoom(RoomViewModel room)
        {
            return _hotelRepository.CreateRoom(room);
        }

        public string DeleteBooking(int id)
        {
            return _hotelRepository.DeleteBooking(id);
        }

        public List<HotelViewModel> GetHotel()
        {
            return _hotelRepository.GetHotel().OrderBy(h => h.HotelName).ToList();
        }

        public List<RoomViewModel> GetRooms()
        {
            var rooms = _hotelRepository.GetRooms();
            return rooms;
        }

        public List<RoomViewModel> GetRoomsByCategory(string Category)
        {
            return _hotelRepository.GetRoomsByCategory(Category);
        }

        public List<RoomViewModel> GetRoomsByCity(string City)
        {
            return _hotelRepository.GetRoomsByCity(City);
        }

        public List<RoomViewModel> GetRoomsByPincode(string Pincode)
        {
            return _hotelRepository.GetRoomsByPincode(Pincode);
        }

        public List<RoomViewModel> GetRoomsByPrice(string Price)
        {
            return _hotelRepository.GetRoomsByPrice(Price);
        }

        public string UpdateBookingDate(int id, BookingViewModel booking)
        {
            return _hotelRepository.UpdateBookingDate(id, booking);
        }

        public string UpdateBookingStauts(int id, BookingViewModel booking)
        {
            return _hotelRepository.UpdateBookingStauts(id, booking);
        }
    }

  
}
