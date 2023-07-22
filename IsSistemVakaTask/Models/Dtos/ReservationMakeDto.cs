using IsSistemVakaTask.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace IsSistemVakaTask.Models.Dtos
{
    public record ReservationMakeDto
    {
        public required string CustomerName { get; set; }
        public required int NumberOfGuests { get; set; }
        public DateTime ReservationDate { get; set; }
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public required string CustomerEmail { get;set; }
    }
}
