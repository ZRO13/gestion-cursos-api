using ApiGestionCursos.Models;
using ApiGestionCursos.Services.IServices;
using Microsoft.AspNetCore.Authorization; 
using Microsoft.AspNetCore.Mvc;

namespace ApiGestionCursos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] 
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriasController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpGet]
        public IActionResult GetCategorias()
        {
            return Ok(_categoriaService.GetCategorias());
        }

        [HttpGet("{id}")]
        public IActionResult GetCategoria(int id)
        {
            var categoria = _categoriaService.GetCategoria(id);
            if (categoria == null) return NotFound();
            return Ok(categoria);
        }

        [HttpPost]
        public IActionResult PostCategoria([FromBody] Categoria categoria)
        {
            if (categoria == null) return BadRequest();
            if (!_categoriaService.CreateCategoria(categoria)) return StatusCode(500);

            return CreatedAtAction(nameof(GetCategoria), new { id = categoria.CategoriaId }, categoria);
        }

        [HttpPut("{id}")]
        public IActionResult PutCategoria(int id, [FromBody] Categoria categoria)
        {
            if (categoria == null || id != categoria.CategoriaId) return BadRequest();

            var existe = _categoriaService.GetCategoria(id);
            if (existe == null) return NotFound();

            if (!_categoriaService.UpdateCategoria(categoria)) return StatusCode(500);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategoria(int id)
        {
            var categoria = _categoriaService.GetCategoria(id);
            if (categoria == null) return NotFound();

            if (!_categoriaService.DeleteCategoria(categoria)) return StatusCode(500);

            return Ok(new { message = "Categoría eliminada correctamente." });
        }
    }
}