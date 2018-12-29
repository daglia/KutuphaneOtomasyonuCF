using KutuphaneOtomasyonuCF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneOtomasyonuCF.ViewModels
{
    public class UyeViewModel
    {
        public int UyeId { get; set; }
        public string UyeAd { get; set; }
        public string UyeSoyad { get; set; }
        public string UyeTCKN { get; set; }
        public string UyeTelefon { get; set; }
        public string UyeMail { get; set; }
        public List<Odunc> Oduncler { get; set; }

        public override string ToString() => $"{UyeId} - {UyeAd} {UyeSoyad}";
    }
}
