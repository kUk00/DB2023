using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaC
{
    internal static class Data
    {
        // Строка подключения
        private static string connectionString = "Data Source=(local);Initial Catalog=CinemaSystem;Integrated Security=true";

        // Списки которые хранят полученные данные
        public static List<Genre> Genres = new List<Genre>();
        public static List<Country> Countries = new List<Country>();
        public static List<Price> Prices = new List<Price>();
        public static List<Hall> Halls = new List<Hall>();
        public static List<Movie> Movies = new List<Movie>();
        public static List<Session> Sessions = new List<Session>();
        public static List<Ticket> Tickets = new List<Ticket>();
        
        public static List<decimal> money = new List<decimal>() { 7.5m, 8.9m, 6.5m };

        public static void Initialization()
        {
            GetGenresFromDB();
            GetCountriesFromDB();
            GetPricesFromDB();
            GetHallsFromDB();
            GetMoviesFromDB();
            GetSessionsFromDB();
            GetTicketsFromDB();
        }

        public static void GetGenresFromDB()
        {
            try
            {
                string query = "SELECT * FROM Genres";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(query, connection);
                    SqlDataReader reader = cmd.ExecuteReader();
                    
                    Genres.Clear();

                    while (reader.Read())
                    {
                        Genres.Add(new Genre(reader.GetString(1), reader.GetInt32(0)));
                    }

                    reader.Close();
                    connection.Close();
                }
            }
            catch (SqlException ex)
            {
                string error = string.Empty;

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
                    MessageBox.Show(error);
                }
            }
        }

        public static void GetCountriesFromDB()
        {
            try
            {
                string query = "SELECT * FROM Countries";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(query, connection);
                    SqlDataReader reader = cmd.ExecuteReader();

                    Countries.Clear();

                    while (reader.Read())
                    {
                        Countries.Add(new Country(reader.GetString(0), reader.GetInt32(1)));
                    }

                    reader.Close();
                    connection.Close();
                }
            }
            catch (SqlException ex)
            {
                string error = string.Empty;

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
                    MessageBox.Show(error);
                }
            }
        }

        public static void EditSession(Session oldss, Session newss)
        {
            try
            {
                string sqlExpression = $"UPDATE Sessions SET " +
                    $"Date = '{newss.Date}', Time = '{newss.Time}', Hall = '{newss.Hall}', Movie = '{newss.Movie}' WHERE " +
                    $"Date = '{oldss.Date}' AND Time = '{oldss.Time}' AND Hall = '{oldss.Hall}' AND Movie = '{oldss.Movie}'";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    int number = command.ExecuteNonQuery();
                    connection.Close();
                }

                Sessions[Sessions.IndexOf(oldss)] = newss;
                Initialization();
            }
            catch (SqlException ex)
            {
                string error = string.Empty;

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
                    MessageBox.Show(error);
                }
            }
        }
        
        public static void EditTicket(Ticket oldtk, Ticket newtk)
        {
            try
            {
                string sqlExpression = $"UPDATE Tickets SET " +
                    $"Row = '{newtk.Row}', Place = '{newtk.Place}', Sold = '{Convert.ToInt32(newtk.Sold)}', Session = '{newtk.Session}', idPrice = '{newtk.idPrice}' WHERE " +
                    $"Row = '{oldtk.Row}' AND Place = '{oldtk.Place}' AND Sold = '{Convert.ToInt32(oldtk.Sold)}' AND Session = '{oldtk.Session}' AND idPrice = '{oldtk.idPrice}'";
                
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    int number = command.ExecuteNonQuery();
                    connection.Close();
                }

                Tickets[Tickets.IndexOf(oldtk)] = newtk;
                Initialization();
            }
            catch (SqlException ex)
            {
                string error = string.Empty;

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
                    MessageBox.Show(error);
                }
            }
        }
        
        public static void EditMovie(Movie oldmv, Movie newmv)
        {
            try
            {
                string sqlExpression = $"UPDATE Movies SET " +
                    $"NameMovie = '{newmv.NameMovie}', Production = '{newmv.Production}', YearOfIssue = '{newmv.YearOfIssue}', iGenre = '{newmv.Genre}', Duration = '{newmv.Duration}' WHERE " +
                    $"NameMovie = '{oldmv.NameMovie}' AND Production = '{oldmv.Production}' AND YearOfIssue = '{oldmv.YearOfIssue}' AND iGenre = '{oldmv.Genre}' AND Duration = '{oldmv.Duration}'";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    int number = command.ExecuteNonQuery();
                    connection.Close();
                }

                Movies[Movies.IndexOf(oldmv)] = newmv;
                Initialization();
            }
            catch (SqlException ex)
            {
                string error = string.Empty;

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
                    MessageBox.Show(error);
                }
            }
        }
        
        public static void DelSession(Session ss)
        {
            try
            {
                string sqlExpression = $"DELETE FROM Sessions WHERE " +
                    $"Date = '{ss.Date}' AND Time = '{ss.Time}' AND Hall = '{ss.Hall}' " +
                    $"AND Movie = '{ss.Movie}'";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    int number = command.ExecuteNonQuery();
                    connection.Close();
                }

                Sessions.Remove(ss);
                Initialization();
            }
            catch (SqlException ex)
            {
                string error = string.Empty;

                foreach (SqlError err in ex.Errors)
                {
                    error += $"Message: {err.Message}\nLevel:{err.Class}\nProcedure:{err.Procedure}\nLineNumber:{err.LineNumber}\n";
                    MessageBox.Show(error);
                }
            }
        }

        public static void AddSession(Session ss)
        {
            try
            {
                string sqlExpression = $"INSERT INTO Sessions (Date, Time, Hall, Movie) VALUES " +
                    $"('{ss.Date}', '{ss.Time}', '{ss.Hall}', '{ss.Movie}')";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    int number = command.ExecuteNonQuery();
                    connection.Close();
                }

                Sessions.Add(ss);
            }
            catch (SqlException ex)
            {
                string error = string.Empty;

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
                    MessageBox.Show(error);
                }
            }
        }

        public static void DelTicket(Ticket tk)
        {
            try
            {
                string sqlExpression = $"DELETE FROM Tickets WHERE " +
                    $"Row = '{tk.Row}' AND Place = '{tk.Place}' AND Sold = '{tk.Sold}' " +
                    $"AND Session = '{tk.Session}' AND idPrice = '{tk.idPrice}'";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    int number = command.ExecuteNonQuery();
                    connection.Close();
                }

                Tickets.Remove(tk);
                Initialization();
            }
            catch (SqlException ex)
            {
                string error = string.Empty;

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
                    MessageBox.Show(error);
                }
            }
        }

        public static void AddTicket(Ticket tk)
        {
            try
            {
                string sqlExpression = $"INSERT INTO Tickets (Row, Place, Sold, Session, idPrice) VALUES " +
                    $"('{tk.Row}', '{tk.Place}', '{tk.Sold}', '{tk.Session}', '{tk.idPrice}')";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    int number = command.ExecuteNonQuery();
                    connection.Close();
                }

                Tickets.Add(tk);
            }
            catch (SqlException ex)
            {
                string error = string.Empty;

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
                    MessageBox.Show(error);
                }
            }
        }

        public static int GetSessionID(Session s)
        {
            int sID = -1;
            try
            {
                string sqlExpression = $"SELECT ID_Session FROM Sessions WHERE " +
                    $"Date = '{s.Date}' AND Time = '{s.Time}' AND Hall = '{s.Hall}' AND Movie = '{s.Movie}'";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    SqlDataReader reader = command.ExecuteReader();


                    while (reader.Read())
                    {
                        sID = reader.GetInt32(0);
                    }

                    reader.Close();
                    connection.Close();
                }
            }
            catch (SqlException ex)
            {
                string error = string.Empty;

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
                    MessageBox.Show(error);
                }
            }

            return sID;
        }

        public static int GetTicketID(Ticket t)
        {
            int tID = -1;
            try
            {
                string sqlExpression = $"SELECT IDticket FROM Tickets WHERE " +
                    $"Row = '{t.Row}' AND Place = '{t.Place}' AND Sold = '{t.Sold}' AND Session = '{t.Session}' AND idPrice = '{t.idPrice}'";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    SqlDataReader reader = command.ExecuteReader();


                    while (reader.Read())
                    {
                        tID = reader.GetInt32(0);
                    }

                    reader.Close();
                    connection.Close();
                }
            }
            catch (SqlException ex)
            {
                string error = string.Empty;

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
                    MessageBox.Show(error);
                }
            }

            return tID;
        }

        public static void DelMovie(Movie mv)
        {
            try
            {
                string sqlExpression = $"DELETE FROM Movies WHERE " +
                    $"NameMovie = '{mv.NameMovie}' AND Production = '{mv.Production}' AND YearOfIssue = '{mv.YearOfIssue}' " +
                    $"AND iGenre = '{mv.Genre}' AND Duration = '{mv.Duration}'";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    int number = command.ExecuteNonQuery();
                    connection.Close();
                }

                Movies.Remove(mv);
                Initialization();
            }
            catch (SqlException ex)
            {
                string error = string.Empty;

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
                    MessageBox.Show(error);
                }
            }
        }

        public static void AddMovie(Movie mv)
        {
            try
            {
                string sqlExpression = $"INSERT INTO Movies (NameMovie, Production, YearOfIssue, iGenre, Duration) VALUES " +
                    $"('{mv.NameMovie}', '{mv.Production}', '{mv.YearOfIssue}', '{mv.Genre}', '{mv.Duration}')";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    int number = command.ExecuteNonQuery();
                    connection.Close();
                }

                Movies.Add(mv);
            }
            catch (SqlException ex)
            {
                string error = string.Empty;

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
                    MessageBox.Show(error);
                }
            }
        }

        public static void GetPricesFromDB()
        {
            try
            {
                string query = "SELECT * FROM Prices";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(query, connection);
                    SqlDataReader reader = cmd.ExecuteReader();

                    Prices.Clear();

                    while (reader.Read())
                    {
                        Prices.Add(new Price(reader.GetInt32(0), reader.GetDecimal(1), reader.GetInt32(2)));
                    }

                    reader.Close();
                    connection.Close();
                }
            }
            catch (SqlException ex)
            {
                string error = string.Empty;

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
                    MessageBox.Show(error);
                }
            }
        }

        public static int GetPriceID(int idHall)
        {
            int pID = -1;
            try
            {
                string query = "SELECT * FROM Prices WHERE " + $"idHall = '{idHall}'";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(query, connection);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        pID = reader.GetInt32(0);
                    }

                    reader.Close();
                    connection.Close();
                }
            }
            catch (SqlException ex)
            {
                string error = string.Empty;

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
                    MessageBox.Show(error);
                }
            }

            return pID;
        }

        public static void GetHallsFromDB()
        {
            try
            {
                string query = "SELECT * FROM Halls";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(query, connection);
                    SqlDataReader reader = cmd.ExecuteReader();

                    Halls.Clear();

                    while (reader.Read())
                    {
                        Halls.Add(new Hall(reader.GetInt32(0), reader.GetString(1)));
                    }

                    reader.Close();
                    connection.Close();
                }
            }
            catch (SqlException ex)
            {
                string error = string.Empty;

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
                    MessageBox.Show(error);
                }
            }
        }

        public static void GetMoviesFromDB()
        {
            try
            {
                string query = "SELECT * FROM Movies";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(query, connection);
                    SqlDataReader reader = cmd.ExecuteReader();

                    Movies.Clear();

                    while (reader.Read())
                    {
                        Movies.Add(new Movie(reader.GetString(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetInt32(5)));
                    }

                    reader.Close();
                    connection.Close();
                }
            }
            catch (SqlException ex)
            {
                string error = string.Empty;

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
                    MessageBox.Show(error);
                }
            }
        }

        public static void GetSessionsFromDB()
        {
            try
            {
                string query = "SELECT * FROM Sessions";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(query, connection);
                    SqlDataReader reader = cmd.ExecuteReader();

                    Sessions.Clear();

                    while (reader.Read())
                    {
                        Sessions.Add(new Session(reader.GetDateTime(0), reader.GetTimeSpan(1), reader.GetInt32(2), reader.GetInt32(3)));
                    }

                    reader.Close();
                    connection.Close();
                }
            }
            catch(SqlException ex)
            {
                string error = string.Empty;

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
                    MessageBox.Show(error);
                }
            }
        }

        public static void GetTicketsFromDB()
        {
            try
            {
                string query = "SELECT * FROM Tickets";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(query, connection);
                    SqlDataReader reader = cmd.ExecuteReader();

                    Tickets.Clear();

                    while(reader.Read())
                    {
                        Tickets.Add(new Ticket(reader.GetInt32(1), reader.GetInt32(2), reader.GetBoolean(3), reader.GetInt32(4), reader.GetInt32(5)));
                    }

                    reader.Close();
                    connection.Close();
                }
            }
            catch (SqlException ex)
            {
                string error = string.Empty;

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
                    MessageBox.Show(error);
                }
            }
        }

    }
}
