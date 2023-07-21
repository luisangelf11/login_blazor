using Login.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Login.Data.Context
{
    public class LoginDBContext : DbContext, ILoginDBContext
    {
        private readonly IConfiguration config;

        public LoginDBContext(IConfiguration config)
        {
            this.config = config;
        }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(config.GetConnectionString("MSSQL"));
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
