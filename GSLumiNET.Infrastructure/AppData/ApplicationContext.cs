using GSLumiNET.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GSLumiNET.Infrastructure.AppData
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<RegistroEntity> Registro { get; set; }
    }
}
