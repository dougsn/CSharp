using Exercicio_Composicao.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio_Composicao.Entities {
    internal class Worker {
        public string Name{ get; set; }
        public WorkerLevel Level { get; set; }
        public double BaseSalary { get; set; }
        public Department Department{ get; set; }
        public List<HourContract> Contracts { get; set; } = new List<HourContract>(); // Associando os contrator ao trabalhor


        public Worker() { }
        public Worker(string name, WorkerLevel level, double baseSalary, Department department) {
            Name = name;
            Level = level;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void addContract(HourContract contract) { // Adicionando um contrato ao trabalhador
            Contracts.Add(contract);
        }

        public void removeContract(HourContract contract) { // Removendo um contrato
            Contracts.Remove(contract);
        }


        public double Income(int year, int month) {

            double sum = BaseSalary;

            foreach (var item in Contracts) {
                // Percorrendo a lista de contratos, comparando o ano e o mês e se for igual, somar o valor do contrato.
                if(item.Date.Year == year && item.Date.Month == month) {
                    sum += item.TotalValue();
                }
            }

            return sum;

        }


    }
}
