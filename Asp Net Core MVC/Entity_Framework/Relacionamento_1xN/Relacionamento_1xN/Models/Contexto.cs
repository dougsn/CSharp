using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Relacionamento_1xN.Models;

namespace Relacionamento_1xN.Models
{
    public class Contexto : DbContext
    {
        public DbSet<Empregado> Empregados { get; set; }

        public Contexto(DbContextOptions<Contexto> opcoes) : base(opcoes) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // O Empregado tem 1 trabalho e 1 trabalho tem muitos empregados, a chave estrangeira está no TrabalhoId, que está na classe Empregado.
            modelBuilder.Entity<Empregado>().HasOne(x => x.Trabalho).WithMany(x => x.Empregados).HasForeignKey(x => x.TrabalhoId);

            // O Trabalho tem N Empregados e os Empregados tem 1 Trabalho.
            modelBuilder.Entity<Trabalho>().HasMany(x => x.Empregados).WithOne(x => x.Trabalho);

        }

        public DbSet<Relacionamento_1xN.Models.Trabalho> Trabalho { get; set; }

    }
}
