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

namespace _20113131
{
    public partial class Menu : Form
    {
        MySqlConnection connection = new MySqlConnection("server=localhost;user=root;password=123;database=點餐系統");
        MySqlDataAdapter adapter;

        public Menu()
        {
            InitializeComponent();
        }

        //新增菜單
        private void btnAddMenu_Click(object sender, EventArgs e)
        {
            //判斷目前是否有菜單
            if (pictureBox.Image != null)
            {
               MessageBox.Show("已經有菜單了，請先刪除目前的菜單。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                //開啟舊檔上傳圖片
                openFileDialog_addMenu.ShowDialog();
            }
        }

        //刪除菜單
        private void btnDeleteMenu_Click(object sender, EventArgs e)
        {
            //是否的對話框
            if (MessageBox.Show("此操作不可逆，確定要刪除菜單嗎?", "刪除菜單。", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //執行 Yes 按鈕的代碼
                try
                {
                    connection.Open();
                    string query = "DELETE FROM 菜單";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.ExecuteNonQuery();
                    MessageBox.Show("成功刪除此菜單。","訊息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } finally
                {
                    connection.Close();
                    // 重新啟動應用程式
                    this.Close();
                    Menu frm = new Menu();
                    //把form放在畫面正中間，後生成(show)
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.Show();
                }
            }
            else
            {
                //執行 No 按鈕的代碼
                MessageBox.Show("繼續保留菜單。","訊息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        //上傳圖片後按確認的動作
        private void openFileDialog_addMenu_FileOk(object sender, CancelEventArgs e)
        {
            string selectedFilePath = openFileDialog_addMenu.FileName;

            // 讀取圖片檔案的二進位數據
            byte[] imageBytes = File.ReadAllBytes(selectedFilePath);

            // 上傳圖片到 MySQL 資料庫
            try
            {
                //MySqlConnection connection = new MySqlConnection("server=localhost;user=root;password=;database=`點餐系統`");
                connection.Open();
                string query = "INSERT INTO `菜單` VALUES (@picture)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@picture", imageBytes);
                command.ExecuteNonQuery();
                MessageBox.Show("上傳成功，請確認菜單是否正確。","訊息");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
                this.Close();
                Menu frm = new Menu();
                //把form放在畫面正中間，後生成(show)
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.Show();
            }
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            //連接到資料庫 IP;帳號;密碼;資料庫名稱
            MySqlConnection connection = new MySqlConnection("server=localhost;user=root;password=123;database=點餐系統");
            try
            {
                connection.Open();
                //執行SQL語法
                MySqlCommand command = new MySqlCommand("SELECT * FROM 菜單", connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    //讀取菜單屬性
                    byte[] picture = (byte[])reader["菜單"];
                    MemoryStream ms = new MemoryStream(picture);
                    
                    //顯示在pictureBox上
                    pictureBox.Image = Image.FromStream(ms);                    
                    this.Controls.Add(pictureBox);

                }
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
