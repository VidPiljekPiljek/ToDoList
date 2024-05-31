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
using System.Security.Cryptography;
using System.Threading;

namespace ToDoList
{
    public partial class Form2 : Form
    {
        //public delegate void LoadListBoxCallback();
        //public LoadListBoxCallback LoadListBox;
        Form1 firstform = null;
        public Form2(Form1 first)
        {
            InitializeComponent();
            firstform = first;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string naziv = textBox1.Text;
            string path = Path.GetFullPath("ToDoList.exe");
            path = path.Replace("ToDoList.exe", naziv + ".csv");
            if (File.Exists(path))
            {
                MessageBox.Show("Datoteka već postoji, pokušajte ponovo.");
            }
            else
            {
                FileStream fs = File.Create(path);
                this.Close();
                //Form1 form1 = new Form1();
                //this.LoadListBox += new LoadListBoxCallback(form1.LoadListBox);
                firstform.LoadListBox();
                //form1.ShowDialog();
            }
        }
    }
}
