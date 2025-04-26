using FestivosPascua.Aplicacion.Servicios;
using FestivosPascua.Core.Repositorios;
using FestivosPascua.Core.Servicios;
using FestivosPascua.Persistencia.Contexto;
using FestivosPascua.Infraestructura.Repositorios;
using Microsoft.EntityFrameworkCore;


namespace FestivosPascua.Presentacion.DI
{
    public static class InyeccionDependencias
    {
        public static IServiceCollection AgregarDependencias(this IServiceCollection servicios,
            IConfiguration Configuracion)
        {
            //agregar la instancia del DbContext
            servicios.AddDbContext<ClsFestivosPascuaContext>(opciones =>
            {
                opciones.UseSqlServer(Configuracion.GetConnectionString("Festivos"));
            });

            //agregar repositorios
            servicios.AddTransient<IFestivoRepositorio, FestivosRepositorio>();
            servicios.AddTransient<ITipoRepositorio, TipoRepositorio>();

            //agregar servicios
            servicios.AddTransient<IFestivoServicio, FestivosServicio>();
            servicios.AddTransient<ITipoServicios, TipoServicio>();

            return servicios;
        }
    }
}
