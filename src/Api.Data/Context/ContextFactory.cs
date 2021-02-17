using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace src.Api.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        public MyContext CreateDbContext(string[] args)
        {
            // var connectionString = "Server=localhost;Port=3306;Database=dbAPI;Uid=root;Pwd=******";
            var connectionString = "Server=.\\SQLEXPRESS;Database=dbAPI;User Id=sa;Password=******";
            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
            // optionsBuilder.UseMySql(connectionString);
            optionsBuilder.UseSqlServer(connectionString);
            return new MyContext(optionsBuilder.Options);
        }
    }
}
