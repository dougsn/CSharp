

using Comparison_Lambda.Entities;

namespace Comparison_Lambda {
    class Program {
        static void Main(string[] args) {

            List<Products> list = new List<Products>();

            list.Add(new Products("TV", 900.00));
            list.Add(new Products("Notebook", 1200.00));
            list.Add(new Products("Tablet", 450.00));

            // A expressão lambda, é um função anonima que é auto executada.
            // Neste caso, está ocorrendo a ordenação da lista pelo nome em maiusculo.

            list.Sort((p1, p2) => p1.Name.ToUpper().CompareTo(p2.Name.ToUpper()));

            foreach (Products p in list) {
                Console.WriteLine(p); // após a ordenação da lista de produtos, é impresso no console.
            }
        }
    }
}