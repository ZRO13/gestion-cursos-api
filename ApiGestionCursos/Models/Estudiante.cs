using System.ComponentModel.DataAnnotations;

namespace ApiGestionCursos.Models
{
    public class Estudiante
    {
        [Key]
        public int EstudianteId { get; set; }

        [Required]
        [StringLength(100)]
        public string NombreCompleto { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Correo { get; set; } = string.Empty;

        public bool Activo { get; set; } = true;

        // Navigation
        public List<Inscripcion> Inscripciones { get; set; } = new();
    }
}
