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
using System.Security.Policy;
using System.Collections.Specialized;
using System.Numerics;
using System.Windows.Markup;

namespace ToDoList
{
    public partial class Form3 : Form
    {

        public struct Zadatak {
            public string zadatak;
            public string vaznost;
            public string rok;
        }
        //Zadatak zadatak = new Zadatak();
        List<Zadatak> zadatakList = new List<Zadatak>();
        string path = null;
        Form1 form1 = null;

        public Form3(Form1 form)
        {
            InitializeComponent();
            form1 = form;
            path = form1.SendSelectedPath();
            ReadFile(path);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form4 = new Form4(this);
            form4.Show();
        }

        public void ReadFile(string path)
        {
            zadatakList.Clear(); // Brišu se svi podatci u listi da se spriječi dupliciranje kod upisa podataka iz .csv datoteke u listu
            StreamReader sr = null;
            if (File.Exists(path))
            {
                sr = new StreamReader(File.OpenRead(path));
                while (!sr.EndOfStream)
                {
                    Zadatak zadatak = new Zadatak();
                    string line = sr.ReadLine();
                    listBox1.Items.Add(line);
                    var values = line.Split(',');
                    zadatak.zadatak = values[0];
                    zadatak.vaznost = values[1];
                    zadatak.rok = values[2];
                    zadatakList.Add(zadatak);
                }

                sr.Close();
            }
            else
            {
                MessageBox.Show("Datoteka ne postoji, pokušajte ponovo pokrenuti program.");
            }
        }

        public void AddTask(string zadatak1, string vaznost, string rok)
        {
            File.WriteAllText(path, string.Empty); // Briše sve podatke u .csv datoteci da se spriječi dupliciranje
            listBox1.Items.Clear(); // Briše sve podatke u .csv datoteci da se spriječi dupliciranje
            StringBuilder output = new StringBuilder();
            Zadatak zadatak = new Zadatak();
            zadatak.zadatak = zadatak1;
            zadatak.vaznost = vaznost;
            zadatak.rok = rok;
            zadatakList.Add(zadatak);
            foreach (Zadatak z in zadatakList)
            {
                output.Append(z.zadatak + "," + z.vaznost + "," + z.rok + "\n");
            }
            File.AppendAllText(path, output.ToString());
            ReadFile(path);
        }

        //public void RemoveTask(string zadatak)
        //{
        //    foreach(Zadatak z in zadatakList)
        //    {
        //        if (z.zadatak == zadatak1 && z.vaznost == vaznost && z.rok == rok)
        //        {
        //            zadatakList.Remove(z);
        //        }
        //    }
        //    StringBuilder output = new StringBuilder();
        //    foreach (Zadatak z in zadatakList)
        //    {
        //        output.Append(z.zadatak + "," + z.vaznost + "," + z.rok + "\n");
        //    }
        //    File.AppendAllText(path, output.ToString());
        //    ReadFile(path);
        //}

        private void button2_Click(object sender, EventArgs e)
        {
            RemoveTask(listBox1.SelectedItem.ToString());
        }

        public void RemoveTask(string line)
        {
            var values = line.Split(',');
            zadatakList.RemoveAll(z => z.zadatak == values[0] && z.vaznost == values[1] && z.rok == values[2]);
            StringBuilder output = new StringBuilder();
            File.WriteAllText(path, string.Empty); // Briše sve podatke u .csv datoteci da se spriječi dupliciranje kada se upisuju podatci u .csv datoteku iz liste
            listBox1.Items.Clear(); // Briše sve podatke u listBox-u da se spriječi dupliciranje
            foreach (Zadatak z in zadatakList)
            {
                output.Append(z.zadatak + "," + z.vaznost + "," + z.rok + "\n");
            }
            File.AppendAllText(path, output.ToString());
            ReadFile(path);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var form4 = new Form4(this);
            form4.Show();
        }
    }
}
