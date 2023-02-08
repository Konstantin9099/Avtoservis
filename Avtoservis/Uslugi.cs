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
using System.IO;
using System.Reflection;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Diagnostics;

namespace Avtoservis
{
    public partial class Uslugi : Form
    {
        public int ID = 0;

        public Uslugi(int id_user)
        {
            InitializeComponent();
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            this.MaximizeBox = false;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            ID = id_user;
            Get_Info(id_user);
        }

        // Вывод данных из БД в dataGridView на форме Studenti.
        public void Get_Info(int ID)
        {
            string query = "select id_uslugi as 'Код услуги', clienti.FIO as 'ФИО клиента', Marka_avto as 'Марка авто', Nomer_avto as 'Гос. номер', mastera.fio_mastera as 'ФИО мастера', vid_rabot.Naimenovanie_rabot as 'Вид работы', vid_rabot.Stoimost as 'Цена', data_1 as 'Начало работ', data_2 as 'Окончание работ' from uslugi,clienti,mastera, vid_rabot where uslugi.clien_id=Clienti.id_clienti and uslugi.mastera_id=Mastera.id_mastera and uslugi.rabot_id=Vid_rabot.Id_rabot order by id_uslugi;";
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlDataAdapter sda = new MySqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.ClearSelection();
                this.dataGridView1.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView1.Columns[0].Width = 50;
                this.dataGridView1.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView1.Columns[1].Width = 170;
                this.dataGridView1.Columns[2].Visible = false;
                this.dataGridView1.Columns[3].Visible = false;
                this.dataGridView1.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView1.Columns[4].Width = 170;
                this.dataGridView1.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView1.Columns[5].Width = 360;
                this.dataGridView1.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView1.Columns[6].Width = 65;
                this.dataGridView1.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView1.Columns[7].Width = 70;
                this.dataGridView1.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView1.Columns[8].Width = 70;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла непредвиденая ошибка!" + Environment.NewLine + ex.Message);
            }

            // Таблица - клиенты
            string query1 = " select id_clienti as 'Код клиента', FIO as 'ФИО клиента', Nomer_avto as 'Гос. номер', Marka_avto as 'Марка авто' from clienti order by FIO;";
            MySqlConnection conn1 = DBUtils.GetDBConnection();
            MySqlDataAdapter sda1 = new MySqlDataAdapter(query1, conn1);
            DataTable dt1 = new DataTable();
            try
            {
                conn1.Open();
                sda1.Fill(dt1);
                dataGridView2.DataSource = dt1;
                dataGridView2.ClearSelection();
                this.dataGridView2.Columns[0].Visible = false;
                this.dataGridView2.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView2.Columns[1].Width = 250;
                this.dataGridView2.Columns[2].Visible = false;
                this.dataGridView2.Columns[3].Visible = false;
                dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                conn1.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла непредвиденая ошибка!" + Environment.NewLine + ex.Message);
            }

            // Таблица - мастера
            string query2 = " select id_mastera as 'Код мастера',  fio_mastera as 'ФИО мастера', telefon_mastera as 'Телефон матера' from mastera order by fio_mastera;";
            MySqlConnection conn2 = DBUtils.GetDBConnection();
            MySqlDataAdapter sda2 = new MySqlDataAdapter(query2, conn2);
            DataTable dt2 = new DataTable();
            try
            {
                conn2.Open();
                sda2.Fill(dt2);
                dataGridView3.DataSource = dt2;
                dataGridView3.ClearSelection();
                this.dataGridView3.Columns[0].Visible = false;
                this.dataGridView3.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView3.Columns[1].Width = 250;
                this.dataGridView3.Columns[2].Visible = false;
                dataGridView3.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                conn2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла непредвиденая ошибка!" + Environment.NewLine + ex.Message);
            }

