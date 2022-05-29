using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Kutuphane_Otomasyon_Sistemi
{
    public partial class Anasayfa_Form : Form
    {
        public Anasayfa_Form()
        {
            InitializeComponent();
        }

        private void Anasayfa_Form_Load(object sender, EventArgs e)
        {

        }

        private void btnKitaplar_Click(object sender, EventArgs e)
        {
            Kitaplar_Form kitaplar = new Kitaplar_Form();
            kitaplar.ShowDialog();
        }

        private void btnUye_Click(object sender, EventArgs e)
        {
            Uyeler_Form uyeler = new Uyeler_Form();
            uyeler.ShowDialog();
        }

        private void btnTeslim_Click(object sender, EventArgs e)
        {
            KitapAlma_Form teslim = new KitapAlma_Form();
            teslim.ShowDialog();
        }

        private void btnEmanet_Click(object sender, EventArgs e)
        {
            EmanetKitaplar_Form emanetKitaplar = new EmanetKitaplar_Form();
            emanetKitaplar.ShowDialog();
        }

        private void btnPersonelKayit_Click(object sender, EventArgs e)
        {
            Personel_Form personelForm = new Personel_Form();
            personelForm.ShowDialog();
        }
    }
}
