using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//發信的
using System.Net.Mail;
using System.Net;
//建立用戶連接的
using System.Net.Sockets;

namespace _20113131
{
    public partial class OderingManager : System.Windows.Forms.Form
    {
        //處理開始、結束點餐
        bool oder = true;
        //連線資料庫
        MySqlConnection connection = new MySqlConnection("server=localhost;user=root;password=123;database=點餐系統");

        public OderingManager()
        {
            InitializeComponent();
        }

        private void OderingManager_Load(object sender, EventArgs e)
        {
            //每幾秒執行一次
            timer1.Interval = 5000; // 设置时间间隔为5秒
            timer1.Tick += timer1_Tick;
            timer1.Start();
            //DateGridView顯示點餐資訊
            LoadData();
        }

        //上傳菜單
        private void btn_addMenu_Click(object sender, EventArgs e)
        {
            bool opened = false;
            //用foreach找出已經開啟的畫面中有沒有叫Menu的，如果有就將他叫到最上層
            foreach (Form frm in Application.OpenForms)
            {
                if (frm.Name == "Menu")
                {
                    opened = true;
                    //把form叫到最上層
                    frm.Focus();
                }
            }
            if (!opened)
            {
                Menu frm = new Menu();
                //把form放在畫面正中間，後生成(show)
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.Show();
            }
        }

        //開始、結束點餐
        private void btn_startAndStop_Click(object sender, EventArgs e)
        {
            //建立server端連接
            TcpListener server = new TcpListener(IPAddress.Parse("127.0.0.1"), int.Parse("8181"));
            if (oder)
            {
                if (MessageBox.Show("要立即開始接受點餐嗎？", "開始點餐", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {           
                    try
                    {
                        //發送訊息給client端
                        server.Start();
                        MessageBox.Show("您已成功開啟點餐系統，請耐心等待員工點餐。", "訊息", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // 將按鈕的圖像跟文字改為結束點餐
                        btn_startAndStop.Image = Properties.Resources.images;
                        GoOrder.Text = "結束點餐";
                        // 取得圖像
                        Image image = btn_startAndStop.Image;
                        // 調整圖像的大小
                        image = new Bitmap(image, btn_startAndStop.Width - 5, btn_startAndStop.Height - 5);
                        // 重新設置圖像
                        btn_startAndStop.Image = image;
                        oder = false;
                    } catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        MessageBox.Show(ex.Message);
                    }
                }
            } else
            {
                if(MessageBox.Show("這麼做會停止接受點餐，確定要停止嗎？","結束點餐", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                    
                    try
                    {
                        //關閉連接
                        server.Stop();
                        MessageBox.Show("點餐系統已被關閉，祝用餐愉快！", "結束點餐", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //開啟點餐
                        btn_startAndStop.Image = Properties.Resources._5453658;
                        GoOrder.Text = "開始點餐";
                        Image image = btn_startAndStop.Image;
                        image = new Bitmap(image, btn_startAndStop.Width - 5, btn_startAndStop.Height - 5);
                        btn_startAndStop.Image = image;
                        oder = true;
                    } catch(Exception ex)
                    {
                        
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        //發送gmail。Send("寄件人", "收件人", "主旨", " 內容");
        public static void Send(string from, string to, string subject, string body)
        {
            // 設定SMTP伺服器
            string smtpServer = "smtp.gmail.com";
            int smtpPort = 587;
            //登入帳密
            string smtpUsername = "你的Gmail帳號";
            string smtpPassword = "應用程式密碼";

            // 設定MailMessage
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(from);
            mail.To.Add(to);
            mail.Subject = subject;
            mail.Body = body;

            // 設定SMTPClient
            SmtpClient client = new SmtpClient();
            client.Host = smtpServer;
            client.Port = smtpPort;
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential(smtpUsername, smtpPassword);

            // 寄出信件
            try
            {
                client.Send(mail);
                Console.WriteLine("Email sent successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error sending email: " + ex.Message);
            }
        }

        private void btn_sendMail_Click(object sender, EventArgs e)
        {
            SendMail sendMail = new SendMail();
            sendMail.Activate();
            sendMail.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            LoadData();
        }

        //DateGridView顯示點餐資訊
        private void LoadData()
        {
            //將員工的點餐資訊顯示在螢幕上
            try
            {
                //連接到資料庫 IP;帳號;密碼;資料庫名稱
                connection.Open();
                //執行SQL語法
                MySqlDataAdapter adapter = new MySqlDataAdapter("Select * from 員工餐點", connection);
                DataTable table = new DataTable();
                adapter.Fill(table);
                BindingSource bSource = new BindingSource();
                //主畫面的BindingSource顯示table
                bSource.DataSource = table;
                dataGridView1.DataSource = bSource;
                dataGridView1.Refresh();
                /*以下都可從BindingSource的屬性改
                //資料表改背景色(Headers是表格第一格的行)
                dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.LightYellow;
                //改字色
                dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Blue;
                //改字體
                dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("標楷體", 14);
                //顯示出來
                dataGridView1.EnableHeadersVisualStyles = false;*/
                connection.Close();
                adapter.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("獲取員工資料錯誤");
                Console.WriteLine(ex.Message);
            }
        }

        private void btn_END_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("此動作會刪除所有餐點，請確認點餐完畢再進行！", "點餐完畢。", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string deleteSQL = "DELETE FROM `員工餐點`";
                try
                {
                    connection = new MySqlConnection("server=localhost;user=root;password=123;database=點餐系統;Allow User Variables=true;");
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand(deleteSQL, connection);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("菜單已全數清空。");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
