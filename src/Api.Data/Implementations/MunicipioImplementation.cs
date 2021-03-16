using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using src.Api.Data.Context;
using src.Api.Data.Repository;
using src.Api.Domain.Entities;
using src.Api.Domain.Repository;

namespace src.Api.Data.Implementations
{
    public class MunicipioImplementation : BaseRepository<MunicipioEntity>, IMunicipioRepository
    {
        private DbSet<MunicipioEntity> _dataset;

        public MunicipioImplementation(MyContext context) : base(context)
        {
            _dataset = context.Set<MunicipioEntity>();
        }

        public async Task<MunicipioEntity> GetCompleteByIBGE(int codIBGE)
        {
            return await _dataset.Include(m => m.Uf).FirstOrDefaultAsync(m => m.CodIBGE.Equals(codIBGE));
        }

        public async Task<MunicipioEntity> GetCompleteById(Guid id)
        {
            return await _dataset.Include(m => m.Uf).FirstOrDefaultAsync(m => m.CodIBGE.Equals(id));
        }
    }
}
