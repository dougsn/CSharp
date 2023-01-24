using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conta {
    internal class Usuario {
        private string NumConta { get; set; }
        private string Titular { get; set; }
        private double Saldo { get; set; }

        public Usuario() { 
        }
        public Usuario(string numConta, string titular) {
            this.NumConta = numConta;
            this.Titular = titular;

        }

        public double Deposito(double valor) {
            return Saldo += valor;
        }

        public double Saque(double valor) {
            return Saldo -= valor + 5;
        }
        public override string ToString() {
            return "Conta "
                + NumConta
                + ", " 
                + "Titular: "
                + Titular
                + ", "
                + "Saldo: $ "
                + Saldo;
        }

    }
}
