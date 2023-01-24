using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntroducaoFluentAPI.Models
{
    public class PessoaContexto : DbContext
    {
        public DbSet<Pessoa> pessoas { get; set; }

        public PessoaContexto(DbContextOptions<PessoaContexto> opcoes) : base(opcoes) {}

        // Sobreescrevendo a classe para modelar a base de dados
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Pessoa>().HasKey(x => x.PessoaId);

            // Configurando a coluna de nome, que terá o tipo text, de no máximo 50 varchar e sendo obrigatório.
            modelBuilder.Entity<Pessoa>().Property(x => x.Nome).HasColumnName("Nome").HasColumnType("ntext").HasMaxLength(50).IsRequired();

            // Configurando a coluna de idade, que terá o tipo int, e não é obrigatório.
            modelBuilder.Entity<Pessoa>().Property(x => x.Idade).HasColumnName("Idade").HasColumnType("int").IsRequired(false);

            // Configurando a coluna de peso, que terá o tipo float (pois no sqlserver não possui o tipo double), não é obrigatório.
            modelBuilder.Entity<Pessoa>().Property(x => x.Peso).HasColumnName("Peso").HasColumnType("float").IsRequired(false);

            // Configurando o nome da Tabela no Banco de Dados.
            modelBuilder.Entity<Pessoa>().ToTable("Pessoas");

        }

    }
}
