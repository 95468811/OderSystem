using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OderClient
{
    public partial class CheckMenu : Form
    {
        public CheckMenu()
        {
            InitializeComponent();
        }

        private void CheckMenu_Load(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection("server=localhost;user=root;password=123;database=點餐系統");
            try
            {              
                connection.Open();
                MySqlCommand command = new MySqlCommand("SELECT * FROM 菜單", connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    //讀取菜單屬性
                    byte[] picture = (byte[])reader["菜單"];
                    MemoryStream ms = new MemoryStream(picture);

                    //顯示在pictureBox上
                    pictureBox.Image = Image.FromStream(ms);
                    /*pictureBox.BackgroundImageLayout = ImageLayout.Stretch;
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;*/
                    this.Controls.Add(pictureBox);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("出現錯誤，請連絡相關人員", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(ex.Message);
            }         
        }
    }
}
