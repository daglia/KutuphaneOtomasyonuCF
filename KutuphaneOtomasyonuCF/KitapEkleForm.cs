﻿using KutuphaneOtomasyonuCF.BLL;
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
                .Where(x => x.Ad.ToLower().Contains(ara) || x.Yazar.YazarAd.ToString().ToLower().Contains(ara) || x.Yazar.YazarSoyad.ToString().ToLower().Contains(ara))
                .ToList()
                .ForEach(x => bulunanlar.Add(new KitapViewModel() {
                    Ad = x.Ad,
                    Yazar = x.Yazar,
                    Stok = x.Stok,
                    KitapId = x.KitapId
                }));
            lbKitap.DataSource = bulunanlar;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                string[] YazarTam = cmbYazar.Text.Split(' ');
                var kitapBusiness = new KitapBusiness();
                var kitapModel = new KitapViewModel()
                {
                    Ad = txtAd.Text,
                    Yazar = new Yazar()
                    {
                        YazarAd = cmbYazar.Text.Remove(cmbYazar.Text.Length - YazarTam[YazarTam.Length-1].Length - 1),
                        YazarSoyad = YazarTam[YazarTam.Length-1]
                    },
                    Stok = (short)nudStok.Value
                };

                kitapBusiness.KitapEkle(kitapModel);

                MessageBox.Show($"Yeni kitap eklendi: {kitapModel.Yazar.YazarAd} {kitapModel.Yazar.YazarSoyad} - {kitapModel.Ad}", "Yeni kitap eklendi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                VerileriGetir();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            string[] YazarTam = cmbYazar.Text.Split(' ');
            try
            {
                Context db = new Context();
                var seciliKitap = lbKitap.SelectedItem as KitapViewModel;
                var kitap = db.Kitaplar.Find(seciliKitap.KitapId);
                kitap.Ad = txtAd.Text;

                if(cmbYazar.Text != (kitap.Yazar.YazarAd + " " + kitap.Yazar.YazarSoyad)){
                    kitap.Yazar = new Yazar()
                    {
                        YazarAd = cmbYazar.Text.Remove(cmbYazar.Text.Length - YazarTam[YazarTam.Length - 1].Length - 1),
                        YazarSoyad = YazarTam[YazarTam.Length - 1]
                    };
                }

                kitap.Stok = (short)nudStok.Value;
                db.SaveChanges();
                VerileriGetir();
                MessageBox.Show($"Seçili kitap güncellendi.");
            }
            catch (DbEntityValidationException ex)
            {
                MessageBox.Show(EntityHelper.ValidationMessage(ex), "Bir hata oluştu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void lbKitap_SelectedIndexChanged(object sender, EventArgs e)
        {
            var kitapModel = lbKitap.SelectedItem as KitapViewModel;
            txtAd.Text = kitapModel.Ad;
            txtKitapId.Text = kitapModel.KitapId.ToString();
            txtYazarId.Text = kitapModel.Yazar.YazarId.ToString();
            cmbYazar.Text = kitapModel.Yazar.YazarAd + " " + kitapModel.Yazar.YazarSoyad;
            nudStok.Value = kitapModel.Stok;
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (lbKitap.SelectedItem == null) return;

            var kitapId = (lbKitap.SelectedItem as KitapViewModel).KitapId;
            var cevap = MessageBox.Show("Seçili kitabı silmek istiyor musunuz?", "Kitap silme",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cevap != DialogResult.Yes) return;
            try
            {
                Context db = new Context();
                var kitap = db.Kitaplar.Find(kitapId);
                db.Kitaplar.Remove(kitap);
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

        private void cmbYazar_SelectedIndexChanged(object sender, EventArgs e)
        {
            var yazarModel = cmbYazar.SelectedItem as YazarViewModel;
            txtYazarId.Text = yazarModel.YazarId.ToString();
        }
    }
}
