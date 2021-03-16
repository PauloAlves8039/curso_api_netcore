using System.Threading.Tasks;
using src.Api.Domain.Entities;
using src.Api.Domain.Interfaces;

namespace src.Api.Domain.Repository
{
    public interface ICepRepository : IRepository<CepEntity>
    {
        Task<CepEntity> SelectAsync(string cep);
    }
}
