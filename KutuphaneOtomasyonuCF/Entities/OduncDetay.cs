using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneOtomasyonuCF.Entities
{
    [Table("OduncDetaylar")]
    public class OduncDetay
    {
        [Key]
        public int OduncDetayId { get; set; }

        [Required]
        public int OduncId { get; set; }

        [Required]
        [ForeignKey("OduncId")]
        public virtual Odunc Odunc { get; set; }

        public TimeSpan GunSayisi { get; set; } = (TimeSpan)(Odunc.VerisTarihi - Odunc.AlisTarihi);
    }
}
