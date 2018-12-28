using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace KutuphaneOtomasyonuCF.Entities
{
    [Table("Uyeler")]
    public class Uye
    {
        [Key]
        public int UyeId { get; set; }

        [StringLength(20,ErrorMessage = "Üye adı 20 karakterden fazla olamaz")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Ad sadece harflerden oluşmalıdır.")]
        [Required]
        public string UyeAd { get; set; }

        [StringLength(20,ErrorMessage = "Üye soyadı 20 karakterden fazla olamaz")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Soyad sadece harflerden oluşmalıdır.")]
        [Required]
        public string UyeSoyad { get; set; }

        [StringLength(11, ErrorMessage = "TCKN 11 karakterden fazla olamaz")]
        [MinLength(11,ErrorMessage = "TCKN 11 karakterden az olamaz")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "TCKN sadece rakamlardan oluşmalıdır.")]
        [Required]
        public string UyeTCKN { get; set; }

        [StringLength(10, ErrorMessage = "Telefon 10 karakterden fazla olamaz")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Telefon sadece rakamlardan oluşmalıdır.")]
        public string UyeTelefon { get; set; }

        [StringLength(30, ErrorMessage = "Mail 30 karakterden fazla olamaz")]
        [EmailAddress(ErrorMessage = "Geçersiz mail adresi.")]
        public string UyeMail { get; set; }

        public virtual ICollection<Odunc> Oduncler { get; set; } = new HashSet<Odunc>();
    }
}
