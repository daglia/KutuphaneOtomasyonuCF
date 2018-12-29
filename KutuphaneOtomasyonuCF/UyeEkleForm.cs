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
    }
}
