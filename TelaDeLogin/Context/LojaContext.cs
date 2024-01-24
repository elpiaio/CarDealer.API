using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TelaDeLogin.DTO;

namespace TelaDeLogin.Context
{
    public class LojaContext : DbContext
    {
        public LojaContext(DbContextOptions<LojaContext> options) : base(options)
        {
        
        }
        public DbSet<Cliente> Clientes { get; set; }
    }
}
