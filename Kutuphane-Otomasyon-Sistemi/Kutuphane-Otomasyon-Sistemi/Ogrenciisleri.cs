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
    public partial class Ogrenciisleri : Form
    {
        public Ogrenciisleri()
        {
            InitializeComponent();
        }
        DataSet daset = new DataSet();

        MySqlConnection baglanti = new MySqlConnection("SERVER=172.21.54.3;DATABASE=Lunatic;UID=Lunatic;password=B.batur1316");

        public int Kontrol(string Sorgu)
        {
            MySqlConnection baglanti = new MySqlConnection("SERVER=172.21.54.3;DATABASE=Lunatic;UID=Lunatic;password=B.batur1316");
            int control;
            baglanti.Open();
            MySqlCommand cmd = new MySqlCommand(Sorgu, baglanti);
            control = Convert.ToInt32(cmd.ExecuteScalar());
            baglanti.Close();
            return control;
        }
        private void araVeGoster(string sorgu, DataGridView dgv)
        {
            string sql = sorgu;
            MySqlCommand cmd = new MySqlCommand(sql, baglanti);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            adp.Fill(tbl);
            dgv.DataSource = tbl;
            baglanti.Close();

        }
        private void kitapAlmaListe()
        {
            araVeGoster("SELECT kitap_alma.id,kitap_alma.almatarihi,kitap_alma.teslimtarihi,kitapLar.adi,kitap_alma.okul_no,kitap_alma.teslimDurum FROM kitap_alma INNER JOİN kitapLar ON kitap_alma.kitap_id=kitapLar.id", dataGridView2);
        }
        private void Ogrenciisleri_Load(object sender, EventArgs e)
        {

        }
        private void teslimListele()
        {
            araVeGoster("SELECT `id`, `almatarihi`, `teslimtarihi`, `kitap_id`, `okul_no`, `teslimDurum` FROM `kitap_alma` WHERE okul_no LIKE '%" + textBox1.Text + "%'", dataGridView2);
        }

        private void uyeGoster()
        {
            baglanti.Open();
            MySqlDataAdapter adtr = new MySqlDataAdapter("select *from uyeler", baglanti);
            adtr.Fill(daset, "uyeler");
            dataGridView1.DataSource = daset.Tables["uyeler"];
            baglanti.Close();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            daset.Tables["uyeler"].Clear();
            baglanti.Open();
            MySqlDataAdapter adtr = new MySqlDataAdapter("select *from uyeler where okul_no like '%" + textBox1.Text + "%'", baglanti);
            adtr.Fill(daset, "uyeler");
            dataGridView1.DataSource = daset.Tables["uyeler"];
            baglanti.Close();

            teslimListele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            MySqlCommand komut = new MySqlCommand("delete from uyeler where okul_no=@okul_no", baglanti);
            komut.Parameters.AddWithValue("@okul_no", dataGridView1.CurrentRow.Cells[0].Value.ToString());
            komut.ExecuteNonQuery();
            baglanti.Close();
            daset.Tables["uyeler"].Clear();
            uyeGoster();
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
            string sql = "DELETE FROM kitap_alma WHERE id = @id";
            baglanti.Open();
            MySqlCommand cmd = new MySqlCommand(sql, baglanti);
            cmd.Parameters.AddWithValue("id", dataGridView2.CurrentRow.Cells[0].Value);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Odünç Alma İşlemi Veri Tabanından Silindi");
                kitapAlmaListe();

            }
            catch (Exception ex)
            {

                MessageBox.Show("Hata" + ex.Message);
            }
            baglanti.Close();
        }

        private void Ogrenciisleri_Shown(object sender, EventArgs e)
        {
            uyeGoster();
            kitapAlmaListe();
        }
    }
}
