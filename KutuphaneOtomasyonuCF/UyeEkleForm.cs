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
using KutuphaneOtomasyonuCF.BLL;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using KutuphaneOtomasyonuCF.Helpers;

namespace KutuphaneOtomasyonuCF
{
    public partial class UyeEkleForm : Form
    {
        public UyeEkleForm()
        {
            InitializeComponent();
        }

        private void UyeEkleForm_Load(object sender, EventArgs e)
        {
            VerileriGetir();
        }

        private void VerileriGetir()
        {
            Context db = new Context();
            lbUyeler.DataSource = db.Uyeler
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
            List<UyeViewModel> bulunanlar = new List<UyeViewModel>();

            db.Uyeler
                .Where(x => x.UyeAd.ToLower().Contains(ara) || x.UyeSoyad.ToString().ToLower().Contains(ara) || x.UyeId.ToString().Contains(ara))
                .ToList()
                .ForEach(x => bulunanlar.Add(new UyeViewModel()
                {
                    UyeAd = x.UyeAd,
                    UyeSoyad = x.UyeSoyad,
                    UyeId = x.UyeId
                }));
            lbUyeler.DataSource = bulunanlar;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                var uyeBusiness = new UyeBusiness();
                var uyeModel = new UyeViewModel()
                {
                    UyeAd = txtAd.Text,
                    UyeSoyad = txtSoyad.Text,
                    UyeTCKN = txtTCKN.Text,
                    UyeTelefon = txtTelefon.Text,
                    UyeMail = txtMail.Text
                };

                uyeBusiness.UyeEkle(uyeModel);

                MessageBox.Show($"Yeni üye eklendi: {uyeModel.UyeAd} {uyeModel.UyeSoyad}","Yeni üye eklendi",MessageBoxButtons.OK,MessageBoxIcon.Information);
                VerileriGetir();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (lbUyeler.SelectedItem == null) return;

            var uyeId = (lbUyeler.SelectedItem as UyeViewModel).UyeId;
            var cevap = MessageBox.Show("Seçili üyeyi silmek istiyor musunuz?", "Üye silme",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cevap != DialogResult.Yes) return;
            try
            {
                Context db = new Context();
                var uye = db.Uyeler.Find(uyeId);
                db.Uyeler.Remove(uye);
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

        private void lbUyeler_SelectedIndexChanged(object sender, EventArgs e)
        {
            var uyeModel = lbUyeler.SelectedItem as UyeViewModel;
            txtId.Text = uyeModel.UyeId.ToString();
            txtAd.Text = uyeModel.UyeAd;
            txtSoyad.Text = uyeModel.UyeSoyad;
            txtTCKN.Text = uyeModel.UyeTCKN;
            txtTelefon.Text = uyeModel.UyeTelefon;
            txtMail.Text = uyeModel.UyeMail;
        }

        private void btnMock_Click(object sender, EventArgs e)
        {
            Context Context = new MockData.MockData().Context;
            VerileriGetir();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                Context db = new Context();
                var seciliUye = lbUyeler.SelectedItem as UyeViewModel;
                var uye = db.Uyeler.Find(seciliUye.UyeId);
                uye.UyeAd = txtAd.Text;
                uye.UyeSoyad = txtSoyad.Text;
                uye.UyeTCKN = txtTCKN.Text;
                uye.UyeTelefon = txtTelefon.Text;
                uye.UyeMail = txtMail.Text;
                db.SaveChanges();
                VerileriGetir();
                MessageBox.Show($"Seçili üye güncellendi.");
            }
            catch (DbEntityValidationException ex)
            {
                MessageBox.Show(EntityHelper.ValidationMessage(ex), "Bir hata oluştu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
