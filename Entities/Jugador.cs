using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace PrimeraAPI.Entities
{
    [Table("Jugador")]
    public class Jugador
    {
        [Key]
        [Column(TypeName = "int")]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }


        public int Club_id { get; set; } = 1;

        [ForeignKey("Club_id")] 
        public virtual Club? club { get; set; }
    }
}
