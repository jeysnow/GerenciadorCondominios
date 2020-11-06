﻿using GerenciadorCondominiosBLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciadorCondominiosDAL.Mapeamentos
{
    public class ServicosMap : IEntityTypeConfiguration<Servico>
    {
        public void Configure(EntityTypeBuilder<Servico> builder)
        {

            builder.Property(s => s.ServicoId);
            builder.Property(s => s.Nome).IsRequired().HasMaxLength(30);
            builder.Property(s => s.Valor).IsRequired();
            builder.Property(s => s.Status).IsRequired();
            builder.Property(s => s.UsuarioId).IsRequired();

            builder.HasOne(s => s.Usuario).WithMany(s => s.Servicos).HasForeignKey(s => s.UsuarioId);
            builder.HasMany(s => s.ServicoPredios).WithOne(s => s.Servico);

            builder.ToTable("Servicos");
        }
    }
}
