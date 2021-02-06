using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using src.Api.Data.Context;
using src.Api.Data.Repository;
using src.Api.Domain.Entities;
using src.Api.Domain.Repository;

namespace src.Api.Data.Implementations
{
    public class UserImplementation : BaseRepository<UserEntity>, IUserRepository
    {
        private DbSet<UserEntity> _dataset;

        public UserImplementation(MyContext context) : base(context)
        {
            _dataset = context.Set<UserEntity>();
        }

        public async Task<UserEntity> FindByLogin(string email)
        {
            return await _dataset.FirstOrDefaultAsync(u => u.Email.Equals(email));
        }
    }
}
