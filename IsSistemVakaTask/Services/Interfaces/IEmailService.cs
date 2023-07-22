using IsSistemVakaTask.Models.Dtos;
using IsSistemVakaTask.Models.Entities;
using IsSistemVakaTask.Repositories.Interfaces;

namespace IsSistemVakaTask.Services.Interfaces
{
    public interface IEmailService
    {
        bool SendEmail(EmailModel email);
    }
}
