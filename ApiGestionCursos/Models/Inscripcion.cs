using System.ComponentModel.DataAnnotations;

namespace ApiGestionCursos.Models
{
    public class Inscripcion
    {
        [Key]
        public int InscripcionId { get; set; }

        public DateTime FechaInscripcion { get; set; } = DateTime.Now;

        public bool Estado { get; set; } = true;

        public decimal NotaFinal { get; set; }

        // FK
        public int CursoId { get; set; }

        public int EstudianteId { get; set; }

        // Navigation
        public Curso? Curso { get; set; }

        public Estudiante? Estudiante { get; set; }

    }
}
