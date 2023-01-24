using System.Globalization;

namespace EntradaDeDados {
    class Program {
        static void Main(string[] agrs) {

            // string frase = Console.ReadLine();
            // string x = Console.ReadLine();
            // string y = Console.ReadLine();
            // string z = Console.ReadLine();

            // string[] v = Console.ReadLine().Split(' ');
            // string a = v[0];
            // string b = v[1];
            // string c = v[2];

            //Console.WriteLine("Você digitou: ");
            //Console.WriteLine(frase);
            //Console.WriteLine(x);
            //Console.WriteLine(y);
            //Console.WriteLine(z);
            //Console.WriteLine(a);
            //Console.WriteLine(b);
            //Console.WriteLine(c);

            // Entrada de Dados parte 2

            int n1 = int.Parse(Console.ReadLine()); // Convertendo de inteiro para String
            char ch = char.Parse(Console.ReadLine());
            double n2 = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            // o CultureInfo, transforma a ,(vírgula) em .(ponto)

            string[] s = Console.ReadLine().Split(' ');
            string nome = s[0];
            char sexo = char.Parse(s[1]);
            int idade = int.Parse(s[2]);
            double altura = double.Parse(s[3], CultureInfo.InvariantCulture);


            Console.WriteLine("Você digitou: ");
            Console.WriteLine(n1);
            Console.WriteLine(ch);
            Console.WriteLine(n2);
            Console.WriteLine(nome);
            Console.WriteLine(sexo);
            Console.WriteLine(idade);
            Console.WriteLine(altura.ToString("F2", CultureInfo.InvariantCulture));




        }
    }
}