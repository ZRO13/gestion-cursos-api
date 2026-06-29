using ApiGestionCursos.Models;

namespace ApiGestionCursos.Services.IServices
{
    public interface ICategoriaService
    {
        ICollection<Categoria> GetCategorias();

        Categoria? GetCategoria(int id);

        bool CreateCategoria(Categoria categoria);

        bool UpdateCategoria(Categoria categoria);

        bool DeleteCategoria(Categoria categoria);
    }
}