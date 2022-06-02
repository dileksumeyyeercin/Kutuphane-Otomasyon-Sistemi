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
            MySqlCommand komut2 = new MySqlCommand("Select Count(*) from kitap_alma", con);
            MySqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                emntktp_lbl.Text = dr2[0].ToString();
            }
            con.Close();

            con.Open();
            MySqlDataAdapter komut3 = new MySqlDataAdapter("select kitapLar.adi from kitap_alma inner join kitapLar on kitap_alma.kitap_id = kitapLar.id GROUP BY kitap_alma.kitap_id ORDER BY Count(kitap_id) desc limit 8", con);
            DataTable dt = new DataTable();
            komut3.Fill(dt);
            encokokunan_dgv.DataSource = dt;
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
            MySqlDataAdapter komut6 = new MySqlDataAdapter("select kitapLar.tur from kitap_alma inner join kitapLar on kitap_alma.kitap_id = kitapLar.id GROUP BY kitap_alma.kitap_id ORDER BY Count(kitap_id) desc limit 1", con);
            DataTable dt2 = new DataTable();
            komut6.Fill(dt2);
            encokokunanktpturu_dgv.DataSource = dt2;
            con.Close();

            con.Open();
            MySqlDataAdapter komut7 = new MySqlDataAdapter("select yazarlar.adi_soyadi from kitap_alma inner join yazarlar on kitap_alma.kitap_id = yazarlar.id GROUP BY kitap_alma.kitap_id ORDER BY Count(kitap_id) desc limit 2", con);
            DataTable dt3 = new DataTable();
            komut7.Fill(dt3);

            encokokunanyzr_dgv.DataSource = dt3;
            con.Close();
        }


       
    }
}
