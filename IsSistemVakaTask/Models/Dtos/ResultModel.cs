using System.Runtime.ConstrainedExecution;

namespace IsSistemVakaTask.Models.Dtos
{
    public record ResultModel<T>
    {
        public T Data { get; set; }

        public List<string> ErrorMessages{ get; set; }

        public bool IsSuccess => !(ErrorMessages is not null && ErrorMessages.Any());
        public int StatusCode => IsSuccess ? 200 : 400;
    }
}
