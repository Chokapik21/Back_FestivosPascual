using FestivosPascua.Dominio.Entidades;

namespace FestivosPascua.Core.Repositorios
{
    public interface ITipoRepositorio
    {
        Task<ClsTipo> Agregar(ClsTipo tipo);
        Task<IEnumerable<ClsTipo>> Buscar(string dato);
        Task<bool> Eliminar(int id);
        Task<ClsTipo> Modificar(ClsTipo tipo);
        Task<ClsTipo> Obtener(int id);
        Task<IEnumerable<ClsTipo>> ObtenerTodos();
    }
}
