using IsSistemVakaTask.Models.ExtensionModels;

namespace IsSistemVakaTask.Extension
{
    public static class EmailInformation
    {
        private static IConfiguration _configuration;

        static EmailInformation()
        {
            // appsettings.json dosyasını yükleyin
            _configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
        }

        public static EmailInformationModel GetEmailInformation()
        {
            return new EmailInformationModel()
            {
                EmailAddress = _configuration["EmailSettings:Email"],
                Password = _configuration["EmailSettings:Password"]
            };
        }
    }
}
