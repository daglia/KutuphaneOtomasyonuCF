using KutuphaneOtomasyonuCF.Entities;
using KutuphaneOtomasyonuCF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneOtomasyonuCF.BLL
{
    public class OduncBusiness
    {
        public void OduncEkle(OduncViewModel odunc)
        {
            Context db = new Context();
            using (var tran = db.Database.BeginTransaction())
            {
                try
                {
                    var yeniOdunc = new Odunc()
                    {
                        OduncId = odunc.OduncId,
                        UyeId = odunc.Uye.UyeId,
                        Uye = odunc.Uye
                    };
                    db.Oduncler.Add(yeniOdunc);
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
