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
    public partial class kullaniciSayfasi : Form
    {
        public kullaniciSayfasi()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 anaSayfa = new Form1();
            this.Hide();
            anaSayfa.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sifremiUnuttum sifremiUnuttum = new sifremiUnuttum();
            this.Hide();
            sifremiUnuttum.Show();
        }

        private void kullaniciSayfasi_Load(object sender, EventArgs e)
        {
            lbl_yetkilendirme.Text = Form1.eposta;
            String yetki = "admin";
            SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DKE10017\source\repos\ShiftManagementSystem\ShiftManagementSystem\db\DB.mdf;Integrated Security=True;Connect Timeout=30");
            string query = "Select * from tbl_Login where eposta ='" + Form1.eposta.Trim() + "' and yetki = '" + yetki.Trim() + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            if (dtbl.Rows.Count >= 1)
            {
                
            }
            else
            {
                button6.Visible = false;
                button7.Visible = false;

            }
        }

        private void btn_register_Click(object sender, EventArgs e)
        {
            kullaniciBilgileriDegistir kullaniciBilgileriDegistir = new kullaniciBilgileriDegistir();
            this.Hide();
            kullaniciBilgileriDegistir.Show();
        }
    }
}
