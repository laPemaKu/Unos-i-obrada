using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.IO;


namespace Kolekcije_Kategorije_vozila_xml
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            for(int i = 2023; i > 1769; i--)
            {
                comGodine.Items.Add(i);
            }
        }
        List<Vozilo> voziloList = new List<Vozilo>();
        
        private void btnUnos_Click(object sender, EventArgs e)
        {
            
            string model = txtModel.Text;
            int godina_proizvodnje = Convert.ToInt32(comGodine.SelectedItem.ToString()), broj_kotača = Convert.ToInt32(numUDbrojkotaca.Text);
            Vozilo vozilo = new Vozilo(model, godina_proizvodnje, broj_kotača);
            voziloList.Add(vozilo);
            txtModel.Clear();
            comGodine.SelectedItem = null;
        }

        private void btnObrada_Click(object sender, EventArgs e)
        {
            foreach(Vozilo vozilo in voziloList)
            {
                vozilo.OdabirKategorije();
            }
        }

        private void btnispis_Click(object sender, EventArgs e)
        {
            txtIspis.Clear();
            txtIspis.AppendText("Model\t\tGodina Proizvodnje\t\tBroj Kotača\tTip Vozila\n\r");
            foreach (Vozilo vozilo in voziloList)
            {
                txtIspis.AppendText("\n\r" + vozilo.Model + "\t\t" + vozilo.Godina_proizvodnje + "\t\t\t" + vozilo.Broj_kotaca + "\t\t" + vozilo.Tip_vozila + "\n\r");
            } 
        }

        private void btnSpremanjeXml_Click(object sender, EventArgs e)
        {
            XDocument xml = new XDocument(new XElement("Vozilo",
                from vozilo in voziloList
                select new XElement("Vozilo",
                new XAttribute("Model", vozilo.Model),
                new XAttribute("GodinaProizvodnje", vozilo.Godina_proizvodnje),
                new XAttribute("BrojKotaca", vozilo.Broj_kotaca),
                new XAttribute("TipVozila", vozilo.Tip_vozila))
                ));
            
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Xml files (*.xml)|*.xml";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.DefaultExt = "*.xml";

            if(saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using(StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                {
                    writer.WriteLine( xml.ToString());
                }
            }
            
        }

        private void btnUcitavanjeXml_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                using(StreamReader reader = new StreamReader(openFileDialog.FileName))
                {
                    txtIspis.Clear();
                    txtIspis.AppendText(reader.ReadToEnd());
                }
            }
        }
    }
}
