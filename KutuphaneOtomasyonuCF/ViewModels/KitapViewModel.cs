using KutuphaneOtomasyonuCF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneOtomasyonuCF.ViewModels
{
    public class KitapViewModel
    {
        public int KitapId { get; set; }
        public string Ad { get; set; }
        public Yazar Yazar { get; set; }
        public int Stok { get; set; }

        public override string ToString() => $"{Yazar.YazarAd} {Yazar.YazarSoyad} - {Ad} ({Stok})";
    }
}
