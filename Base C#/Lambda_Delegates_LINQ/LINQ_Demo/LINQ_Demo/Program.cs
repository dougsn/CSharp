


using LINQ_Demo.Entities;

namespace LINQ_Demo {
    internal class Program {

        // Método criado para poder percorrer a lista e amostrar. Para não precisar ficar repetindo o foreach para amostrar o resultado da LINQ
        static void Print<T>( string msg, IEnumerable<T> collection) {
            Console.WriteLine(msg);
            foreach (T obj in collection) {
                Console.WriteLine(obj);
            }
            Console.WriteLine();
        }

        private static void Main(string[] args) {


            Category c1 = new Category(1, "Tools", 2);
            Category c2 = new Category(2, "Computers", 1);
            Category c3 = new Category(3, "Electronics", 1);


            List<Product> products = new List<Product>() {
                new Product() { Id = 1, Name = "Computer", Price = 1100.0, Category = c2 },
                new Product() { Id = 2, Name = "Hammer", Price = 90.0, Category = c1 },
                new Product() { Id = 3, Name = "TV", Price = 1700.0, Category = c3 },
                new Product() { Id = 4, Name = "Notebook", Price = 1300.0, Category = c2 },
                new Product() { Id = 5, Name = "Saw", Price = 80.0, Category = c1 },
                new Product() { Id = 6, Name = "Tablet", Price = 700.0, Category = c2 },
                new Product() { Id = 7, Name = "Camera", Price = 700.0, Category = c3 },
                new Product() { Id = 8, Name = "Printer", Price = 350.0, Category = c3 },
                new Product() { Id = 9, Name = "MacBook", Price = 1800.0, Category = c2 },
                new Product() { Id = 10, Name = "Sound Bar", Price = 700.0, Category = c3 },
                new Product() { Id = 11, Name = "Level", Price = 70.0, Category = c1 }
            };

            var r1 = products.Where(x => x.Category.Tier == 1 && x.Price < 900);
            Print("TIER 1 E PRICE < 900:", r1);

            var r2 = products.Where(x => x.Category.Name == "Tools").Select(x => x.Name);
            Print("PRODUTOS COM O NOME TOOLS", r2);

            var r3 = products.Where(p => p.Name[0] == 'C').Select(p => new { p.Name, p.Price, CategoryName = p.Category.Name });
            Print("NAMES STARTED WITH 'C' AND ANONYMOUS OBJECT", r3);

            var r4 = products.Where(p => p.Category.Tier == 1).OrderBy(p => p.Price).ThenBy(p => p.Name);
            Print("TIER 1 ORDER BY PRICE THEN BY NAME", r4); // Ordenando por preço, se empatar, ordena por nome

            var r5 = r4.Skip(2).Take(4); // Pula os 2 primeiros, e pega os 4 elementos.
            Print("TIER 1 ORDER BY PRICE THEN BY NAME SKIP 2 TAKE 4", r5);

            var r6 = products.FirstOrDefault(); // Pega o primeiro elemento da fonte de dados.
            Console.WriteLine("First or default test1: " + r6);
            var r7 = products.Where(p => p.Price > 3000.0).FirstOrDefault(); // Como não encontrou ninguem, retorna nulo.
            Console.WriteLine("First or default test2: " + r7);
            Console.WriteLine();

            var r8 = products.Where(p => p.Id == 3).SingleOrDefault(); // É utilizado para buscar algo único na base de dados.
            Console.WriteLine("Single or default test1: " + r8);
            var r9 = products.Where(p => p.Id == 30).SingleOrDefault();  // Retorna o que foi solicitado, mas se n tiver, retorna nulo.
            Console.WriteLine("Single or default test2: " + r9);
            Console.WriteLine();

            var r10 = products.Max(p => p.Price); // Pega o máximo da coleção, com base na expressão Lambda.
            Console.WriteLine("Max price: " + r10);
            var r11 = products.Min(p => p.Price); // Pega o minimo da coleção, com base na expressão Lambda
            Console.WriteLine("Min price: " + r11);
            var r12 = products.Where(p => p.Category.Id == 1).Sum(p => p.Price); // Soma os produtos.
            Console.WriteLine("Category 1 Sum prices: " + r12);
            var r13 = products.Where(p => p.Category.Id == 1).Average(p => p.Price); // Pegando a média.
            Console.WriteLine("Category 1 Average prices: " + r13);
            var r14 = products.Where(p => p.Category.Id == 5).Select(p => p.Price).DefaultIfEmpty(0.0).Average(); // Protegendo o calculo da média, para não ter calculo com nulo.
            Console.WriteLine("Category 5 Average prices: " + r14);
            var r15 = products.Where(p => p.Category.Id == 1).Select(p => p.Price).Aggregate(0.0, (x, y) => x + y); // O Aggregate é utilizado para personalizar alguma conta que não temos como padrão pelo LINQ.
            Console.WriteLine("Category 1 aggregate sum: " + r15);
            Console.WriteLine();

            var r16 = products.GroupBy(p => p.Category); // Vai agrupar os produtos, de acordo com a função Lambda.
        // Para ler, temos que utilizar o IGrouping, para conseguir pegar os 2 tipos que serão utilizados como chave.

            foreach (IGrouping<Category, Product> group in r16) { // O primeiro Loop é utilizado para ler a categoria
                Console.WriteLine("Category " + group.Key.Name + ":");
                foreach (Product p in group) { // O segundo Loop é utilizado para ler os produtos contidos naquela categoria.
                    Console.WriteLine(p);
                }
                Console.WriteLine();
            }
        }
    }
}