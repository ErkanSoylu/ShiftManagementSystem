using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace ShiftManagementSystem
{
    public partial class sifreyiSifirla : Form
    {
        string username = sifremiUnuttum.to;
        public sifreyiSifirla()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

     

        private void btn_login_Click(object sender, EventArgs e)
        {
            Form1 girisSayfasi = new Form1();
            this.Hide();
            girisSayfasi.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txt_sifre1.Text == txt_sifre2.Text)
            {
                SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DKE10017\source\repos\ShiftManagementSystem\ShiftManagementSystem\db\DB.mdf;Integrated Security=True;Connect Timeout=30");
                SqlCommand cmd = new SqlCommand("UPDATE [dbo].[tbl_Login] SET [password] = '"+txt_sifre2.Text+"' WHERE eposta='"+username+"'", sqlcon);
                sqlcon.Open();
                cmd.ExecuteNonQuery();
                sqlcon.Close();
                MessageBox.Show("Şifreniz Başarıyla Değiştirilmiştir.");


            }
            else
            {
                MessageBox.Show("Girilen Şifreler Uyuşmamaktadır.");
            }
        }
    }
}
