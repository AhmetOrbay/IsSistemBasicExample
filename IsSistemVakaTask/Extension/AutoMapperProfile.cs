using AutoMapper;
using IsSistemVakaTask.Models.Dtos;
using IsSistemVakaTask.Models.Entities;
using Table = IsSistemVakaTask.Models.Entities.Table;

namespace IsSistemVakaTask.Extension
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Table, TableDto>()
                .ReverseMap();
            CreateMap<Reservation, ReservationDto>()
                .ReverseMap();
        }
    }

}
