using ApiGestionCursos.Models; 
using ApiGestionCursos.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace ApiGestionCursos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CursosController : ControllerBase
    {
        private readonly ICursoService _cursoService;

        public CursosController(ICursoService cursoService)
        {
            _cursoService = cursoService;
        }

        [HttpGet]
        public IActionResult GetCursos()
        {
            var cursos = _cursoService.GetCursos();
            return Ok(cursos);
        }

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

        [HttpPost]
        public IActionResult PostCurso([FromBody] Curso curso)
        {
            if (curso == null) return BadRequest();

            _cursoService.CreateCurso(curso);

            return CreatedAtAction(nameof(GetCurso), new { id = curso.CursoId }, curso);
        }

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
            return NoContent();
        }
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