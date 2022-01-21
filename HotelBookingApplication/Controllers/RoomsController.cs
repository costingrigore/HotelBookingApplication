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

        private readonly ApplicationDbContext _context;

        public RoomsController(ApplicationDbContext context)
        {
            _context = context;
            // Ensure the database gets created
            _context.Database.EnsureCreated();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRooms([FromQuery] RoomQueryParameters queryParameters)
        {
            IQueryable<RoomEntity> rooms = _context.Rooms;

            
            if (queryParameters.yearStart != 0 
                && queryParameters.monthStart != 0
                && queryParameters.dayStart != 0
                && queryParameters.yearEnd != 0
                && queryParameters.monthEnd != 0
                && queryParameters.dayEnd != 0
                && queryParameters.Capacity > 0)
            {
                DateTime dateStart = new(queryParameters.yearStart, queryParameters.monthStart, queryParameters.dayStart);
                DateTime dateEnd = new(queryParameters.yearEnd, queryParameters.monthEnd, queryParameters.dayEnd);

                rooms = rooms.Where(
                    p => ((dateStart.ToUniversalTime() < p.DateIn && dateEnd.ToUniversalTime() < p.DateIn) || (dateStart.ToUniversalTime() > p.DateOut)) && (p.Capacity == queryParameters.Capacity)
                    );
            }

            rooms = rooms
                .Skip(queryParameters.Size * (queryParameters.Page - 1))
                .Take(queryParameters.Size);

            return rooms == null ? NotFound() : Ok(await rooms.ToArrayAsync());
        }

        [HttpPut]
        public async Task<IActionResult> BookARoom([FromQuery] BookingQueryParameters queryParameters)
        {
            if (queryParameters.RoomId != 0)
            {
                var room = await _context.Rooms.FindAsync(queryParameters.RoomId);

                if(room == null)
                {
                    return NotFound();
                }

                if (queryParameters.yearStart != 0
                    && queryParameters.monthStart != 0
                    && queryParameters.dayStart != 0
                    && queryParameters.yearEnd != 0
                    && queryParameters.monthEnd != 0
                    && queryParameters.dayEnd != 0
                    && queryParameters.RoomId > 0)
                {
                    DateTime dateStart = new(queryParameters.yearStart, queryParameters.monthStart, queryParameters.dayStart);
                    DateTime dateEnd = new(queryParameters.yearEnd, queryParameters.monthEnd, queryParameters.dayEnd);

                    if ((dateStart.ToUniversalTime() < room.DateIn && dateEnd.ToUniversalTime() < room.DateIn)
                        || (dateStart.ToUniversalTime() > room.DateOut) || (room.DateIn == null && room.DateOut == null))
                    {
                        room.DateIn = dateStart;
                        room.DateOut = dateEnd;
                        room.IsAvailable = false;
                        _context.Entry(room).State = EntityState.Modified;

                        try
                        {
                            _context.SaveChanges();
                            return Ok(room);
                        }
                        catch (DbUpdateConcurrencyException)
                        {
                            if (_context.Rooms.Find(room.RoomId) == null)
                            {
                                return NotFound();
                            }
                            throw;
                        }
                    }
                }
                return BadRequest("The room is not available at this time");
            }
            else
            {
                return BadRequest("No room was found");
            }
        }

        [HttpGet, Route("/Rooms/{id}")]
        public async Task<IActionResult> GetARoom(int id)
        {
            var room = await _context.Rooms.FindAsync(id);
            return room == null ? NotFound() : Ok(room);
        }
    }
}
