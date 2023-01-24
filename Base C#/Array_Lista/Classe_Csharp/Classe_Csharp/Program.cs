

using Classe_Csharp;
using System.Globalization;

class Program {

    static void Main(string[] args) {

        /*        Triangulo x, y;

                x = new Triangulo();
                y = new Triangulo();

                Console.WriteLine("Entre com as medidas do triângulo X: ");
                x.A = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                x.B = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                x.C = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Console.WriteLine("Entre com as medidas do triângulo Y: ");
                y.A = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                y.B = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                y.C = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                double areaX = x.Area();

                double areaY = y.Area();


                Console.WriteLine("Área de X = " + areaX.ToString("F4", CultureInfo.InvariantCulture));
                Console.WriteLine("Área de Y = " + areaY.ToString("F4", CultureInfo.InvariantCulture));

                if (areaX > areaY) {
                    Console.WriteLine("Maior área: X");
                } else {
                    Console.WriteLine("Maior área: Y");
                }*/

        Produto p = new Produto();

        Console.WriteLine("Entre os dados do produto: ");
        Console.Write("Nome: ");
        p.Nome = Console.ReadLine();
        Console.Write("Preço: ");
        p.Preco = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        Console.Write("Quantidade no estoque: ");
        p.Quantidade = int.Parse(Console.ReadLine());

        Console.WriteLine();
        Console.WriteLine("Dados do produto: " + p);
        Console.WriteLine();

        Console.Write("Digite o número de produtos a ser adicionado ao estoque: ");
        int qte = int.Parse(Console.ReadLine());
        p.AdicionarProdutos(qte);

        Console.WriteLine("Dados atualizados: " + p);


        Console.Write("Digite o número de produtos a ser removido do estoque: ");

        qte = int.Parse(Console.ReadLine());
        p.RemoverProdutos(qte);
        Console.WriteLine("Dados atualizados: " + p);

    }
}
