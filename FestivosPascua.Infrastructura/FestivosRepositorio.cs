using FestivosPascua.Core.Repositorios;
using FestivosPascua.Dominio.Entidades;
using FestivosPascua.Persistencia.Contexto;
using Microsoft.EntityFrameworkCore;

namespace FestivosPascua.Infraestructura.Repositorios
{
    public class FestivosRepositorio : IFestivoRepositorio
    {
        private readonly ClsFestivosPascuaContext Context;

        public FestivosRepositorio(ClsFestivosPascuaContext Context)
        {
            this.Context = Context;
        }

        public async Task<ClsFestivos> Agregar(ClsFestivos festivo)
        {
            Context.Festivos.Add(festivo);
            await Context.SaveChangesAsync();
            return festivo;
        }

        public async Task<IEnumerable<ClsFestivos>> Buscar(int Tipo, string Dato)
        {
            return await Context.Festivos
                .Where(f => f.IdTipo == Tipo && f.Nombre.Contains(Dato))
                .ToListAsync();
        }

        public async Task<bool> Eliminar(int Id)
        {
            var festivoExistente = await Context.Festivos.FindAsync(Id);
            if (festivoExistente == null)
            {
                return false;
            }
            try
            {
                Context.Festivos.Remove(festivoExistente);
                await Context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ClsFestivos> Modificar(ClsFestivos festivo)
        {
            var festivoExistente = await Context.Festivos.FindAsync(festivo.Id);
            if (festivoExistente == null) return null;
            
            Context.Festivos.Update(festivo);
            await Context.SaveChangesAsync();
            return festivo;
        }

        public async Task<ClsFestivos> Obtener(int Id)
        {
            return await Context.Festivos.Include(f => f.Tipo)
                                         .FirstOrDefaultAsync(f => f.Id == Id);
        }

        public async Task<IEnumerable<ClsFestivos>> ObtenerTodos()
        {
            return await Context.Festivos.Include(f => f.Tipo).ToListAsync();
        }
        public async Task<List<ClsFestivos>> ObtenerTodosFestivos()
        {
            return await Context.Festivos.Include(f => f.Tipo).ToListAsync();
        }


    }
}

