using KutuphaneOtomasyonuCF.BLL;
using KutuphaneOtomasyonuCF.Entities;
using KutuphaneOtomasyonuCF.Helpers;
using KutuphaneOtomasyonuCF.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KutuphaneOtomasyonuCF
{
    public partial class YazarEkleForm : Form
    {
        public YazarEkleForm()
        {
            InitializeComponent();
        }

        private void YazarEkleForm_Load(object sender, EventArgs e)
        {
            VerileriGetir();
        }

        private void VerileriGetir()
        {
            Context db = new Context();
            lbYazarlar.DataSource = db.Yazarlar
                .OrderBy(x => x.YazarId)
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
            List<YazarViewModel> bulunanlar = new List<YazarViewModel>();

            db.Yazarlar
                .Where(x => x.YazarAd.ToLower().Contains(ara) || x.YazarSoyad.ToString().ToLower().Contains(ara) || x.YazarId.ToString().Contains(ara))
                .ToList()
                .ForEach(x => bulunanlar.Add(new YazarViewModel()
                {
                    YazarId = x.YazarId,
                    YazarAd = x.YazarAd,
                    YazarSoyad = x.YazarSoyad
                }));
            lbYazarlar.DataSource = bulunanlar;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                var yazarBusiness = new YazarBusiness();
                var yazarModel = new YazarViewModel()
                {
                    YazarAd = txtAd.Text,
                    YazarSoyad = txtSoyad.Text,
                };

                yazarBusiness.YazarEkle(yazarModel);

                MessageBox.Show($"Yeni yazar eklendi: {yazarModel.YazarId} - {yazarModel.YazarAd} {yazarModel.YazarSoyad}", "Yeni yazar eklendi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                VerileriGetir();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (lbYazarlar.SelectedItem == null) return;

            var yazarId = (lbYazarlar.SelectedItem as YazarViewModel).YazarId;
            var cevap = MessageBox.Show("Seçili yazarı silmek istiyor musunuz?", "Yazar silme",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cevap != DialogResult.Yes) return;
            try
            {
                if((lbYazarlar.SelectedItem as YazarViewModel).Kitaplar.Any())
                {
                    MessageBox.Show($"Yazarın {(lbYazarlar.SelectedItem as YazarViewModel).Kitaplar.Count} kitabı bulunmaktadır. Devam etmek için önce kitapları silin.");
                    return;
                }
                Context db = new Context();
                var yazar = db.Yazarlar.Find(yazarId);
                db.Yazarlar.Remove(yazar);
                db.SaveChanges();
                MessageBox.Show("Kayıt silindi.");
                VerileriGetir();
            }
            catch (DbUpdateException)
            {
                MessageBox.Show("Silmek istediğiniz kayıt başka bir tabloda kullanıldığı için silemezsiniz.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                Context db = new Context();
                var seciliYazar = lbYazarlar.SelectedItem as YazarViewModel;
                var yazar = db.Yazarlar.Find(seciliYazar.YazarId);
                yazar.YazarAd = txtAd.Text;
                yazar.YazarSoyad = txtSoyad.Text;
                db.SaveChanges();
                VerileriGetir();
                MessageBox.Show($"Seçili üye güncellendi.");
            }
            catch (DbEntityValidationException ex)
            {
                MessageBox.Show(EntityHelper.ValidationMessage(ex), "Bir hata oluştu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void lbYazarlar_SelectedIndexChanged(object sender, EventArgs e)
        {
            var yazarModel = lbYazarlar.SelectedItem as YazarViewModel;
            txtAd.Text = yazarModel.YazarAd;
            txtSoyad.Text = yazarModel.YazarSoyad;
            txtId.Text = yazarModel.YazarId.ToString();
        }

        private void lbYazarlar_DoubleClick(object sender, EventArgs e)
        {
            var yazarModel = lbYazarlar.SelectedItem as YazarViewModel;
            if (yazarModel.Kitaplar == null) return;
            string kitaplar = "";
            foreach (Kitap kitap in yazarModel.Kitaplar)
            {
                kitaplar += kitap.Ad + "\n";
            }
            MessageBox.Show("Yazarın kitapları:\n" + kitaplar);
        }
    }
}
