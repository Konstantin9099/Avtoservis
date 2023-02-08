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
    public partial class Menu : Form
    {
        public int ID = 0;
        public Menu(int id_user)
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            ID = id_user;
        }

        private void Menu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        //клиент 
        private void button1_Click(object sender, EventArgs e)
        {
            Clienti clienti = new Clienti(ID); // Обращение к форме "Menu", на которую будет совершаться переход.
            clienti.Owner = this;
            this.Hide();
            clienti.Show(); // Запуск окна "Menu".
        }
        //мастер
        private void button2_Click(object sender, EventArgs e)
        {
            Mastera mastera = new Mastera(ID); // Обращение к форме "Menu", на которую будет совершаться переход.
            mastera.Owner = this;
            this.Hide();
            mastera.Show(); // Запуск окна "Menu".
        }
        //услуги
        private void button3_Click(object sender, EventArgs e)
        {
            Uslugi uslugi = new Uslugi(ID); // Обращение к форме "Menu", на которую будет совершаться переход.
            uslugi.Owner = this;
            this.Hide();
            uslugi.Show(); // Запуск окна "Menu".
        }
        //вид работы 
        private void button4_Click(object sender, EventArgs e)
        {
            Vid_rabot vid = new Vid_rabot(ID); // Обращение к форме "Menu", на которую будет совершаться переход.
            vid.Owner = this;
            this.Hide();
            vid.Show(); // Запуск окна "Menu".
        }
        //профиль
        private void button5_Click(object sender, EventArgs e)
        {
            Profil prof = new Profil(ID); // Обращение к форме "Menu", на которую будет совершаться переход.
            prof.Owner = this;
            this.Hide();
            prof.Show(); // Запуск окна "Menu".
        }
    }
}
