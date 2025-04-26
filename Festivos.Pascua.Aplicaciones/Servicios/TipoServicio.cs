using FestivosPascua.Core.Repositorios;
using FestivosPascua.Core.Servicios;
using FestivosPascua.Dominio.Entidades;

namespace FestivosPascua.Aplicacion.Servicios
{
    public class TipoServicio : ITipoServicios
    {
        private readonly ITipoRepositorio repositorio;

        public TipoServicio(ITipoRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        public async Task<ClsTipo> Agregar(ClsTipo tipo)
        {
            return await repositorio.Agregar(tipo);
        }

        public async Task<IEnumerable<ClsTipo>> Buscar(string dato)
        {
            return await repositorio.Buscar(dato);
        }

        public async Task<bool> Eliminar(int id)
        {
            return await repositorio.Eliminar(id);
        }

        public async Task<ClsTipo> Modificar(ClsTipo tipo)
        {
            return await repositorio.Modificar(tipo);
        }

        public async Task<ClsTipo> Obtener(int id)
        {
            return await repositorio.Obtener(id);
        }

        public async Task<IEnumerable<ClsTipo>> ObtenerTodos()
        {
            return await repositorio.ObtenerTodos();
        }
    }
}
