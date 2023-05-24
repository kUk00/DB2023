using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace CinemaC
{
    public partial class Control : Form
    {
        public Control()
        {
            InitializeComponent();

            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;

            comboBox1.Visible = false;
            comboBox2.Visible = false;
            comboBox3.Visible = false;
            checkBox1.Visible = false;

            RefreshData();
        }

        private void Control_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        
        //Метод перезаполнения datagGridView
        public void RefreshData()
        {
            // Фильмы
            if (radioButton1.Checked)
            {
                dataGridView1.Rows.Clear();
                int count = Data.Movies.Count;
                for (int i = 0; i < count; i++)
                {
                    dataGridView1.Rows.Add(Data.Movies[i].NameMovie, Data.Countries[Data.Movies[i].Production - 1].NameCountry, Data.Movies[i].YearOfIssue, Data.Genres[Data.Movies[i].Genre - 1].NameGenre, Data.Movies[i].Duration);
                }
            } // Билеты
            else if (radioButton2.Checked)
            {
                dataGridView1.Rows.Clear();
                int count = Data.Tickets.Count;

                for (int i = 0; i < count; i++)
                {
                    //Выборка цены
                    decimal price = 0m;
                    for(int j = 0; j < Data.Prices.Count; j++)
                    {
                        if (Data.Prices[j].IDPrice == Data.Tickets[i].idPrice)
                            price = Data.Prices[j].price;
                    }

                    price = Math.Truncate(price * 100) / 100;

                    dataGridView1.Rows.Add(Data.Tickets[i].Session, Data.Tickets[i].Row, Data.Tickets[i].Place, Data.Tickets[i].Sold, price);
                }
            } // Сеансы
            else if (radioButton3.Checked)
            {
                dataGridView1.Rows.Clear();
                int count = Data.Sessions.Count;
                for (int i = 0; i < count; i++)
                {
                    dataGridView1.Rows.Add(Data.Sessions[i].Date.ToLongDateString(), Data.Sessions[i].Time.ToString().Remove(5, 3), Data.Halls[Data.Sessions[i].Hall - 1].NameHall, Data.Movies[Data.Sessions[i].Movie - 1].NameMovie);
                }
            }
        }
        
        // Настройка окна 
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                switch (radioButton.Text)
                {
                    case "Фильмы":
                        {
                            comboBox1.Visible = true;
                            comboBox2.Visible = false;
                            comboBox3.Visible = true;
                            checkBox1.Visible = false;
                            dateTimePicker1.Visible = false;

                            textBox1.Visible = false;
                            textBox2.Text = "";
                            textBox2.Visible = true;
                            textBox3.Visible = false;
                            textBox4.Visible = true;
                            textBox5.Visible = false;
                            textBox6.Visible = true;
                            label5.Visible = true;
                            label6.Visible = true;

                            for (int i = 0; i < Data.Genres.Count; i++)
                            {
                                comboBox3.Items.Add(Data.Genres[i].NameGenre);
                            }

                            for (int i = 0; i < Data.Countries.Count; i++)
                            {
                                comboBox1.Items.Add(Data.Countries[i].NameCountry);
                            }

                            label1.Text = "";
                            label2.Text = "Название фильма:";
                            label3.Text = "Производство:";
                            label4.Text = "Год выпуска:";
                            label5.Text = "Жанр:";
                            label6.Text = "Длительность, мин";

                            dataGridView1.Columns[0].HeaderText = "Название фильма";
                            dataGridView1.Columns[1].HeaderText = "Производство";
                            dataGridView1.Columns[2].HeaderText = "Дата выпуска";
                            dataGridView1.Columns[3].HeaderText = "Жанр";
                            if (dataGridView1.Columns.Count < 5)
                            {
                                dataGridView1.Columns.Add("", "");
                                dataGridView1.Columns[4].HeaderText = "Длительность, мин";
                            }
                            else
                                dataGridView1.Columns[4].HeaderText = "Длительность, мин";

                            if (dataGridView1.Columns.Count == 6)
                                dataGridView1.Columns.RemoveAt(5);

                            RefreshData();
                            break;
                        }
                    case "Билеты":
                        {
                            dataGridView1.Columns[0].HeaderText = "№ сеанса";
                            dataGridView1.Columns[1].HeaderText = "Ряд";
                            dataGridView1.Columns[2].HeaderText = "Место";
                            dataGridView1.Columns[3].HeaderText = "Занят/Не занят";
                            if (dataGridView1.Columns.Count < 5)
                            {
                                dataGridView1.Columns.Add("", "");
                                dataGridView1.Columns[4].HeaderText = "Цена, руб.";
                            }
                            else
                                dataGridView1.Columns[4].HeaderText = "Цена, руб.";

                            if (dataGridView1.Columns.Count == 6)
                                dataGridView1.Columns.RemoveAt(5);
                            else if (dataGridView1.Columns.Count == 7)
                                dataGridView1.Columns.RemoveAt(6);

                            comboBox3.Items.Clear();
                            comboBox2.Items.Clear();
                            comboBox1.Items.Clear();

                            for (int i = 1; i <= 15; i++)
                                comboBox3.Items.Add($"{i}");

                            for (int i = 1; i <= 13; i++)
                                comboBox2.Items.Add($"{i}");

                            for (int i = 0; i < Data.Sessions.Count; i++)
                            {
                                    comboBox1.Items.Add(Data.GetSessionID(Data.Sessions[i]));
                            }

                            textBox2.Text = "";
                            label5.Visible = true;
                            label6.Visible = true;
                            label1.Text = "";
                            label2.Text = "";
                            label3.Text = "Сеанс:";
                            label4.Text = "Ряд:";
                            label5.Text = "Место:";
                            label6.Text = "Занят/Не занят:";

                            dateTimePicker1.Visible = false;
                            comboBox1.Visible = true;
                            comboBox2.Visible = true;
                            comboBox3.Visible = true;
                            checkBox1.Visible = true;

                            textBox1.Visible = false;
                            textBox2.Visible = false;
                            textBox3.Visible = false;
                            textBox4.Visible = false;
                            textBox5.Visible = false;
                            textBox6.Visible = false;

                            RefreshData();
                            break;
                        }
                    case "Сеансы":
                        {
                            textBox1.Visible = true;
                            textBox2.Text = "";
                            textBox2.Visible = true;
                            dateTimePicker1.Visible = true;
                            comboBox1.Visible = true;
                            comboBox1.Items.Clear();
                            for (int i = 1; i <= Data.Halls.Count; i++)
                            {
                                comboBox1.Items.Add(Data.Halls[i - 1].NameHall);
                            }

                            label1.Text = "Дата:";
                            label2.Text = "Время:";
                            label3.Text = "Зал:";
                            label4.Text = "Фильм";
                            label5.Visible = false;
                            label6.Visible = false;

                            comboBox2.Visible = true;
                            comboBox3.Visible = false;
                            checkBox1.Visible = false;

                            textBox1.Visible = false;
                            textBox3.Visible = false;
                            textBox4.Visible = false;
                            textBox5.Visible = false;
                            textBox6.Visible = false;

                            dataGridView1.Columns[0].HeaderText = "Дата";
                            dataGridView1.Columns[1].HeaderText = "Время";
                            dataGridView1.Columns[2].HeaderText = "Зал";
                            dataGridView1.Columns[3].HeaderText = "Фильм";

                            if (dataGridView1.Columns.Count == 6)
                                dataGridView1.Columns.RemoveAt(5);

                            if (dataGridView1.Columns.Count == 5)
                                dataGridView1.Columns.RemoveAt(4);

                            comboBox2.Items.Clear();

                            //Добавление фильмов в комбобокс
                            for (int i = 0; i < Data.Movies.Count; i++)
                            {
                                comboBox2.Items.Add(Data.Movies[i].NameMovie);
                            }

                            RefreshData();
                            break;
                        }
                }
            }
        }

        // Добавление
        private void button1_Click(object sender, EventArgs e)
        {
            // Если выбраны фильмы
            if (radioButton1.Checked)
            {
                if (textBox2.Text != String.Empty && comboBox1.Text != String.Empty && textBox4.Text != String.Empty && comboBox3.Text != String.Empty && textBox6.Text != String.Empty)
                {
                    // Найдём код страны по названию
                    int id = 0;
                    for(int i = 0; i < Data.Countries.Count; i++)
                    {
                        if (Data.Countries[i].NameCountry.IndexOf(comboBox1.Text) != -1)
                            id = i;
                    }

                    // Найдём код жанра по названию
                    int id2 = 0;
                    for (int i = 0; i < Data.Genres.Count; i++)
                    {
                        if (Data.Genres[i].NameGenre.IndexOf(comboBox3.Text) != -1)
                            id2 = i;
                    }

                    Movie mv = new Movie(textBox2.Text, Data.Countries[id].idProduction, Convert.ToInt32(textBox4.Text), Data.Genres[id2].idGenre, Convert.ToInt32(textBox6.Text));

                    // Команда на добавлине в БД
                    Data.AddMovie(mv);

                    // Обновление DataGridView
                    RefreshData();
                }
                else
                {
                    MessageBox.Show("Какое-то из полей не заполнено!", "Уведомление");
                }

            }// Если выбраны билеты
            else if (radioButton2.Checked)
            {
                if (comboBox1.SelectedIndex != -1 && comboBox2.SelectedIndex != -1 && comboBox3.SelectedIndex != -1)
                {
                    Ticket tk = new Ticket(comboBox2.SelectedIndex + 1, comboBox3.SelectedIndex + 1, checkBox1.Checked, Convert.ToInt32(comboBox1.Text), Data.GetPriceID(Data.Sessions[comboBox1.SelectedIndex].Hall));

                    // Команда на добавлине в БД
                    Data.AddTicket(tk);

                    // Обновление DataGridView
                    RefreshData();
                }
                else
                {
                    MessageBox.Show("Какое-то из полей не заполнено!", "Уведомление");
                }
            } // Если выбраны сеансы
            else if (radioButton3.Checked)
            {
                if (textBox2.Text != String.Empty && comboBox1.SelectedIndex != -1 && comboBox2.SelectedIndex != -1)
                {
                    Session ss = new Session(dateTimePicker1.Value, TimeSpan.Parse(textBox2.Text), comboBox1.SelectedIndex + 1, comboBox2.SelectedIndex + 1);

                    // Команда на добавлине в БД
                    Data.AddSession(ss);

                    // Обновление DataGridView
                    RefreshData();
                }
                else
                {
                    MessageBox.Show("Какое-то из полей не заполнено!", "Уведомление");
                }
            }
        }

        // Удаление
        private void button2_Click(object sender, EventArgs e)
        {
            // Если выбран фильм
            if (radioButton1.Checked)
            {
                if (textBox2.Text != String.Empty && comboBox1.Text != String.Empty && textBox4.Text != String.Empty && comboBox3.Text != String.Empty && textBox6.Text != String.Empty)
                {
                    // Найдём код страны по названию
                    int id = 0;
                    for (int i = 0; i < Data.Countries.Count; i++)
                    {
                        if (Data.Countries[i].NameCountry.IndexOf(comboBox1.Text) != -1)
                            id = i;
                    }

                    // Найдём код жанра по названию
                    int id2 = 0;
                    for (int i = 0; i < Data.Genres.Count; i++)
                    {
                        if (Data.Genres[i].NameGenre.IndexOf(comboBox3.Text) != -1)
                            id2 = i;
                    }

                    Movie mv = new Movie(textBox2.Text, Data.Countries[id].idProduction, Convert.ToInt32(textBox4.Text), Data.Genres[id2].idGenre, Convert.ToInt32(textBox6.Text));

                    // Команда на удаление из БД
                    Data.DelMovie(mv);

                    // Обновление DataGridView
                    RefreshData();
                }
                else
                {
                    MessageBox.Show("Какое-то из полей не заполнено!", "Уведомление");
                }
            }// Если выбран билет
            else if (radioButton2.Checked)
            {
                if (comboBox1.SelectedIndex != -1 && comboBox2.SelectedIndex != -1 && comboBox3.SelectedIndex != -1)
                {
                    Ticket tk = new Ticket(comboBox2.SelectedIndex + 1, comboBox3.SelectedIndex + 1, checkBox1.Checked, Convert.ToInt32(comboBox1.Text), Data.GetPriceID(Data.Sessions[comboBox1.SelectedIndex].Hall));

                    // Команда на удаление из БД
                    Data.DelTicket(tk);

                    // Обновление DataGridView
                    RefreshData();
                }
                else
                {
                    MessageBox.Show("Какое-то из полей не заполнено!", "Уведомление");
                }
            }// Если выбран сеанс
            else if (radioButton3.Checked)
            {
                if (textBox2.Text != String.Empty && comboBox1.SelectedIndex != -1 && comboBox2.SelectedIndex != -1)
                {
                    Session ss = new Session(dateTimePicker1.Value, TimeSpan.Parse(textBox2.Text), comboBox1.SelectedIndex + 1, comboBox2.SelectedIndex + 1);

                    // Команда на удаление из БД
                    Data.DelSession(ss);

                    // Обновление DataGridView
                    RefreshData();
                }
                else
                {
                    MessageBox.Show("Какое-то из полей не заполнено!", "Уведомление");
                }
            }
        }

        // Изменить
        private void button3_Click(object sender, EventArgs e)
        {
            // Если выбраны фильмы
            if (radioButton1.Checked)
            {
                if (textBox2.Text != String.Empty && comboBox1.Text != String.Empty && textBox4.Text != String.Empty && comboBox3.Text != String.Empty && textBox6.Text != String.Empty && dataGridView1.CurrentRow is not null)
                {
                    // Найдём код страны по названию
                    int id = 0;
                    for (int i = 0; i < Data.Countries.Count; i++)
                    {
                        if (Data.Countries[i].NameCountry.IndexOf(comboBox1.Text) != -1)
                            id = i;
                    }

                    // Найдём код жанра по названию
                    int id2 = 0;
                    for (int i = 0; i < Data.Genres.Count; i++)
                    {
                        if (Data.Genres[i].NameGenre.IndexOf(comboBox3.Text) != -1)
                            id2 = i;
                    }

                    Movie newmv = new Movie(textBox2.Text, Data.Countries[id].idProduction, Convert.ToInt32(textBox4.Text), Data.Genres[id2].idGenre, Convert.ToInt32(textBox6.Text));
                   
                    Movie oldmv = Data.Movies[dataGridView1.CurrentCell.RowIndex];

                    // Команда на изменение в БД
                    Data.EditMovie(oldmv, newmv);

                    // Обновление DataGridView
                    RefreshData();
                }
                else
                    MessageBox.Show("Вы не ввели изменённые данные", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }// Если выбраны билеты
            else if (radioButton2.Checked)
            {
                Ticket newtk = new Ticket(comboBox2.SelectedIndex + 1, comboBox3.SelectedIndex + 1, checkBox1.Checked, Convert.ToInt32(comboBox1.Text), Data.GetPriceID(Data.Sessions[comboBox1.SelectedIndex].Hall));
                
                Ticket oldtk = Data.Tickets[dataGridView1.CurrentCell.RowIndex];
                
                // Команда на изменение в БД
                Data.EditTicket(oldtk, newtk);

                // Обновление DataGridView
                RefreshData();
            }// Если выбраны сеансы
            else if (radioButton3.Checked)
            {
                Session newss = new Session(dateTimePicker1.Value, TimeSpan.Parse(textBox2.Text), comboBox1.SelectedIndex + 1, comboBox2.SelectedIndex + 1);

                Session oldss = Data.Sessions[dataGridView1.CurrentCell.RowIndex];

                // Команда на изменение в БД
                Data.EditSession(oldss, newss);

                // Обновление DataGridView
                RefreshData();
            }
        }
        // Подставка данных при выборе строки в DataGridView 
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            // Если выбраны фильмы
            if (radioButton1.Checked)
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                    textBox2.Text = selectedRow.Cells[0].Value.ToString();
                    comboBox1.Text = selectedRow.Cells[1].Value.ToString();
                    textBox4.Text = selectedRow.Cells[2].Value.ToString();
                    comboBox3.Text = selectedRow.Cells[3].Value.ToString();
                    textBox6.Text = selectedRow.Cells[4].Value.ToString();
                }
            }// Если выбраны билеты
            else if (radioButton2.Checked)
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                    comboBox1.Text = selectedRow.Cells[0].Value.ToString();
                    comboBox2.Text = selectedRow.Cells[1].Value.ToString();
                    comboBox3.Text = selectedRow.Cells[2].Value.ToString();
                    checkBox1.Checked = Convert.ToBoolean(selectedRow.Cells[3].Value);
                }
            }// Если выбраны сеансы
            else if (radioButton3.Checked)
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                    dateTimePicker1.Text = selectedRow.Cells[0].Value.ToString();
                    textBox2.Text = selectedRow.Cells[1].Value.ToString();
                    comboBox1.Text = selectedRow.Cells[2].Value.ToString();
                    comboBox2.Text = selectedRow.Cells[3].Value.ToString();
                }
            }
        }
    }
}
