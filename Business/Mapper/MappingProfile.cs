using AutoMapper;
using DataAccess.Data;
using DataAccess.Data.Models;
using Models;

namespace Business.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<HotelRoomDTO, HotelRoom>();
        CreateMap<HotelRoom, HotelRoomDTO>();
    }
}