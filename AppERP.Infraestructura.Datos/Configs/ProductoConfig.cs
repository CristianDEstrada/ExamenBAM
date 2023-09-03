using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppERP.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppERP.Infraestructura.Datos.Configs
{
    class ProductoConfig : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.ToTable("tblProductos");
            builder.HasKey(c => c.productoId);

            builder
                .HasMany(producto => producto.CompraDetalles)
                .WithOne(detalle => detalle.Producto);
        }
    }
}
