using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Avtoservis
{
    public partial class Profil : Form
    {
        public int ID = 0;
        public Profil(int id_user)
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            ID = id_user;
            textBox1.Visible = false;
            textBox2.Visible = false;
        }

        // Кнопка "Изменить логин и пароль".
        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Изменить")
            {
                textBox1.Visible = true;
                textBox2.Visible = true;
                button1.Text = "Сохранить";
                return;
            }

            else if (button1.Text == "Сохранить")
            {
                // Проверяем, чтобы была заполнена строка поиска.
                if (textBox1.Text == null || textBox1.Text == "" || textBox2.Text == null || textBox2.Text == "")
                {
                    MessageBox.Show("Вы не ввели логин и пароль!\nВыполнить изменение невозможно.",
                        "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                {
                    string query = "update avtorizacia set login ='" + textBox1.Text + "', parol ='" + textBox2.Text + "' where id = '" + ID.ToString() + "';";
                  //string query = "UPDATE Mastera SET fio_mastera='" + textBox1.Text + "', telefon_mastera='" + textBox2.Text + "' WHERE id_mastera='" + id + "'; ";

                    MySqlConnection conn = DBUtils.GetDBConnection();
                    MySqlCommand cmDB = new MySqlCommand(query, conn);
                    try
                    {
                        conn.Open();
                        cmDB.ExecuteReader();
                        conn.Close();
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox1.Visible = false;
                        textBox2.Visible = false;
                        button1.Text = "Изменить";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Возникла непредвиденная ошибка!" + Environment.NewLine + ex.Message);
                    }
                }
            }
        }

        // Кнопка "Назад" - возврат на форму "Меню".
        private void button2_Click(object sender, EventArgs e)
        {
            Menu men = new Menu(ID);
            men.Owner = this;
            this.Hide();
            men.Show();
        }

        private void Profil_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
