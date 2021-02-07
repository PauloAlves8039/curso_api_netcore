using System.Threading.Tasks;
using src.Api.Domain.Dtos;
using src.Api.Domain.Interfaces.Services.User;
using src.Api.Domain.Repository;

namespace src.Api.Service.Services
{
    public class LoginService : ILoginService
    {
        private IUserRepository _repository;

        public LoginService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<object> FindByLogin(LoginDto user)
        {
            if (user != null && !string.IsNullOrWhiteSpace(user.Email))
            {
                return await _repository.FindByLogin(user.Email); ;
            }
            else
            {
                return null;
            }
        }
    }
}
