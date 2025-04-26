using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

namespace FestivosPascua.Dominio.Entidades
{
    [Table("Festivo")]
    public class ClsFestivos
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("Nombre"), StringLength(50)]
        public required string Nombre { get; set; }

        [Column("Dia")]
        public int Dia { get; set; }

        [Column("Mes")]
        public int Mes { get; set; }

        [Column("DiasPascua")]
        public int DiasPascuas { get; set; }

        [Column("IdTipo")]
        public int IdTipo { get; set; }

        [ForeignKey("IdTipo")]
        public ClsTipo Tipo { get; set; }
    }
}
    
