using FestivosPascua.Dominio.Entidades;

namespace FestivosPascua.Core.Repositorios
{
    public interface IFestivoRepositorio
    {
        Task<ClsFestivos> Agregar(ClsFestivos festivo);
        Task<IEnumerable<ClsFestivos>> Buscar(int tipo, string dato);
        Task<bool> Eliminar(int id);
        Task<ClsFestivos> Modificar(ClsFestivos festivo);
        Task<ClsFestivos> Obtener(int id);
        Task<IEnumerable<ClsFestivos>> ObtenerTodos();
        Task<List<ClsFestivos>> ObtenerTodosFestivos();
    }
}
