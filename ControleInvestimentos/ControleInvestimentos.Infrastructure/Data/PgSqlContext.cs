using ControleInvestimentos.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace ControleInvestimentos.Infrastructure.Data
{
    public class PgSqlContext : DbContext
    {
        public PgSqlContext()
        {

        }
        public PgSqlContext(DbContextOptions<PgSqlContext> options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Transacao> Transacoes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
