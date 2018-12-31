using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneOtomasyonuCF.Entities
{
    [Table("Kitaplar")]
    public class Kitap
    {
        [Key]
        public int KitapId { get; set; }

        [StringLength(100)]
        [Required]
        public string Ad { get; set; }

        [Required]
        public int YazarId { get; set; }

        [Required]
        [ForeignKey("YazarId")]
        public virtual Yazar Yazar { get; set; }

        [Required]
        public short Stok { get; set; }
    }
}
