using System;
using System.Threading.Tasks;
using src.Api.Domain.Entities;
using src.Api.Domain.Interfaces;

namespace src.Api.Domain.Repository
{
    public interface IMunicipioRepository : IRepository<MunicipioEntity>
    {
        Task<MunicipioEntity> GetCompleteById(Guid id);
        Task<MunicipioEntity> GetCompleteByIBGE(int codIBGE);
    }
}
