using Microsoft.AspNetCore.Mvc;
using BackEnd.Model;
using BackEnd.Services.Interfaces;
using BackEnd.Services.Implementations;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotaController : ControllerBase
    {

        private INotaService _notaService;

        public NotaController(INotaService notaService)
        {
            _notaService = notaService;
        }



        // GET: api/<NotaController>
        [HttpGet]
        public IEnumerable<NotaModel> Get()
        {
            return _notaService.Get();
        }


        // GET api/<NotaController>/5
        [HttpGet("{id}")]
        public NotaModel Get(int id)
        {
            return _notaService.Get(id);

        }


        // POST api/<NotaController>
        [HttpPost]
        public NotaModel Post([FromBody] NotaModel nota)
        {
            _notaService.Add(nota);
            return nota;

        }

        // PUT api/<NotaController>/5
        [HttpPut]
        public NotaModel Put([FromBody] NotaModel nota)
        {
            _notaService.Update(nota);
            return nota;

        }

        // DELETE api/<NotaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

            NotaModel nota = new NotaModel
            {
                IdNota = id
            };

            _notaService.Remove(nota);
        }
    }
}
