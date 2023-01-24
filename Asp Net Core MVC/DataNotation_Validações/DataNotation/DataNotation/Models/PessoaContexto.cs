using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataNotation.Models
{
    public class PessoaContexto : DbContext
    {
        public DbSet<Pessoa> Pessoas { get; set; }

        public PessoaContexto(DbContextOptions<PessoaContexto> opcoes) : base(opcoes) { }

    }
}
