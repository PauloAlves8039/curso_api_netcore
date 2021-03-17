using AutoMapper;
using src.Api.Domain.Dtos.Cep;
using src.Api.Domain.Dtos.Municipio;
using src.Api.Domain.Dtos.Uf;
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

            CreateMap<UfDto, UfEntity>().ReverseMap();

            CreateMap<MunicipioDto, MunicipioEntity>().ReverseMap();

            CreateMap<MunicipioDtoCompleto, MunicipioEntity>().ReverseMap();

            CreateMap<MunicipioDtoCreateResult, MunicipioEntity>().ReverseMap();

            CreateMap<MunicipioDtoUpdateResult, MunicipioEntity>().ReverseMap();

            CreateMap<CepDto, CepEntity>().ReverseMap();

            CreateMap<CepDtoCreateResult, CepEntity>().ReverseMap();

            CreateMap<CepDtoUpdateResult, CepEntity>().ReverseMap();
        }
    }
}
