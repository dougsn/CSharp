using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProAtividade.API.Data;
using ProAtividade.API.Models;

namespace ProAtividade.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AtividadeController : ControllerBase
    {
        private readonly DataContext _contexto;

        public AtividadeController(DataContext contexto)
        {
            _contexto = contexto;

        }

        [HttpGet]
        public IEnumerable<Atividade> Get()
        {
            return _contexto.Atividades;
        }

        [HttpGet("{id}")]
        public Atividade Get(int id)
        {
            return _contexto.Atividades.FirstOrDefault(ativ => ativ.Id == id);
        }

        [HttpPost]
        public Atividade Post(Atividade atividade)
        {
            _contexto.Atividades.Add(atividade);
            if (_contexto.SaveChanges() > 0)
                return _contexto.Atividades.FirstOrDefault(ativ => ativ.Id == atividade.Id);
            else
                throw new Exception("Você não conseguiu adicionar uma atividade");

        }

        [HttpPut("{id}")]
        public Atividade Put(int id, Atividade atividade)
        {
            if (atividade.Id != id) throw new Exception("Você está tentando atualizar a atividade errada.");

            _contexto.Update(atividade);
            if (_contexto.SaveChanges() > 0)
                return _contexto.Atividades.FirstOrDefault(ativ => ativ.Id == id);
            else
                return new Atividade();
        }

        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            var atividade = _contexto.Atividades.FirstOrDefault(ativ => ativ.Id == id);

            if (atividade == null)
                throw new Exception("Você está tentando deletar uma atividade que não existe");

            _contexto.Remove(atividade);

            return _contexto.SaveChanges() > 0;
        }
    }
}
