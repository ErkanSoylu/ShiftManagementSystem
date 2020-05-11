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
    public partial class kayitOl : Form
    {
        SqlConnection baglanti;
        SqlCommand komut;
        SqlDataAdapter da;
        public kayitOl()
        {
            InitializeComponent();
        }

        private void btn_register_Click(object sender, EventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DKE10017\source\repos\ShiftManagementSystem\ShiftManagementSystem\db\DB.mdf;Integrated Security=True;Connect Timeout=30");
            string sorgu = "INSERT INTO tbl_Login(username,password,ad,soyad,eposta,telefon) VALUES (@username,@password,@ad,@soyad,@eposta,@telefon)";
            komut = new SqlCommand(sorgu,sqlcon);
            komut.Parameters.AddWithValue("@username",txt_username.Text);
            komut.Parameters.AddWithValue("@password", txt_password.Text);
            komut.Parameters.AddWithValue("@ad", txt_ad.Text);
            komut.Parameters.AddWithValue("@soyad", txt_soyad.Text);
            komut.Parameters.AddWithValue("@eposta", txt_eposta.Text);
            komut.Parameters.AddWithValue("@telefon", txt_telefon.Text);
            sqlcon.Open();
            komut.ExecuteNonQuery();
            sqlcon.Close();
            MessageBox.Show("Kayıt İşlemi Başarıyla Gerçekleştirildi.");
        }

        private void kayitOl_Load(object sender, EventArgs e)
        {

        }
    }
}
