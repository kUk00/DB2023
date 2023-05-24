using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.SqlClient;

namespace CinemaC
{
    public partial class BookOfTicket : Form
    {
        public BookOfTicket()
        {
            InitializeComponent();
            RefreshData();
        }

        private void RefreshData()
        {
            dataGridView1.Rows.Clear();

            int count = Data.Tickets.Count();

            for (int i = 0; i < count; i++)
            {
                //Выборка цены
                decimal price = 0m;
                for (int j = 0; j < Data.Prices.Count; j++)
                {
                    if (Data.Prices[j].IDPrice == Data.Tickets[i].idPrice)
                        price = Data.Prices[j].price;
                }

                price = Math.Truncate(price * 100) / 100;

                dataGridView1.Rows.Add(Data.GetTicketID(Data.Tickets[i]), Data.Tickets[i].Session, Data.Tickets[i].Row, Data.Tickets[i].Place, Data.Tickets[i].Sold, price);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != String.Empty)
            {
                bool NotData = true;
                int count = Data.Tickets.Count();
                for (int i = 0; i < count; i++)
                {
                    if (textBox1.Text == Convert.ToString(Data.GetTicketID(Data.Tickets[i])))
                    {
                        NotData = false;
                        if (Data.Tickets[i].Sold == true)
                        {
                            MessageBox.Show("Увы, место уже забронировано кем-то другим!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            textBox1.Text = "";
                        }
                        else
                        {
                            textBox1.Text = "";

                            string connectionString = "Data Source=(local);Initial Catalog=CinemaSystem;Integrated Security=true";

                            string sqlExpression = $"UPDATE Tickets SET Sold = 1 WHERE IDticket = '{Data.GetTicketID(Data.Tickets[i])}'";

                            using (SqlConnection connection = new SqlConnection(connectionString))
                            {
                                connection.Open();
                                SqlCommand command = new SqlCommand(sqlExpression, connection);
                                int number = command.ExecuteNonQuery();
                                connection.Close();
                            }

                            //Обновление данных в классе
                            Data.Initialization();

                            // Обновление DataGridView
                            RefreshData();

                            MessageBox.Show("Билет успешно забронирован!", "Бронирование", MessageBoxButtons.OK);
                        }
                    }
                }
                
                if(NotData)
                {
                    MessageBox.Show("Такого № не существует", "Уведомление");
                    textBox1.Text = "";
                }
            }
            else
                MessageBox.Show("Вы не ввели номер билета", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
    }
}
