
namespace FileStream_StreamReader {
    class Program {
        static void Main(string[] args) {
            // O @ 'economiza' uma \ para navegar entre os diretórios
            string sourcePath = @"C:\Users\dnascimento\estudoC#\file1.txt"; // Salvado o caminho do arquivo txt
            string targetPath = @"C:\Users\dnascimento\estudoC#\file2.txt";
            
            try {

                // Utilizando o using, assim que o bloco de código de dentro acabar de ser realizado, as chamadas são finalizadas.


                using (StreamReader sr = File.OpenText(sourcePath)) { // Abrindo o arquivo que está no caminho do path

                    string[] lines = File.ReadAllLines(sourcePath); 

                    while (!sr.EndOfStream) {// Enquanto não chega no final do arquivo, eu leio a linha e mostro na tela.
                        string line = sr.ReadLine();
                        Console.WriteLine(line);
                    }

                    using (StreamWriter sw = File.AppendText(targetPath)) { // Criando o arquivo de escrita no caminho especificado no targetPath
                        foreach (string line in lines) {
                            sw.WriteLine(line.ToUpper()); // Escrevendo no caminho arquivo o que foi lido no vetor.

                        }
                    }
                }

                

            } catch (IOException e) {
                Console.WriteLine("An error ocorred");
                Console.WriteLine(e.Message);
            }
        }
    }
}
