using Janos.Models;
using Microsoft.EntityFrameworkCore;

namespace Janos.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Item> Itens { get; set; }
        public DbSet<Loja> Lojas { get; set; }
        public DbSet<Nota> Notas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseOracle("User Id=rm99433;Password=090397;Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=oracle.fiap.com.br)(PORT=1521)))(CONNECT_DATA=(SERVICE_NAME=orcl)))");
            }
        }

        public bool TestConnection()
        {
            try
            {
                this.Database.OpenConnection();
                this.Database.CloseConnection();
                return true; 
            }
            catch
            {
                return false; 
            }
        }
    }
}
