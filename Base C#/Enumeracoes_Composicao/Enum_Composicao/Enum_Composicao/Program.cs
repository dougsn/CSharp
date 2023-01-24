
using Enum_Composicao.Entities;
using Enum_Composicao.Entities.Enums;
using System;

namespace Enum_Composicao {

    class Program {
        static void Main(string[] args) {

            Order order = new Order {
                Id = 1080,
                Moment = DateTime.Now,
                Status = OrderStatus.PedingPayment
            };

            Console.WriteLine(order);

            string txt = OrderStatus.PedingPayment.ToString(); // Convertendo de enum para string

            Console.WriteLine(txt);

            OrderStatus os = Enum.Parse<OrderStatus>("Delivered"); // Convertendo de string para enum 
            Console.WriteLine(os);

        }

    }

}