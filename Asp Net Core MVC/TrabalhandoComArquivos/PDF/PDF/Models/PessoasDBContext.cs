using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PDF.Models
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=PessoasDB;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pessoas>(entity =>
            {
                entity.HasKey(e => e.PessoaId);
            });
        }
    }
}
