using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using src.Api.Domain.Dtos.Municipio;

namespace src.Api.Domain.Interfaces.Services.Municipio
{
    public interface IMunicipioService
    {
        Task<MunicipioDto> Get(Guid id);

        Task<MunicipioDtoCompleto> GetCompleteById(Guid id);

        Task<MunicipioDtoCompleto> GetCompleteByIBGE(int codIBGE);

        Task<IEnumerable<MunicipioDto>> GetAll();

        Task<MunicipioDtoCreateResult> Post(MunicipioDtoCreate municipio);

        Task<MunicipioDtoUpdateResult> Put(MunicipioDtoUpdate municipio);

        Task<bool> Delete(Guid id);
    }
}
