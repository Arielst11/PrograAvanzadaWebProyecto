using Microsoft.AspNetCore.Mvc;
using BackEnd.Model;
using BackEnd.Services.Interfaces;
using Entities.Entities;
using BackEnd.Services.Implementations;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsistenciaController : ControllerBase
    {
        private IAsistenciaService _asistenciaService;

        public AsistenciaController(IAsistenciaService asistenciaService)
        {
            _asistenciaService = asistenciaService;
        }

        // GET: api/<AsistenciaController>
        //[Authorize(Roles = "Admin,Profesor")]
        [Authorize]
        [HttpGet]
        public IEnumerable<AsistenciaModel> Get()
        {
            return _asistenciaService.Get();
        }

        // GET api/<AsistenciaController>/5
        [HttpGet("{id}")]
        public AsistenciaModel Get(int id)
        {
            return _asistenciaService.Get(id);
        }

        // POST api/<AsistenciaController>
        [HttpPost]
        public AsistenciaModel Post([FromBody] AsistenciaModel asistencia)
        {
            _asistenciaService.Add(asistencia);
            return asistencia;
        }

        // PUT api/<AsistenciaController>/5
        [HttpPut]
        public AsistenciaModel Put([FromBody] AsistenciaModel asistencia)
        {
            _asistenciaService.Update(asistencia);
            return asistencia;
        }

        // DELETE api/<AsistenciaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            AsistenciaModel asistencia = new AsistenciaModel { IdAsistencia = id };
            _asistenciaService.Remove(asistencia);
        }
    }
}
