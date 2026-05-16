using ApiGestionCursos.Models;
using ApiGestionCursos.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace ApiGestionCursos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudiantesController : ControllerBase
    {
        private readonly IEstudianteService _estudianteService;

        public EstudiantesController(IEstudianteService estudianteService)
        {
            _estudianteService = estudianteService;
        }

        [HttpGet]
        public IActionResult GetEstudiantes()
        {
            return Ok(_estudianteService.GetEstudiantes());
        }

        [HttpGet("{id}")]
        public IActionResult GetEstudiante(int id)
        {
            var estudiante = _estudianteService.GetEstudiante(id);
            if (estudiante == null) return NotFound();
            return Ok(estudiante);
        }

        [HttpPost]
        public IActionResult PostEstudiante([FromBody] Estudiante estudiante)
        {
            if (estudiante == null) return BadRequest();
            if (!_estudianteService.CreateEstudiante(estudiante)) return StatusCode(500);

            return CreatedAtAction(nameof(GetEstudiante), new { id = estudiante.EstudianteId }, estudiante);
        }

        [HttpPut("{id}")]
        public IActionResult PutEstudiante(int id, [FromBody] Estudiante estudiante)
        {
            if (estudiante == null || id != estudiante.EstudianteId) return BadRequest();

            var existe = _estudianteService.GetEstudiante(id);
            if (existe == null) return NotFound();

            if (!_estudianteService.UpdateEstudiante(estudiante)) return StatusCode(500);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEstudiante(int id)
        {
            var estudiante = _estudianteService.GetEstudiante(id);
            if (estudiante == null) return NotFound();

            if (!_estudianteService.DeleteEstudiante(estudiante)) return StatusCode(500);

            return Ok(new { message = "Estudiante eliminado correctamente." });
        }
    }
}