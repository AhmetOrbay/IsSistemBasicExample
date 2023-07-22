namespace IsSistemVakaTask.Models.Dtos
{
    public record EmailModel
    {
        public required string Recipient { get; set; }
        public required string Subject { get; set; }
        public required string Message { get; set; }
    }
}
