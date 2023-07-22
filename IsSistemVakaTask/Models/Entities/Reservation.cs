using System.ComponentModel.DataAnnotations;

namespace IsSistemVakaTask.Models.Entities
{
    public class Reservation : BaseEntity
    {
        public required string CustomerName { get; set; }
        public DateTime ReservationDate { get; set; }
        public required int NumberOfGuests { get; set; }
        public required int TableNumber { get; set; }
    }
}
