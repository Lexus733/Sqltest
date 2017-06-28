using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;


namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form2());

            InventoryDAL inv = new InventoryDAL();
            //     Crew crew = new Crew();
            //      Race race = new Race();


            //         inv.InsertCrew(crew.num,crew.drivers,crew.city,crew.car,crew.group,crew.carClass,"Crew");
            //          inv.InsertRace(race.id,race.title,race.dateBegin,race.dateEnd,race.pointRate,race.countST,race.penaltyToLate,race.penaltyToHold,race.penaltyKP,race.penaltyKS,"Race");


        }
    }

    class InventoryDAL
    {
        /*        public void InsertData(int id, string name, string city, DateTime date)
                {
                    string sql = string.Format("INSERT INTO [Table]" +
                       "([Id], [Name], [City],[Date]) Values(@Id,@Name,@City,@Date)");

                    using (SqlConnection con = new SqlConnection(
                   ConsoleApp1.Properties.Settings.Default.Database1ConnectionString))
                    {

                        try
                        {
                            con.Open();
                            using (SqlCommand cmd = new SqlCommand(sql, con))
                            {
                                SqlParameter param = new SqlParameter();
                                param.ParameterName = "@Id";
                                param.Value = id;
                                param.SqlDbType = SqlDbType.Int;
                                cmd.Parameters.Add(param);

                                param = new SqlParameter();
                                param.ParameterName = "@Name";
                                param.Value = name;
                                param.SqlDbType = SqlDbType.VarChar;
                                param.Size = 20;
                                cmd.Parameters.Add(param);

                                param = new SqlParameter();
                                param.ParameterName = "@City";
                                param.Value = city;
                                param.SqlDbType = SqlDbType.Char;
                                param.Size = 10;
                                cmd.Parameters.Add(param);

                                param = new SqlParameter();
                                param.ParameterName = "@Date";
                                param.Value = date;
                                param.SqlDbType = SqlDbType.Date;
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
                } */
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

        public DataTable GetAllYableAsDataTable(string tablee)
        {
            DataTable table = new DataTable();
            string sql = String.Format("SELECT * FROM [{0}]", tablee);
            using (SqlConnection con = new SqlConnection(
              ConsoleApp1.Properties.Settings.Default.Database1ConnectionString))
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        SqlDataReader dr = cmd.ExecuteReader();
                        table.Load(dr);
                        dr.Close();
                    }
                }
                catch (SqlException ex)
                { }
                finally
                { con.Close(); }

                return table;
            }
        }

        public void InsertCrew(int num, string drivers, string city, string car, string group, string carClass, string tableName)
        {
            string sql = string.Format("INSERT INTO [{0}]" +
               "([Num],[Drivers],[City],[Car],[Group],[CarClass]) Values(@Num,@Drivers,@City,@Car,@Group,@CarClass)", tableName);

            using (SqlConnection con = new SqlConnection(
           ConsoleApp1.Properties.Settings.Default.Database1ConnectionString))
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        SqlParameter param = new SqlParameter();
                        param.ParameterName = "@Num";
                        param.Value = num;
                        param.SqlDbType = SqlDbType.Int;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter();
                        param.ParameterName = "@Drivers";
                        param.Value = drivers;
                        param.SqlDbType = SqlDbType.VarChar;
                        param.Size = 50;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter();
                        param.ParameterName = "@City";
                        param.Value = city;
                        param.SqlDbType = SqlDbType.VarChar;
                        param.Size = 50;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter();
                        param.ParameterName = "@Car";
                        param.Value = car;
                        param.SqlDbType = SqlDbType.VarChar;
                        param.Size = 50;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter();
                        param.ParameterName = "@Group";
                        param.Value = group;
                        param.SqlDbType = SqlDbType.VarChar;
                        param.Size = 50;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter();
                        param.ParameterName = "@CarClass";
                        param.Value = carClass;
                        param.SqlDbType = SqlDbType.VarChar;
                        param.Size = 50;
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

        public void InsertRace(int id, string title, DateTime dateBegin, DateTime dateEnd, double pointRate, int countST, int penaltyToLate, int penaltyToHold, int penaltyKP, int penaltyKS, string tableName)
        {
            string sql = string.Format("INSERT INTO [{0}]" +
               "([Id],[Title],[DateBegin],[DateEnd],[PointRate],[CountST],[PenaltyToLate],[PenaltyToHold],[PenaltyKP],[PenaltyKS]) Values(@Id,@Title,@DateBegin,@DateEnd,@PointRate,@CountST,@PenaltyToLate,@PenaltyToHold,@PEnaltyKP,@PenaltyKS)", tableName);

            using (SqlConnection con = new SqlConnection(
           ConsoleApp1.Properties.Settings.Default.Database1ConnectionString))
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        SqlParameter param = new SqlParameter();
                        param.ParameterName = "@Id";
                        param.Value = id;
                        param.SqlDbType = SqlDbType.Int;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter();
                        param.ParameterName = "@Title";
                        param.Value = title;
                        param.SqlDbType = SqlDbType.VarChar;
                        param.Size = 50;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter();
                        param.ParameterName = "@DateBegin";
                        param.Value = dateBegin;
                        param.SqlDbType = SqlDbType.Date;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter();
                        param.ParameterName = "@DateEnd";
                        param.Value = dateEnd;
                        param.SqlDbType = SqlDbType.Date;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter();
                        param.ParameterName = "@PointRate";
                        param.Value = pointRate;
                        param.SqlDbType = SqlDbType.Float;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter();
                        param.ParameterName = "@CountST";
                        param.Value = countST;
                        param.SqlDbType = SqlDbType.Int;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter();
                        param.ParameterName = "@PenaltyToLate";
                        param.Value = penaltyToLate;
                        param.SqlDbType = SqlDbType.Int;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter();
                        param.ParameterName = "@PenaltyToHold";
                        param.Value = penaltyToHold;
                        param.SqlDbType = SqlDbType.Int;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter();
                        param.ParameterName = "@PenaltyKP";
                        param.Value = penaltyKP;
                        param.SqlDbType = SqlDbType.Int;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter();
                        param.ParameterName = "@PenaltyKS";
                        param.Value = penaltyKS;
                        param.SqlDbType = SqlDbType.Int;
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



        /*   class Crew
           {
              public int num = Int32.Parse(Console.ReadLine()); // стартовый номер
              public string drivers = Console.ReadLine().ToString(); // водители
              public string city = Console.ReadLine().ToString(); // город
              public string car = Console.ReadLine().ToString(); // авто
              public string group = Console.ReadLine().ToString(); // зачетная группа
              public string carClass = Console.ReadLine().ToString(); // класс
           }

           class SpecTrack
           {
             public int num; // стартовый номер экипажа
             public int countKP; // количество КП
             public int countKPpass; // количество пройденных КП
             public DateTime penaltyTimeKP; // штрафное время за непройденные КП
             public int countKS; // количество КС
             public int countKSpass; // количество пройденных КС
             public DateTime penaltyTimeKS; // штрафное время за непройденные КС
             public DateTime arrivePlan; // время прибытия на старт плановое
             public DateTime arriveFact; // время прибытия на старт фактическое
             public DateTime penaltyTimeToLate; // штрафное время за опоздание на старт
             public DateTime startPlan; // время старта плановое
             public DateTime startFact; // время старта фактическое
             public DateTime penaltyTimeToHold; // штрафное время за задержку старта
             public DateTime timeFinish; // время финиша
             public DateTime timeToPass; // время, потраченное на спецучасток
             public DateTime penaltyTimeAll; // сумма штрафов
             public DateTime timeFinally; // итоговое время с учетом штрафов
           }

           class Race
           {
             public int id = Int32.Parse(Console.ReadLine()); // идентификатор гонки
             public string title = Console.ReadLine().ToString(); // наименование гонки
             public DateTime dateBegin = DateTime.Today; // дата начала
             public DateTime dateEnd = DateTime.Today; // дата конца
             public double pointRate = Double.Parse(Console.ReadLine()); // коэффициент очков
             public int countST = Int32.Parse(Console.ReadLine()); // количество спец участков
             public int penaltyToLate = Int32.Parse(Console.ReadLine()); // штраф за опоздание
             public int penaltyToHold = Int32.Parse(Console.ReadLine()); // штраф за задержку старта
             public int penaltyKP = Int32.Parse(Console.ReadLine()); // штраф за пропуск КП
             public int penaltyKS = Int32.Parse(Console.ReadLine()); // штраф за пропуск КС
           }
           */


    }
}
