using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Cache.Models
{
    public partial class PessoasDBContext : DbContext
    {
        public PessoasDBContext()
        {
        }

        public PessoasDBContext(DbContextOptions<PessoasDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Pessoas> Pessoas { get; set; }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pessoas>(entity =>
            {
                entity.HasKey(e => e.PessoaId);
            });
        }
    }
}
