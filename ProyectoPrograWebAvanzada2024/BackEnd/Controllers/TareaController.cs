using Microsoft.AspNetCore.Mvc;
using BackEnd.Model;
using BackEnd.Services.Interfaces;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareaController : ControllerBase
    {

        private ITareaService _tareaService;

        public TareaController(ITareaService tareaService)
        {
            _tareaService = tareaService;
        }



        // GET: api/<TareaController>
        [HttpGet]
        public IEnumerable<TareaModel> Get()
        {
            return _tareaService.Get();
        }


        // GET api/<TareaController>/5
        [HttpGet("{id}")]
        public TareaModel Get(int id)
        {
            return _tareaService.Get(id);

        }


        // POST api/<TareaController>
        [HttpPost]
        public TareaModel Post([FromBody] TareaModel tarea)
        {
            _tareaService.Add(tarea);
            return tarea;

        }

        // PUT api/<TareaController>/5
        [HttpPut("{id}")]
        public TareaModel Put(int id, [FromBody] TareaModel tarea)
        {
            _tareaService.Update(tarea);
            return tarea;

        }

        // DELETE api/<TareaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

            TareaModel tarea = new TareaModel
            {
                ConsecutivoTarea = id
            };

            _tareaService.Remove(tarea);
        }
    }
}
