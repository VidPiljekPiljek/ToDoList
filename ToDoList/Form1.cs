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
    public partial class Form1 : Form
    {

        string selectedPath = null; // Za otvaranje odabranih datoteka u Form3

        public Form1()
        {
            InitializeComponent();
            string path = Path.GetFullPath("ToDoList.exe");
            path = path.Replace("ToDoList.exe", "");
            string[] files = System.IO.Directory.GetFiles(path, "*.csv");
            foreach (string file in files)
            {
                string datoteka = file;
                datoteka = datoteka.Replace(path, "");
                listBox1.Items.Add(datoteka);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var form2 = new Form2(this);
            form2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Odaberite nešto prvo!");
            }
            else
            {
                selectedPath = Path.GetFullPath(listBox1.SelectedItem.ToString());
                var form3 = new Form3(this);
                form3.Show();
            }
            
        }

        public void LoadListBox()
        {
            listBox1.Items.Clear();
            string path = Path.GetFullPath("ToDoList.exe");
            path = path.Replace("ToDoList.exe", "");
            string[] files = System.IO.Directory.GetFiles(path, "*.csv");
            foreach (string file in files)
            {
                string datoteka = file;
                datoteka = datoteka.Replace(path, "");
                listBox1.Items.Add(datoteka);
            }
        }

        public string SendSelectedPath()
        {
            //string selectedPathRef = selectedPath;
            //selectedPath = null;
            return selectedPath;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Odaberite nešto prvo!");
            }
            else
            {
                string datoteka = listBox1.SelectedItem.ToString();
                listBox1.Items.Remove(datoteka);
                string path = Path.GetFullPath(datoteka);
                File.Delete(path);
            }
        }
    }
}
