using IsSistemVakaTask.Models.Dtos;
using IsSistemVakaTask.Models.Entities;

namespace IsSistemVakaTask.Services.Interfaces
{
    public interface IReservationService
    {
        /// <summary>
        /// preparation of the reservation
        /// </summary>
        /// <param name="reservationMake"></param>
        /// <returns></returns>
        Task<ResultModel<ReservationDto>> MakeReservation(ReservationMakeDto reservationMake);
        Task<ResultModel<ReservationDto>> CreateReservation(Reservation reservation);
    }
}
