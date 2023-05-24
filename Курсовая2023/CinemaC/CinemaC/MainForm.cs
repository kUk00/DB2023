namespace CinemaC
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            Data.Initialization();
            DataStart();
            label1.Visible = false;
            textBox1.Visible = false;
        }

        int labelID = 0;

        // Заполнение и отображение DataGridView
        public void DataStart()
        {
            dataGridView1.Rows.Clear();

            for (int i = 0; i < Data.Sessions.Count(); i++)
            {
                dataGridView1.Rows.Add(Data.GetSessionID(Data.Sessions[i]), Data.Sessions[i].Date.ToLongDateString(), Data.Sessions[i].Time.ToString().Remove(5,3), Data.Halls[Data.Sessions[i].Hall - 1].NameHall, Data.Movies[Data.Sessions[i].Movie - 1].NameMovie, Data.Movies[Data.Sessions[i].Movie - 1].Duration);
            }
        }

        // Смена аккаунта с пользователя до администратора
        private void AccountChanged()
        {
            if (пользовательToolStripMenuItem.Checked == true)
            {
                new MainForm().Show();
            }
            else
            {
                Form adm = new Adm();
                adm.ShowDialog();
                if (adm.DialogResult == DialogResult.OK)
                {
                    MessageBox.Show("Вы авторизовались от имени администратора", "Уведомление");
                    администраторToolStripMenuItem.Checked = true;
                    пользовательToolStripMenuItem.Checked = false;
                    this.Hide();
                    new Control().Show();
                }
                else
                {
                    MessageBox.Show("Вы остались пользователем", "Уведомление");
                    администраторToolStripMenuItem.Checked = false;
                    пользовательToolStripMenuItem.Checked = true;
                }
            }
        }

        private void администраторToolStripMenuItem_Click(object sender, EventArgs e)
        {
            администраторToolStripMenuItem.Checked = true;
            пользовательToolStripMenuItem.Checked = false;
            AccountChanged();
        }

        private void пользовательToolStripMenuItem_Click(object sender, EventArgs e)
        {
            администраторToolStripMenuItem.Checked = false;
            пользовательToolStripMenuItem.Checked = true;
            AccountChanged();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // При выборе типа поиска
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                switch(radioButton.Text)
                {
                    case "По фильму":
                        {
                            label1.Text = "Название фильма:";
                            label1.Visible = true;
                            textBox1.Text = "";
                            textBox1.Visible = true;
                            labelID = 1;
                            CancelSearch.Visible = true;
                            break;
                        }
                    case "По дате":
                        {
                            label1.Text = "Дата представления:";
                            label1.Visible = true;
                            textBox1.Text = "";
                            textBox1.Visible = true;
                            labelID = 2;
                            CancelSearch.Visible = true;
                            break;
                        }
                    case "По времени":
                        {
                            label1.Text = "Время фильма:";
                            label1.Visible = true;
                            textBox1.Text = "";
                            textBox1.Visible = true;
                            labelID = 3;
                            CancelSearch.Visible = true;
                            break;
                        }
                    default:
                        break;
                }
            }
        }

        // Поиск, когда в окно для поиска вводится символ
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string str = textBox1.Text;
            dataGridView1.Rows.Clear();
            int count = Data.Sessions.Count;
            for(int i = 0; i < count; i++)
            {
                if (labelID == 1)
                {
                    if (Data.Movies[Data.Sessions[i].Movie - 1].NameMovie.IndexOf(str) != -1)
                    {
                        dataGridView1.Rows.Add(Data.GetSessionID(Data.Sessions[i]), Data.Sessions[i].Date.ToLongDateString(), Data.Sessions[i].Time.ToString().Remove(3, 3), Data.Sessions[i].Hall, Data.Movies[Data.Sessions[i].Movie - 1].NameMovie, Data.Movies[Data.Sessions[i].Movie - 1].Duration);
                    }
                }
                else if (labelID == 2)
                {
                    if (Data.Sessions[i].Date.ToLongDateString().IndexOf(str) != -1)
                    {
                        dataGridView1.Rows.Add(Data.GetSessionID(Data.Sessions[i]), Data.Sessions[i].Date.ToLongDateString(), Data.Sessions[i].Time.ToString().Remove(3, 3), Data.Sessions[i].Hall, Data.Movies[Data.Sessions[i].Movie - 1].NameMovie, Data.Movies[Data.Sessions[i].Movie - 1].Duration);
                    }
                }
                else if (labelID == 3)
                {
                    if (Data.Sessions[i].Time.ToString().Remove(3, 3).IndexOf(str) != -1)
                    {
                        dataGridView1.Rows.Add(Data.GetSessionID(Data.Sessions[i]), Data.Sessions[i].Date.ToLongDateString(), Data.Sessions[i].Time.ToString().Remove(3,3), Data.Sessions[i].Hall, Data.Movies[Data.Sessions[i].Movie - 1].NameMovie, Data.Movies[Data.Sessions[i].Movie - 1].Duration);
                    }
                }

            }
        }

        // Отмена поиска
        private void CancelSearch_Click(object sender, EventArgs e)
        {
            CancelSearch.Visible = false;
            textBox1.Text = "";
            textBox1.Visible = false;
            label1.Visible = false;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            DataStart();
        }

        private void помощьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("С помощью этой программы вы можете посмотреть список сеансов, включающий такую информацию, как дата и время, тип зала и название фильма, а так же можно забронировать себе билет\n\n\n- Для поиска по определённым критериям используйте область \"Поиск\"\n- Для бронирования нажмите на кнопку \"Бронирование\"", "Помощь", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        // Кнопка бронирования
        private void BookOfTicket_Click(object sender, EventArgs e)
        {
            new BookOfTicket().ShowDialog();
        }
    }
}