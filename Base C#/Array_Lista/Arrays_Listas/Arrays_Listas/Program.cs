
using Arrays_Listas;
using System.Globalization;

namespace Arrays_Lista {
    class Program {
        static void Main(string[] args) {
            /*
                        int n = int.Parse(Console.ReadLine());

                        Produto[] vect = new Produto[n];

                        for (int i = 0; i < n; i++) {
                            string name = Console.ReadLine();
                            double price = double.Parse(Console.ReadLine());
                            vect[i] = new Produto(name, price);

                        }

                        double sum = 0.0;

                        for (int i = 0; i < n; i++) {
                            sum += vect[i].Price;
                        }

                        double avg = sum / n;

                        Console.WriteLine("Preco médio = " + avg.ToString("F2", CultureInfo.InvariantCulture));
            */

            List<string> list = new List<string>();

            list.Add("Maria");
            list.Add("Alex");
            list.Add("Bob");
            list.Add("Anna");
            list.Insert(2, "Marco"); // Pega a posição e insere a string, não exclui a informação que estava anteriomente na posição 2, só "empurra" para a posição 3

            foreach (var item in list) {
                Console.WriteLine(item);
            }

            Console.WriteLine("Contagem da lista: " + list.Count); // Como se fosse o Length.

            string s1 = list.Find(x => x[0] == 'A'); // Busca o primeiro que tem a palavra A
            Console.WriteLine("Primeira 'A': " + s1);

            string s2 = list.FindLast(x => x[0] == 'A');
            Console.WriteLine("Último 'A': " + s2);

            int pos1 = list.FindIndex(x => x[0] == 'A'); // Retorna a posição na lista da informação que começa com 'A'
            Console.WriteLine("Primeira posição 'A': " + pos1);

            int pos2 = list.FindLastIndex(x => x[0] == 'A');
            Console.WriteLine("Última posição 'A': " + pos2);


            List<string> list2 = list.FindAll(x => x.Length == 5); // Gravando em outra lista, as posições que possuem mais de 5 strings
            Console.WriteLine("-------------------");
            foreach(string item in list2){
                Console.WriteLine(item);
            }

            list.Remove("Alex"); // Removendo um item
            Console.WriteLine("-------------------");
            foreach (string item in list) {
                Console.WriteLine(item);
            }

            list.RemoveAll(x => x[0] == 'M'); // Removendo um item que começa com 'M'
            Console.WriteLine("-------------------");
            foreach (string item in list) {
                Console.WriteLine(item);
            }



        }
    }
}