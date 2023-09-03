using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AppERP.Dominio;
using AppERP.Infraestructura.Datos.Configs;
namespace AppERP.Infraestructura.Datos.Contexto
{
    public class CompraContexto : DbContext 
    {
        public DbSet<Producto> Productos { get; set; }

        public DbSet<Compra> Compras { get; set; }

        public DbSet<CompraDetalle> ComprasDetalle { get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder options) 
        {
            options.UseSqlServer("Server=exmanbamvm.database.windows.net;Database=examenbam;User Id=admindbam;Password=B123456789a;");

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new ProductoConfig());
            builder.ApplyConfiguration(new CompraConfig());
            builder.ApplyConfiguration(new CompraDetalleConfig());
        }
    }
}
