using IsSistemVakaTask.Models.Entities;
using Microsoft.AspNetCore.Authentication;
using System.Threading.Tasks;

namespace IsSistemVakaTask.Repositories.Interfaces
{
    public interface ITableRepo
    {
        /// <summary>
        /// Get Tables List
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        Task<List<Table>> GetTables(int guests);

        Task UpdateTableStatus(int Id);
    }
}
