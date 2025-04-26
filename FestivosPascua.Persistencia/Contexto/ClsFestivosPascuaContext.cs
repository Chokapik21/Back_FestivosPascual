using FestivosPascua.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace FestivosPascua.Persistencia.Contexto
{
    public class ClsFestivosPascuaContext : DbContext
    {
        public ClsFestivosPascuaContext(DbContextOptions<ClsFestivosPascuaContext> options)
        : base(options)
        {
        }

        public DbSet<ClsTipo> Tipos { get; set; }
        public DbSet<ClsFestivos> Festivos { get; set; }

        void OnModelCreating(ModelBuilder Modelbuilder)
        {
            Modelbuilder.Entity<ClsTipo>(Entidad =>
            {
                Entidad.HasKey(e => e.Id);
                Entidad.HasIndex(e => e.Nombre).IsUnique();
            });

            Modelbuilder.Entity<ClsFestivos>(Entidad =>
            {
                Entidad.HasKey(e => e.Id);
                Entidad.HasIndex(e => e.Nombre).IsUnique();
                Entidad.HasIndex(e => e.Dia).IsUnique();
                Entidad.HasIndex(e => e.Mes).IsUnique();
                Entidad.HasIndex(e => e.DiasPascuas).IsUnique();
            });

            Modelbuilder.Entity<ClsFestivos>()
                .HasOne(e => e.Tipo)
                .WithMany()
                .HasForeignKey(e => e.IdTipo);
        }
    }
}
