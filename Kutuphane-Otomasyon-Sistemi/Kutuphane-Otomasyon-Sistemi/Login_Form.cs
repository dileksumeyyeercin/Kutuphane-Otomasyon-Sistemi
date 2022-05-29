using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kutuphane_Otomasyon_Sistemi
{
    public partial class Login_Form : Form
    {
        public Login_Form()
        {
            InitializeComponent();
        }

        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            string gelenAd = txtKullaniciAdi.Text;
            string gelenSifre = txtSifre.Text;
            if (gelenAd.Equals("admin") && gelenSifre.Equals("123"))
            {
                MessageBox.Show(text: "Başarılı");
               
            }
            else
            {
                MessageBox.Show(text: "Kullanıcı adı veya şifre hatalı!");
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void txtSifre_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtKullaniciAdi_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void Sifre_Click(object sender, EventArgs e)
        {

        }

        private void KullaniciAdi_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void KuOShG_Click(object sender, EventArgs e)
        {

        }

        private void Login_Form_Load(object sender, EventArgs e)
        {

        }
    }
}
