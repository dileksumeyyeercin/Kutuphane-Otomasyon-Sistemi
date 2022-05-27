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
    public partial class Kategoriler_Form : Form
    {

        MySqlConnection baglanti;
        MySqlCommand komut;
        MySqlDataAdapter da;
        public Kategoriler_Form()
        {
            InitializeComponent();
        }
        void KategoriGetir()
        {
            baglanti = new MySqlConnection("SERVER=172.21.54.3;DATABASE=Lunatic;UID=Lunatic;password=B.batur1316");
            baglanti.Open();
            da = new MySqlDataAdapter("SELECT *FROM kategori ", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            string sorgu = ("INSERT INTO kategori (adi) VALUES (@adi)");
            komut = new MySqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@adi", txtAdi.Text);
            baglanti.Open();
            MessageBox.Show(" Eklendi.");
            komut.ExecuteNonQuery();
            baglanti.Close();
            KategoriGetir();
        }

        private void Kategoriler_Form_Load(object sender, EventArgs e)
        {
            KategoriGetir();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            string sorgu = ("DELETE FROM kategori WHERE adi=@adi");
            komut = new MySqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@adi", (txtAdi.Text));
            baglanti.Open();
            MessageBox.Show(" Silindi.");
            komut.ExecuteNonQuery();
            baglanti.Close();
            KategoriGetir();
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {

        }
    }
}
