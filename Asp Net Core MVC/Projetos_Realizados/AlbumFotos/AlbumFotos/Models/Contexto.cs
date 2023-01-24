using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlbumFotos.Models
{


    public class Contexto : DbContext
    {
        public DbSet<Album> Albuns { get; set; }
        public DbSet<Imagem> Imagens { get; set; }

        public Contexto(DbContextOptions<Contexto> opcoes) : base(opcoes) { }
    }

 

}
