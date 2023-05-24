using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CinemaC
{
    public partial class Adm : Form
    {
        public Adm()
        {
            InitializeComponent();
            eye.BackgroundImage = imageList1.Images[0];
            passwordbox.UseSystemPasswordChar = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = usernamebox.Text;
            string password = passwordbox.Text;
            try
            {
                string connectionString = "Data Source=(local);Initial Catalog=CinemaSystem;Integrated Security=true";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT Role FROM UserRoles WHERE UserLogin=@username AND UserPassword=@password", connection);
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);
                    object role = command.ExecuteScalar();
                    if (role != null)
                    {
                        if (role.ToString() == "admin")
                        {
                            // Авторизация администратора
                            this.Close();
                            this.DialogResult = DialogResult.OK;
                        }
                        else
                        {
                            // Остаёмся обычным пользователем
                            this.Close();
                            this.DialogResult = DialogResult.No;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Неверный логин или пароль");
                    }
                    // Закрытие соединения с базой данных
                    connection.Close();
                }
            }
            catch (SqlException ex)
            {
                string error = ex.Message + "\n";

                foreach (SqlError err in ex.Errors)
                {
                    error += "Message: "
                    + err.Message
                    + "\n"
                    + "Level: "
                    + err.Class
                    + "\n"
                    + "Procedure: "
                    + err.Procedure
                    + "\n"
                    + "Line Number: "
                    + err.LineNumber
                    + "\n";
                }
                MessageBox.Show("Ошибка подключения к базе данных: " + ex.Message);
            }
        }

        private void eye_Click(object sender, EventArgs e)
        {
            if (passwordbox.UseSystemPasswordChar)
            {
                eye.BackgroundImage = imageList1.Images[0];
                passwordbox.UseSystemPasswordChar = false;
            }
            else
            {
                eye.BackgroundImage = imageList1.Images[1];
                passwordbox.UseSystemPasswordChar = true;
            }
        }
    }
}
