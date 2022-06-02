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
            komut.Parameters.AddWithValue("@yazar_id", comboYazar.SelectedValue.ToString());
            komut.Parameters.AddWithValue("@kategori_id", comboKategori.SelectedValue.ToString());
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
            MySqlDataAdapter adtr = new MySqlDataAdapter("SELECT kitapLar.id,kitapLar.adi,kitapLar.sayfa_sayisi,kitapLar.tur,kitapLar.demirBas_no,kitapLar.yayinevi,yazarlar.adi_soyadi,kategori.adi,kitapLar.raf FROM kitapLar INNER JOİN kategori ON kitapLar.kategori_id = kategori.id INNER JOİN  yazarlar  ON kitapLar.yazar_id = yazarlar.id where adi like '%" + txtYayineviAra.Text + "%'", connection);

            adtr.Fill(daset, "kitapLar");
            dataGridView1.DataSource = daset.Tables["kitapLar"];
            connection.Close();





        }

        private void Kitaplar_Form_Load(object sender, EventArgs e)
        {
            #region yazarcombo
            MySqlConnection con = new MySqlConnection("SERVER=172.21.54.3;DATABASE=Lunatic;UID=Lunatic;password=B.batur1316");
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM yazarlar ORDER BY adi_soyadi ASC", con);
            MySqlDataAdapter daYazar = new MySqlDataAdapter(cmd);
            DataSet dsYazar = new DataSet();
            daYazar.Fill(dsYazar);
            cmd.ExecuteNonQuery();
            con.Close();
            comboYazar.DataSource = dsYazar.Tables[0];
            comboYazar.DisplayMember = "adi_soyadi";
            comboYazar.ValueMember = "id";
            #endregion
            con.Open();
            MySqlCommand cmdktgr = new MySqlCommand("SELECT * FROM kategori ORDER BY adi ASC", con);
            MySqlDataAdapter daKategori = new MySqlDataAdapter(cmdktgr);
            DataSet dsKategori = new DataSet();
            daKategori.Fill(dsKategori);
            cmd.ExecuteNonQuery();
            con.Close();
            comboKategori.DataSource = dsKategori.Tables[0];
            comboKategori.DisplayMember = "adi";
            comboKategori.ValueMember = "id";
        }
        

        private void txtKitapAra_TextChanged_1(object sender, EventArgs e)
        {
            daset.Tables["kitapLar"].Clear();
            connection.Open();
            MySqlDataAdapter adtr = new MySqlDataAdapter("SELECT kitapLar.id,kitapLar.adi,kitapLar.sayfa_sayisi,kitapLar.tur,kitapLar.demirBas_no,kitapLar.yayinevi,yazarlar.adi_soyadi,kategori.adi,kitapLar.raf FROM kitapLar INNER JOİN kategori ON kitapLar.kategori_id = kategori.id INNER JOİN  yazarlar  ON kitapLar.yazar_id = yazarlar.id where kitapLar.adi like '%" + txtKitapAra.Text + "%'", connection);

            adtr.Fill(daset, "kitapLar");
            dataGridView1.DataSource = daset.Tables["kitapLar"];
            connection.Close();
        }

        private void txtAdi_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtDemirBas_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Kitaplar_Form_Shown(object sender, EventArgs e)
        {
            Kitap_Listele();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow dgvRow = dataGridView1.Rows[e.RowIndex];
                txtAdi.Text = dgvRow.Cells[1].Value.ToString();
                txtSayfaSayisi.Text = dgvRow.Cells[2].Value.ToString();
                txtTur.Text = dgvRow.Cells[3].Value.ToString();
                txtDemirBas.Text = dgvRow.Cells[4].Value.ToString();
                txtYayinevi.Text = dgvRow.Cells[5].Value.ToString();
                comboYazar.Text = dgvRow.Cells[6].Value.ToString();
                comboKategori.Text = dgvRow.Cells[7].Value.ToString();
                txtRaf.Text = dgvRow.Cells[8].Value.ToString();


            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void btnYazarEkle_Click(object sender, EventArgs e)
        {
            Yazarlar_Form yazarlarForm = new Yazarlar_Form();
            yazarlarForm.ShowDialog();
        }

        private void btnKategoriEkle_Click(object sender, EventArgs e)
        {
            Kategoriler_Form kategorilerForm = new Kategoriler_Form();
            kategorilerForm.ShowDialog();
        }

        private void txtYazarAdiAra_TextChanged(object sender, EventArgs e)
        {
            daset.Tables["kitapLar"].Clear();
            connection.Open();
            MySqlDataAdapter adtr = new MySqlDataAdapter("SELECT kitapLar.id,kitapLar.adi,kitapLar.sayfa_sayisi,kitapLar.tur,kitapLar.demirBas_no,kitapLar.yayinevi,yazarlar.adi_soyadi,kategori.adi,kitapLar.raf FROM kitapLar INNER JOİN kategori ON kitapLar.kategori_id = kategori.id INNER JOİN  yazarlar  ON kitapLar.yazar_id = yazarlar.id where yazarlar.adi_soyadi like '%" + txtYazarAra.Text + "%'", connection);
            adtr.Fill(daset, "kitapLar");
            dataGridView1.DataSource = daset.Tables["kitapLar"];
            connection.Close();
        }

        private void txtYayinEviAra_TextChanged(object sender, EventArgs e)
        {
            daset.Tables["kitapLar"].Clear();
            connection.Open();
            MySqlDataAdapter adtr = new MySqlDataAdapter("select * from kitapLar where yayinevi like '%" + txtYayineviAra.Text + "%'", connection);
            adtr.Fill(daset, "kitapLar");
            dataGridView1.DataSource = daset.Tables["kitapLar"];
            connection.Close();
        }

        private void txtYazarAdiAra_TextChanged_1(object sender, EventArgs e)
        {
            daset.Tables["kitapLar"].Clear();
            connection.Open();
            MySqlDataAdapter adtr = new MySqlDataAdapter("SELECT kitapLar.id,kitapLar.adi,kitapLar.sayfa_sayisi,kitapLar.tur,kitapLar.demirBas_no,kitapLar.yayinevi,yazarlar.adi_soyadi,kategori.adi,kitapLar.raf FROM kitapLar INNER JOİN kategori ON kitapLar.kategori_id = kategori.id INNER JOİN  yazarlar  ON kitapLar.yazar_id = yazarlar.id where adi_soyadi like '%" + txtYazarAra.Text + "%'", connection);
            adtr.Fill(daset, "kitapLar");
            dataGridView1.DataSource = daset.Tables["kitapLar"];
            connection.Close();
        }

        private void txtYayineviAra_TextChanged_1(object sender, EventArgs e)
        {
            daset.Tables["kitapLar"].Clear();
            connection.Open();
            MySqlDataAdapter adtr = new MySqlDataAdapter("SELECT kitapLar.id,kitapLar.adi,kitapLar.sayfa_sayisi,kitapLar.tur,kitapLar.demirBas_no,kitapLar.yayinevi,yazarlar.adi_soyadi,kategori.adi,kitapLar.raf FROM kitapLar INNER JOİN kategori ON kitapLar.kategori_id = kategori.id INNER JOİN  yazarlar  ON kitapLar.yazar_id = yazarlar.id where yayinevi like '%" + txtYayineviAra.Text + "%'", connection);
            adtr.Fill(daset, "kitapLar");
            dataGridView1.DataSource = daset.Tables["kitapLar"];
            connection.Close();
        }

        private void btnYazarEkle_Click_1(object sender, EventArgs e)
        {
            Yazarlar_Form yazarlarForm = new Yazarlar_Form();
            yazarlarForm.ShowDialog();
        }

        private void btnKategoriEkle_Click_1(object sender, EventArgs e)
        {
            Kategoriler_Form kategorilerForm = new Kategoriler_Form();
            kategorilerForm.ShowDialog();
        }
    }
}
