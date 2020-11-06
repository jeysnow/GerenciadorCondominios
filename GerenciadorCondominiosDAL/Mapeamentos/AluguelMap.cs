using GerenciadorCondominiosBLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciadorCondominiosDAL.Mapeamentos
{
    public class AluguelMap : IEntityTypeConfiguration<Aluguel>
    {
        public void Configure(EntityTypeBuilder<Aluguel> builder)
        {
            builder.HasKey(async => async.AluguelId);
            builder.Property(a => a.Valor).IsRequired();
            builder.Property(a => a.MesId).IsRequired();
            builder.Property(a => a.Ano).IsRequired();

            builder.HasOne(a => a.Mes).WithMany(a => a.Alugueis).HasForeignKey(a => a.MesId);
            
            builder.HasMany(a => a.Pagamentos).WithOne(a => a.Aluguel);

            builder.ToTable("Alugueis");

        }
    }
}
