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

        private void KaybolanKitaplar_Form_Load(object sender, EventArgs e)
        {
            
        }
    }
}

