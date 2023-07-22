using IsSistemVakaTask.Models.Entities;
using IsSistemVakaTask.Models.ExtensionModels;
using IsSistemVakaTask.Repositories.Interfaces;

namespace IsSistemVakaTask.Services.Interfaces
{
    public interface IEmailService
    {
        bool SendEmail(EmailModel email);
    }
}
