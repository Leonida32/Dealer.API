using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Sqlite;
using System.ComponentModel;
using System.Collections.Specialized;
using Microsoft.EntityFrameworkCore;

namespace Models_Services
{
    public class Servicio : DbContext
    {
        public Servicio(DbContextOptions<Servicio> options) : base(options) { }
        
        public DbSet<Clientes> Clientes { get; set; } 
        public DbSet<Vehiculos> Vehiculos { get; set; }

    }
}
