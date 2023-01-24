

using Fixacao_Pedidos.Entities;
using Fixacao_Pedidos.Entities.Enums;
using System.Globalization;

namespace Fixacao_Pedidos {
    class Program {
        static void Main(string[] args) {

            Console.WriteLine("Enter cliente data:");
            
            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Email: ");
            string email = Console.ReadLine();

            Console.Write("Birth date (DD/MM/YYYY): ");
            DateTime birthDate = DateTime.Parse(Console.ReadLine());

            Client c1 = new Client(name, email, birthDate);

            Console.WriteLine("Enter order data: ");
            Console.Write("Status: ");
            OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine()); // Convertendo a string para enum

            Order order = new Order(status, c1);

            Console.Write("How many items to this order? ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++) {

                Console.WriteLine($"Enter {i} item data:");
                
                Console.Write("Product name: ");
                string productName = Console.ReadLine();

                Console.Write("Product price: ");
                double productPrice = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Console.Write("Quantity: ");
                int quantity = int.Parse(Console.ReadLine());

                Product p1 = new Product(productName);

                OrderItem orderItem = new OrderItem(quantity, productPrice, p1);
                order.addItem(orderItem);
            }

            Console.WriteLine("ORDER SUMMARY:");

            Console.WriteLine(order);


        }
    }
}