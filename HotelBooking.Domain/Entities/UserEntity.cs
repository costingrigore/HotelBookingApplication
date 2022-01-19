using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace HotelBooking.Domain.Entities
{
    [Table("Users")]
    public class UserEntity : AuditableEntity
    {
        [Key]
        public int UserId { get; set; }
        public string Email { get; set; }
        [JsonIgnore]
        public virtual List<BookingEntity> Bookings { get; set; }
    }
}
