using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public bool IsBusy { get; set; }
    }
}
