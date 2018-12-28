namespace KutuphaneOtomasyonuCF
{
    partial class AnaSayfa
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.işlemlerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ödünçİşlemleriToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.üyeİşlemleriToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.kitapİşlemleriToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.çıkışToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.işlemlerToolStripMenuItem,
            this.çıkışToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // işlemlerToolStripMenuItem
            // 
            this.işlemlerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ödünçİşlemleriToolStripMenuItem1,
            this.üyeİşlemleriToolStripMenuItem1,
            this.kitapİşlemleriToolStripMenuItem1});
            this.işlemlerToolStripMenuItem.Name = "işlemlerToolStripMenuItem";
            this.işlemlerToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.işlemlerToolStripMenuItem.Text = "İşlemler";
            // 
            // ödünçİşlemleriToolStripMenuItem1
            // 
            this.ödünçİşlemleriToolStripMenuItem1.Name = "ödünçİşlemleriToolStripMenuItem1";
            this.ödünçİşlemleriToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.ödünçİşlemleriToolStripMenuItem1.Text = "Ödünç İşlemleri";
            this.ödünçİşlemleriToolStripMenuItem1.Click += new System.EventHandler(this.ödünçİşlemleriToolStripMenuItem1_Click);
            // 
            // üyeİşlemleriToolStripMenuItem1
            // 
            this.üyeİşlemleriToolStripMenuItem1.Name = "üyeİşlemleriToolStripMenuItem1";
            this.üyeİşlemleriToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.üyeİşlemleriToolStripMenuItem1.Text = "Üye İşlemleri";
            this.üyeİşlemleriToolStripMenuItem1.Click += new System.EventHandler(this.üyeİşlemleriToolStripMenuItem1_Click);
            // 
            // kitapİşlemleriToolStripMenuItem1
            // 
            this.kitapİşlemleriToolStripMenuItem1.Name = "kitapİşlemleriToolStripMenuItem1";
            this.kitapİşlemleriToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.kitapİşlemleriToolStripMenuItem1.Text = "Kitap İşlemleri";
            this.kitapİşlemleriToolStripMenuItem1.Click += new System.EventHandler(this.kitapİşlemleriToolStripMenuItem1_Click);
            // 
            // çıkışToolStripMenuItem
            // 
            this.çıkışToolStripMenuItem.Name = "çıkışToolStripMenuItem";
            this.çıkışToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.çıkışToolStripMenuItem.Text = "Çıkış";
            this.çıkışToolStripMenuItem.Click += new System.EventHandler(this.çıkışToolStripMenuItem_Click);
            // 
            // AnaSayfa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::KutuphaneOtomasyonuCF.Properties.Resources.pexels_photo_12064;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "AnaSayfa";
            this.Text = "Kütüphane Otomasyonu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem işlemlerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ödünçİşlemleriToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem üyeİşlemleriToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem kitapİşlemleriToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem çıkışToolStripMenuItem;
    }
}