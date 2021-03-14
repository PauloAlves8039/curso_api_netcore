using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using src.Api.Domain.Entities;

namespace src.Api.Data.Mapping
{
    public class CepMap : IEntityTypeConfiguration<CepEntity>
    {
        public void Configure(EntityTypeBuilder<CepEntity> builder)
        {
            builder.ToTable("Municipio");

            builder.HasKey(u => u.Id);

            builder.HasIndex(u => u.Cep);

            builder.HasOne(c => c.Municio).WithMany(m => m.Ceps);
        }
    }
}
