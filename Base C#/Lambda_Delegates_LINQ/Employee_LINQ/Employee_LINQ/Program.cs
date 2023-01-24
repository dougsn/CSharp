using Employee_LINQ.Entities;
using System.Collections.Generic;
using System.Globalization;
using System.Net;

internal class Program {
    private static void Main(string[] args) {

        Console.Write("Entre com o caminho do arquivo: ");
        string path = Console.ReadLine();

        Console.Write("Digite o valor: ");
        double value = double.Parse(Console.ReadLine());

        List<Employee> list = new List<Employee>();


        using (StreamReader sr = File.OpenText(path)) {
            while (!sr.EndOfStream) {
                string[] employee = sr.ReadLine().Split(',');
                string name = employee[0];
                string email = employee[1];
                double salary = double.Parse(employee[2], CultureInfo.InvariantCulture);

                list.Add(new Employee(name, email, salary));
            }
        }


        var emails = list.Where(obj => obj.Salary > value).OrderBy(obj => obj.Email).Select(obj => obj.Email);
        var sum = list.Where(obj => obj.Name[0] == 'M').Sum(obj => obj.Salary);


        Console.WriteLine("Email of people whose salary is more than " + value.ToString("F2", CultureInfo.InvariantCulture));
        foreach (string email in emails) {
            Console.WriteLine(email);
        }

        Console.WriteLine("Sum of salary of people whose name starts with 'M': " + sum.ToString("F2", CultureInfo.InvariantCulture));

    }
}