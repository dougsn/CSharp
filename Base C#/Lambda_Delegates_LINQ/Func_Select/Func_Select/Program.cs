using Func_Select.Entities;
using System.Linq;

internal class Program {
    private static void Main(string[] args) {

        List<Product> list = new List<Product>();
        list.Add(new Product("Tv", 900.00));
        list.Add(new Product("Mouse", 50.00));
        list.Add(new Product("Tablet", 350.50));
        list.Add(new Product("HD Case", 80.90));

        

        /*List<string> result = list.Select(p => p.Name.ToUpper()).ToList();*/

        // O método Select, é do tipo Func<>, que espera uma função que retorne uma string. Como vimos, nesse caso está retornando os nomes
        // da lista em caixa alta. É necessário no final, "converter" para lista com .ToList();
        List<string> result = list.Select(NameUpper).ToList();
        foreach (string s in result) {
            Console.WriteLine(s);

        }


    }

    static string NameUpper(Product p) {
        return p.Name.ToUpper();
    }


}