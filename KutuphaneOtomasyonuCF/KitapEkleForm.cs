using KutuphaneOtomasyonuCF.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KutuphaneOtomasyonuCF
{
    public partial class KitapEkleForm : Form
    {
        public KitapEkleForm()
        {
            InitializeComponent();
        }

        private void KitapEkleForm_Load(object sender, EventArgs e)
        {
            VerileriGetir();
        }

        private void VerileriGetir()
        {
            Context db = new Context();
            lbKitap.DataSource = db.Kitaplar
                .OrderBy(x => x.Yazar.YazarId)
                .Select(x => new KitapViewModel()
                {
                    KitapId = x.KitapId,
                    Ad = x.Ad,
                    Yazar = x.Yazar,
                    Stok = x.Stok
                }).ToList();
            cmbYazar.DataSource = db.Yazarlar
                .OrderBy(x => x.YazarAd)
                .ThenBy(x => x.YazarSoyad)
                .Select(x => new YazarViewModel()
                {
                    YazarId = x.YazarId,
                    YazarAd = x.YazarAd,
                    YazarSoyad = x.YazarSoyad
                }).ToList();
        }

        private void txtAra_KeyUp(object sender, KeyEventArgs e)
        {
            string ara = txtAra.Text.ToLower();

            Context db = new Context();
            List<KitapViewModel> bulunanlar = new List<KitapViewModel>();

            db.Kitaplar
                .Where(x => x.Ad.ToLower().Contains(ara) || x.Yazar.ToString().ToLower().Contains(ara))
                .ToList()
                .ForEach(x => bulunanlar.Add(new KitapViewModel() {
                    Ad = x.Ad,
                    Yazar = x.Yazar
                }));
            lbKitap.DataSource = bulunanlar;
        }
    }
}
