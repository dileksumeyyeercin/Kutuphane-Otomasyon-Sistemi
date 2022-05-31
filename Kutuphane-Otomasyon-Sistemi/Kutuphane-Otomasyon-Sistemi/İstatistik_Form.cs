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
    public partial class İstatistik_Form : Form
    {
        public İstatistik_Form()
        {
            InitializeComponent();
        }
        MySqlConnection con = new MySqlConnection("server = 172.21.54.3; user id = Lunatic; password = B.batur1316; database = Lunatic");
        
        private void İstatistik_Form_Load(object sender, EventArgs e)
        {
            con.Open();
            MySqlCommand komut1 = new MySqlCommand("Select Count(*) from kitapLar", con);
            MySqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                tplmktp_Lbl.Text = dr1[0].ToString();
            }
            con.Close();

            con.Open();
            MySqlCommand komut2 = new MySqlCommand("Select Count(*) from kaybolan_kitaplar", con);
            MySqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                kyblnktp_Lbl.Text = dr2[0].ToString();
            }
            con.Close();

            con.Open();
            MySqlCommand komut3 = new MySqlCommand("Select Count(okul_no),kitap_id from kitap_alma group by kitap_id order by Count(okul_no) desc", con);
            MySqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                oknnktp_Lb.Items.Add(dr3["kitap_id"]);
            }
            con.Close();

            con.Open();
            MySqlCommand komut4 = new MySqlCommand("Select Count(*) from uyeler", con);
            MySqlDataReader dr4 = komut4.ExecuteReader();
            while (dr4.Read())
            {
                tplmuye_Lbl.Text = dr4[0].ToString();
            }
            con.Close();

            con.Open();
            MySqlCommand komut5 = new MySqlCommand("Select Count(*) from personel", con);
            MySqlDataReader dr5 = komut5.ExecuteReader();
            while (dr5.Read())
            {
                tplmprsnl_Lbl.Text = dr5[0].ToString();
            }
            con.Close();

            con.Open();
            MySqlCommand komut6 = new MySqlCommand("Select Count(okul_no),okul_no from kitap_alma group by okul_no order by Count(okul_no) desc", con);
            MySqlDataReader dr6 = komut3.ExecuteReader();
            while (dr6.Read())
            {
                oknnktp_Lb.Items.Add(dr6[0]);
            }
            con.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
