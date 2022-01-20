using HotelBooking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelBooking.Infrastructure.Persistence.Seeding
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookingEntity>().HasData(
                new BookingEntity { BookingId = 1, BookingDate = new DateTime(2021, 12, 30), UserId = 1, HotelId = 2, RoomId = 7 },
                new BookingEntity { BookingId = 2, BookingDate = new DateTime(2021, 11, 20), UserId = 2, HotelId = 2, RoomId = 10},
                new BookingEntity { BookingId = 3, BookingDate = new DateTime(2021, 12, 21), UserId = 3, HotelId = 1, RoomId = 5 },
                new BookingEntity { BookingId = 4, BookingDate = new DateTime(2021, 08, 03), UserId = 2, HotelId = 1, RoomId = 3 },
                new BookingEntity { BookingId = 5, BookingDate = new DateTime(2021, 12, 08), UserId = 3, HotelId = 2, RoomId = 9 });

            modelBuilder.Entity<HotelEntity>().HasData(
                new HotelEntity { HotelId = 1, Name = "Plaza Hotel" },
                new HotelEntity { HotelId = 2, Name = "Hotel Budapest" });

            modelBuilder.Entity<RoomEntity>().HasData(
                new RoomEntity { RoomId = 1, RoomType = "single", DateIn = new DateTime(2021, 12, 28), DateOut = new DateTime(2021, 12, 30), IsAvailable = false, Price = 74, Capacity = 1, HotelId = 1 },
                new RoomEntity { RoomId = 2, RoomType = "single", DateIn = null, DateOut = null, IsAvailable = true, Price = 74, Capacity = 1, HotelId = 1 },
                new RoomEntity { RoomId = 3, RoomType = "double", DateIn = null, DateOut = null, IsAvailable = true, Price = 74, Capacity = 2, HotelId = 1 },
                new RoomEntity { RoomId = 4, RoomType = "double", DateIn = null, DateOut = null, IsAvailable = true, Price = 74, Capacity = 2, HotelId = 1 },
                new RoomEntity { RoomId = 5, RoomType = "deluxe", DateIn = null, DateOut = null, IsAvailable = true, Price = 74, Capacity = 4, HotelId = 1 },
                new RoomEntity { RoomId = 6, RoomType = "deluxe", DateIn = null, DateOut = null, IsAvailable = true, Price = 74, Capacity = 4, HotelId = 1 },
                new RoomEntity { RoomId = 7, RoomType = "single", DateIn = new DateTime(2022, 01, 18), DateOut = new DateTime(2022, 01, 24), IsAvailable = false, Price = 74, Capacity = 1, HotelId = 2 },
                new RoomEntity { RoomId = 8, RoomType = "single", DateIn = null, DateOut = null, IsAvailable = true, Price = 74, Capacity = 1, HotelId = 2 },
                new RoomEntity { RoomId = 9, RoomType = "double", DateIn = null, DateOut = null, IsAvailable = true, Price = 74, Capacity = 2, HotelId = 2 },
                new RoomEntity { RoomId = 10, RoomType = "double", DateIn = null, DateOut = null, IsAvailable = true, Price = 74, Capacity = 2, HotelId = 2 },
                new RoomEntity { RoomId = 11, RoomType = "deluxe", DateIn = null, DateOut = null, IsAvailable = true, Price = 74, Capacity = 4, HotelId = 2 },
                new RoomEntity { RoomId = 12, RoomType = "deluxe", DateIn = null, DateOut = null, IsAvailable = true, Price = 74, Capacity = 4, HotelId = 2 }
                );;

            modelBuilder.Entity<UserEntity>().HasData(
                new UserEntity { UserId = 1, Email = "adam@example.com" },
                new UserEntity { UserId = 2, Email = "barbara@example.com" });
        }
    }
}
