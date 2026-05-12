using System.ComponentModel.DataAnnotations;

namespace ApiGestionCursos.Models
{
    public class Docente
    {
        [Key]
        public int DocenteId { get; set; }

        [Required]
        [StringLength(100)]
        public string NombreCompleto { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Correo { get; set; } = string.Empty;

        [Required]
        public string Especialidad { get; set; } = string.Empty;

        public bool Activo { get; set; } = true;

      
        public List<Curso> Cursos { get; set; } = new();
    
    }
}
