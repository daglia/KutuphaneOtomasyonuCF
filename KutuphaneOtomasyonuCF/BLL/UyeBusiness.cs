using KutuphaneOtomasyonuCF.Entities;
using KutuphaneOtomasyonuCF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneOtomasyonuCF.BLL
{
    public class UyeBusiness
    {
        public void UyeEkle(UyeViewModel uye)
        {
            Context db = new Context();
            using(var tran = db.Database.BeginTransaction())
            {
                try
                {
                    var yeniUye = new Uye()
                    {
                        UyeAd = uye.UyeAd,
                        UyeSoyad = uye.UyeSoyad,
                        UyeTCKN = uye.UyeTCKN,
                        UyeTelefon = uye.UyeTelefon,
                        UyeMail = uye.UyeMail
                    };
                    db.Uyeler.Add(yeniUye);
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
