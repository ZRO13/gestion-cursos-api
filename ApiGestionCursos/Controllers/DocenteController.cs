using ApiGestionCursos.Models;
using ApiGestionCursos.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace ApiGestionCursos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocentesController : ControllerBase
    {
        private readonly IDocenteService _docenteService;

        public DocentesController(IDocenteService docenteService)
        {
            _docenteService = docenteService;
        }

        [HttpGet]
        public IActionResult GetDocentes()
        {
            return Ok(_docenteService.GetDocentes());
        }

        [HttpGet("{id}")]
        public IActionResult GetDocente(int id)
        {
            var docente = _docenteService.GetDocente(id);
            if (docente == null) return NotFound();
            return Ok(docente);
        }

        [HttpPost]
        public IActionResult PostDocente([FromBody] Docente docente)
        {
            if (docente == null) return BadRequest();
            if (!_docenteService.CreateDocente(docente)) return StatusCode(500);

            return CreatedAtAction(nameof(GetDocente), new { id = docente.DocenteId }, docente);
        }

        [HttpPut("{id}")]
        public IActionResult PutDocente(int id, [FromBody] Docente docente)
        {
            if (docente == null || id != docente.DocenteId) return BadRequest();

            var existe = _docenteService.GetDocente(id);
            if (existe == null) return NotFound();

            if (!_docenteService.UpdateDocente(docente)) return StatusCode(500);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDocente(int id)
        {
            var docente = _docenteService.GetDocente(id);
            if (docente == null) return NotFound();

            if (!_docenteService.DeleteDocente(docente)) return StatusCode(500);

            return Ok(new { message = "Docente eliminado correctamente." });
        }
    }
}