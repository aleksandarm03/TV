using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication1
{
    
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        tv[] t = new tv[100];
        int n = 0;

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();

            try
            {
                StreamReader f = new StreamReader("tv.txt");
                n = 0;
                while (!f.EndOfStream)
                {
                    string p = f.ReadLine();
                    string m = f.ReadLine();
                    double c = Convert.ToDouble(f.ReadLine());
                    t[n] = new tv(p, m, c);
                    n++;
                }
                f.Close();

                for (int i = 0; i < n; i++)
                {
                    for (int j = i + 1; j < n; j++)
                    {
                        if (t[j].Cena < t[i].Cena)
                        {
                            tv pom = t[i];
                            t[i] = t[j];
                            t[j] = pom;
                        }
                    }
                }


                listBox1.Items.Clear();
                for (int i = 0; i < n; i++)
                {
                    listBox1.Items.Add("Naziv: " + t[i].Naziv);
                    listBox1.Items.Add("Model: " + t[i].Model);
                    //ne moze t[i].cena, zato sto je private
                    listBox1.Items.Add("Cena: " + t[i].Cena + "RSD");
                    listBox1.Items.Add("* * *");
                }
                button2.Enabled = false;
            }
            catch (Exception izuzetak)
            {
                MessageBox.Show(izuzetak.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                StreamReader fr = new StreamReader("tv.txt");
                n = 0;
                while (!fr.EndOfStream)
                {
                    string p = fr.ReadLine();
                    string m = fr.ReadLine();
                    double c = Convert.ToDouble(fr.ReadLine());
                    t[n] = new tv(p, m, c);
                    n++;
                }
                fr.Close();
                double procenat = Convert.ToDouble(textBox2.Text);
                for (int i = 0; i < n; i++)
                {
                    if (t[i].Naziv.Equals(textBox1.Text))
                    {
                        t[i].Cena = t[i].Cena * (100 - procenat) / 100;
                    }
                }
                listBox1.Items.Clear();
                StreamWriter fw = new StreamWriter("spisak.txt");
                for (int i = 0; i < n; i++)
                {
                    fw.WriteLine(t[i].Naziv);
                    fw.WriteLine(t[i].Model);
                    fw.WriteLine(t[i].Cena.ToString());
                }
                fw.Close();




                listBox1.Items.Clear();
                for (int i = 0; i < n; i++)
                {
                    listBox1.Items.Add("Naziv: " + t[i].Naziv);
                    listBox1.Items.Add("Model: " + t[i].Model);
                    listBox1.Items.Add("Cena: " + t[i].Cena + "RSD");
                    listBox1.Items.Add("* * *");
                }
                button2.Enabled = true;
            }
            catch (Exception izuzetak)
            {
                MessageBox.Show(izuzetak.Message);
            }
        }
    }
}