using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace ShiftManagementSystem
{
    public partial class sifremiUnuttum : Form
    {
        string randomCode;
        public static string to;
        public sifremiUnuttum()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(randomCode== (txt_sendcode.Text).ToString())
            {
                to = txt_email.Text;
                sifreyiSifirla sifreSifirlama = new sifreyiSifirla();
                this.Hide();
                sifreSifirlama.Show();
            }
            else
            {
                MessageBox.Show("Gönderilmiş olan Erişim Kodu Hatalıdır.");
            }
            
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            string from, pass, messageBody;
            Random rand = new Random();
            randomCode = (rand.Next(999999)).ToString();
            MailMessage message = new MailMessage();
            to = (txt_email.Text).ToString();
            from = "erkanyollu@gmail.com";
            pass = "ReK9Lsa6.";
            messageBody = "Şifre Sıfırlama Erişim Kodunuz..."+randomCode;
            message.To.Add(to);
            message.From = new MailAddress(from);
            message.Body = messageBody;
            message.Subject = "Şifre Sıfırlama Kodu";
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(from,pass);
            try
            {
                smtp.Send(message);
                MessageBox.Show("Kod Başarıyla Gönderilmiştir.");
            }catch(Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
