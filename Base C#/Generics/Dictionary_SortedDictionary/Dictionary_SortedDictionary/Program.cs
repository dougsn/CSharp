internal class Program {
    private static void Main(string[] args) {
        
        // O Dictionary é igual ao MAP, para salvar algo na lista, precisa de uma CHAVE, que é a key, e o tipo de informação, fica no <>.
        // Não salva informações iguais, ele sobreescreve se for da mesma chave.
        
        Dictionary<string, string> cookies = new Dictionary<string, string>();

        cookies["user"] = "maria";
        cookies["email"] = "maria@gmail.com";
        cookies["phone"] = "99771122";
        cookies["phone"] = "99771133";

        Console.WriteLine(cookies["email"]);
        cookies.Remove("email");
        Console.WriteLine("Phone number: " + cookies["phone"]);

        if (cookies.ContainsKey("email")) { // Verificando se possui a chave do email, se tiver, retornar no console.
            Console.WriteLine("Email: " + cookies["email"]); 
        } else {
            Console.WriteLine("There is not 'email' key");
        }
        Console.WriteLine("Size: " + cookies.Count);
        Console.WriteLine("ALL COOKIES:");
        // O KeyValuePair, é utilizado para fazer o looping com o Dictionary. Poderia ser utilizado o VAR tbm.
        foreach (KeyValuePair<string, string> item in cookies) {
            Console.WriteLine(item.Key + ": " + item.Value);
        }

    }
}