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
    public partial class UyeListeleme_Form : Form
    {
        public UyeListeleme_Form()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtOKulNo.Text = dataGridView1.CurrentRow.Cells["okul_no"].Value.ToString();
        }
        MySqlConnection baglanti = new MySqlConnection("SERVER=172.21.54.3;DATABASE=Lunatic;UID=Lunatic;password=B.batur1316");
        private void txtOKulNo_TextChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            MySqlCommand komut = new MySqlCommand("select *from uyeler where okul_no like '" +txtOKulNo.Text+ "'", baglanti);
            MySqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                txtAd.Text = read["adi"].ToString();
                txtSoyad.Text = read["soyadi"].ToString();
                txtTelefon.Text = read["telefon"].ToString();
                txtMail.Text = read["email"].ToString();
                comboBox1.Text = read["cinsiyet"].ToString();
            }
            baglanti.Close();
        }
        DataSet daset = new DataSet();

        private void txtOkulNoAra_TextChanged(object sender, EventArgs e)
        {
            daset.Tables["uyeler"].Clear();
            baglanti.Open();
            MySqlDataAdapter adtr = new MySqlDataAdapter("select *from uyeler where okul_no like '%" + txtOkulNoAra.Text + "%'", baglanti);
            adtr.Fill(daset, "uyeler");
            dataGridView1.DataSource = daset.Tables["uyeler"];
            baglanti.Close();

        }

        private void btnİptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            MySqlCommand komut = new MySqlCommand("delete from uyeler where okul_no=@okul_no", baglanti);
            komut.Parameters.AddWithValue("@okul_no", dataGridView1.CurrentRow.Cells["okul_no"].Value.ToString());
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Üye Silindi.");
            daset.Tables["uyeler"].Clear();
            uyelistele();
            foreach (Control item in Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }

        }
        private void uyelistele()
        {
            baglanti.Open();
            MySqlDataAdapter adtr = new MySqlDataAdapter("select *from uyeler", baglanti);
            adtr.Fill(daset, "uyeler");
            dataGridView1.DataSource = daset.Tables["uyeler"];
            baglanti.Close();
        }

        private void UyeListeleme_Form_Load(object sender, EventArgs e)
        {
            uyelistele();
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            MySqlCommand komut = new MySqlCommand("update uyeler set adi=@adi,soyadi=@soyadi,telefon=@telefon,email=@email,cinsiyet=@cinsiyet WHERE okul_no=@okul_no", baglanti);
            komut.Parameters.AddWithValue("@okul_no",(txtOKulNo.Text));
            komut.Parameters.AddWithValue("@adi", txtAd.Text);
            komut.Parameters.AddWithValue("@soyadi", txtSoyad.Text);
            komut.Parameters.AddWithValue("@telefon", txtTelefon.Text);
            komut.Parameters.AddWithValue("@email", txtMail.Text);
            komut.Parameters.AddWithValue("@cinsiyet", comboBox1.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            daset.Tables["uyeler"].Clear();
            uyelistele();
            foreach (Control item in Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
