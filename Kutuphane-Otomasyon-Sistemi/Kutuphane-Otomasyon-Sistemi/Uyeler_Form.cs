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
using System.Data.SqlClient;

namespace Kutuphane_Otomasyon_Sistemi
{
    public partial class Uyeler_Form : Form
    {
        public Uyeler_Form()
        {
            InitializeComponent();
        }

        private void Uyeler_Form_Load(object sender, EventArgs e)
        {

        }
        MySqlConnection baglanti = new MySqlConnection("SERVER=172.21.54.3;DATABASE=Lunatic;UID=Lunatic;password=B.batur1316");

        private void btnİptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
           
            MySqlCommand komut = new MySqlCommand ("INSERT INTO uyeler (okul_no,adi,soyadi,telefon,email,cinsiyet) VALUES (@okul_no,@adi,@soyadi,@telefon,@email,@cinsiyet)",baglanti);
            baglanti.Open();
            komut.Parameters.AddWithValue("@okul_no", txtOKulNo.Text);
            komut.Parameters.AddWithValue("@adi", txtAd.Text);
            komut.Parameters.AddWithValue("@soyadi", txtSoyad.Text);
            komut.Parameters.AddWithValue("@telefon", txtTelefon.Text);
            komut.Parameters.AddWithValue("@email", txtMail.Text);
            komut.Parameters.AddWithValue("@cinsiyet", comboBox1.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Yeni Üye Eklendi.");
            foreach (Control item in Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            UyeListeleme_Form uyeListeleme = new UyeListeleme_Form();
            uyeListeleme.ShowDialog();
        }
    }
}
