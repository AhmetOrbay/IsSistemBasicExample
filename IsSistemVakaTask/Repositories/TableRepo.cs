using IsSistemVakaTask.Models.Entities;
using IsSistemVakaTask.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IsSistemVakaTask.Repositories
{
    public class TableRepo : ITableRepo
    {
        private readonly VakaDbContext _dbContext;

        public TableRepo(VakaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        /// <summary>
        /// Get tables by guests size
        /// </summary>
        /// <param name="guests"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<List<Table>> GetTables(int guests)
        {
            try
            {
                return await _dbContext.Tables
                                  .Where(x => x.TableStatus && x.Capacity == guests)
                                  .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error : {ex.Message}");
            }
          
        }

        /// <summary>
        /// Update Data
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task UpdateTableStatus(int Id)
        {
            try
            {
                var entityEntry = await _dbContext.Tables.FindAsync(Id);
                if (entityEntry is not null)
                {
                    entityEntry.TableStatus = !entityEntry.TableStatus;
                    await _dbContext.SaveChangesAsync();
                }
                else throw new Exception($"Not found Table");
            }
            catch (Exception ex)
            {
                throw new Exception($"Update table status error : {ex.Message}");
            }
        }
    }
}
