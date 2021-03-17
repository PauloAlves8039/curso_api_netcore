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

            CreateMap<UfModel, UfEntity>().ReverseMap();

            CreateMap<MunicipioModel, MunicipioEntity>().ReverseMap();

            CreateMap<CepModel, CepEntity>().ReverseMap();
        }
    }
}
