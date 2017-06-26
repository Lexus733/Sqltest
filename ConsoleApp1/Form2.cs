﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
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
    }
}
