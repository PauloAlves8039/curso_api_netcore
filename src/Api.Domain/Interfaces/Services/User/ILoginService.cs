using System.Threading.Tasks;
using src.Api.Domain.Dtos;

namespace src.Api.Domain.Interfaces.Services.User
{
    public interface ILoginService
    {
        Task<object> FindByLogin(LoginDto user);
    }
}
