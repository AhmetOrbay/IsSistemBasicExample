using System.Runtime.ConstrainedExecution;

namespace IsSistemVakaTask.Models.Dtos
{
    public record ResultModel<T>
    {
        public T Data { get; set; }

        public List<string> ErrorMessages{ get; set; }

        //private bool _isSuccess;

        public bool IsSuccess => !(ErrorMessages is not null && ErrorMessages.Any());
    }
}
