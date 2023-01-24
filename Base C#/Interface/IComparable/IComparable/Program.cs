internal class Program {
    private static void Main(string[] args) {
        string path = @"C:\Users\dnascimento\estudoC#\Interface\in.txt";
        try {
            using (StreamReader sr = File.OpenText(path)) { // Lendo o arquivo que foi passado no arquvio
                List<string> list = new List<string>();
                while (!sr.EndOfStream) {
                    list.Add(sr.ReadLine());
                }
                list.Sort(); // Ordenando o array
                foreach (string str in list) { // Lendo os nomes do array ordenado.
                    Console.WriteLine(str);
                }
            }
        } catch (IOException e) {
            Console.WriteLine("An error occurred");
            Console.WriteLine(e.Message);
        }
    }
}