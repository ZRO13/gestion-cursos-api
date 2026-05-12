using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiGestionCursos.Models
{
    public class Curso
    {
        [Key]
        public int CursoId { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Descripcion { get; set; } = string.Empty;

        [Required]
        public bool Activo { get; set; }

        [Required]
        public int Cupos { get; set; }

        [Required]
        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        // FK
        public int DocenteId { get; set; }

        public Docente? Docente { get; set; }

        public List<Inscripcion> Inscripciones { get; set; } = new();
    }
}
