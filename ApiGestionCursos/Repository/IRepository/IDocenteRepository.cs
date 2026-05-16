using ApiGestionCursos.Models;

namespace ApiGestionCursos.Repository.IRepository
{
        public interface IDocenteRepository
        {
            ICollection<Docente> GetDocentes();
            Docente? GetDocente(int id);
            bool DocenteExists(int id);
            bool CreateDocente(Docente docente);
            bool UpdateDocente(Docente docente);
            bool DeleteDocente(Docente docente);
            bool Save();
        }
    
}
