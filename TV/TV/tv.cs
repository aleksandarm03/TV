using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace WindowsFormsApplication1
{
    class tv
    {
        private string naziv, model;
        private double cena;

        public string Naziv
        {
            get { return naziv; }
        }

        public string Model
        {
            get { return model; }
        }

        public double Cena
        {
            get { return cena; }
            set
            {
                if (value < 0) throw new Exception("Cena ne moze biti negativan broj");
                else cena = value;
            }
        }

        public tv()
        {
            naziv = model = "";
            cena = 0;
        }

        public tv(string p, string m, double c)
        {
            if (p.Equals(String.Empty))
                throw new Exception("Nema naziv");
            if (m.Equals(String.Empty))
                throw new Exception("nema model");
            naziv = p;
            model = m;
            Cena = c;
        }

        public bool JeftinijiOd(tv t)
        {
            return cena < t.cena;
        }

        public static bool operator <(tv t1, tv t2)
        {
            return t1.cena < t2.cena;
        }

        public static bool operator >(tv t1, tv t2)
        {
            return t1.cena > t2.cena;
        }

        public override string ToString()
        {
            return naziv + " - " + model + " - " + cena + "RSD";
        }




        public void Prikaz(ListBox lb)
        {
            //lb.Items.Add(ToString());
            lb.Items.Add("naziv: " + naziv);
            lb.Items.Add("Model: " + model);
            lb.Items.Add("Cena: " + cena + "RSG");
            lb.Items.Add("* * *");
        }

        public void Unos(StreamReader f)
        {
            naziv = f.ReadLine();
            model = f.ReadLine();
            if (naziv.Equals(String.Empty))
                throw new Exception("nema naziv");
            if (model.Equals(String.Empty))
                throw new Exception("nema model");
            Cena = Convert.ToDouble(f.ReadLine()); //poziva set

            /* ukoliko nema svojstvo:
            double c = Convert.ToDouble(f.ReadLine());
            if (c < 0)
                throw new Exception("cena<0!");
            cena = c;
            */
        }

        public void Ispis(StreamWriter f)
        {
            f.WriteLine(naziv);
            f.WriteLine(model);
            f.WriteLine(cena);
        }

        public void Popust(double procenat)
        {
            cena = cena * (100 - procenat) / 100;
        }
    }


}
