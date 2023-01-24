internal class Program {
    private static void Main(string[] args) {
         
        // O SortedSet já cria uma colecction ordenada, independendo da ordem de inserção dos dados na coleção.

        SortedSet<int> a = new SortedSet<int>() { 0, 2, 4, 5, 6, 8, 10 };
        SortedSet<int> b = new SortedSet<int>() { 5, 6, 7, 8, 9, 10 };

        // União de coleções, neste caso, pegou as informações da coleçao A e colocou na coleção C
        SortedSet<int> c = new SortedSet<int>(a);
        c.UnionWith(b); // Realizando a união entre a coleção C com a B

        PrintCollection(c);

        //
        SortedSet<int> d = new SortedSet<int>(a);
        d.IntersectWith(b); // Realizando a intersecção das 2 coleções, são os elementos que existem nos 2 conjuntos.
        PrintCollection(d);

        //
        SortedSet<int> e = new SortedSet<int>(a);
        e.ExceptWith(b); // São os elementos de A, excluidos aqueles elemento de B.
        PrintCollection(e);


    }

    // Foi utilizado o IEnumerable, pois ele é implementado em todas as coleções.
    static void PrintCollection<T>(IEnumerable<T> collection) { // Realizando a leitura das coleções e imprimindo na tela.
        foreach (T obj in collection) {
            Console.Write(obj + " ");
        }
        Console.WriteLine();
    }

}