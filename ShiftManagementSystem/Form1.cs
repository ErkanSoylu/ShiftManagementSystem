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
using System.Security.Policy;

namespace ShiftManagementSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static string eposta, sifre;
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            eposta = txt_username.Text;
            sifre = txt_password.Text;
            SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DKE10017\source\repos\ShiftManagementSystem\ShiftManagementSystem\db\DB.mdf;Integrated Security=True;Connect Timeout=30");
            string query = "Select * from tbl_Login where eposta ='" + eposta.Trim() + "' and password = '" + sifre.Trim()+"'";
            SqlDataAdapter sda = new SqlDataAdapter(query,sqlcon);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            if (dtbl.Rows.Count>=1)
            {
                kullaniciSayfasi kullaniciSayfasi = new kullaniciSayfasi();
                this.Hide();
                kullaniciSayfasi.Show();
            }
            else
            {
                MessageBox.Show("Kullanıcı adınız veya şifreniz hatalıdır.");
            }
        }

        private void btn_forgetpassword_Click(object sender, EventArgs e)
        {
            sifremiUnuttum sifremiUnuttum = new sifremiUnuttum();
            this.Hide();
            sifremiUnuttum.Show();
        }

        private void btn_register_Click(object sender, EventArgs e)
        {
            kayitOl kullaniciSayfasi = new kayitOl();
            this.Hide();
            kullaniciSayfasi.Show();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txt_password_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txt_username_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }
    }
}
