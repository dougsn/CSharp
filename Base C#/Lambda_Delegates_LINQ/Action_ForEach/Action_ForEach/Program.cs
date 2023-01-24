using Action_ForEach.Entities;

internal class Program {
    private static void Main(string[] args) {
        List<Products> list = new List<Products>();
        list.Add(new Products("Tv", 900.00));
        list.Add(new Products("Mouse", 50.00));
        list.Add(new Products("Tablet", 350.50));
        list.Add(new Products("HD Case", 80.90));

        // Funciona da mesma forma, só muda a forma que se cria a lógica.
        // list.ForEach(p => {p.Price += p.Price * 0.1; });

        // O ForEach recebe uma função void, que receba um parâmetro do tipo Produto.
        // O ForEach percorre toda a lista e implementa a lógica especificada no método utilizado ou no Lambda utilizado.
        list.ForEach(UpdatePrice);
        foreach (Products p in list) {
            Console.WriteLine(p.Name + " " + p.Price) ;

        }
        

    }
    
    static void UpdatePrice(Products p) {
        p.Price += p.Price * 0.1;
    }

}