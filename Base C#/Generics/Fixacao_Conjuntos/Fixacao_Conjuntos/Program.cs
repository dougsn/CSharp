using Fixacao_Conjuntos.Entities;
using System.IO;

internal class Program {
    private static void Main(string[] args) {

        HashSet<LogRecord> set = new HashSet<LogRecord>();

        Console.Write("Enter file full path: ");
        string path = Console.ReadLine();

        try {
            using (StreamReader sr = File.OpenText(path)) {
                while (!sr.EndOfStream) {
                    string[] line = sr.ReadLine().Split(' ');
                    string name = line[0];
                    DateTime instant = DateTime.Parse(line[1]);
                    set.Add(new LogRecord { Username = name, Instant = instant }); // adicionando os logs na coleção
                }
                Console.WriteLine("Total users: " + set.Count); // Pegando o total de usuarios da coleção
            }
        } catch (IOException e) {
            Console.WriteLine(e.Message);
        }
    }
}