using Comparacao_HashSet.Entities;

internal class Program {
    private static void Main(string[] args) {
        
        // A coleção HashSet guardar "aleatoriamente" as informações, por meio de um código hash gerado por ele.
        // Para realizarmos a comparação e igualdade de uma coleção HashSet, é necessário que a classe tenha os métodos GetHashCode e Equals.

        HashSet<Product> a = new HashSet<Product>();
        a.Add(new Product("TV", 900.0));
        a.Add(new Product("Notebook", 1200.0));

        HashSet<Point> b = new HashSet<Point>();
        b.Add(new Point(3, 4));
        b.Add(new Point(5, 10));

        Product prod = new Product("Notebook", 1200.0);
        Console.WriteLine(a.Contains(prod)); // Verificando se a coleção a, possui o conteudo da prod.

        Point point = new Point(5, 10);
        Console.WriteLine(b.Contains(point)); // Verificando se a coleção b possui o conteudo do point.

    }

    // OBSSS

    // Se o objeto for struct, não é necessário implementar o GetHashCode ou Equals, para realizar a comparação por conteúdo.


}