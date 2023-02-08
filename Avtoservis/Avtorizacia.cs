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
    public partial class Avtorizacia : Form
    {
        public Avtorizacia()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Запрос к таблице Authorization.
            string query = "SELECT id FROM Avtorizacia WHERE login ='" + textBox1.Text + "' and  parol = '" + textBox2.Text + "';";
            MySqlConnection conn = DBUtils.GetDBConnection();
            // Объект для выполнения SQL-запроса.
            MySqlCommand cmDB = new MySqlCommand(query, conn);
            try
            {
                // Устанавливаем соединение с БД.
                conn.Open();
                int id_user = 0;
                id_user = Convert.ToInt32(cmDB.ExecuteScalar());
                if (id_user > 0)
                {
                    Menu menu = new Menu(id_user); // Обращение к форме "Menu", на которую будет совершаться переход.
                    menu.Owner = this;
                    this.Hide();
                    menu.Show(); // Запуск окна "Menu".
                    textBox1.Clear(); // Очистка поля - логин.
                    textBox2.Clear(); // Очистка поля - пароль.
                }
                else
                    MessageBox.Show("Возникла ошибка авторизации!");
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Возникла непредвиденная ошибка!" + Environment.NewLine + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Avtorizacia_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        //регистрация
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Registraciya reg = new Registraciya(); // Обращение к форме "Menu", на которую будет совершаться переход.
            reg.Owner = this;
            this.Hide();
            reg.Show(); // Запуск окна "Menu".
        }
    }
}
