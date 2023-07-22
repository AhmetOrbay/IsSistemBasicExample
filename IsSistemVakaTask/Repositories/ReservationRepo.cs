using IsSistemVakaTask.Models.Dtos;
using IsSistemVakaTask.Models.Entities;
using IsSistemVakaTask.Repositories.Interfaces;
using IsSistemVakaTask.Services.Interfaces;

namespace IsSistemVakaTask.Repositories
{
    public class ReservationRepo : IReservationRepo
    {
        private readonly VakaDbContext _dbContext;

        public ReservationRepo(VakaDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<Reservation> SaveReservation(Reservation reservation)
        {
            try
            {
                var result =await _dbContext.Reservations.AddAsync(reservation);
                await _dbContext.SaveChangesAsync();
                return result.Entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
