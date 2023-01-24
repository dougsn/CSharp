using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MontagemCr.Models
{
    public class Usuario
    {
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(50, ErrorMessage = "Use menos caracteres")]
        [EmailAddress(ErrorMessage = "Email Inválido")]  
        [Remote("UsuarioExiste", "Usuarios")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(50, ErrorMessage = "Use menos caracteres")]        
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        public ICollection<InformacaoLogin> InformacoesLogin { get; set; }
        public ICollection<Curriculo> Curriculos { get; set; }
    }
}
