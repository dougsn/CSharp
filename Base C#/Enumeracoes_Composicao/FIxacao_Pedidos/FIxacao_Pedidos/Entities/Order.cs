using Fixacao_Pedidos.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fixacao_Pedidos.Entities {
    internal class Order {

        public DateTime Moment { get; set; }
        public OrderStatus status { get; set; }
        public List<OrderItem> items { get; set; } = new List<OrderItem>();
        public Client client { get; set; }

        public Order() { }

      

        public Order(OrderStatus status, Client client) {
            Moment = DateTime.Now;
            this.status = status;
            this.client = client;
        }

        public void addItem(OrderItem item) {            
            items.Add(item); 
        }

        public void removeItem(OrderItem item) {
            items.Remove(item);
        }

        public double total() {
            double total = 0;
            foreach (var item in items) {
                total += item.subTotal();
            }
            return total;
        }

        public override string ToString() {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Order moment: " + Moment);
            sb.AppendLine("Order status: " + status);
            foreach (var c in items) {

            }
            sb.AppendLine("Client: " + client);
            return sb.ToString();

        }


    }
}
