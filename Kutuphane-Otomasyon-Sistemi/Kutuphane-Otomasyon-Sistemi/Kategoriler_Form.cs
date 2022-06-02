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

            MySqlDataAdapter adtr = new MySqlDataAdapter("select *from kategori", baglanti);
            adtr.Fill(daset, "kategori");
            dataGridView1.DataSource = daset.Tables["kategori"];
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

        private void label2_Click(object sender, EventArgs e)
        {

        }
        DataSet daset = new DataSet();

        private void txtAra_TextChanged(object sender, EventArgs e)
        {
            daset.Tables["kategori"].Clear();
            baglanti.Open();
            MySqlDataAdapter adtr = new MySqlDataAdapter("select *from kategori where adi like '%" + txtAra.Text + "%'", baglanti);
            adtr.Fill(daset, "kategori");
            dataGridView1.DataSource = daset.Tables["kategori"];
            baglanti.Close();
        }

        private void txtAdi_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
