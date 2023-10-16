using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kolekcije_Kategorije_vozila_xml
{
    internal class Vozilo
    {
        private string model;
        private string tip_vozila;
        private int broj_kotaca;
        private int godina_proizvodnje;

        public string Model { get => model; set => model = value; }
        public int Godina_proizvodnje { get => godina_proizvodnje; set => godina_proizvodnje = value; }
        public int Broj_kotaca { get => broj_kotaca; set => broj_kotaca = value; }
        public string Tip_vozila { get => tip_vozila; set => tip_vozila = value; }

        public Vozilo(string model, int godina_proizvodnje, int broj_kotaca)
        {
            this.model = model;
            this.godina_proizvodnje = godina_proizvodnje;
            this.broj_kotaca = broj_kotaca;
        }

        public void OdabirKategorije()
        {
            if(this.broj_kotaca == 2)
            {
                Motocikl motocikl = new Motocikl(this.model, this.godina_proizvodnje, this.broj_kotaca);
                this.tip_vozila = "Motocikl";
                
            }
            if(this.broj_kotaca == 4)
            {
                Automobil automobil = new Automobil(this.model, this.godina_proizvodnje, this.broj_kotaca);
                this.tip_vozila = "Automobil";
            }
            if (this.broj_kotaca > 4)
            {
                Kamion kamion = new Kamion(this.model, this.godina_proizvodnje, this.broj_kotaca);
                this.tip_vozila = "Kamion";
            }
        }
    }

    class Motocikl : Vozilo
    {
        public Motocikl(string model, int godina_proizvodnje, int broj_kotaca) : base(model, godina_proizvodnje, broj_kotaca)
        {

        }
    }
    class Automobil : Vozilo
    {
        public Automobil(string model, int godina_proizvodnje, int broj_kotaca) : base(model, godina_proizvodnje, broj_kotaca)
        {

        }
    }
    class Kamion : Vozilo
    {
        public Kamion(string model, int godina_proizvodnje, int broj_kotaca) : base(model, godina_proizvodnje, broj_kotaca)
        {

        }
    }
}
