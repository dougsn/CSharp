
namespace Path_Arquivos {

    class Program {
        static void Main(string[] args) {

            string path = @"c:\temp\myfolder\file1.txt";
            Console.WriteLine("DirectorySeparatorChar: " + Path.DirectorySeparatorChar); // Pega o sepador dos diretórios
            Console.WriteLine("PathSeparator: " + Path.PathSeparator); 
            Console.WriteLine("GetDirectoryName: " + Path.GetDirectoryName(path)); // Pega o nome do diretório
            Console.WriteLine("GetFileName: " + Path.GetFileName(path)); // Pega o nome do arquivo
            Console.WriteLine("GetExtension: " + Path.GetExtension(path)); // Pega a extensão do arquivo
            Console.WriteLine("GetFileNameWithoutExtension: " + Path.GetFileNameWithoutExtension(path)); // Pega o nome do arquivo sem extensão
            Console.WriteLine("GetFullPath: " + Path.GetFullPath(path)); // Pega o caminho inteiro do arquivo
            Console.WriteLine("GetTempPath: " + Path.GetTempPath()); // Pega o caminho da pasta temporaria do sistema que se esta usando

        }
    }

}