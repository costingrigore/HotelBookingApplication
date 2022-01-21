using HotelBooking.Application.Queries;
using HotelBooking.Domain.Entities;
using HotelBooking.Infrastructure.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBookingAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BookingsController(ApplicationDbContext context)
        {
            _context = context;
            // Ensure the database gets created
            _context.Database.EnsureCreated();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBookings([FromQuery] BookingQueryParameters queryParameters)
        {
            IQueryable<BookingEntity> bookings = _context.Bookings;

            if (!string.IsNullOrEmpty(queryParameters.SortBy))
            {
                if (typeof(HotelEntity).GetProperty(queryParameters.SortBy) != null)
                {
                    bookings = bookings.OrderByCustom(queryParameters.SortBy, queryParameters.SortOrder);
                }
            }

            bookings = bookings
                .Skip(queryParameters.Size * (queryParameters.Page - 1))
                .Take(queryParameters.Size);

            return bookings == null ? NotFound() : Ok(await bookings.ToArrayAsync());
        }

        [HttpPost]
        public async Task<IActionResult> MakeABooking([FromQuery] BookingQueryParameters queryParameters)
        {


            IQueryable<RoomEntity> rooms = _context.Rooms;

            DateTime dateStart = new(queryParameters.yearStart, queryParameters.monthStart, queryParameters.dayStart);
            DateTime dateEnd = new(queryParameters.yearEnd, queryParameters.monthEnd, queryParameters.dayEnd);

            var booking = new BookingEntity {
                StartDate = dateStart,
                EndDate = dateEnd,
                UserId = queryParameters.UserId,
                HotelId = queryParameters.HotelId,
                RoomId = queryParameters.RoomId
                };

            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();

            return Ok(booking);
        }

        [HttpGet, Route("/bookings/{id}")]
        public async Task<IActionResult> GetABooking(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            return booking == null ? NotFound() : Ok(booking);
        }
    }
}
