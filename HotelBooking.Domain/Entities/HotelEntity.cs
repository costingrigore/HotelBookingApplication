using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBooking.Domain.Entities
{
    [Table("Hotels")]
    public class HotelEntity : AuditableEntity
    {
        [Key]
        public int HotelId { get; set; }
        public string Name { get; set; }
        public RoomEntity RoomId { get; set; }

    }
}
