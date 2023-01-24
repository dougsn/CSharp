
using Exercicio_Composicao.Entities;
using Exercicio_Composicao.Entities.Enums;
using System.Globalization;

namespace Exercicio_Composicao {

    class Program {
        static void Main(string[] args) {
            Console.Write("Enter department's name: ");
            
            string dptname = Console.ReadLine();
            Console.WriteLine("Enter worker data: ");
            
            Console.Write("Name: ");
            string name = Console.ReadLine();
            
            Console.Write("Level (Junior/MidLevel/Senior): ");
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine()); // convertendo a entrada de dados em string para Enum

            Console.Write("Base salary: ");
            double salary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Department dept = new Department(dptname);
            Worker worker = new Worker(name, level, salary, dept);


            Console.Write("How many contracts to this worker? ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++) {

                Console.WriteLine($"Enter #{i} contract data: ");
                
                Console.Write("Date (DD / MM / YYYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());

                Console.Write("Value per hour: ");
                double value = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Console.Write("Duration (hours): ");
                int duration = int.Parse(Console.ReadLine());

                HourContract contracts = new HourContract(date, value, duration);

                worker.addContract(contracts);
            }

            Console.WriteLine("");

            Console.Write("Enter month and year to calculate income (MM/YYYY): ");
            string monthAndYear = Console.ReadLine();

            int month = int.Parse(monthAndYear.Substring(0, 2));
            int year = int.Parse(monthAndYear.Substring(3));

            Console.WriteLine("Name: " + worker.Name);
            Console.WriteLine("Department: " + worker.Department.Name);
            Console.WriteLine("Income for " + monthAndYear + worker.Income(year,month));




        }

    }
}