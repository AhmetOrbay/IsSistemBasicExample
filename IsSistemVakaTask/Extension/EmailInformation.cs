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

        public static (string,string) GetEmailInformation()
        {
            var Email = _configuration["EmailSettings:Email"];
            var Password = _configuration["EmailSettings:Password"];
            return (Email, Password);
        }
    }
}
