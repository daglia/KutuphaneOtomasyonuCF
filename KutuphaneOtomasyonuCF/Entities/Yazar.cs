using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace KutuphaneOtomasyonuCF.Entities
{
    public class Yazar
    {
        [Key]
        public int YazarId { get; set; }

        [StringLength(20, ErrorMessage = "Yazar adı 20 karakterden fazla olamaz")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Ad sadece harflerden oluşmalıdır.")]
        [Required]
        public string YazarAd { get; set; }

        [StringLength(20, ErrorMessage = "Yazar soyadı 20 karakterden fazla olamaz")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Soyad sadece harflerden oluşmalıdır.")]
        [Required]
        public string YazarSoyad { get; set; }

        public virtual ICollection<Kitap> Kitaplar { get; set; } = new HashSet<Kitap>();
    }
}
