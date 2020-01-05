using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data
{
    [Table("Produto")]
    public class Produto
    {
        [Column("Id"), Key]
        public int Id { get; set; }

        [Column("Nome")]
        public string Nome { get; set; }
        
        [Column("Quantidade")]
        public int Quantidade { get; set; }
        
        [Column("Preco")]
        public double Preco { get; set; }
    }
}
