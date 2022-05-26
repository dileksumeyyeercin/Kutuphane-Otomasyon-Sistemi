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
    public partial class Personel_Form : Form
    {
        MySqlConnection baglanti;
        MySqlCommand komut;
        MySqlDataAdapter da;
        public Personel_Form()
        {
            InitializeComponent();
        }
        void PersonelGetir()
        {
            baglanti = new MySqlConnection("SERVER=172.21.54.3;DATABASE=Lunatic;UID=Lunatic;password=B.batur1316");
            baglanti.Open();
            da = new MySqlDataAdapter("SELECT *FROM personel ", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }

        private void Personel_Form_Load(object sender, EventArgs e)
        {
            PersonelGetir();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            string sorgu = ("INSERT INTO personel (adi,soyadi,telefon,kullanici_adi,sifre) VALUES (@adi,@soyadi,@telefon,@kullanici_adi,@sifre)");
            komut = new MySqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@adi", txtAd.Text);
            komut.Parameters.AddWithValue("@soyadi", txtSoyad.Text);
            komut.Parameters.AddWithValue("@telefon", txtTelefon.Text);
            komut.Parameters.AddWithValue("@kullanici_adi", txtKadi.Text);
            komut.Parameters.AddWithValue("@sifre", txtSifre.Text);
            baglanti.Open();
            MessageBox.Show("Kullanıcı Eklendi.");
            komut.ExecuteNonQuery();
            baglanti.Close();
            PersonelGetir();
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            string sorgu = "UPDATE personel SET adi=@adi,soyadi=@soyadi,telefon=@telefon,sifre=@sifre WHERE kullanici_adi=@kullanici_adi";
            komut = new MySqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@kullanici_adi", Convert.ToString(txtKadi.Text));
            komut.Parameters.AddWithValue("@adi", txtAd.Text);
            komut.Parameters.AddWithValue("@soyadi", txtSoyad.Text);
            komut.Parameters.AddWithValue("@telefon", txtTelefon.Text);
            komut.Parameters.AddWithValue("@sifre", txtSifre.Text);
            baglanti.Open();
            MessageBox.Show("Kullanıcı Güncellendi.");
            komut.ExecuteNonQuery();
            baglanti.Close();
            PersonelGetir();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            string sorgu = ("DELETE FROM personel WHERE kullanici_adi=@kullanici_adi");
            komut = new MySqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@kullanici_adi", Convert.ToString(txtKadi.Text));
            baglanti.Open();
            MessageBox.Show("Kullanıcı Silindi.");
            komut.ExecuteNonQuery();
            baglanti.Close();
            PersonelGetir();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtAd.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtSoyad.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtTelefon.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtKadi.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtSifre.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }
    }
}
