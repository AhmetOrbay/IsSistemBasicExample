

using IsSistemVakaTask.Models.Dtos;

namespace IsSistemVakaTask.Services.Interfaces
{
    public interface ITableService
    {
        Task<ResultModel<List<TableDto>>> GetTables(int guests);
        Task UpdateTableStatus(int Id);
    }
}
