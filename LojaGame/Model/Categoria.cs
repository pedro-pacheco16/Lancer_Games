using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LojaGame.Model
{
    public class Categoria 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // identity (1,1)
        public long id { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(100)]
        public string Tipo { get; set; } = string.Empty;

        [InverseProperty("Categoria")]
 
        public virtual ICollection<Produto>? produto { get; set; }


    }
}
