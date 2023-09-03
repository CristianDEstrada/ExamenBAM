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
    class CompraConfig : IEntityTypeConfiguration<Compra>
    {
        public void Configure(EntityTypeBuilder<Compra> builder)
        {
            builder.ToTable("tblCompra");
            builder.HasKey(c => c.compraId);

            builder
                .HasMany(compra => compra.CompraDetalles)
                .WithOne(detalle => detalle.Compra);
            
        }
    }
}
