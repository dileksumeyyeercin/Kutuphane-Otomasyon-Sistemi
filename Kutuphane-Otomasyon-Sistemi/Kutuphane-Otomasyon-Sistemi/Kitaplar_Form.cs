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
    public partial class Kitaplar_Form : Form
    {
        public Kitaplar_Form()
        {
            InitializeComponent();

        }
        MySqlConnection connection = new MySqlConnection("SERVER=172.21.54.3;DATABASE=Lunatic;UID=Lunatic;password=B.batur1316");
        DataSet daset = new DataSet();

        

        public void Kitap_Listele()
        {
            connection.Open();
            MySqlDataAdapter adtr = new MySqlDataAdapter("SELECT kitapLar.id,kitapLar.adi,kitapLar.sayfa_sayisi,kitapLar.tur,kitapLar.demirBas_no,kitapLar.yayinevi,yazarlar.adi_soyadi,kategori.adi,kitapLar.raf FROM kitapLar INNER JOİN kategori ON kitapLar.kategori_id = kategori.id INNER JOİN  yazarlar  ON kitapLar.yazar_id = yazarlar.id", connection);
            adtr.Fill(daset, "kitapLar");
            dataGridView1.DataSource = daset.Tables["kitapLar"];
            connection.Close();
        }
        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            connection.Open();
            MySqlCommand komut = new MySqlCommand("update kitapLar set  sayfa_sayisi=@sayfa_sayisi, tur=@tur,demirBas_no=@demirBas_no, yayinevi=@yayinevi, yazar_id=@yazar_id, kategori_id=@kategori_id, raf=@raf where adi=@adi", connection);
            komut.Parameters.AddWithValue("@adi", txtAdi.Text);
            komut.Parameters.AddWithValue("@sayfa_sayisi", txtSayfaSayisi.Text);
            komut.Parameters.AddWithValue("@tur", txtTur.Text);
            komut.Parameters.AddWithValue("@demirBas_no", txtDemirBas.Text);
            komut.Parameters.AddWithValue("@yayinevi", txtYayinevi.Text);
            komut.Parameters.AddWithValue("@yazar_id", comboYazar.Text);
            komut.Parameters.AddWithValue("@kategori_id", comboKategori.Text);
            komut.Parameters.AddWithValue("@raf", txtRaf.Text);
            komut.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Kitap Güncellendi.");
            daset.Tables["kitapLar"].Clear();
            Kitap_Listele();
            foreach (Control item in Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            KitapEkle kitapEkle = new KitapEkle();
            kitapEkle.ShowDialog();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            string sql = "DELETE FROM kitapLar WHERE id =@id";
            MySqlConnection con = new MySqlConnection("SERVER = 172.21.54.3; DATABASE = Lunatic; UID = Lunatic; password = B.batur1316");
            con.Open();
            MySqlCommand cmd = new MySqlCommand(sql, con);

            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@id", dataGridView1.CurrentRow.Cells[0].Value);
            try
            {
                cmd.ExecuteNonQuery();

                MessageBox.Show("Kitap Silindi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Kitap_Listele();

            }
            catch (Exception ex)
            {

                MessageBox.Show("Kitap Silinirken Hata" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }

        private void txtKitapAra_TextChanged(object sender, EventArgs e)
        {
            daset.Tables["kitapLar"].Clear();
            connection.Open();
            MySqlDataAdapter adtr = new MySqlDataAdapter("select *from kitapLar where adi like '%" + txtAdi.Text + "%'", connection);
            adtr.Fill(daset, "kitapLar");
            dataGridView1.DataSource = daset.Tables["kitapLar"];
            connection.Close();





        }

        private void Kitaplar_Form_Load(object sender, EventArgs e)
        {
          
        }

        private void txtKitapAra_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void txtAdi_TextChanged(object sender, EventArgs e)
        {
            connection.Open();
            MySqlCommand komut = new MySqlCommand("select *from kitapLar where adi like'" + txtKitapAra.Text + "'", connection);
            MySqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                
                txtSayfaSayisi.Text = read["sayfa_sayisi"].ToString();
                txtTur.Text = read["tur"].ToString();
                txtDemirBas.Text = read["demirBas_no"].ToString();
                txtYayinevi.Text = read["yayinevi"].ToString();
                comboYazar.Text = read["yazar_id"].ToString();
                comboKategori.Text = read["kategori_id"].ToString();
                txtRaf.Text = read["raf"].ToString();

            }
            connection.Close();
        }

        private void txtDemirBas_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Kitaplar_Form_Shown(object sender, EventArgs e)
        {
            Kitap_Listele();
        }
    }
}
