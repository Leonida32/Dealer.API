using Microsoft.EntityFrameworkCore;
using Models_Services;
namespace Dealer.API
{
    public class Factory
    {

    }
    public class DbContex : DbContext
    {
        public DbContex(DbContextOptions<DbContex> options ): base(options) { }
        
        public DbSet<Vehiculos> Vehiculos { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
    }
}

