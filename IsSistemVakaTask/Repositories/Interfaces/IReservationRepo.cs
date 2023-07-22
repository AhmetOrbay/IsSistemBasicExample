using IsSistemVakaTask.Models.Dtos;
using IsSistemVakaTask.Models.Entities;

namespace IsSistemVakaTask.Repositories.Interfaces
{
    public interface IReservationRepo
    {
        /// <summary>
        /// Save reservation 
        /// </summary>
        /// <param name="reservation"></param>
        /// <returns></returns>
        Task<Reservation> SaveReservation(Reservation reservation);
    }
}
