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

        private void btniptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTeslimAl_Click(object sender, EventArgs e)
        {

        }
    }
}
