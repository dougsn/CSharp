

namespace Directory_Arquivos {
    class Program {
        static void Main(string[] args) {

            string path = @"C:\Users\dnascimento\estudoC#\myFolder";

            try {

                // Criando uma lista, que recebe todos os diretorios que estão no caminho do path
                var folders = Directory.EnumerateDirectories(path,"*.*", SearchOption.AllDirectories);
                Console.WriteLine("FOLDERS:");
                foreach (string s in folders) {
                    Console.WriteLine(s); // Percorrendo a lista e amostrando no Console.
                }


                // Criando uma lista que pega todos os arquivos que se encontra no path especificado
                var files = Directory.EnumerateFiles(path, "*", SearchOption.AllDirectories);
                Console.WriteLine("FILES");
                foreach (string s in files) {
                    Console.WriteLine(s); // Percorrendo a lista dos arquivos e amostrando no Console.
                }

                Directory.CreateDirectory(path + @"\newFolder");

            } catch(IOException e) {
                Console.WriteLine("An error ocurred");
                Console.WriteLine(e.Message);
            }

        }
    }
}