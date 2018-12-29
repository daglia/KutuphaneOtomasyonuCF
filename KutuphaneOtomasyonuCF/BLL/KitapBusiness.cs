using KutuphaneOtomasyonuCF.Entities;
using KutuphaneOtomasyonuCF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneOtomasyonuCF.BLL
{
    public class KitapBusiness
    {
        public void KitapEkle(KitapViewModel kitap)
        {
            Context db = new Context();
            using (var tran = db.Database.BeginTransaction())
            {
                try
                {
                    var yeniKitap = new Kitap()
                    {
                        Ad = kitap.Ad,
                        Yazar = kitap.Yazar,
                        Stok = (short)kitap.Stok
                    };
                    db.Kitaplar.Add(yeniKitap);
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
