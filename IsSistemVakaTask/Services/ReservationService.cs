using IsSistemVakaTask.Models.Dtos;
using IsSistemVakaTask.Models.Entities;
using IsSistemVakaTask.Services.Interfaces;
using IsSistemVakaTask.Repositories.Interfaces;
using IsSistemVakaTask.Models.ExtensionModels;
using AutoMapper;

namespace IsSistemVakaTask.Services
{
    internal class ReservationService : IReservationService
    {
        private readonly ITableService _tableService;
        private readonly IReservationRepo _reservationRepo;
        private readonly IMapper _mapper;
        private readonly IEmailService _EmailService;
        public ReservationService(ITableService tableService,
            IReservationRepo reservationRepo,
            IMapper mapper,
            IEmailService emailService)
        {
            _tableService = tableService;
            _reservationRepo = reservationRepo;
            _mapper = mapper;
            _EmailService = emailService;
        }


        /// <summary>
        /// Make Reservation
        /// </summary>
        /// <param name="reservationMake"></param>
        /// <returns></returns>
        public async Task<ResultModel<ReservationDto>> MakeReservation(ReservationMakeDto reservationMake)
        {
            var result = new ResultModel<ReservationDto>();
            try
            {
                //Checking table status and Number Of Guest
                var tables = await _tableService.GetTables(reservationMake.NumberOfGuests);
                if (!tables.IsSuccess)
                {
                    throw new Exception(string.Join(",", tables.ErrorMessages));
                }

                var table = tables.Data.FirstOrDefault();
                var reservation = new Reservation
                {
                    CustomerName = reservationMake.CustomerName,
                    ReservationDate = reservationMake.ReservationDate,
                    NumberOfGuests = reservationMake.NumberOfGuests,
                    TableNumber = table.Number
                };


                //Send Email
                var email = $"Sayın {reservationMake.CustomerName}, rezervasyonunuz başarıyla alındı. Masa No: {table.Number}, Tarih: {reservationMake.ReservationDate}, Kişi Sayısı: {reservationMake.NumberOfGuests}";
                var EmailResponse = _EmailService.SendEmail(new EmailModel
                {
                    Message = "Rezervasyon Onayı",
                    Recipient = reservationMake.CustomerEmail,
                    Subject = email
                });


                //Email Status
                if (EmailResponse)
                {
                    //Save reservation
                    var resultEntity = await CreateReservation(reservation);
                    if (resultEntity.IsSuccess)
                    {
                        result.Data = _mapper.Map<ReservationDto>(resultEntity.Data);

                        //update table status
                        await _tableService.UpdateTableStatus(table.Id);
                    }
                    else result.ErrorMessages = new List<string> { $"Not create Reservation" };
                }
                else result.ErrorMessages = new List<string> { $"Not send Customer Email" };

            }
            catch (Exception ex)
            {
                result.ErrorMessages = new List<string> { $"Error Messages : {ex.Message}" };
            }
            return result;
        }



        /// <summary>
        /// record in reservation table
        /// </summary>
        /// <param name="reservation"></param>
        /// <returns></returns>
        public async Task<ResultModel<ReservationDto>> CreateReservation(Reservation reservation)
        {
            var result = new ResultModel<ReservationDto>();
            try
            {
                var response = await _reservationRepo.SaveReservation(reservation);
                result.Data = _mapper.Map<ReservationDto>(response);
            }
            catch (Exception ex)
            {
                result.ErrorMessages = new List<string> { $"Error Create reservation : {ex.Message}" };
            }
            return result;
        }
    }
}
