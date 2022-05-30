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
    public partial class KitapEkle : Form
    {
        public KitapEkle()
        {
            InitializeComponent();
        }
        Kitaplar_Form frm = new Kitaplar_Form();
        MySqlConnection connection = new MySqlConnection("SERVER=172.21.54.3;DATABASE=Lunatic;UID=Lunatic;password=B.batur1316");
        
        private void btnEkle_Click(object sender, EventArgs e)
        {
            
        }

        private void KitapEkle_Load(object sender, EventArgs e)
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

        private void btnEkle_Click_1(object sender, EventArgs e)
        {
            connection.Open();
            MySqlCommand command = new MySqlCommand("INSERT INTO kitapLar (adi,sayfa_sayisi,tur,demirBas_no,yayinevi,yazar_id,kategori_id,raf)  VALUES (@adi, @sayfa_sayisi, @tur, @demirBas_no, @yayinevi,@yazar_id, @kategori_id, @raf) ", connection);

            command.Parameters.AddWithValue("@adi", txtAdi.Text);
            command.Parameters.AddWithValue("@sayfa_sayisi", txtSayfaSayisi.Text);
            command.Parameters.AddWithValue("@tur", txtTur.Text);
            command.Parameters.AddWithValue("@demirBas_no", txtDemirBas.Text);
            command.Parameters.AddWithValue("@yayinevi", txtYayinevi.Text);
            command.Parameters.AddWithValue("@yazar_id", comboYazar.SelectedValue.ToString());
            command.Parameters.AddWithValue("@kategori_id", comboKategori.SelectedValue.ToString());
            command.Parameters.AddWithValue("@raf", txtRaf.Text);
            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("Yeni Kitap Eklendi");
                frm.Kitap_Listele();
            }
            catch (Exception hata )
            {
                MessageBox.Show("Kitap Ekleme Başarısız"+hata.Message);
               
            }
            
            connection.Close();
            
            
        }
    }
}
