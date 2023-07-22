namespace IsSistemVakaTask.Models.Dtos
{
    public record TableDto : BaseDto
    {
        public int Number { get; set; }
        public int Capacity { get; set; }
        public bool TableStatus { get; set; }
        public bool IsDelete { get; set; }
    }
}
