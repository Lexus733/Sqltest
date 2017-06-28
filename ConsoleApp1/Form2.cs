using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;


namespace ConsoleApp1
{
    public partial class Form2 : Form
    {
        Program pr = new Program();

        private DataTable CreateTable()
        {
            //создаём таблицу
            DataTable dt = new DataTable("Friends");
            //создаём три колонки
            DataColumn colID = new DataColumn("ID", typeof(Int32));
            DataColumn colName = new DataColumn("Name", typeof(String));
            DataColumn colAge = new DataColumn("Age", typeof(Int32));
            //добавляем колонки в таблицу
            dt.Columns.Add(colID);
            dt.Columns.Add(colName);
            dt.Columns.Add(colAge);
            DataRow row = null;
            //создаём новую строку
            row = dt.NewRow();
            //заполняем строку значениями
            row["ID"] = 1;
            row["Name"] = "Vanya";
            row["Age"] = 45;
            //добавляем строку в таблицу
            dt.Rows.Add(row);
            //создаём ещё одну запись в таблице
            row = dt.NewRow();
            row["ID"] = 2;
            row["Name"] = "Vasya";
            row["Age"] = 35;
            dt.Rows.Add(row);
            return dt;
        }
        private void ExportToExcel()
        {
            Excel.Application exApp = new Excel.Application();
            exApp.Visible = true;
            exApp.Workbooks.Add();
            Excel.Worksheet workSheet = (Excel.Worksheet)exApp.ActiveSheet;
            workSheet.Cells[1, 1] = "Id";
            workSheet.Cells[1, 2] = "Name";
            workSheet.Cells[1, 3] = "Age";
            int rowExcel = 2;
            for (int i = 0; i < CreateTable().Rows.Count; i++)
            {
                workSheet.Cells[rowExcel, "A"] = CreateTable().Rows[i].Field<int>("Id");
                workSheet.Cells[rowExcel, "B"] = CreateTable().Rows[i].Field<string>("Name");
                workSheet.Cells[rowExcel, "C"] = CreateTable().Rows[i].Field<int>("Age");
                ++rowExcel;
            }
            workSheet.SaveAs(Environment.CurrentDirectory + "MyFile.xls");
        }

        public Form2()
        {
            
           
            InitializeComponent();
            dataGridView1.DataSource = CreateTable();
        }

        private void crewBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.crewBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.database1DataSet);

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database1DataSet.Race". При необходимости она может быть перемещена или удалена.
            this.raceTableAdapter.Fill(this.database1DataSet.Race);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database1DataSet.Crew". При необходимости она может быть перемещена или удалена.
            this.crewTableAdapter.Fill(this.database1DataSet.Crew);

        }

        private void raceDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }


        private void button2_Click(object sender, EventArgs e)
        {
            CreateTable();
            ExportToExcel();
        }
    }
}
    
