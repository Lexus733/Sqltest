using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace ConsoleApp1
{
    class Program
    {


        static void Main(string[] args)
        {
            InventoryDAL inv = new InventoryDAL();

            int id = 1;
            string name = "Dima";
            string city = "Ulyanovsk";

            int id2 = 2;
            string name2 = "Dima";
            string city2 = "Ulyanovsk";

            int id3 = 3;
            string name3 = "Dima";
            string city3 = "Ulyanovsk";

            inv.InsertData(id, name, city);
            inv.InsertData(id2, name2, city2);
            inv.InsertData(id3, name3, city3);
            Console.ReadKey();

        }
    }

    class InventoryDAL
    {
        public void InsertData(int id, string name, string city)
        {
            using (SqlConnection con = new SqlConnection(
           ConsoleApp1.Properties.Settings.Default.Database1ConnectionString))
            {
                con.Open();
                // Оператор SQL
                string sql = string.Format("INSERT INTO [Table]" +
                "([Id], [Name], [City]) Values(@Id,@Name,@City)");

                // Параметризованная команда
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                  SqlParameter param = new SqlParameter();
                   param.ParameterName = "@ID";
                  param.Value = id;
                   param.SqlDbType = SqlDbType.Int;
                  cmd.Parameters.Add(param);

                   param = new SqlParameter();
                 param.ParameterName = "@Name";
                 param.Value = name;
                   param.SqlDbType = SqlDbType.Char;
                    param.Size = 10;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter();
                    param.ParameterName = "@City";
                   param.Value = city;
                    param.SqlDbType = SqlDbType.Char;
                    param.Size = 10;
                    cmd.Parameters.Add(param);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
