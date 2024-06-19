using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;

namespace _20113131
{
    public partial class SendMail : Form
    {
        public SendMail()
        {
            InitializeComponent();
        }

        private void SendMail_Load(object sender, EventArgs e)
        {
            
        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            try
            {
                // 設定 SMTP 伺服器
                string host = "smtp.gmail.com";
                int port = 587;
                string user = txtBox_user.Text;
                string password = txtBox_password.Text;
                //Google需要的安全性政策
                string googleSecurityPassword = "pmyu soog ssea uisl";

                // 建立 MailMessage 物件
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(user);
                mail.To.Add(txtBox_clientMail.Text);
                mail.Subject = txtBox_mailTitle.Text;
                mail.Body = rtxtBox_massage.Text.Replace(Environment.NewLine, "<br>"); // 使用 <br> 表示換行
                mail.IsBodyHtml = true;

                // 建立 SmtpClient 類別
                SmtpClient client = new SmtpClient(host, port);
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(user, googleSecurityPassword);

                // 發送電子郵件
                client.Send(mail);
                MessageBox.Show("已成功發送，收信人："+ txtBox_clientMail.Text, "發送成功", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                client.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show(ex.Message);
            }
        }
    }
}
