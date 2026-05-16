using ApiGestionCursos.Models; // Asegúrate de importar tu modelo Curso
using ApiGestionCursos.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace ApiGestionCursos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // Si usas versionamiento por query string como vimos en Swagger, 
    // el decorador [ApiVersion("1.0")] iría aquí si estuviera configurado globalmente.
    public class CursosController : ControllerBase
    {
        private readonly ICursoService _cursoService;

        public CursosController(ICursoService cursoService)
        {
            _cursoService = cursoService;
        }

        // GET: api/Cursos
        [HttpGet]
        public IActionResult GetCursos()
        {
            var cursos = _cursoService.GetCursos();
            return Ok(cursos);
        }

        // GET: api/Cursos/5
        [HttpGet("{id}")]
        public IActionResult GetCurso(int id)
        {
            var curso = _cursoService.GetCurso(id);
            if (curso == null)
            {
                return NotFound(new { message = $"Curso con ID {id} no encontrado." });
            }
            return Ok(curso);
        }

        // POST: api/Cursos
        [HttpPost]
        public IActionResult PostCurso([FromBody] Curso curso)
        {
            if (curso == null) return BadRequest();

            _cursoService.CreateCurso(curso);

            // Retorna un 201 Created y la ubicación del nuevo recurso
            return CreatedAtAction(nameof(GetCurso), new { id = curso.CursoId }, curso);
        }

        // PUT: api/Cursos/5
        [HttpPut("{id}")]
        public IActionResult PutCurso(int id, [FromBody] Curso curso)
        {
            if (curso == null || id != curso.CursoId)
            {
                return BadRequest(new { message = "El ID del curso no coincide." });
            }

            var existe = _cursoService.GetCurso(id);
            if (existe == null) return NotFound();

            _cursoService.UpdateCurso(curso);
            return NoContent(); // 204 No Content es estándar para PUT exitoso
        }

        // DELETE: api/Cursos/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCurso(int id)
        {
            var curso = _cursoService.GetCurso(id);
            if (curso == null) return NotFound();

            _cursoService.DeleteCurso(id);
            return Ok(new { message = "Curso eliminado correctamente." });
        }
    }
}