using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ToDoList
{
    public partial class Form4 : Form
    {
        Form3 form3 = null;

        public Form4(Form3 form)
        {
            InitializeComponent();
            form3 = form;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string zadatak1 = textBox1.Text;
            string vaznost = comboBox1.Text;
            string rok = dateTimePicker1.Text;
            form3.AddTask(zadatak1, vaznost, rok);
            this.Close();
        }
    }
}
