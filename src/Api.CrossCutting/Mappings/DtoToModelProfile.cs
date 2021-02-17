using AutoMapper;
using src.Api.Domain.Dtos.User;
using src.Api.Domain.Models;

namespace src.Api.CrossCutting.Mappings
{
    public class DtoToModelProfile : Profile
    {
        public DtoToModelProfile()
        {
            CreateMap<UserModel, UserDto>().ReverseMap();

            CreateMap<UserModel, UserDtoCreate>().ReverseMap();

            CreateMap<UserModel, UserDtoUpdate>().ReverseMap();
        }
    }
}
