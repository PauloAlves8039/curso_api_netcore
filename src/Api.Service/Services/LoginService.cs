using System.Threading.Tasks;
using src.Api.Domain.Entities;
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

        public async Task<object> FindByLogin(UserEntity user)
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
