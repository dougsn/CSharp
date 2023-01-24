using AppModelo.Models;
using Microsoft.EntityFrameworkCore;

namespace AppModelo.Data
{
    public class MeuDbContext : DbContext
    {
        public MeuDbContext(DbContextOptions<MeuDbContext> options) : base(options)
        {

        }

        public DbSet<Aluno> Alunos { get; set; } // Mapeando a model para o banco de dados.

    }
}
