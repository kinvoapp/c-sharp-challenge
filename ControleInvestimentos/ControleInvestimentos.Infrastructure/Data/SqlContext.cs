using ControleInvestimentos.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace ControleInvestimentos.Infrastructure.Data
{
    public class SqlContext : DbContext
    {
        public SqlContext()
        {

        }
        public SqlContext(DbContextOptions<SqlContext> options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Acao> Acoes { get; set; }
        public DbSet<Transacao> Transacoes { get; set; }
    }
}
