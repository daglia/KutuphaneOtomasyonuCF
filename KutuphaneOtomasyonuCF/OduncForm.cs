using KutuphaneOtomasyonuCF.Entities;
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
    public partial class OduncForm : Form
    {
        public OduncForm()
        {
            InitializeComponent();
        }

        private void OduncForm_Load(object sender, EventArgs e)
        {
            VerileriGetir();
        }

        private void VerileriGetir()
        {
            Context db = new Context();
            clbKitaplar.DataSource = db.Kitaplar
                .OrderBy(x => x.Yazar.YazarId)
                .Select(x => new KitapViewModel()
                {
                    KitapId = x.KitapId,
                    Ad = x.Ad,
                    Yazar = x.Yazar,
                    Stok = x.Stok
                }).ToList();
            cmbUye.DataSource = db.Uyeler
                .OrderBy(x => x.UyeId)
                .Select(x => new UyeViewModel()
                {
                    UyeId = x.UyeId,
                    UyeAd = x.UyeAd,
                    UyeSoyad = x.UyeSoyad,
                    UyeTCKN = x.UyeTCKN,
                    UyeTelefon = x.UyeTelefon,
                    UyeMail = x.UyeMail
                }).ToList();
        }

        private void txtAra_KeyUp(object sender, KeyEventArgs e)
        {
            string ara = txtAra.Text.ToLower();

            Context db = new Context();
            List<KitapViewModel> bulunanlar = new List<KitapViewModel>();

            db.Kitaplar
                .Where(x => x.Ad.ToLower().Contains(ara) || x.Yazar.YazarAd.ToString().ToLower().Contains(ara) || x.Yazar.YazarSoyad.ToString().ToLower().Contains(ara))
                .ToList()
                .ForEach(x => bulunanlar.Add(new KitapViewModel()
                {
                    Ad = x.Ad,
                    Yazar = x.Yazar,
                    Stok = x.Stok,
                    KitapId = x.KitapId
                }));
            clbKitaplar.DataSource = bulunanlar;
        }
    }
}
