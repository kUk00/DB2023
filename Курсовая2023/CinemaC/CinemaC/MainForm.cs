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

        // ���������� � ����������� DataGridView
        public void DataStart()
        {
            dataGridView1.Rows.Clear();

            for (int i = 0; i < Data.Sessions.Count(); i++)
            {
                dataGridView1.Rows.Add(Data.GetSessionID(Data.Sessions[i]), Data.Sessions[i].Date.ToLongDateString(), Data.Sessions[i].Time.ToString().Remove(5,3), Data.Halls[Data.Sessions[i].Hall - 1].NameHall, Data.Movies[Data.Sessions[i].Movie - 1].NameMovie, Data.Movies[Data.Sessions[i].Movie - 1].Duration);
            }
        }

        // ����� �������� � ������������ �� ��������������
        private void AccountChanged()
        {
            if (������������ToolStripMenuItem.Checked == true)
            {
                new MainForm().Show();
            }
            else
            {
                Form adm = new Adm();
                adm.ShowDialog();
                if (adm.DialogResult == DialogResult.OK)
                {
                    MessageBox.Show("�� �������������� �� ����� ��������������", "�����������");
                    �������������ToolStripMenuItem.Checked = true;
                    ������������ToolStripMenuItem.Checked = false;
                    this.Hide();
                    new Control().Show();
                }
                else
                {
                    MessageBox.Show("�� �������� �������������", "�����������");
                    �������������ToolStripMenuItem.Checked = false;
                    ������������ToolStripMenuItem.Checked = true;
                }
            }
        }

        private void �������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            �������������ToolStripMenuItem.Checked = true;
            ������������ToolStripMenuItem.Checked = false;
            AccountChanged();
        }

        private void ������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            �������������ToolStripMenuItem.Checked = false;
            ������������ToolStripMenuItem.Checked = true;
            AccountChanged();
        }

        private void �����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // ��� ������ ���� ������
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                switch(radioButton.Text)
                {
                    case "�� ������":
                        {
                            label1.Text = "�������� ������:";
                            label1.Visible = true;
                            textBox1.Text = "";
                            textBox1.Visible = true;
                            labelID = 1;
                            CancelSearch.Visible = true;
                            break;
                        }
                    case "�� ����":
                        {
                            label1.Text = "���� �������������:";
                            label1.Visible = true;
                            textBox1.Text = "";
                            textBox1.Visible = true;
                            labelID = 2;
                            CancelSearch.Visible = true;
                            break;
                        }
                    case "�� �������":
                        {
                            label1.Text = "����� ������:";
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

        // �����, ����� � ���� ��� ������ �������� ������
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

        // ������ ������
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

        private void ������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("� ������� ���� ��������� �� ������ ���������� ������ �������, ���������� ����� ����������, ��� ���� � �����, ��� ���� � �������� ������, � ��� �� ����� ������������� ���� �����\n\n\n- ��� ������ �� ����������� ��������� ����������� ������� \"�����\"\n- ��� ������������ ������� �� ������ \"������������\"", "������", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        // ������ ������������
        private void BookOfTicket_Click(object sender, EventArgs e)
        {
            new BookOfTicket().ShowDialog();
        }
    }
}