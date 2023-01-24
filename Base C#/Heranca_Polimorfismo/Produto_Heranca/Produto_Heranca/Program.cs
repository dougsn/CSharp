
using Produto_Heranca.Entities;
using System.Globalization;

namespace Produto_Heranca {
    class Program {
        static void Main(string[] args) {

            List<Product> list = new List<Product>();

            Console.Write("Enter the number os products: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++) {

                Console.WriteLine($"Product #{i} data:");
                
                Console.Write("Common, used or imported (c/u/i)? ");
                char response = char.Parse(Console.ReadLine());

                Console.Write("Name: ");
                string name = Console.ReadLine();

                Console.Write("Price: ");
                double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                

                if (response == 'c') {
                    Product product = new Product(name, price);
                    list.Add(product);

                } else if (response == 'i') {
                    Console.Write("Custom fee: ");
                    double customFee = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                    ImportedProduct imported = new ImportedProduct(name, price, customFee);

                    list.Add(imported);


                } else if (response == 'u') {
                    Console.Write("Manufacture date (DD/MM/YYYY): ");
                    DateTime date = DateTime.Parse(Console.ReadLine());

                    UsedProduct used = new UsedProduct(name, price, date);

                    list.Add(used);
                }

            }
            Console.WriteLine();
            Console.WriteLine("PRICE TAGS:");

            foreach (Product p in list) {
                Console.WriteLine(p.PriceTag());
            }

        

        }
    }
}