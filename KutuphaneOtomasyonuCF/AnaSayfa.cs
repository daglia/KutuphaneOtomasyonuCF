using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KutuphaneOtomasyonuCF.MockData;

namespace KutuphaneOtomasyonuCF
{
    public partial class AnaSayfa : Form
    {
        public AnaSayfa()
        {
            InitializeComponent();
        }

        private OduncForm oduncForm;
        private UyeEkleForm uyeForm;
        private KitapEkleForm kitapForm;

        private void ödünçİşlemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void ödünçİşlemleriToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (oduncForm == null || oduncForm.IsDisposed)
            {
                oduncForm = new OduncForm
                {
                    Text = "Ödünç İşlemleri",
                    MdiParent = this
                };
                oduncForm.Show();
            }
        }

        private void üyeİşlemleriToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (uyeForm == null || uyeForm.IsDisposed)
            {
                uyeForm = new UyeEkleForm
                {
                    Text = "Üye İşlemleri",
                    MdiParent = this
                };
                uyeForm.Show();
            }
        }

        private void kitapİşlemleriToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (kitapForm == null || kitapForm.IsDisposed)
            {
                kitapForm = new KitapEkleForm
                {
                    Text = "Kitap İşlemleri",
                    MdiParent = this
                };
                kitapForm.Show();
            }
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
