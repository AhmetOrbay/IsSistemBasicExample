using AutoMapper;
using IsSistemVakaTask.Models.Dtos;
using IsSistemVakaTask.Repositories.Interfaces;
using IsSistemVakaTask.Services.Interfaces;

namespace IsSistemVakaTask.Services
{
    public class TableService : ITableService
    {
        private readonly ITableRepo _tableRepo;
        private readonly IMapper _mapper;


        public TableService(ITableRepo tableRepo, IMapper mapper)
        {
            _tableRepo = tableRepo;
            _mapper = mapper;
        }

        /// <summary>
        /// Get Available tables
        /// </summary>
        /// <param name="guests"></param>
        /// <returns></returns>
        public async Task<ResultModel<List<TableDto>>> GetTables(int guests)
        {
            var result = new ResultModel<List<TableDto>>();
            try
            {
                if(guests > 0)
                {
                    var TableList = await _tableRepo.GetTables(guests);
                    if (!TableList.Any()) result.ErrorMessages = new List<string> { $"Not Found Data" };
                    result.Data = _mapper.Map<List<TableDto>>(TableList);
                } else result.ErrorMessages = new List<string> { $"guess count cannot be zero" };
            }
            catch (Exception ex)
            {
                result.ErrorMessages = new List<string> { $"Error Messages : {ex.Message}" };
            }
            return result;
        }

        public Task UpdateTableStatus(int Id)
        {
            try
            {
                return _tableRepo.UpdateTableStatus(Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
