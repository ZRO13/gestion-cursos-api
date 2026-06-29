using ApiGestionCursos.Models;
using ApiGestionCursos.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace ApiGestionCursos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InscripcionesController : ControllerBase
    {
        private readonly IInscripcionService _inscripcionService;

        public InscripcionesController(IInscripcionService inscripcionService)
        {
            _inscripcionService = inscripcionService;
        }

        [HttpGet]
        public IActionResult GetInscripciones()
        {
            return Ok(_inscripcionService.GetInscripciones());
        }

        [HttpGet("{id}")]
        public IActionResult GetInscripcion(int id)
        {
            var inscripcion = _inscripcionService.GetInscripcion(id);

            if (inscripcion == null)
                return NotFound();

            return Ok(inscripcion);
        }

        [HttpPost]
        public IActionResult PostInscripcion([FromBody] Inscripcion inscripcion)
        {
            if (inscripcion == null)
                return BadRequest();

            if (!_inscripcionService.CreateInscripcion(inscripcion))
                return StatusCode(500);

            return CreatedAtAction(nameof(GetInscripcion), new { id = inscripcion.InscripcionId }, inscripcion);
        }

        [HttpPut("{id}")]
        public IActionResult PutInscripcion(int id, [FromBody] Inscripcion inscripcion)
        {
            if (inscripcion == null || id != inscripcion.InscripcionId)
                return BadRequest();

            var existe = _inscripcionService.GetInscripcion(id);

            if (existe == null)
                return NotFound();

            if (!_inscripcionService.UpdateInscripcion(inscripcion))
                return StatusCode(500);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteInscripcion(int id)
        {
            var inscripcion = _inscripcionService.GetInscripcion(id);

            if (inscripcion == null)
                return NotFound();

            if (!_inscripcionService.DeleteInscripcion(inscripcion))
                return StatusCode(500);

            return Ok(new { message = "Inscripción eliminada correctamente." });
        }
    }
}