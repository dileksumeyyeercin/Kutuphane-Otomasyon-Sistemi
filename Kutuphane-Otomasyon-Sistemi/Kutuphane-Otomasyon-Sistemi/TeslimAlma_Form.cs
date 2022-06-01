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
    public partial class TeslimAlma_Form : Form
    {
        public TeslimAlma_Form()
        {
            InitializeComponent();
        }
        MySqlConnection con = new MySqlConnection("server = 172.21.54.3; user id = Lunatic; password = B.batur1316; database = Lunatic");
        DataSet daset = new DataSet();

        private void TeslimAlma_Form_Load(object sender, EventArgs e)
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

        private void btniptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTeslimAl_Click(object sender, EventArgs e)
        {

        }

        private void btniptal_Click_1(object sender, EventArgs e)
        {
            this.Close();
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
        private void kitapAlmaListe()
        {
            araVeGoster("SELECT kitap_alma.id,kitap_alma.almatarihi,kitap_alma.teslimtarihi,kitapLar.adi,kitap_alma.okul_no,kitap_alma.teslimDurum FROM kitap_alma INNER JOİN kitapLar ON kitap_alma.kitap_id=kitapLar.id",dataGridView1);
        }
        private void btnTeslimAl_Click_1(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("SERVER=172.21.54.3;DATABASE=Lunatic;UID=Lunatic;password=B.batur1316");
            string sorgu = "UPDATE kitap_alma SET teslimDurum='Teslim Edildi' WHERE id =@id";
            MySqlCommand command = new MySqlCommand(sorgu, con);
            con.Open();
            command.Parameters.AddWithValue("@id", dataGridView1.CurrentRow.Cells[0].Value);
            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("Teslim İşlemi Başarılı");
                kitapAlmaListe();
               
            }
            catch (Exception msj)
            {
                MessageBox.Show("Teslim İşlemi Başarısız" + msj.Message);

            }
            con.Close();
        }

        private void TeslimAlma_Form_Shown(object sender, EventArgs e)
        {
            kitapAlmaListe();
        }
       private void teslimListele()
        {
            araVeGoster("SELECT `id`, `almatarihi`, `teslimtarihi`, `kitap_id`, `okul_no`, `teslimDurum` FROM `kitap_alma` WHERE okul_no LIKE '%"+txtAra.Text+"%'", dataGridView1);
        }

        


        


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            teslimListele();
        }
    }
}
