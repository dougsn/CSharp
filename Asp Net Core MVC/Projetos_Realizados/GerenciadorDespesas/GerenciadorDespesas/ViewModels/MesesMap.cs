using GerenciadorDespesas.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciadorDespesas.Mapeamento
{
    public class GastosTotaisMesViewModel   
    {
        public double ValorTotalGasto { get; set; }
        public double Salario { get; set; }
    }
}
