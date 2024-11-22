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
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        base.OnConfiguring(options);
        
        options.UseOracle("User Id=rm99573;Password=170504;Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=oracle.fiap.com.br)(PORT=1521))(CONNECT_DATA=(SID=ORCL)));", 
            b => b.MigrationsAssembly("GSLumiNET.Infrastructure"));
    }
        public DbSet<RegistroEntity> Registro { get; set; }
    }
}
