using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Relacionamento_1x1.Models;

namespace Relacionamento_1x1.Models
{
    public class PessoaContexto : DbContext
    {
        public DbSet<Pessoa> pessoas { get; set; }

        public PessoaContexto(DbContextOptions<PessoaContexto> opcoes) : base(opcoes) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   // Mapeando a tabela Pessoa com a tabela Endereço, sendo 1 pessoa para 1 endereço.
           
            // Entidade Pessoa, possui 1 endereço com 1 pessoa, e tem 1 chave estrangeira<Que está em Pessoa> de Endereço.
            modelBuilder.Entity<Pessoa>().HasOne(x => x.Endereco).WithOne(x => x.Pessoa).HasForeignKey<Pessoa>(x => x.EnderecoId);

            // Já na Entidade de Endereco, precisamos apenas vincular o relacionamento 1x1, pois a chave estrangeira está na classe Pessoa.
            modelBuilder.Entity<Endereco>().HasOne(x => x.Pessoa).WithOne(x => x.Endereco);
        }

        public DbSet<Relacionamento_1x1.Models.Endereco> Endereco { get; set; }

    }
}
