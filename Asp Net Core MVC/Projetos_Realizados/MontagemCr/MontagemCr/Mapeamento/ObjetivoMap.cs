using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MontagemCr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MontagemCr.Mapeamento
{
    public class ObjetivoMap : IEntityTypeConfiguration<Objetivo>
    {
        public void Configure(EntityTypeBuilder<Objetivo> builder)
        {
            builder.HasKey(o => o.ObjetivoId);

            builder.Property(o => o.Descrição).IsRequired().HasMaxLength(1000);

            builder.HasOne(o => o.Curriculo).WithMany(o => o.Objetivos).HasForeignKey(o => o.CurriculoId);

            builder.ToTable("Objetivos");
        }
    }
}
