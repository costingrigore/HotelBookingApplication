using HotelBooking.Application.Queries;
using HotelBooking.Domain.Entities;
using HotelBooking.Infrastructure.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBookingAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly ApplicationDbContextContext _context;

        public HotelsController(ApplicationDbContextContext context)
        {
            _context = context;
            // Ensure the database gets created
            _context.Database.EnsureCreated();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllHotels([FromQuery] HotelQueryParameters queryParameters)
        {
            IQueryable<HotelEntity> hotels = _context.Hotels;

            if(!string.IsNullOrEmpty(queryParameters.Name))
            {
                hotels = hotels.Where(
                    p => p.Name.ToLower().Contains(queryParameters.Name.ToLower()));
            }

            if (!string.IsNullOrEmpty(queryParameters.SortBy))
            {
                if (typeof(HotelEntity).GetProperty(queryParameters.SortBy) != null)
                {
                    hotels = hotels.OrderByCustom(queryParameters.SortBy, queryParameters.SortOrder);
                }
            }

            hotels = hotels
                .Skip(queryParameters.Size * (queryParameters.Page - 1))
                .Take(queryParameters.Size);

            return hotels == null ? NotFound() :  Ok( await hotels.ToArrayAsync());
        }

        [HttpGet, Route("/hotels/{id}")]
        public async Task<IActionResult> GetAHotel(int id)
        {
            var hotel = await _context.Hotels.FindAsync(id);
            return hotel == null ? NotFound() : Ok(hotel);
        }
    }
}
