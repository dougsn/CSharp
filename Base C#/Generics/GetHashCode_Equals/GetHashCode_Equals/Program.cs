using GetHashCode_Equals.Entities;

internal class Program {
    private static void Main(string[] args) {


        Client a = new Client { Name = "Maria", Email = "maria@gmail.com" };
        Client b = new Client { Name = "Alex", Email = "alex@gmail.com" };

        Console.WriteLine(a.Equals(b)); // Nesse tipo de comparação, é realizado a comparação pelo conteúdo
        Console.WriteLine(a == b); // A comparação assim, compara o endereço da memória e não o conteúdo em si
        Console.WriteLine(a.GetHashCode());
        Console.WriteLine(b.GetHashCode());


    }
}