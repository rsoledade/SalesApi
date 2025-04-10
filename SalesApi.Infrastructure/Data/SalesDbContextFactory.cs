using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace SalesApi.Infrastructure.Data
{
    public class SalesDbContextFactory : IDesignTimeDbContextFactory<SalesDbContext>
    {
        public SalesDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SalesDbContext>();

            // Conexão usada em tempo de design (ajuste conforme necessário)
            optionsBuilder.UseNpgsql("Host=localhost;Database=SalesApiDb;Username=postgres;Password=admin");

            return new SalesDbContext(optionsBuilder.Options);
        }
    }
}
