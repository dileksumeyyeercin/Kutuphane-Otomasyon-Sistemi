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
using MySql.Data;

namespace Kutuphane_Otomasyon_Sistemi
{
    public partial class KitapAlma_Form : Form
    {
        public KitapAlma_Form()
        {
            InitializeComponent();
        }
      
        private void KitapAlma_Form_Load(object sender, EventArgs e)
        {
           

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

        private void araVeGoster(string sorgu,DataGridView dgv)
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

        private void uyeGoster()
        {
            araVeGoster("SELECT okul_no, adi, soyadi, telefon, email, cinsiyet FROM uyeler", dataGridView1);
        }
        private void kitapGoster()
        {
            araVeGoster("SELECT kitapLar.id,kitapLar.adi,kitapLar.sayfa_sayisi,kitapLar.tur,kitapLar.demirBas_no,kitapLar.yayinevi,yazarlar.adi_soyadi,kategori.adi,kitapLar.raf FROM kitapLar INNER JOİN kategori ON kitapLar.kategori_id = kategori.id INNER JOİN  yazarlar  ON kitapLar.yazar_id = yazarlar.id",dataGridView2);
        } 
        
        private void btnİptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       

        private void btnEkle_Click(object sender, EventArgs e)
        {
            
                    
           
        }

        private void txtOkulNo_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtDemirbasNo_TextChanged(object sender, EventArgs e)
        {
            
            
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
           
        }

        private void btnTeslimEt_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void KitapAlma_Form_Shown(object sender, EventArgs e)
        {
            uyeGoster();
            kitapGoster();
        }

        private void btnEmanetEt_Click(object sender, EventArgs e)
        {
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand("INSERT INTO `kitap_alma`(`almatarihi`, `teslimtarihi`, `kitap_id`, `okul_no`) VALUES (@almatarihi,@teslimtarihi,@kitap_id,@okul_no)", con);
            cmd.Parameters.AddWithValue("@almatarihi", dateTimePicker1.Text);
            cmd.Parameters.AddWithValue("@teslimtarihi", dateTimePicker2.Text);
            cmd.Parameters.AddWithValue("@kitap_id", dataGridView2.CurrentRow.Cells[0].Value);
            cmd.Parameters.AddWithValue("@okul_no", dataGridView1.CurrentRow.Cells[0].Value);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Emanet Verme İşelmi Başarılı", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            catch (Exception msg)
            {

                MessageBox.Show("Emanet Verme İşlemi Başarısız\n" + msg.Message);
            }

            con.Close();
        }
    }
    }

