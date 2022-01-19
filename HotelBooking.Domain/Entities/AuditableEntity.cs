using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBooking.Domain.Entities
{
    public abstract class AuditableEntity
    {
        public DateTime CreatedAt { get; set; }

        [Column(TypeName = "varchar(64)")]
        public string CreatedBy { get; set; }

        public DateTime? LastUpdatedAt { get; set; }

        [Column(TypeName = "varchar(64)")]
        public string LastUpdatedBy { get; set; }
    }
}
