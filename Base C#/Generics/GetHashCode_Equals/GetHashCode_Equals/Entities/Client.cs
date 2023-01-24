using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetHashCode_Equals.Entities {
    internal class Client {

        public string Name { get; set; }
        public string Email { get; set; }

        public override bool Equals(object? obj) {

            if (!(obj is Client client)) return false; // Verificando se o objeto é do tipo correto

            Client other = obj as Client;
            return Email.Equals(other.Email); // Realizando a comparação por E-mail

        }

        override public int GetHashCode() { 
        
            return Email.GetHashCode(); // Retornando o hashcode do cliente, para realizar a comparação se necessário.
        }


    }
}
