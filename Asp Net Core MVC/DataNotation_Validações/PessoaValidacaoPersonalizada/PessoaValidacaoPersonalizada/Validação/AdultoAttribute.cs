using PessoaValidacaoPersonalizada.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PessoaValidacaoPersonalizada.Validação
{
    public class AdultoAttribute : ValidationAttribute
    { // Criando uma classe com um método PERSONALIZADO para validar se uma pessoa é adulta

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Pessoa pessoa = (Pessoa)validationContext.ObjectInstance;

            if(pessoa.Idade < 18)
            {
                return new ValidationResult("Apenas adultos podem se cadastrar");
            }

            return ValidationResult.Success;
        }

    }
}
