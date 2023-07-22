using IsSistemVakaTask.Models.Entities;
using IsSistemVakaTask.Repositories;
using IsSistemVakaTask.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using IsSistemVakaTask.Models.ExtensionModels;
using Moq;

namespace IsSistemTest
{
    public class IntegrationTest
    {
        private DbContextOptions<VakaDbContext> _options;
        private VakaDbContext _dbContext;

        private IReservationService _Reservationservice;
        private Mock<IReservationService> _ReservationServiceMock;

        private ITableService _Tableservice;
        private Mock<ITableService> _TableServiceMock;

        private IEmailService _Emailservice;
        private Mock<IEmailService> _EmailServiceMock;


        [SetUp]
        public void Setup()
        {
            CreateConnection();
        }


        [Test]
        [TestCase(3, "test", "deneme@gmail.com", "test")]
        public async Task MakeRezervation(int guess,string Message, string Recipient, string Subject)
        {
            //fetch tables according to guess
            var tableFirst = await _dbContext.Tables
                                            .FirstOrDefaultAsync(x => x.Capacity == guess);
            Assert.IsNotNull(tableFirst);
            
            var EmailModel = new EmailModel() { Message = Message, Recipient = Recipient, Subject = Subject };
            _EmailServiceMock.Setup(service => service.SendEmail(EmailModel))
                        .Returns(true);


            var reversationCount = _dbContext.Reservations.Count();
            var responseData = _Emailservice.SendEmail(EmailModel);
            Assert.IsTrue(responseData);

            //Reservation create and check
            var responseMakeReservation = _dbContext.Reservations.Add(new Reservation()
            {
                CustomerName = "ahmet",
                NumberOfGuests = guess,
                ReservationDate = DateTime.UtcNow,
                TableNumber = tableFirst.Id
            });
            Assert.IsInstanceOf<Reservation>(responseMakeReservation.Entity);
            Assert.IsTrue(responseMakeReservation.Entity.Id == 0);

            //update table status 
            UpdateTable(tableFirst);
        }


        private void UpdateTable(Table tableFirst)
        {
            tableFirst.TableStatus = !tableFirst.TableStatus;
            var Entity = _dbContext.Tables.Update(tableFirst);
            var NewTableStatus = _dbContext.Tables.FirstOrDefaultAsync(x => x.Id == tableFirst.Id && x.TableStatus == tableFirst.TableStatus);
            Assert.IsNotNull(NewTableStatus);
        }


        private void CreateConnection()
        {
            var connectionString = WebApplication.CreateBuilder().Configuration.GetConnectionString("DbConnection");
            _options = new DbContextOptionsBuilder<VakaDbContext>()
            .UseNpgsql(connectionString)
            .Options;
            _dbContext = new VakaDbContext(_options);
            _ReservationServiceMock = new Mock<IReservationService>();
            _Reservationservice = _ReservationServiceMock.Object;

            _TableServiceMock = new Mock<ITableService>();
            _Tableservice = _TableServiceMock.Object;

            _EmailServiceMock = new Mock<IEmailService>();
            _Emailservice = _EmailServiceMock.Object;
        }
    }
}
