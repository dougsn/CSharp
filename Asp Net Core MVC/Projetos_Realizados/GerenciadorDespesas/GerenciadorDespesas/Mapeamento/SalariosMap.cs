using GerenciadorDespesas.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciadorDespesas.Mapeamento
{
    public class SalariosMap : IEntityTypeConfiguration<Salarios>
    {
        public void Configure(EntityTypeBuilder<Salarios> builder)
        {
            builder.HasKey(s => s.SalarioId);
            builder.Property(s => s.Valor).IsRequired();

            // Em um relacionamento 1x1 é nececessário especificar aonde está a chave estrangeira
            builder.HasOne(s => s.Meses).WithOne(s => s.Salarios).HasForeignKey<Salarios>(s => s.MesId);

            builder.ToTable("Salarios");

        }
    }

}
