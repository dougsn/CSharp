using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MontagemCr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MontagemCr.Mapeamento
{
    public class CurriculoMap : IEntityTypeConfiguration<Curriculo>
    {
        public void Configure(EntityTypeBuilder<Curriculo> builder)
        {
            builder.HasKey(c => c.CurriculoId);

            builder.Property(c => c.Nome).IsRequired().HasMaxLength(50);
            builder.HasIndex(c => c.Nome).IsUnique();

            builder.HasOne(c => c.Usuario).WithMany(c => c.Curriculos).HasForeignKey(c => c.UsuarioId);
            builder.HasMany(c => c.Objetivos).WithOne(c => c.Curriculo).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(c => c.FormacoesAcademicas).WithOne(c => c.Curriculo).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(c => c.ExperienciasProfissionais).WithOne(c => c.Curriculo).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(c => c.Idiomas).WithOne(c => c.Curriculo).OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("Curriculos");
        }
    }
}
