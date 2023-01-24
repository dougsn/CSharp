internal class Program {
    private static void Main(string[] args) {


        // Especificando a fonte de dados
        int[] numbers = new int[] { 2, 3, 4, 5 };

        // Definindo a expressão query
        // Utilizando o Where para pegar os numeros pares e depois utilizando o Select para pegar o resultado do Where e * 10.
        IEnumerable<int> result = numbers.Where(n => n % 2 == 0).Select(x => x * 10);

        // Executar a consulta
        foreach (int x in result) {
            Console.WriteLine(x);
        }

    }
}