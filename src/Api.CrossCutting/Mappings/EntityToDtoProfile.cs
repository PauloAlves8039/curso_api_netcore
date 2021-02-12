using AutoMapper;
using src.Api.Domain.Dtos.User;
using src.Api.Domain.Entities;

namespace src.Api.CrossCutting.Mappings
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            CreateMap<UserDto, UserEntity>().ReverseMap();

            CreateMap<UserDtoCreateResult, UserEntity>().ReverseMap();

            CreateMap<UserDtoUpdateResult, UserEntity>().ReverseMap();
        }
    }
}
