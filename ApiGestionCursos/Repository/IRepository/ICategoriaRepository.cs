using ApiGestionCursos.Models;

namespace ApiGestionCursos.Repository.IRepository
{
    public interface ICategoriaRepository
    {
        ICollection<Categoria> GetCategorias();

        Categoria? GetCategoria(int id);

        bool CategoriaExists(int id);

        bool CreateCategoria(Categoria categoria);

        bool UpdateCategoria(Categoria categoria);

        bool DeleteCategoria(Categoria categoria);

        bool Save();
    }
}