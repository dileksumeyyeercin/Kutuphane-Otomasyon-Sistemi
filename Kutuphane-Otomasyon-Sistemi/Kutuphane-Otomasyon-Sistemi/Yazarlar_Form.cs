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
    public partial class Yazarlar_Form : Form
    {
        MySqlConnection baglanti;
        MySqlCommand komut;
        MySqlDataAdapter da;


        public Yazarlar_Form()
        {
            InitializeComponent();
        }

        void YazarGetir()
        {
            baglanti = new MySqlConnection("SERVER=172.21.54.3;DATABASE=Lunatic;UID=Lunatic;password=B.batur1316");
            baglanti.Open();
            da = new MySqlDataAdapter("SELECT * FROM yazarlar", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();  
        }

        private void Yazarlar_Form_Load(object sender, EventArgs e)
        {
            YazarGetir();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            string sorgu = ("INSERT INTO yazarlar (adi_soyadi) VALUES (@adi_soyadi)");
            komut = new MySqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@adi_soyadi", txtAdSoyad.Text);
            baglanti.Open();
            MessageBox.Show("Yazar Eklendi.");
            komut.ExecuteNonQuery();
            baglanti.Close();
            YazarGetir();
        }
        
        private void btnSil_Click(object sender, EventArgs e)
        {
            string sorgu = "DELETE FROM yazarlar WHERE adi_soyadi=@adi_soyadi";
            komut = new MySqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@adi_soyadi", Convert.ToString(txtAdSoyad.Text));
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            YazarGetir();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            string sorgu = "UPDATE yazarlar SET adi_soyadi=@adi_soyadi WHERE id=@id";
            komut = new MySqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@id", Convert.ToInt32(txtId.Text));
            komut.Parameters.AddWithValue("@adi_soyadi", txtAdSoyad.Text);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            YazarGetir();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtAdSoyad.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();

        }

        
    }
}
