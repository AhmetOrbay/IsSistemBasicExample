namespace IsSistemVakaTask.Models.Entities
{
    public class Table : BaseEntity
    {
        public int Number { get; set; }
        public int Capacity { get; set; }
        public bool TableStatus { get; set; }
    }
}
