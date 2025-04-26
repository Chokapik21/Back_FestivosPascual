using FestivosPascua.Core.Repositorios;
using FestivosPascua.Dominio.Entidades;
using FestivosPascua.Persistencia.Contexto;
using Microsoft.EntityFrameworkCore;

namespace FestivosPascua.Infraestructura.Repositorios
{
    public class TipoRepositorio : ITipoRepositorio
    {
        private readonly ClsFestivosPascuaContext Context;

        public TipoRepositorio(ClsFestivosPascuaContext Context)
        {
            this.Context = Context;
        }

        public async Task<ClsTipo> Agregar(ClsTipo tipo)
        {
            Context.Tipos.Add(tipo);
            await Context.SaveChangesAsync();
            return tipo;
        }

        public async Task<IEnumerable<ClsTipo>> Buscar(string dato)
        {
            return await Context.Tipos
                .Where(t => t.Nombre.Contains(dato))
                .ToListAsync();
        }

        public async Task<bool> Eliminar(int id)
        {
            var tipoExistente = await Context.Tipos.FindAsync(id);
            if (tipoExistente == null)
            {
                return false;
            }
            try
            {
                Context.Tipos.Remove(tipoExistente);
                await Context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ClsTipo> Modificar(ClsTipo tipo)
        {
            var tipoExistente = await Context.Tipos.FindAsync(tipo.Id);
            if (tipoExistente == null) return null;

            Context.Tipos.Update(tipo);
            await Context.SaveChangesAsync();
            return tipo;
        }

        public async Task<ClsTipo> Obtener(int id)
        {
            return await Context.Tipos.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<IEnumerable<ClsTipo>> ObtenerTodos()
        {
            return await Context.Tipos.ToListAsync();
        }
    }
}
