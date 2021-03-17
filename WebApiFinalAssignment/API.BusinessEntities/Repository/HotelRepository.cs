using API.Data;
using System;
using System.Collections.Generic;

namespace API.DAL.Repository
{
    public class HotelRepository : IHotelRepository
    {
        private readonly Database.HotelBookingEntities _dbContext;
        public HotelRepository()
        {
            _dbContext = new Database.HotelBookingEntities();
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

        public string BookRoom(Booking booking)
        {
            var a = _dbContext.Bookings.ToList();
            if (a.Count() != 0)
            {
                return "Room is booked";
            }
            if (booking != null)
            {
                Database.Booking entity = new Database.Booking();

                entity.RoomId = booking.RoomId;
                entity.StautsOfBooking = "Optional";
                entity.BookingDate = DateTime.Now;

                _dbContext.Bookings.Add(entity);
                _dbContext.SaveChanges();
                return "Added succeffuly";
            }
            return "Model is null";

        }

        public string CreateHotel(Hotel hotel)
        {
            try
            {
                if (hotel != null)
                {
                    Database.Hotel entity = new Database.Hotel();

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

        public string CreateRoom(Room room)
        {
            try
            {
                if (room != null)
                {
                    Database.Room entity = new Database.Room();

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

        public List<HotelOnly> GetHotel()
        {
            var entity = _dbContext.Hotels.OrderBy(h => h.HotelName).ToList();
            List<HotelOnly> list = new List<HotelOnly>();
            if (_dbContext != null)
            {
                foreach (var item in entity)
                {
                    HotelOnly hotel = new HotelOnly();
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

        public List<Room> GetRooms()
        {
            var entity = _dbContext.Rooms.OrderBy(h => h.RoomPrice).ToList();
            List<Room> list = new List<Room>();
            if (_dbContext != null)
            {
                foreach (var item in entity)
                {
                    Room room = new Room();
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
        public List<Room> GetRoomsByCategory(string Category)
        {
            var entity = _dbContext.Rooms.Where(h => h.RoomCategory.Equals(Category)).ToList();
            List<Room> list = new List<Room>();
            if (_dbContext != null)
            {
                foreach (var item in entity)
                {
                    Room room = new Room();
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

        public List<Room> GetRoomsByCity(string City)
        {
            var entity = _dbContext.Rooms.Where(h => h.Hotel.City.Equals(City)).ToList();
            List<Room> list = new List<Room>();
            if (_dbContext != null)
            {
                foreach (var item in entity)
                {
                    Room room = new Room();
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

        public List<Room> GetRoomsByPincode(string Pincode)
        {
            var entity = _dbContext.Rooms.Where(h => h.Hotel.Pincode.ToString().Equals(Pincode)).ToList();
            List<Room> list = new List<Room>();
            if (_dbContext != null)
            {
                foreach (var item in entity)
                {
                    Room room = new Room();
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

        public List<Room> GetRoomsByPrice(string Price)
        {
            var entity = _dbContext.Rooms.Where(h => h.Hotel.Pincode.ToString().Equals(Price)).ToList();
            List<Room> list = new List<Room>();
            if (_dbContext != null)
            {
                foreach (var item in entity)
                {
                    Room room = new Room();
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

        public string UpdateBookingDate(int id, Booking booking)
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

        public string UpdateBookingStauts(int id, Booking booking)
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
