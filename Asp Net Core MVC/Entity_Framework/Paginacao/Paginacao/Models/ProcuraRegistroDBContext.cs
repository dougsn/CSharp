using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Paginacao.Models
{
    public partial class ProcuraRegistroDBContext : DbContext
    {
        public ProcuraRegistroDBContext()
        {
        }

        public ProcuraRegistroDBContext(DbContextOptions<ProcuraRegistroDBContext> options)
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
