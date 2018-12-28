using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KutuphaneOtomasyonuCF.Entities;
using System.Data.Entity;

namespace KutuphaneOtomasyonuCF
{
    public class Context : DbContext
    {
        public Context() : base("name=MyCon")
        {

        }

        public virtual DbSet<Uye> Uyeler { get; set; }
        public virtual DbSet<Kitap> Kitaplar { get; set; }
        public virtual DbSet<Yazar> Yazarlar { get; set; }
        public virtual DbSet<Odunc> Oduncler { get; set; }
        public virtual DbSet<OduncDetay> OduncDetaylar { get; set; }
    }
}
