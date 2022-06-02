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
    public partial class KaybolanKitaplar_Form : Form
    {
        public KaybolanKitaplar_Form()
        {
            InitializeComponent();
        }
        Kitaplar_Form frm = new Kitaplar_Form();
        MySqlConnection connection = new MySqlConnection("SERVER=172.21.54.3;DATABASE=Lunatic;UID=Lunatic;password=B.batur1316");

        DataSet daset = new DataSet();
        private void KaybolanKitaplar_Form_Load(object sender, EventArgs e)
        {
            
        }
        private void araVeGoster(string sorgu, DataGridView dgv)
        {
            string sql = sorgu;
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            adp.Fill(tbl);
            dgv.DataSource = tbl;
            con.Close();

        }
        public static MySqlConnection GetConnection()
        {
            string sql = "SERVER=172.21.54.3;DATABASE=Lunatic;UID=Lunatic;password=B.batur1316";
            MySqlConnection con = new MySqlConnection(sql);
            try
            {
                con.Open();

            }
            catch (MySqlException excep)
            {
                MessageBox.Show("MySqlConnection!! \n" + excep.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return con;
        }
        public void kayipListele()
        {
            araVeGoster("SELECT kayip.id,kitapLar.adi,kayip.kayipdurum FROM kayip INNER JOİN kitapLar ON  kayip.kitap_id=kitapLar.id ", dataGridView2);
        }
        public void Kitap_Listele()
        {
            connection.Open();
            MySqlDataAdapter adtr = new MySqlDataAdapter("SELECT kitapLar.id,kitapLar.adi,kitapLar.sayfa_sayisi,kitapLar.tur,kitapLar.demirBas_no,kitapLar.yayinevi,yazarlar.adi_soyadi,kategori.adi,kitapLar.raf FROM kitapLar INNER JOİN kategori ON kitapLar.kategori_id = kategori.id INNER JOİN  yazarlar  ON kitapLar.yazar_id = yazarlar.id", connection);
            adtr.Fill(daset, "kitapLar");
            dataGridView1.DataSource = daset.Tables["kitapLar"];
            connection.Close();
        }
        private void txtKitapAra_TextChanged(object sender, EventArgs e)
        {
            daset.Tables["kitapLar"].Clear();
            connection.Open();
            MySqlDataAdapter adtr = new MySqlDataAdapter("select * from kitapLar where adi like '%" + txtKitapAra.Text + "%'", connection);
            adtr.Fill(daset, "kitapLar");
            dataGridView1.DataSource = daset.Tables["kitapLar"];
            connection.Close();
        }

        private void KaybolanKitaplar_Form_Shown(object sender, EventArgs e)
        {
            Kitap_Listele();
            kayipListele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("SERVER=172.21.54.3;DATABASE=Lunatic;UID=Lunatic;password=B.batur1316");
            con.Open();
            MySqlCommand cmd = new MySqlCommand("INSERT INTO kayip(kayip.kitap_id) VALUES (@kitap_id)",con);
            cmd.Parameters.AddWithValue("@kitap_id",dataGridView1.CurrentRow.Cells[0].Value);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Kayıp Kitap Olarak Belirlendi");
                kayipListele();
            }
            catch (Exception hata)
            {

                MessageBox.Show("Kayıp kitap tablosuna eklenmedi" + hata.Message);
            }
            con.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("SERVER=172.21.54.3;DATABASE=Lunatic;UID=Lunatic;password=B.batur1316");
            string sorgu = "UPDATE kayip SET kayipdurum='Kitap Bulundu' WHERE id =@id";
            con.Open();
            MySqlCommand command = new MySqlCommand(sorgu, con);
            command.Parameters.AddWithValue("@id", dataGridView2.CurrentRow.Cells[0].Value);
            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("Kitap Bulundu");
                kayipListele();
            }
            catch (Exception msj)
            {
                MessageBox.Show("Kitap geri alma başarısız " + msj.Message);

            }
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sql = "DELETE FROM kayip WHERE id = @id";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@id", dataGridView2.CurrentRow.Cells[0].Value);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Kayıp Kitap Veri Tabanından Silindi");
                kayipListele();

            }
            catch (Exception ex)
            {

                MessageBox.Show("Hata" + ex.Message);
            }
            con.Close();
        }
    }
}

