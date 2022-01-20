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
    public class RoomsController : ControllerBase
    {

        private readonly ApplicationDbContextContext _context;

        public RoomsController(ApplicationDbContextContext context)
        {
            _context = context;
            // Ensure the database gets created
            _context.Database.EnsureCreated();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRooms([FromQuery] RoomQueryParameters queryParameters)
        {
            IQueryable<RoomEntity> rooms = _context.Rooms;

            DateTime dateStart = new(queryParameters.yearStart, queryParameters.monthStart, queryParameters.dayStart);
            DateTime dateEnd = new(queryParameters.yearEnd, queryParameters.monthEnd, queryParameters.dayEnd);

            if ((dateStart != null && dateEnd != null) && (queryParameters.Capacity > 0))
            {
                rooms = rooms.Where(
                    p => ((dateStart.ToUniversalTime() < p.DateIn && dateEnd.ToUniversalTime() < p.DateIn) || (dateStart.ToUniversalTime() > p.DateOut)) && (p.Capacity == queryParameters.Capacity)
                    );
            }

            rooms = rooms
                .Skip(queryParameters.Size * (queryParameters.Page - 1))
                .Take(queryParameters.Size);

            return rooms == null ? NotFound() : Ok(await rooms.ToArrayAsync());
        }

    }
}
