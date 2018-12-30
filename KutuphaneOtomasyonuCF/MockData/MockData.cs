using KutuphaneOtomasyonuCF.BLL;
using KutuphaneOtomasyonuCF.Entities;
using KutuphaneOtomasyonuCF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneOtomasyonuCF.MockData
{
    public class MockData
    {
        public Context Context { get; set; }

        public MockData()
        {
            Context = new Context();

            for (int i = 0; i < 20; i++)
            {
                var uyeBusiness = new UyeBusiness();
                var uyeModel = new UyeViewModel()
                {
                    UyeAd = FakeData.NameData.GetFirstName(),
                    UyeSoyad = FakeData.NameData.GetSurname(),
                    UyeTCKN = FakeData.TextData.GetNumeric(11),
                    UyeTelefon = "5" + FakeData.TextData.GetNumeric(9)
                };
                uyeModel.UyeMail = (uyeModel.UyeAd.Substring(0, 1) + "." + uyeModel.UyeSoyad + "@kutupmail.com").ToLower();

                uyeBusiness.UyeEkle(uyeModel);
            }
            for (int i = 0; i < 20; i++)
            {
                var yazarBusiness = new YazarBusiness();
                var yazarModel = new YazarViewModel()
                {
                    YazarAd = FakeData.NameData.GetFirstName(),
                    YazarSoyad = FakeData.NameData.GetSurname(),
                };

                yazarBusiness.YazarEkle(yazarModel);
            }
            for (int i = 0; i < 20; i++)
            {
                Context.Kitaplar.Add(new Kitap()
                {
                    Ad = FakeData.TextData.GetSentence(),
                    Stok = (short)FakeData.NumberData.GetNumber(1, 10)
                });
            }
        }
    }
}
