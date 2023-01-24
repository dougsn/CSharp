using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AppMvcBasica.Models
{
    public class Fornecedor : Entity
    {

        public string Nome { get; set; }

        public string Documento { get; set; }
        public TipoFornecedor TipoFornecedor { get; set; }
        /* Dizendo que o Fornecedor tem 1 Endereço */
        public Endereco Endereco { get; set; }

        public bool Ativo { get; set; }
        
        /* Relação 1 para muitos - Fornecedor tem muitos produtos*/
        public IEnumerable<Produto> Produtos { get; set; }
    }
}
