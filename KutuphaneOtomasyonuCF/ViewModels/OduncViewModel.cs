using KutuphaneOtomasyonuCF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneOtomasyonuCF.ViewModels
{
    public class OduncViewModel
    {
        public int OduncId { get; set; }
        public Uye Uye { get; set; }
        public static DateTime AlisTarihi { get; set; } = DateTime.Now.Date;
        public static DateTime? VerisTarihi { get; set; }
        public List<Kitap> Kitaplar { get; set; }

        public override string ToString() => $"{OduncId} - {Uye.UyeAd} {Uye.UyeSoyad} - (ST: {AlisTarihi.AddDays(14)})";
    }
}
