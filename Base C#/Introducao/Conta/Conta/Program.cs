

using System.Globalization;

namespace Conta {
    class Program {
        static void Main(string[] args) {

            Console.Write("Entre com o número da conta: ");
            string numeroConta = Console.ReadLine();
            Console.Write("Entre o titular da conta: ");
            string titularConta = Console.ReadLine();
            Console.Write("Haverá depósito inicial (s/n)? ");
            char pergunta = char.Parse(Console.ReadLine());

            Usuario user1 = new Usuario(numeroConta, titularConta);

            if (pergunta == 's') {
                Console.Write("Entre com o valor de depósito inicial: ");
                double depositoInicial = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                user1.Deposito(depositoInicial);
            }

            

            Console.WriteLine("Dados da conta: " +  user1);

            Console.Write("Entre com um valor para depósito: ");
            double deposito = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            user1.Deposito(deposito);
            Console.WriteLine("Dados da conta atualizados: " + user1);

            Console.Write("Entre com um valor para saque: ");
            double saque = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            user1.Saque(saque);
            Console.WriteLine("Dados da conta atualizados: " + user1);



        }
    }
}