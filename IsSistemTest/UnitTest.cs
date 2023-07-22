using IsSistemVakaTask.Models.Dtos;
using IsSistemVakaTask.Services;
using IsSistemVakaTask.Services.Interfaces;
using Moq;

namespace IsSistemTest
{
    public class UnitTest
    {
        private ITableService _Tableservice;
        private Mock<ITableService> _TableServiceMock;

        private IEmailService _Emailservice;
        private Mock<IEmailService> _EmailServiceMock;

        [SetUp]
        public void Setup()
        {
            _TableServiceMock = new Mock<ITableService>();
            _Tableservice = _TableServiceMock.Object;

            _EmailServiceMock = new Mock<IEmailService>();
            _Emailservice = _EmailServiceMock.Object;
        }

        [Test]
        [TestCase(3, true)]
        public async Task GetTables(int guess, bool status)
        {
            _TableServiceMock.Setup(service => service.GetTables(guess))
                        .ReturnsAsync(new ResultModel<List<TableDto>>
                        {
                            Data = new List<TableDto>()
                            {
                                new TableDto {Capacity=guess,TableStatus=status}
                            }
                            ,
                            ErrorMessages = new List<string>()
                        });


            var responseData = await _Tableservice.GetTables(guess);
            Assert.IsInstanceOf<ResultModel<List<TableDto>>>(responseData);
            Assert.IsNotNull(responseData);
            Assert.IsNotNull(responseData.Data);
            var statusTable = responseData.Data.FirstOrDefault();
            Assert.IsTrue(statusTable.TableStatus);
            var TableList = responseData.Data as List<TableDto>;
            Assert.IsInstanceOf<List<TableDto>>(TableList);
        }



        [TestCase("test", "deneme@gmail.com", "test")]
        public void SendEMail(string Message, string Recipient, string Subject)
        {
            var EmailModel = new EmailModel() { Message = Message, Recipient = Recipient, Subject = Subject };
            _EmailServiceMock.Setup(service => service.SendEmail(EmailModel))
                        .Returns(true);

            var responseData = _Emailservice.SendEmail(EmailModel);
            Assert.IsTrue(responseData);
        }
    }
}
