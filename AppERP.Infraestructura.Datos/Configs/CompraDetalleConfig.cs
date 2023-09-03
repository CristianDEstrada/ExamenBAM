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
    class CompraDetalleConfig : IEntityTypeConfiguration<CompraDetalle>
    {
        public void Configure (EntityTypeBuilder<CompraDetalle> builder)
        {
            builder.ToTable("tblCompraDetalle");
            builder.HasKey(c => new { c.productoId, c.CompraId });

            builder
                .HasOne(detalle => detalle.Producto)
                .WithMany(producto => producto.CompraDetalles);

            builder
                .HasOne(detalle => detalle.Compra)
                .WithMany(compra => compra.CompraDetalles);
        }
    }
}
