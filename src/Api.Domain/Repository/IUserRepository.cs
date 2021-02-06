using System.Threading.Tasks;
using src.Api.Domain.Entities;
using src.Api.Domain.Interfaces;

namespace src.Api.Domain.Repository
{
    public interface IUserRepository : IRepository<UserEntity>
    {
        Task<UserEntity> FindByLogin(string email);
    }
}