            // Таблица - работы
            string query3 = " select Id_rabot as 'Код работы', Naimenovanie_rabot as 'Наименование работы', Stoimost as 'Цена' from vid_rabot order by Naimenovanie_rabot;";
            MySqlConnection conn3 = DBUtils.GetDBConnection();
            MySqlDataAdapter sda3 = new MySqlDataAdapter(query3, conn3);
            DataTable dt3 = new DataTable();
            try
            {
                conn3.Open();
                sda3.Fill(dt3);
                dataGridView4.DataSource = dt3;
                dataGridView4.ClearSelection();
                this.dataGridView4.Columns[0].Visible = false;
                this.dataGridView4.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView4.Columns[1].Width = 430;
                this.dataGridView4.Columns[2].Visible = false;
                dataGridView4.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                conn3.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла непредвиденая ошибка!" + Environment.NewLine + ex.Message);
            }

        }

        public void Action(string query)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlCommand cmDB = new MySqlCommand(query, conn);
            try
            {
                conn.Open();
                cmDB.ExecuteReader();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла непредвиденная ошибка!" + Environment.NewLine + ex.Message);
            }
        }

        private void Uslugi_Load(object sender, EventArgs e)
        {

        }

        // Меню
        private void button4_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu(ID); // Обращение к форме "Menu", на которую будет совершаться переход.
            menu.Owner = this;
            this.Hide();
            menu.Show(); // Запуск окна "Menu".
        }

        private void Uslugi_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            button1.Visible = false;
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
        }

        //Сброс 
        private void button5_Click(object sender, EventArgs e)
        {
            button1.Visible = true;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }

        //Добавить
        private void button1_Click(object sender, EventArgs e)
        {
            // Проверяем, чтобы были заполнены все поля.
            if (textBox1.Text == null || textBox1.Text == "" || textBox2.Text == null || textBox2.Text == "" || textBox3.Text == null || textBox3.Text == "" || textBox4.Text == null || textBox4.Text == "" || textBox5.Text == null || textBox5.Text == "" || textBox6.Text == null || textBox6.Text == "" || checkBox1.Checked == false)
            {
                MessageBox.Show(
                    "Введите полные данные об услуге.",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }
            else
            {
                DialogResult res = MessageBox.Show("Добавить данные об услуге?", "Подтвердите действие", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    try
                    {
                        string date  = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                        if (checkBox1.Checked == true && checkBox2.Checked == true)
                        {
                            string query = "INSERT INTO uslugi (clien_id,mastera_id,rabot_id,data_1,data_2) VALUES ((select id_clienti from Clienti where FIO='" + textBox1.Text + "'  and Nomer_avto='" + textBox6.Text + "'  and Marka_avto='" + textBox5.Text + "'), (select id_mastera from Mastera where fio_mastera='" + textBox2.Text + "'), (select Id_rabot from Vid_rabot where Naimenovanie_rabot='" + textBox3.Text + "'  and Stoimost='" + textBox4.Text + "'), '" + date + "', '" + date + "'); ";
                            MySqlConnection conn1 = DBUtils.GetDBConnection();
                            MySqlCommand cmDB1 = new MySqlCommand(query, conn1);
                            try
                            {
                                conn1.Open();
                                conn1.Close();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Произошла непредвиденная ошибка!" + Environment.NewLine + ex.Message);
                            }
                            Action(query);
                            Get_Info(ID);
                            return;
                        }
                        else if (checkBox1.Checked == true && checkBox2.Checked == false)
                        {
                            string query = "INSERT INTO uslugi (clien_id,mastera_id,rabot_id,data_1) VALUES ((select id_clienti from Clienti where FIO='" + textBox1.Text + "'  and Nomer_avto='" + textBox6.Text + "'  and Marka_avto='" + textBox5.Text + "'), (select id_mastera from Mastera where fio_mastera='" + textBox2.Text + "'), (select Id_rabot from Vid_rabot where Naimenovanie_rabot='" + textBox3.Text + "'  and Stoimost='" + textBox4.Text + "'), '" + date + "'); ";
                            MySqlConnection conn1 = DBUtils.GetDBConnection();
                            MySqlCommand cmDB1 = new MySqlCommand(query, conn1);
                            try
                            {
                                conn1.Open();
                                conn1.Close();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Произошла непредвиденная ошибка!" + Environment.NewLine + ex.Message);
                            }
                            Action(query);
                            Get_Info(ID);
                            return;
                        }
                        else if (checkBox1.Checked == false && checkBox2.Checked == true)
                        {
                            MessageBox.Show("Для внесения даты окончания работ выберете нужную запись в таблице 'Выполненные работы', установите флажок на 'Окончание работ' и нажмите на ссылку 'Выполнено'.", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (NullReferenceException ex)
                    {
                        MessageBox.Show("Произошла непредвиденная ошибка!" + Environment.NewLine + ex.Message);
                    }
                }
            }
        }
        //Измиенить 
        private void button2_Click(object sender, EventArgs e)
        {
            // Проверяем, чтобы были заполнены все поля.
            if (textBox1.Text == null || textBox1.Text == "" || textBox2.Text == null || textBox2.Text == "" || textBox3.Text == null || textBox3.Text == "" || textBox4.Text == null || textBox4.Text == "" || textBox5.Text == null || textBox5.Text == "" || textBox6.Text == null || textBox6.Text == "")
            {
                MessageBox.Show(
                    "Для внесения изменений должны быть заполнены все текстовые поля в блоке 'Учетные данные для оказываемой услуги'.",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }
            else
            {
                DialogResult res = MessageBox.Show("Изменить данные по оказанной услуге?", "Подтвердите действие", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    try
                    {
                        string date = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                        int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString()); // Определяем id клиента.
                        if (checkBox1.Checked == true && checkBox2.Checked == true)
                        {
                            string query = "UPDATE uslugi SET clien_id=(select id_clienti from Clienti where FIO='" + textBox1.Text + "'), mastera_id=(select id_mastera from Mastera where fio_mastera='" + textBox2.Text + "'), rabot_id=(select Id_rabot from Vid_rabot where Naimenovanie_rabot='" + textBox3.Text + "' and Stoimost='" + textBox4.Text + "'), data_1='" + date + "', data_2='" + date + "' WHERE id_uslugi='" + id + "'; ";
                            MySqlConnection conn = DBUtils.GetDBConnection();
                            MySqlCommand cmDB = new MySqlCommand(query, conn);
                            try
                            {
                                conn.Open();
                                conn.Close();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Произошла непредвиденная ошибка!" + Environment.NewLine + ex.Message);
                            }
                            Action(query);
                            Get_Info(ID);
                            textBox1.Clear();
                            textBox2.Clear();
                            textBox3.Clear();
                            textBox4.Clear();
                            textBox5.Clear();
                            textBox6.Clear();
                            checkBox1.Checked = false;
                            checkBox2.Checked = false;
                            return;
                        }
                        else if (checkBox1.Checked == true && checkBox2.Checked == false)
                        {
                            string query = "UPDATE uslugi SET clien_id=(select id_clienti from Clienti where FIO='" + textBox1.Text + "'), mastera_id=(select id_mastera from Mastera where fio_mastera='" + textBox2.Text + "'), rabot_id=(select Id_rabot from Vid_rabot where Naimenovanie_rabot='" + textBox3.Text + "' and Stoimost='" + textBox4.Text + "'), data_1='" + date + "' WHERE id_uslugi='" + id + "'; ";
                            MySqlConnection conn = DBUtils.GetDBConnection();
                            MySqlCommand cmDB = new MySqlCommand(query, conn);
                            try
                            {
                                conn.Open();
                                conn.Close();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Произошла непредвиденная ошибка!" + Environment.NewLine + ex.Message);
                            }
                            Action(query);
                            Get_Info(ID);
                            textBox1.Clear();
                            textBox2.Clear();
                            textBox3.Clear();
                            textBox4.Clear();
                            textBox5.Clear();
                            textBox6.Clear();
                            checkBox1.Checked = false;
                            checkBox2.Checked = false;
                            return;
                        }
                        else if (checkBox1.Checked == false && checkBox2.Checked == true)
                        {
                            string query = "UPDATE uslugi SET clien_id=(select id_clienti from Clienti where FIO='" + textBox1.Text + "'), mastera_id=(select id_mastera from Mastera where fio_mastera='" + textBox2.Text + "'), rabot_id=(select Id_rabot from Vid_rabot where Naimenovanie_rabot='" + textBox3.Text + "' and Stoimost='" + textBox4.Text + "'), data_2='" + date + "' WHERE id_uslugi='" + id + "'; ";
                            MySqlConnection conn = DBUtils.GetDBConnection();
                            MySqlCommand cmDB = new MySqlCommand(query, conn);
                            try
                            {
                                conn.Open();
                                conn.Close();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Произошла непредвиденная ошибка!" + Environment.NewLine + ex.Message);
                            }
                            Action(query);
                            Get_Info(ID);
                            textBox1.Clear();
                            textBox2.Clear();
                            textBox3.Clear();
                            textBox4.Clear();
                            textBox5.Clear();
                            textBox6.Clear();
                            checkBox1.Checked = false;
                            checkBox2.Checked = false;
                            return;
                        }
                        else if (checkBox1.Checked == false && checkBox2.Checked == false)
                        {
                            string query = "UPDATE uslugi SET clien_id=(select id_clienti from Clienti where FIO='" + textBox1.Text + "'), mastera_id=(select id_mastera from Mastera where fio_mastera='" + textBox2.Text + "'), rabot_id=(select Id_rabot from Vid_rabot where Naimenovanie_rabot='" + textBox3.Text + "' and Stoimost='" + textBox4.Text + "') WHERE id_uslugi='" + id + "'; ";
                            MySqlConnection conn = DBUtils.GetDBConnection();
                            MySqlCommand cmDB = new MySqlCommand(query, conn);
                            try
                            {
                                conn.Open();
                                conn.Close();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Произошла непредвиденная ошибка!" + Environment.NewLine + ex.Message);
                            }
                            Action(query);
                            Get_Info(ID);
                            textBox1.Clear();
                            textBox2.Clear();
                            textBox3.Clear();
                            textBox4.Clear();
                            textBox5.Clear();
                            textBox6.Clear();
                            checkBox1.Checked = false;
                            checkBox2.Checked = false;
                            return;
                        }
                    }
                    catch (NullReferenceException ex)
                    {
                        MessageBox.Show("Произошла непредвиденная ошибка!" + Environment.NewLine + ex.Message);
                    }
                }
            }
        }
        //Удалить 
        private void button3_Click(object sender, EventArgs e)
        {
            // Проверяем, чтобы были заполнены все поля.
            if (textBox1.Text == null || textBox1.Text == "" || textBox2.Text == null || textBox2.Text == "" || textBox3.Text == null || textBox3.Text == "" || textBox4.Text == null || textBox4.Text == "" || textBox5.Text == null || textBox5.Text == "" || textBox6.Text == null || textBox6.Text == "")
            {
                MessageBox.Show(
                    "Выберете в таблице 'Выполненные работы' строку, подлежащую удалению.",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }
            else
            {
                DialogResult res = MessageBox.Show("Удалить запись о выполненных работах?", "Подтвердите действие", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    string valueCell = dataGridView1.CurrentCell.Value != null ? dataGridView1.CurrentCell.Value.ToString() : "";
                    string del = "DELETE FROM uslugi WHERE id_uslugi = " + valueCell + ";";
                    Action(del);
                    Get_Info(ID);
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    textBox6.Clear();
                }
                else
                {
                    MessageBox.Show("Удаление записи отменено!");
                }
            }
        }
        // Поиск
        private void button7_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].Selected = false;
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    if (dataGridView1.Rows[i].Cells[j].Value != null)
                        if (dataGridView1.Rows[i].Cells[j].Value.ToString().Contains(textBox7.Text))
                        {
                            dataGridView1.Rows[i].Selected = true;
                            //dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                            break;
                        }
            }
        }
        // Печать
        private void button6_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PDF (*.pdf)|*.pdf";
                sfd.FileName = "Uslugi.pdf";
                bool fileError = false;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(sfd.FileName))
                    {
                        try
                        {
                            File.Delete(sfd.FileName);
                        }
                        catch (IOException ex)
                        {
                            fileError = true;
                            MessageBox.Show("Не удалось записать данные." + ex.Message);
                        }
                    }
                    if (!fileError)
                    {
                        try
                        {
                            PdfPTable pdfTable = new PdfPTable(dataGridView1.Columns.Count);
                            pdfTable.DefaultCell.Padding = 3;
                            pdfTable.WidthPercentage = 100;
                            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;

                            foreach (DataGridViewColumn column in dataGridView1.Columns)
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                                pdfTable.AddCell(cell);
                            }

                            foreach (DataGridViewRow row in dataGridView1.Rows)
                            {
                                foreach (DataGridViewCell cell in row.Cells)
                                {
                                    try
                                    {
                                        pdfTable.AddCell(System.Convert.ToString(cell.Value));
                                    }
                                    catch { }
                                }
                            }

                            using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                            {
                                Document pdfDoc = new Document(PageSize.A3, 10f, 20f, 20f, 10f);
                                PdfWriter.GetInstance(pdfDoc, stream);
                                pdfDoc.Open();
                                pdfDoc.Add(pdfTable);
                                pdfDoc.Close();
                                stream.Close();
                            }

                            MessageBox.Show("Данные успешно экспортированы!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ошибка" + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Нет записей для экспорта!", "Сообщение");
            }
        }
        // Вывод данных в текстовые поля из таблицы клиентов
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            textBox6.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            textBox5.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
        }
        // Внесение даты завершения работы
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Проверяем, чтобы были заполнены все поля.
            if (textBox1.Text == null || textBox1.Text == "" || textBox2.Text == null || textBox2.Text == "" || textBox3.Text == null || textBox3.Text == "" || textBox4.Text == null || textBox4.Text == "" || textBox5.Text == null || textBox5.Text == "" || textBox6.Text == null || textBox6.Text == "")
            {
                MessageBox.Show(
                    "Для записи даты окончания работ необходимо: \n- выбрать оказанную услугу в таблице 'Выполненные работы'; \n- выбрать дату окончания работ; \n- установить флажок на 'Окончание работ'; \n- нажать на ссылку 'Выполнено'.",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else if (checkBox1.Checked == true || checkBox2.Checked == false)
            {
                MessageBox.Show("Для записи даты окончания работ необходимо: \n- выбрать оказанную услугу в таблице 'Выполненные работы'; \n- выбрать дату окончания работ; \n- установить флажок на 'Окончание работ'; \n- нажать на ссылку 'Выполнено'.",
                                "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DialogResult res = MessageBox.Show("Выполнить запись даты окончания работ?", "Подтвердите действие", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    try
                    {
                        string date = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                        int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString()); // Определяем id клиента.
                        string query = "UPDATE uslugi SET data_2='" + date + "' WHERE id_uslugi='" + id + "'; ";
                        MySqlConnection conn = DBUtils.GetDBConnection();
                        MySqlCommand cmDB = new MySqlCommand(query, conn);
                        try
                        {
                            conn.Open();
                            conn.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Произошла непредвиденная ошибка!" + Environment.NewLine + ex.Message);
                        }
                        Action(query);
                        Get_Info(ID);
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox3.Clear();
                        textBox4.Clear();
                        textBox5.Clear();
                        textBox6.Clear();
                    }
                    catch (NullReferenceException ex)
                    {
                        MessageBox.Show("Произошла непредвиденная ошибка!" + Environment.NewLine + ex.Message);
                    }
                }
            }
        }

        // Вывод данных в текстовые поля из таблицы мастеров
        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Text = dataGridView3.CurrentRow.Cells[1].Value.ToString();
        }
        // Вывод данных в текстовые поля из таблицы работ
        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox3.Text = dataGridView4.CurrentRow.Cells[1].Value.ToString();
            textBox4.Text = dataGridView4.CurrentRow.Cells[2].Value.ToString();
        }
    }
}
