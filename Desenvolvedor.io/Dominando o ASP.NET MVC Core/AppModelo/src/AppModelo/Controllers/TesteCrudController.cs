using AppModelo.Data;
using AppModelo.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppModelo.Controllers
{
    public class TesteCrudController : Controller
    {

        private readonly MeuDbContext _contexto; // Configurando o EntityFramework 

        public TesteCrudController(MeuDbContext contexto)
        {
            _contexto = contexto;
        }

        public IActionResult Index()
        {
            var aluno = new Aluno // Instanciando um novo aluno com dados estaticos.
            {
                Name = "Eduardo",
                DataNascimento = DateTime.Now,
                Email ="eduardo@eduardopires.net.br"
            };

            _contexto.Alunos.Add(aluno); // Adicionando o aluno
            _contexto.SaveChanges(); // Salvando o aluno na base de dados.

            var aluno2 = _contexto.Alunos.Find(aluno.Id); // Pegando o aluno pela chave primaria

            var aluno3 = _contexto.Alunos.FirstOrDefault(a => a.Email == "eduardo@eduardopires.net.br"); // buscando o primeiro aluno que tem esse e-mail.

            var aluno4 = _contexto.Alunos.Where(a => a.Name == "Eduardo"); // Pegando todos os alunos que tem o nome Eduardo

            aluno.Name = "João"; // Mudando nome para depois atualizar

            _contexto.Alunos.Update(aluno); // Atualizando aluno
            _contexto.SaveChanges();

            _contexto.Alunos.Remove(aluno); // Removendo aluno
            _contexto.SaveChanges();

            return View("_Layout");
        }
    }
}
