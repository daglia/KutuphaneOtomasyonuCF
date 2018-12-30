using KutuphaneOtomasyonuCF.Entities;
using KutuphaneOtomasyonuCF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneOtomasyonuCF.BLL
{
    public class YazarBusiness
    {
        public void YazarEkle(YazarViewModel yazar)
        {
            Context db = new Context();
            using (var tran = db.Database.BeginTransaction())
            {
                try
                {
                    var yeniYazar = new Yazar()
                    {
                        YazarAd = yazar.YazarAd,
                        YazarSoyad = yazar.YazarSoyad
                    };
                    db.Yazarlar.Add(yeniYazar);
                    db.SaveChanges();

                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;
                }
            }
        }
    }
}
