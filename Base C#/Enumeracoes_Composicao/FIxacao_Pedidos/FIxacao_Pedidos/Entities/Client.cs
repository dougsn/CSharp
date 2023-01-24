using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fixacao_Pedidos.Entities {
    internal class Client {

        public string Name { get; set; }
        public string Email{ get; set; }
        public DateTime birthDate{ get; set; }

        public Client() { }

        public Client(string name, string email, DateTime birthDate) {
            Name = name;
            Email = email;
            this.birthDate = birthDate;
        }

        override public string ToString() {

            StringBuilder sb = new StringBuilder();

            sb.Append("Client: " +  Name);
            sb.Append(" (" + birthDate.ToString("dd/MM/yyyy") + ")");
            sb.AppendLine(" - " + Email);

            return sb.ToString();


        }

    }
}
