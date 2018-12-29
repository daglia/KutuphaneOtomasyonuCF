using KutuphaneOtomasyonuCF.Entities;
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
                Context.Uyeler.Add(new Uye()
                {
                    UyeAd = FakeData.NameData.GetFirstName(),
                    UyeSoyad = FakeData.NameData.GetSurname(),
                    UyeTCKN = FakeData.TextData.GetNumeric(11),
                    UyeTelefon = "5" + FakeData.TextData.GetNumeric(9),
                    UyeMail = (FakeData.NameData.GetFirstName().Substring(0, 1) + "." + FakeData.NameData.GetSurname() + "@kutupmail.com").ToLower()
                });
            }
            for (int i = 0; i < 20; i++)
            {
                Context.Yazarlar.Add(new Yazar()
                {
                    YazarAd = FakeData.NameData.GetFirstName(),
                    YazarSoyad = FakeData.NameData.GetSurname()
                });
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
