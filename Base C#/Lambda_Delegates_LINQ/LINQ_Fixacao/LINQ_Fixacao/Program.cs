using LINQ_Fixacao.Entities;
using System.Globalization;
using System.Linq;

internal class Program {
    private static void Main(string[] args) {

        Console.Write("Entre com o caminho do arquivo: ");
        string path = Console.ReadLine();


        List<Product> list = new List<Product>();

        using(StreamReader sr = File.OpenText(path)) { // Lendo o arquivo que está no caminho que será passado pelo usuario

            while (!sr.EndOfStream) { // Lendo até o final do arquivo
                string[] fields = sr.ReadLine().Split(','); // Criando uma lista, para guardar o arquivo por partes separadas por vírgula.
                string name = fields[0]; // Atrelando a variavel name a primeira posição da lista
                double price = double.Parse(fields[1], CultureInfo.InvariantCulture); // Atrelando no price, a segunda posição da lista.

                list.Add(new Product(name, price)); // Adicionando um novo objeto de produto, com base na lista criada.
            }
        }

        var avg = list.Select(p => p.Price).DefaultIfEmpty(0.0).Average(); // Calculando a média dos produtos com o LINQ
        Console.WriteLine("Media dos preços = " + avg.ToString("F2", CultureInfo.InvariantCulture));

        // Filtrando os preços que estão abaixo da média, ordenando de forma decrescente pelo Nome e pegando apenas o nome do produto e não o objeto inteiro com Select().
        var names = list.Where(p => p.Price < avg).OrderByDescending(p => p.Name).Select(p => p.Name);
        foreach (string name in names) {
            Console.WriteLine(name);
        } 

    }
}