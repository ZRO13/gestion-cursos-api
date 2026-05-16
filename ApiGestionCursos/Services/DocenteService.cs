using ApiGestionCursos.Models;
using ApiGestionCursos.Repository.IRepository;
using ApiGestionCursos.Services.IServices;

namespace ApiGestionCursos.Services
{
    public class DocenteService : IDocenteService
    {
        private readonly IDocenteRepository _docenteRepository;

        public DocenteService(IDocenteRepository docenteRepository)
        {
            _docenteRepository = docenteRepository;
        }

        public ICollection<Docente> GetDocentes() => _docenteRepository.GetDocentes();

        public Docente? GetDocente(int id) => _docenteRepository.GetDocente(id);

        public bool CreateDocente(Docente docente) => _docenteRepository.CreateDocente(docente);

        public bool UpdateDocente(Docente docente) => _docenteRepository.UpdateDocente(docente);

        public bool DeleteDocente(Docente docente) => _docenteRepository.DeleteDocente(docente);
    }
}