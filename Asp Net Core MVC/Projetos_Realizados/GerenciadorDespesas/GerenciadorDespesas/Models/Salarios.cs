using System.ComponentModel.DataAnnotations;

namespace GerenciadorDespesas.Models
{
    public class Salarios
    {
        public int SalarioId { get; set; }
        public int MesId { get; set; }
        public Meses Meses { get; set; }
        [Required(ErrorMessage = "Campo obrigatório.")]
        [Range(0, double.MaxValue, ErrorMessage = "Valor inválido.")]
        public double Valor { get; set; }
    }
}
