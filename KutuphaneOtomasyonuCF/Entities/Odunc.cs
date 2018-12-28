using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneOtomasyonuCF.Entities
{
    [Table("Oduncler")]
    public class Odunc
    {
        [Key]
        public int OduncId { get; set; }

        [Required]
        public int UyeId { get; set; }

        [Required]
        [ForeignKey("UyeId")]
        public virtual Uye Uye { get; set; }

        [Required]
        public static DateTime AlisTarihi { get; set; } = DateTime.Now.Date;

        public static DateTime? VerisTarihi { get; set; }

        public virtual ICollection<Kitap> Kitaplar { get; set; } = new HashSet<Kitap>();
    }
}
