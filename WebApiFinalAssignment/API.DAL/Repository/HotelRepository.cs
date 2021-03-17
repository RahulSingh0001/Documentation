using API.DAL.Models;
using API.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Booking = API.DAL.Models.Booking;
using Hotel = API.DAL.Models.Hotel;

namespace API.DAL.Repository
{
    public class HotelRepository : IHotelRepository
    {
        private readonly HotelBookingEntities _dbContext;
        public HotelRepository()
        {
            _dbContext = new HotelBookingEntities();
        }

        public bool AvailRooms(DateTime date)
        {
            var a = _dbContext.Bookings.Where(h => h.BookingDate == date.Date).ToList();

            if (a.Count() < 15)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string BookRoom(BookingViewModel booking)
        {
            var a = _dbContext.Bookings.ToList();
            if (a.Count() != 0)
            {
                return "Room is booked";
            }
            if (booking != null)
            {
                Booking entity = new Booking();

                entity.RoomId = booking.RoomId;
                entity.StautsOfBooking = "Optional";
                entity.BookingDate = DateTime.Now;

                _dbContext.Bookings.Add(entity);
                _dbContext.SaveChanges();
                return "Added succeffuly";
            }
            return "Model is null";
        }

        public string CreateHotel(HotelViewModel hotel)
        {
            try
            {
                if (hotel != null)
                {
                    Hotel entity = new Hotel();

                    entity.HotelName = hotel.HotelName;
                    entity.Address = hotel.Address;
                    entity.City = hotel.City;
                    entity.Pincode = hotel.Pincode;
                    entity.ContactNumber = hotel.ContactNumber;
                    entity.ContactPerson = hotel.ContactPerson;
                    entity.Website = hotel.Website;
                    entity.Facebook = hotel.Facebook;
                    entity.Twitter = hotel.Twitter;
                    entity.IsActive = true;
                    entity.CreatedDate = DateTime.Now;
                    entity.CreatedBy = hotel.CreatedBy;

                    _dbContext.Hotels.Add(entity);
                    _dbContext.SaveChanges();
                    return "Added succeffuly";
                }
                return "Model is null";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string CreateRoom(RoomViewModel room)
        {
            try
            {
                if (room != null)
                {
                    Room entity = new Room();

                    entity.HotelID = room.HotelID;
                    entity.RoomName = room.RoomName;
                    entity.RoomCategory = room.RoomCategory;
                    entity.RoomPrice = room.RoomPrice;
                    entity.IsActive = true;
                    entity.CreatedDate = DateTime.Now;
                    entity.CreatedBy = room.CreatedBy;

                    _dbContext.Rooms.Add(entity);
                    _dbContext.SaveChanges();
                    return "Added succeffuly";
                }
                return "Model is null";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string DeleteBooking(int id)
        {
            try
            {
                var entity = _dbContext.Bookings.Find(id);
                if (entity != null)
                {
                    entity.StautsOfBooking = "Deleted";
                    _dbContext.SaveChanges();
                    return "Booking Deleted";
                }
                return "No data found";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<HotelViewModel> GetHotel()
        {
            var entity = _dbContext.Hotels.OrderBy(h => h.HotelName).ToList();
            List<HotelViewModel> list = new List<HotelViewModel>();
            if (_dbContext != null)
            {
                foreach (var item in entity)
                {
                    HotelViewModel hotel = new HotelViewModel();
                    hotel.HotelName = item.HotelName;
                    hotel.Address = item.Address;
                    hotel.City = item.City;
                    hotel.Pincode = item.Pincode;
                    hotel.ContactNumber = item.ContactNumber;
                    hotel.ContactPerson = item.ContactPerson;
                    hotel.Website = item.Website;
                    hotel.Facebook = item.Facebook;
                    hotel.Twitter = item.Twitter;
                    list.Add(hotel);
                }
            }
            return list;
        }

        public List<RoomViewModel> GetRooms()
        {
            var entity = _dbContext.Rooms.OrderBy(h => h.RoomPrice).ToList();
            List<RoomViewModel> list = new List<RoomViewModel>();
            if (_dbContext != null)
            {
                foreach (var item in entity)
                {
                    RoomViewModel room = new RoomViewModel();
                    room.Id = item.Id;
                    room.HotelID = item.HotelID;
                    room.RoomName = item.RoomName;
                    room.RoomCategory = item.RoomCategory;
                    room.RoomPrice = item.RoomPrice;
                    room.IsActive = item.IsActive;
                    room.CreatedDate = item.CreatedDate;
                    room.CreatedBy = item.CreatedBy;
                    list.Add(room);
                }
            }
            return list;
        }

        public List<RoomViewModel> GetRoomsByCategory(string Category)
        {
            var entity = _dbContext.Rooms.Where(h => h.RoomCategory.Equals(Category)).ToList();
            List<RoomViewModel> list = new List<RoomViewModel>();
            if (_dbContext != null)
            {
                foreach (var item in entity)
                {
                    RoomViewModel room = new RoomViewModel();
                    room.Id = item.Id;
                    room.HotelID = item.HotelID;
                    room.RoomName = item.RoomName;
                    room.RoomCategory = item.RoomCategory;
                    room.RoomPrice = item.RoomPrice;
                    room.IsActive = item.IsActive;
                    room.CreatedDate = item.CreatedDate;
                    room.CreatedBy = item.CreatedBy;
                    list.Add(room);
                }
            }
            return list;
        }

        public List<RoomViewModel> GetRoomsByCity(string City)
        {
            var entity = _dbContext.Rooms.Where(h => h.Hotel.City.Equals(City)).ToList();
            List<RoomViewModel> list = new List<RoomViewModel>();
            if (_dbContext != null)
            {
                foreach (var item in entity)
                {
                    RoomViewModel room = new RoomViewModel();
                    room.Id = item.Id;
                    room.HotelID = item.HotelID;
                    room.RoomName = item.RoomName;
                    room.RoomCategory = item.RoomCategory;
                    room.RoomPrice = item.RoomPrice;
                    room.IsActive = item.IsActive;
                    room.CreatedDate = item.CreatedDate;
                    room.CreatedBy = item.CreatedBy;
                    list.Add(room);
                }
            }
            return list;
        }

        public List<RoomViewModel> GetRoomsByPincode(string Pincode)
        {
            var entity = _dbContext.Rooms.Where(h => h.Hotel.Pincode.ToString().Equals(Pincode)).ToList();
            List<RoomViewModel> list = new List<RoomViewModel>();
            if (_dbContext != null)
            {
                foreach (var item in entity)
                {
                    RoomViewModel room = new RoomViewModel();
                    room.Id = item.Id;
                    room.HotelID = item.HotelID;
                    room.RoomName = item.RoomName;
                    room.RoomCategory = item.RoomCategory;
                    room.RoomPrice = item.RoomPrice;
                    room.IsActive = item.IsActive;
                    room.CreatedDate = item.CreatedDate;
                    room.CreatedBy = item.CreatedBy;
                    list.Add(room);
                }
            }
            return list;
        }

        public List<RoomViewModel> GetRoomsByPrice(string price)
        {
            var entity = _dbContext.Rooms.Where(h => h.Hotel.Pincode.ToString().Equals(Price)).ToList();
            List<RoomViewModel> list = new List<RoomViewModel>();
            if (_dbContext != null)
            {
                foreach (var item in entity)
                {
                    RoomViewModel room = new RoomViewModel();
                    room.Id = item.Id;
                    room.HotelID = item.HotelID;
                    room.RoomName = item.RoomName;
                    room.RoomCategory = item.RoomCategory;
                    room.RoomPrice = item.RoomPrice;
                    room.IsActive = item.IsActive;
                    room.CreatedDate = item.CreatedDate;
                    room.CreatedBy = item.CreatedBy;
                    list.Add(room);
                }
            }
            return list;
        }

        public string UpdateBookingDate(int id, BookingViewModel booking)
        {
            try
            {
                var entity = _dbContext.Bookings.Find(id);
                if (entity != null)
                {
                    entity.BookingDate = booking.BookingDate;
                    _dbContext.SaveChanges();
                    return "Booking date updated";
                }
                return "No data found";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string UpdateBookingStauts(int id, BookingViewModel booking)
        {
            try
            {
                var entity = _dbContext.Bookings.Find(id);
                if (entity != null)
                {
                    entity.StautsOfBooking = booking.StautsOfBooking;
                    _dbContext.SaveChanges();
                    return "Booking status updated";
                }
                return "No data found";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}