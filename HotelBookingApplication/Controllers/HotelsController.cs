using HotelBooking.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace HotelBookingAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly Context _context;

        public HotelsController(Context context)
        {
            _context = context;
            // Ensure the database gets created
            _context.Database.EnsureCreated();
        }

        [HttpGet]
        public IActionResult GetAllHotels()
        {
            return Ok(_context.Hotels.ToArray());
        }
    }
}
