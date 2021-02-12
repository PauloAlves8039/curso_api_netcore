using AutoMapper;
using src.Api.Domain.Entities;
using src.Api.Domain.Models;

namespace src.Api.CrossCutting.Mappings
{
    public class ModelToEntityProfile : Profile
    {
        public ModelToEntityProfile()
        {
            CreateMap<UserEntity, UserModel>().ReverseMap();
        }
    }
}
