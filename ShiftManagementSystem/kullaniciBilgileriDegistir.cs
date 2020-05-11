using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ShiftManagementSystem
{
    public partial class kullaniciBilgileriDegistir : Form
    {
        SqlConnection baglanti;
        SqlCommand komut;
        SqlDataAdapter da;
        public kullaniciBilgileriDegistir()
        {
            InitializeComponent();
        }

        private void kullaniciBilgileriDegistir_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'dBDataSet.tbl_Login' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.tbl_LoginTableAdapter.Fill(this.dBDataSet.tbl_Login);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            kullaniciSayfasi kullaniciSayfasi = new kullaniciSayfasi();
            this.Hide();
            kullaniciSayfasi.Show();
        }

        private void btn_register_Click(object sender, EventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DKE10017\source\repos\ShiftManagementSystem\ShiftManagementSystem\db\DB.mdf;Integrated Security=True;Connect Timeout=30");
            string sorgu = "UPDATE tbl_Login SET username=@username,password=@password,ad=@ad,soyad=@soyad,eposta=@eposta,telefon=@telefon";
            komut = new SqlCommand(sorgu, sqlcon);
            komut.Parameters.AddWithValue("@username", txt_username.Text);
            komut.Parameters.AddWithValue("@password", txt_password.Text);
            komut.Parameters.AddWithValue("@ad", txt_ad.Text);
            komut.Parameters.AddWithValue("@soyad", txt_soyad.Text);
            komut.Parameters.AddWithValue("@eposta", txt_eposta.Text);
            komut.Parameters.AddWithValue("@telefon", txt_telefon.Text);
            sqlcon.Open();
            komut.ExecuteNonQuery();
            sqlcon.Close();
            MessageBox.Show("Başarıyla Değişiklik Gerçekleştirildi");
        }
    }
}
