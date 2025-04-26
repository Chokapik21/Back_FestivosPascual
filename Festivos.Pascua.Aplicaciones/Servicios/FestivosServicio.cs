using FestivosPascua.Core.Repositorios;
using FestivosPascua.Core.Servicios;
using FestivosPascua.Core.Utilidades;
using FestivosPascua.Dominio.Entidades;


namespace FestivosPascua.Aplicacion.Servicios
{
    public class FestivosServicio : IFestivoServicio
    {
        private readonly IFestivoRepositorio repositorio;

        public FestivosServicio(IFestivoRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        public async Task<ClsFestivos> Agregar(ClsFestivos festivo)
        {
            return await repositorio.Agregar(festivo);
        }

        public async Task<IEnumerable<ClsFestivos>> Buscar(int tipo, string dato)
        {
            return await repositorio.Buscar(tipo, dato);
        }

        public async Task<bool> Eliminar(int id)
        {
            return await repositorio.Eliminar(id);
        }

        public async Task<ClsFestivos> Modificar(ClsFestivos festivo)
        {
            return await repositorio.Modificar(festivo);
        }

        public async Task<ClsFestivos> Obtener(int id)
        {
            return await repositorio.Obtener(id);
        }

        public async Task<IEnumerable<ClsFestivos>> ObtenerTodos()
        {
            return await repositorio.ObtenerTodos();
        }
        public async Task<string> ValidarFecha(DateTime fecha)
        {
            var festivos = await repositorio.ObtenerTodosFestivos();
            return ClsCalcularFestivo.EsFestivo(fecha, festivos);
        }
    }
}
