using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MontagemCr.Models
{
    public class Curriculo
    {
        public int CurriculoId { get; set; }

        public string Nome { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public ICollection<Objetivo> Objetivos { get; set; }

        public ICollection<FormacaoAcademica> FormacoesAcademicas { get; set; }

        public ICollection<ExperienciaProfissional> ExperienciasProfissionais { get; set; }

        public ICollection<Idioma> Idiomas { get; set; }
    }
}
