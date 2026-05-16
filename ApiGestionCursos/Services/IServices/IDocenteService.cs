using ApiGestionCursos.Models;
namespace ApiGestionCursos.Services.IServices
{

        public interface IDocenteService
        {
            ICollection<Docente> GetDocentes();
            Docente? GetDocente(int id);
            bool CreateDocente(Docente docente);
            bool UpdateDocente(Docente docente);
            bool DeleteDocente(Docente docente);
        }
    
}
