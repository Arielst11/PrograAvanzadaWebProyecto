using Microsoft.AspNetCore.Mvc;
using BackEnd.Model;
using BackEnd.Services.Interfaces;
using Entities.Entities;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsistenciasController : ControllerBase
    {

        private IAsistenciasService _asistenciasService;

        public AsistenciasController(IAsistenciasService asistenciasService)
        {
            _asistenciasService = asistenciasService;
        }



        // GET: api/<AsistenciasController>
        [HttpGet]
        public IEnumerable<AsistenciasModel> Get()
        {
            return _asistenciasService.Get();
        }


        // GET api/<AsistenciasController>/5
        [HttpGet("{id}")]
        public AsistenciasModel Get(int id)
        {
            return _asistenciasService.Get(id);

        }


        // POST api/<AsistenciasController>
        [HttpPost]
        public AsistenciasModel Post([FromBody] AsistenciasModel asistencias)
        {
            _asistenciasService.Add(asistencias);
            return asistencias;

        }

        // PUT api/<AsistenciasController>/5
        [HttpPut("{id}")]
        public AsistenciasModel Put(int id, [FromBody] AsistenciasModel asistencias)
        {
            _asistenciasService.Update(asistencias);
            return asistencias;

        }

        // DELETE api/<AsistenciasController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

            AsistenciasModel asistencias = new AsistenciasModel
            {
                ConsecutivoAsistencia = id
            };

            _asistenciasService.Remove(asistencias);
        }
    }
}
