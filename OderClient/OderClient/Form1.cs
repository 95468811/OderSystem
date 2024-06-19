using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OderClient
{
    public partial class Form1 : Form
    {
        MySqlConnection connection;
        TcpClient tcpClient;
        public static string mail;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                tcpClient = new TcpClient("127.0.0.1", int.Parse("8181"));
            }
            catch (SocketException ex)
            {
                MessageBox.Show("還沒開始點餐喔~請耐心等待");
            }
        }

        private void btn_checkMenu_Click(object sender, EventArgs e)
        {
            try
            {
                tcpClient = new TcpClient("127.0.0.1", int.Parse("8181"));
                new CheckMenu().Visible = true ;
            }
            catch (SocketException ex)
            {
                MessageBox.Show("還沒開始點餐喔~請耐心等待");
            } 
        }

        private void txtBox_mealPrice_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int price = int.Parse(txtBox_mealPrice.Text) + int.Parse(txtBox_drinkPrice.Text) + int.Parse(txtBox_soupPrice.Text);
                txtBox_Price.Text = price.ToString();
            } catch(Exception ex)
            {
                MessageBox.Show("請輸入整數");
            }
        }

        private void btn_sendMenu_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("即將上傳點餐，確認無誤了嗎?", "上傳餐點。", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    //開啟client端
                    tcpClient = new TcpClient("127.0.0.1", int.Parse("8181"));
                    connection = new MySqlConnection("server=localhost;user=root;password=123;database=點餐系統;Allow User Variables=true;");
                    connection.Open();
                    //參數化查詢
                    MySqlCommand cmd = new MySqlCommand("INSERT INTO 員工餐點 (Gmail, 姓名, 主餐, 飲料, 湯品, 總價) VALUES (@Gmail, @姓名, @主餐, @飲料, @湯品, @總價)", connection);
                    cmd.Parameters.AddWithValue("@Gmail", txtBox_mail.Text);
                    cmd.Parameters.AddWithValue("@姓名", txtBox_name.Text);
                    cmd.Parameters.AddWithValue("@主餐", txtBox_meal.Text);
                    cmd.Parameters.AddWithValue("@飲料", txtBox_drink.Text);
                    cmd.Parameters.AddWithValue("@湯品", txtBox_soup.Text);
                    cmd.Parameters.AddWithValue("@總價", txtBox_Price.Text);
                    // 執行 SQL 語句
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("上傳成功，請至gmail收件夾查看點餐是否正確", "發送成功", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //寄信
                    sendMail();
                    //釋放資源
                    connection.Close();
                    tcpClient.Close();
                }
                catch (SocketException ex)
                {
                    MessageBox.Show("還沒開始點餐，請連絡相關人員");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("上傳錯誤");
                    Console.WriteLine(ex.Message);
                }
            }
        }
        

        private void btn_UpdateMenu_Click(object sender, EventArgs e)
        {
                try
                {
                    tcpClient = new TcpClient("127.0.0.1", int.Parse("8181"));
                    bool opened = false;
                     mail = txtBox_mail.Text;

                    foreach (Form frm in Application.OpenForms)
                    {
                        if (frm.Name == "UpdateFrm")
                        {
                            opened = true;
                            frm.Focus();
                        }
                    }
                    if (!opened)
                    {
                        UpdateMenu frm = new UpdateMenu();
                        frm.StartPosition = FormStartPosition.CenterScreen;
                        frm.Show();
                    }
                }
                catch (SocketException ex)
                {
                    MessageBox.Show("還沒開始點餐喔~請耐心等待");
                }

            connection = new MySqlConnection("server=localhost;user=root;password=123;database=點餐系統");
            connection.Open();
            //計算欄位數量
            MySqlCommand cmd = new MySqlCommand("SELECT* FROM 員工餐點", connection);
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            var schemaTable = reader.GetSchemaTable();
            //欄位數量
            int fieldnum = reader.FieldCount;
            Label[] lb = new Label[fieldnum];
            TextBox[] txt = new TextBox[fieldnum];
            //欄位、文字生成的座標
            int lbStartX = 100, lbStartY = 20;
            int txtStartX = 210, txtStartY = 20;
        }

        //寄信
        private void sendMail()
        {
            try
            {
                // 設定 SMTP 伺服器
                string host = "smtp.gmail.com";
                int port = 587;
                string user = "s20113131@stu.edu.tw";
                string password = "su3g4go6";
                //Google需要的安全性政策
                string googleSecurityPassword = "pmyu soog ssea uisl";
                //發送的內容<br>是html中的換行
                string menu = "您好，您今天中午的餐點為<br>主餐：" + txtBox_meal.Text+"， "+txtBox_mealPrice.Text+ "元<br>飲料：" + txtBox_drink.Text+"， "+txtBox_drinkPrice.Text+ "元<br>湯品：" + txtBox_drinkPrice.Text+ "元<br>總共是" + txtBox_Price.Text+ "元<br>祝您用餐愉快。";

                // 建立 MailMessage 物件
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(user);
                mail.To.Add(txtBox_mail.Text);
                //主旨
                mail.Subject = "(無須回復)點餐系統餐點確認";
                //內文
                mail.Body = menu.Replace(Environment.NewLine, "<br>"); // 使用 <br> 表示換行
                mail.IsBodyHtml = true;

                // 建立 SmtpClient 類別
                SmtpClient client = new SmtpClient(host, port);
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(user, googleSecurityPassword);

                // 發送電子郵件
                client.Send(mail);
                client.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("發送郵件錯誤，請確認電子郵件無誤");
                MessageBox.Show(ex.Message);
            }
        }
    }
}
