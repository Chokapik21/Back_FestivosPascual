using FestivosPascua.Dominio.Entidades;

namespace FestivosPascua.Core.Servicios
{
    public interface IFestivoServicio
    {
        Task<string> ValidarFecha(DateTime fecha);
        Task<IEnumerable<ClsFestivos>> ObtenerTodos();
        Task<ClsFestivos> Obtener(int Id);

        Task<ClsFestivos> Agregar(ClsFestivos Festivo);

        Task<ClsFestivos> Modificar(ClsFestivos Festivo);

        Task<bool> Eliminar(int Id);

        Task<IEnumerable<ClsFestivos>> Buscar(int Tipo, string Dato);
    }
}
