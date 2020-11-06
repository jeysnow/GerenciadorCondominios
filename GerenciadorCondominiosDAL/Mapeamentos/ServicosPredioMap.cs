using GerenciadorCondominiosBLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciadorCondominiosDAL.Mapeamentos
{
    public class ServicosPredioMap : IEntityTypeConfiguration<ServicoPredio>
    {
        public void Configure(EntityTypeBuilder<ServicoPredio> builder)
        {
            builder.HasKey(s => s.ServicoPredioId);
            builder.Property(s => s.ServicoPredioId).IsRequired();
            builder.Property(s => s.DataExecucao).IsRequired();

            builder.HasOne(s => s.Servico)
                .WithMany(s => s.ServicoPredios)
                .HasForeignKey(s => s.ServicoId);

            builder.ToTable("ServicoPredio");

        }
    }
}
