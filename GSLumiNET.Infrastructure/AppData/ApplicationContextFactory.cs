using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace GSLumiNET.Infrastructure.AppData
{
    public class ApplicationSContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
        public ApplicationContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            optionsBuilder.UseSqlServer("Server=oracle.fiap.com.br;Database=ORCL;User Id=rm97898;Password=210904;");

            return new ApplicationContext(optionsBuilder.Options);
        }
    }
}
