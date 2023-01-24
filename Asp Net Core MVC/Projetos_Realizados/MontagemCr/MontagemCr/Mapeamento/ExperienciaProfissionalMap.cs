using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MontagemCr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MontagemCr.Mapeamento
{
    public class ExperienciaProfissionalMap : IEntityTypeConfiguration<ExperienciaProfissional>
    {
        public void Configure(EntityTypeBuilder<ExperienciaProfissional> builder)
        {
            builder.HasKey(e => e.ExperienciaProfissionalId);

            builder.Property(e => e.NomeEmpresa).IsRequired().HasMaxLength(50);
            builder.Property(e => e.Cargo).IsRequired().HasMaxLength(50);
            builder.Property(e => e.AnoInicio).IsRequired();
            builder.Property(e => e.AnoFim).IsRequired();
            builder.Property(e => e.DescricaoAtividades).IsRequired().HasMaxLength(500);

            builder.HasOne(e => e.Curriculo).WithMany(e => e.ExperienciasProfissionais).HasForeignKey(e => e.CurriculoId);

            builder.ToTable("ExperienciasProfissionais");
        }
    }
}
