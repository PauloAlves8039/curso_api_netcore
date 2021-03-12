using System;
using System.Threading.Tasks;
using src.Api.Domain.Dtos.Cep;

namespace src.Api.Domain.Interfaces.Services.Cep
{
    public interface ICepService
    {
        Task<CepDto> Get(Guid id);

        Task<CepDto> Get(string cep);

        Task<CepDtoCreateResult> Post(CepDtoCreate cep);

        Task<CepDtoUpdateResult> Put(CepDtoCreate cep);

        Task<bool> Delete(Guid id);
    }
}
