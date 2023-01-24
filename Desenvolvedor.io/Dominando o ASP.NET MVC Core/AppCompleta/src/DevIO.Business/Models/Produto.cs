using System.ComponentModel.DataAnnotations;

namespace AppMvcBasica.Models
{
    public class Produto : Entity
    {
        /* Fazendo a vinculação de fornecedor com produto */
        public Guid FornecedorId { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public string Imagem { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal Valor { get; set; }

        public DateTime DataCadastro { get; set; }

        public bool  Ativo { get; set; }

        /* O Produto possuí apenas 1 Fornecedor */
        public Fornecedor Fornecedor { get; set; }

    }
}
