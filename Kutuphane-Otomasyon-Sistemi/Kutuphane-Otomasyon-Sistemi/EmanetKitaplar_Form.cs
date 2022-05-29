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
    public partial class EmanetKitaplar_Form : Form
    {
        public EmanetKitaplar_Form()
        {
            InitializeComponent();
        }
        MySqlConnection baglanti;
        MySqlCommand komut;
        MySqlDataAdapter da;
        private void label1_Click(object sender, EventArgs e)
        {

        }
        void EmanetListele()
        {
            baglanti = new MySqlConnection("SERVER=172.21.54.3;DATABASE=Lunatic;UID=Lunatic;password=B.batur1316");
            baglanti.Open();
            da = new MySqlDataAdapter("SELECT * FROM kitap_alma", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }

        private void EmanetKitaplar_Form_Load(object sender, EventArgs e)
        {
            EmanetListele();
            comboBox1.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Tüm Kitaplar");
            comboBox1.Items.Add("Geciken Kitaplar");
            comboBox1.Items.Add("Gecikmeyen Kitaplar");
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
                        
            if (comboBox1.SelectedIndex==0)
            {
                EmanetListele();
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                baglanti.Open();
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                baglanti.Open();
            }
        }
    }
}
