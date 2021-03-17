using AutoMapper;
using src.Api.Domain.Dtos.Cep;
using src.Api.Domain.Dtos.Municipio;
using src.Api.Domain.Dtos.Uf;
using src.Api.Domain.Dtos.User;
using src.Api.Domain.Models;

namespace src.Api.CrossCutting.Mappings
{
    public class DtoToModelProfile : Profile
    {
        public DtoToModelProfile()
        {
            #region User
            CreateMap<UserModel, UserDto>().ReverseMap();

            CreateMap<UserModel, UserDtoCreate>().ReverseMap();

            CreateMap<UserModel, UserDtoUpdate>().ReverseMap();
            #endregion

            #region UF
            CreateMap<UfModel, UfDto>().ReverseMap();
            #endregion

            #region Municipio
            CreateMap<MunicipioModel, MunicipioDto>().ReverseMap();

            CreateMap<MunicipioModel, MunicipioDtoCreate>().ReverseMap();

            CreateMap<MunicipioModel, MunicipioDtoUpdate>().ReverseMap();
            #endregion

            #region Cep
            CreateMap<CepModel, CepDto>().ReverseMap();

            CreateMap<CepModel, CepDtoCreate>().ReverseMap();

            CreateMap<CepModel, CepDtoUpdate>().ReverseMap();
            #endregion


        }
    }
}
