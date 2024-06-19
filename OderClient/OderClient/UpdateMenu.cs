using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OderClient
{
    public partial class UpdateMenu : Form
    {
        MySqlConnection conn;
        List<Label> label = new List<Label>();
        List<TextBox> txtBox = new List<TextBox>();
        //Label[] lb = new Label[7];
        //TextBox[] txt = new TextBox[7];
        static int fieldnum;

        public UpdateMenu()
        {
            InitializeComponent();
        }

        private void UpdateMenu_Load(object sender, EventArgs e)
        {
            
        }
        private void btn_selectMenu_Click(object sender, EventArgs e)
        {
            conn= new MySqlConnection("server=localhost;user=root;password=123;database=點餐系統;Allow User Variables=true;");
            conn.Open();
            //計算欄位數量
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM `員工餐點`" + " WHERE `Gmail`= '" + txtBox_mail.Text+"'", conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            var schemaTable = reader.GetSchemaTable();
            //欄位數量
            fieldnum = reader.FieldCount;
            
            //欄位、文字生成的座標
            int lbStartX = 100, lbStartY = 20;
            int txtStartX = 210, txtStartY = 20;

            try
            {
                reader.Read();
                //取得第i個索引的欄位名稱
                for (int i = 0; i < fieldnum; i++)
                {
                    //取得第i個索引的欄位名稱
                    String fieldname = reader.GetName(i);
                    //建立欄位名稱i一樣的label
                    Label lb = new Label();
                    TextBox txt = new TextBox();
                    //lb[i] = new Label();
                    lb.Name = "lb" + fieldname;
                    lb.Text = fieldname;
                    lb.Font = new Font("標楷體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
                    lb.Location = new System.Drawing.Point(lbStartX, lbStartY);
                    lb.Visible = true;
                    //建立和欄位名稱i一樣的textBox
                    //txt = new TextBox();
                    txt.Name = "txt" + fieldname;
                    txt.Size = new System.Drawing.Size(300, 22);
                    txt.Location = new System.Drawing.Point(txtStartX, txtStartY);
                    txt.Font = new Font("標楷體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
                    txt.Visible = true;
                    txt.Text = reader.GetValue(i).ToString();
                    //每生成一組座標往下移動製造多行
                    lbStartY += 45;
                    txtStartY += 45;
                    //顯示出來
                    txt.Parent = this;
                    lb.Parent = this;
                    label.Add(lb);
                    txtBox.Add(txt);
                }
                //UpdateSQL += "`" + fieldname + "`, ";
            }
            catch(MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("發生錯誤，信箱錯誤或是您還未點餐");
                Console.WriteLine(ex.Message);
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("確定要刪除此餐點嗎？", "刪除餐點。", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string deleteSQL = "DELETE FROM `員工餐點` WHERE `Gmail` = @Gmail";
                try
                {
                    conn = new MySqlConnection("server=localhost;user=root;password=;database=點餐系統;Allow User Variables=true;");
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(deleteSQL, conn);
                    cmd.Parameters.AddWithValue("@Gmail", txtBox[0].Text);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("刪除成功，請重新點餐");
                    //寄信通知
                    sendMail();
                    this.Close();
                    UpdateMenu frm = new UpdateMenu();
                    //把form放在畫面正中間，後生成(show)
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

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
                string message = "您好，您的餐點已被撤銷，請重新點餐謝謝。";

                // 建立 MailMessage 物件
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(user);
                mail.To.Add(txtBox_mail.Text);
                //主旨
                mail.Subject = "(無須回復)餐點撤銷";
                //內文
                mail.Body = message.Replace(Environment.NewLine, "<br>"); // 使用 <br> 表示換行
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