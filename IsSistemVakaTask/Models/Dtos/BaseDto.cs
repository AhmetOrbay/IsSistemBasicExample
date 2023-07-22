using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace IsSistemVakaTask.Models.Dtos
{
    public record BaseDto 
    {
        public int Id { get; set; }
        [JsonIgnore]
        public bool IsDelete { get; set; }
    }
}
