using Microsoft.AspNetCore.Mvc;
using BackEnd.Model;
using BackEnd.Services.Interfaces;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClaseController : ControllerBase
    {

        private IClaseService _claseService;

        public ClaseController(IClaseService claseService)
        {
            _claseService = claseService;
        }



        // GET: api/<ClaseController>
        [HttpGet]
        public IEnumerable<ClaseModel> Get()
        {
            return _claseService.Get();
        }


        // GET api/<ClaseController>/5
        [HttpGet("{id}")]
        public ClaseModel Get(int id)
        {
            return _claseService.Get(id);

        }


        // POST api/<TareaController>
        [HttpPost]
        public ClaseModel Post([FromBody] ClaseModel clase)
        {
            _claseService.Add(clase);
            return clase;

        }

        // PUT api/<ClaseController>/5
        [HttpPut("{id}")]
        public ClaseModel Put(int id, [FromBody] ClaseModel clase)
        {
            _claseService.Update(clase);
            return clase;

        }

        // DELETE api/<ClaseController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

            ClaseModel clase = new ClaseModel
            {
                ConsecutivoClase = id
            };

            _claseService.Remove(clase);
        }
    }
}
