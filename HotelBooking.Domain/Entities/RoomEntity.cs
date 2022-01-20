using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace HotelBooking.Domain.Entities
{
    [Table("Rooms")]
    public class RoomEntity : AuditableEntity
    {
        [Key]
        public int RoomId { get; set; }
        public string RoomType { get; set; }
        public DateTime? DateIn { get; set; }
        public DateTime? DateOut { get; set; }
        public bool IsAvailable { get; set; }
        public decimal? Price { get; set; }
        public int Capacity { get; set; }
        public int HotelId { get; set; }
        [JsonIgnore]
        public virtual HotelEntity Hotel { get; set; }
    }
}
