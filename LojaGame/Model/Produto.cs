using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LojaGame.Model
{
    public class Produto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // identity (1,1)
        public long id { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(100)]
        public string Nome { get; set; } = string.Empty;

        [Column(TypeName = "varchar")]
        [StringLength(255)]
        public string Descricao { get; set; } = string.Empty;

        [Column(TypeName = "varchar")]
        [StringLength(255)]
        public string Console { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        [Column(TypeName = "DATE")]
        public DateOnly? DataLancamento { get; set; } 

        [Column(TypeName = "Decimal(6,2)")]
        public decimal Preco { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(5000)]
        public string Foto { get; set; }  = string.Empty;

        public virtual Categoria? Categoria { get; set; }
    }
}
