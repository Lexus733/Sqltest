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
            int id;
            Int32.TryParse(Console.ReadLine(), out id);
            string name = "Dima";
            string city = "Ulyanovsk";

            int id2;
            Int32.TryParse(Console.ReadLine(), out id2);
            string name2 = "Dima";
            string city2 = "Ulyanovsk";

            int id3;
            Int32.TryParse(Console.ReadLine(), out id3);
            string name3 = "Dima";
            string city3 = "Ulyanovsk";

            inv.InsertData(id, name, city);
            inv.InsertData(id2, name2, city2);
            inv.InsertData(id3, name3, city3);
            inv.ChangeData(1, "Andrey");
            inv.DeleteData(2);
        }
    }

    class InventoryDAL
    {
        public void InsertData(int id, string name, string city)
        {
            string sql = string.Format("INSERT INTO [Table]" +
               "([Id], [Name], [City]) Values(@Id,@Name,@City)");

            using (SqlConnection con = new SqlConnection(
           ConsoleApp1.Properties.Settings.Default.Database1ConnectionString))
            {
              
                try
                {
                    con.Open();
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
                catch (SqlException ex)
                { Console.WriteLine(ex.Message); }
                finally
                  { con.Close(); }
            }
        }
        public void DeleteData(int id)
        {
            string sql = string.Format("DELETE FROM [Table] WHERE [Id] = '{0}'", id);

            using (SqlConnection con = new SqlConnection(
          ConsoleApp1.Properties.Settings.Default.Database1ConnectionString))
            {
              
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {

                    }
                    finally
                    {
                        con.Close();
                    }
                }

            }
        }

            public void ChangeData(int id, string newName)
            {
              string sql = string.Format("UPDATE [Table] SET [Name] = '{0}' WHERE [Id] = '{1}'",
                 newName, id);
            using (SqlConnection con = new SqlConnection(
              ConsoleApp1.Properties.Settings.Default.Database1ConnectionString))
                {
                try
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException ex)
                { }
                finally
                { con.Close(); }
                }
            }
        }
    }
