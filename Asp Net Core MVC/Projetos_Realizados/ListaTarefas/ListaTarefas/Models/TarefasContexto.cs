using Microsoft.EntityFrameworkCore;

namespace ListaTarefas.Models
{
    public class TarefasContexto : DbContext
    {
        public DbSet<Tarefas> Tarefas { get; set; }
        public TarefasContexto(DbContextOptions<TarefasContexto> opcoes) : base(opcoes) { }
    }
}
