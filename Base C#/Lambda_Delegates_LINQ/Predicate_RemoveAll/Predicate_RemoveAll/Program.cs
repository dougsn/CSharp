using Predicate_RemoveAll.Entities;

internal class Program {
    private static void Main(string[] args) {


        List<Product> list = new List<Product>();
        list.Add(new Product("Tv", 900.00));
        list.Add(new Product("Mouse", 50.00));
        list.Add(new Product("Tablet", 350.50));
        list.Add(new Product("HD Case", 80.90));

        // Poderiamos utilizar dessa forma, pois o RemoveAll espera um Predicate, um predicate solicita uma função anonima (auto executavel).
        // list.RemoveAll(p => p.Price >= 100.00);

        list.RemoveAll(ProductTest);

        foreach (Product p in list) {
            Console.WriteLine(p.Name + " " + p.Price);

        }

    }

    public static bool ProductTest(Product p) {
        return p.Price >= 100;
    }

}