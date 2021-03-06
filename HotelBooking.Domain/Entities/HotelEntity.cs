using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace HotelBooking.Domain.Entities
{
    [Table("Hotels")]
    public class HotelEntity : AuditableEntity
    {
        [Key]
        public int HotelId { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public virtual List<RoomEntity> Rooms { get; set; }
        [JsonIgnore]
        public virtual List<BookingEntity> Bookings { get; set; }

    }
}
