using System.ComponentModel.DataAnnotations;

namespace IsSistemVakaTask.Models.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public bool IsDelete { get; set; }
    }
}
