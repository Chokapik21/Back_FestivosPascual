using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace FestivosPascua.Dominio.Entidades
{
    [Table("Tipo")]
    public class ClsTipo
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("Tipo"), StringLength(50)]
        public required string Nombre { get; set; }
    }
}

