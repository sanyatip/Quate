using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace QuateProject
{
    class DT
    {
        MySqlConnectionStringBuilder connectionStr;
        MySqlConnection connection;

        public void CreateStrConnection()
        {
            connectionStr = new MySqlConnectionStringBuilder();
            connectionStr.Server = "localhost";
            connectionStr.UserID = "root";
            connectionStr.Password = "root";
            connectionStr.Database = "quote";
            connection = new MySqlConnection(connectionStr.ToString());
        }



        public void Addquote(string Text, string Author, string Link)
        {

            string CommandText = $"INSERT INTO quote_table (quoteText,quoteAuthor,quoteLink) VALUES ('{Text}','{Author}','{Link}');";


            try
            {

                connection.Open();

                MySqlCommand command = new MySqlCommand(CommandText, connection);

                command.ExecuteNonQuery();

            }
            catch (Exception error)
            {
                System.Windows.MessageBox.Show(error.Message);
            }
            connection.Close();

        }

        public List<BD> Grquote()
        {
            List<BD> quotes = new List<BD>();

            string CommandText = $"SELECT * FROM quote_table;";

            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(CommandText, connection);

                MySqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        quotes.Add(new BD()
                        {
                            idtable1 = reader.GetInt32(0),
                            quoteText = reader.GetString(1),
                            quoteAuthor = reader.GetString(2),
                            quoteLink = reader.GetString(3)
                        });
                    }
                }

            }
            catch (Exception error)
            {
                System.Windows.MessageBox.Show(error.Message);
            }
            connection.Close();
            return quotes;
        }

    }

}
