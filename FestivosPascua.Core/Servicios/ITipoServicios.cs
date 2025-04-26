using FestivosPascua.Dominio.Entidades;

namespace FestivosPascua.Core.Servicios
{
    public interface ITipoServicios
    {
        Task<ClsTipo> Agregar(ClsTipo tipo);
        Task<IEnumerable<ClsTipo>> Buscar(string dato);
        Task<bool> Eliminar(int id);
        Task<ClsTipo> Modificar(ClsTipo tipo);
        Task<ClsTipo> Obtener(int id);
        Task<IEnumerable<ClsTipo>> ObtenerTodos();
    }
}
