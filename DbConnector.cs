using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

namespace WpfApp1
{
    internal static class DbConnector
    {
        private static readonly string ConnStr = "Server=localhost;DataBase=testDb;port=3306;User Id=ivan;password=Testpass123";
        private static readonly MySqlConnection Conn = new MySqlConnection(ConnStr);

        static DbConnector()
        {
            Conn.Open();
        }

        public static long AddRecord(Record record)
        {
            try
            {
                var cmd = Conn.CreateCommand();
                cmd.CommandText = "INSERT INTO `integrals` (lowLimit, highLimit, integralValue) VALUES (@low, @high, @value)";
                cmd.Parameters.Add(new MySqlParameter("@low", record.LowLimit));
                cmd.Parameters.Add(new MySqlParameter("@high", record.HighLimit));
                cmd.Parameters.Add(new MySqlParameter("@value", record.IntegralValue));
                cmd.ExecuteNonQuery();
                return cmd.LastInsertedId;
            }
            catch
            {
                return -1;
            }
        }

        public static IEnumerable<Record> LoadAll()
        {
            List<Record> users = new List<Record> {};
            try
            {
                var cmd = Conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM `integrals`";
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            users.Add(new Record
                            (
                                reader.GetInt32("lowLimit"),
                                reader.GetInt32("highLimit"),
                                reader.GetInt32("integralValue")
                            ));
                        }
                    }
                }
            }
            catch
            {
            }
            Console.WriteLine(users);
            return users;
        }
    }
}