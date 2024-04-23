using System;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Threading.Tasks;
using System.IO;

namespace HairCareRecommendation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Izveidojam savienojuma ceļu, izmantojot relatīvo ceļu, lai dati būtu vienmēr pieejami aplikācijai
            string connectionString = "Data Source=mansjauns.db;Version=3;";
            connection = new SQLiteConnection(connectionString);
        }
        private SQLiteConnection connection;

        


            private void button1_Click(object sender, EventArgs e)
        {
            string recommendations = "";

            // Gender
            if (cbsieviete.Checked)
            {
                recommendations += "Dzimums: vīrietis\n";
                recommendations += "ieteikums: lieto sampunu kas piemerots viriesiem.\n\n";
            }
            else if (cbvirietis.Checked)
            {
                recommendations += "Dzimums: Sieviete\n";
                recommendations += "ieteikums: lieto sampūnus, kas domāti sievietēm.\n\n";
            }

            // Age
            if (cbvecums1.Checked)
            {
                recommendations += "Vecums: līdz 30\n";
                recommendations += "ieteikums: lieto šampūnu, kas ir bez sulfātiem.\n\n";
            }
            else if (cbvecums2.Checked)
            {
                recommendations += "Vecums: pēc 30\n";
                recommendations += "ieteikums: Izmantojiet šampūnu, kas paredzēts nobriedušiem matiem.\n\n";
            }

            if (cbgaisi.Checked)
            {
                recommendations += "Matu krasa: gaiši\n";
                recommendations += "ieteikums: lieto šampūnu, kas ir paredzeti gaisiem matiem.\n\n";
            }
            else if(cbtumsi.Checked)
            {
                recommendations += "Matu krasa: tumši\n";
                recommendations += "ieteikums: lieto šampūnu, kas ir paredzets tumsiem matiem.\n\n";
            }

            // Hair Drapery
            if (cbnekrasoti.Checked)
            {
                recommendations += "Matu vesture: nekrāsoti\n";
                recommendations += "ieteikums: Izmantojiet šampūnu, kas ir piemērots jūsu matu krāsai.\n\n";
            }
            else if (cbkrasoti.Checked)
            {
                recommendations += "Matu vesture: krāsoti\n";
                recommendations += "ieteikums: Izmantojiet šampūnu, kas paredzēts krāsotiem matiem.\n\n";
            }
            else if (cbbalinati.Checked)
            {
                recommendations += "Matu vesture: balināti\n";
                recommendations += "ieteikums: Izmantojiet šampūnu, kas paredzēts balinātiem matiem.\n\n";
            }

            // Hair Structure
            if (cbtrausli.Checked)
            {
                recommendations += "Matu struktūra: trausli\n";
                recommendations += "ieteikums: Izmantojiet šampūnu, kas paredzēts trausliem matiem.\n\n";
            }
            else if (cbbojati.Checked)
            {
                recommendations += "Matu vesture: bojāti\n";
                recommendations += "ieteikums: Izmantojiet šampūnu, kas paredzēts bojātiem matiem.\n\n";
            }
            else if (cbplani.Checked)
            {
                recommendations += "Matu vesture: plāni\n";
                recommendations += "ieteikums: Izmantojiet šampūnu, kas paredzēts, lai piešķirtu apjomu plāniem matiem.\n\n";
            }
            else if (cbtaukaini.Checked)
            {
                recommendations += "Matu vesture: eļļaini\n";
                recommendations += "ieteikums: Izmantojiet šampūnu, kas paredzēts eļļas ražošanas kontrolei.\n\n";
            }

            // Hair Dryness
            if (cb13.Checked)
            {
                recommendations += "matu sausums: 1-3\n";
                recommendations += "ieteikums: Izmantojiet mitrinošu šampūnu.\n\n";
            }
            else if (cb47.Checked)
            {
                recommendations += "matu sausums: 4-7\n";
                recommendations += "ieteikums: Izmantojiet dziļu kondicionējošu ārstēšanu reizi nedēļā.\n\n";
            }
            else if (cb810.Checked)
            {
                recommendations += "matu sausums: 8-10\n";
                recommendations += "ieteikums: Apsveriet iespēju lietot matu masku reizi nedēļā.\n\n";
            }

            // Eating Habits
            if (cbvisedajs.Checked)
            {
                recommendations += "ēšanas paradumi: Visēdājs\n";
                recommendations += "ieteikums: Pārliecinieties, ka uzturā saņemat pietiekami daudz olbaltumvielu un dzelzs, jo tie ir būtiski matu augšanai.\n\n";
            }
            else if (cbvegetarietis.Checked)
            {
                recommendations += "ēšanas paradumi: Veģetārietis\n";
                recommendations += "ieteikums: Pārliecinieties, ka uzturā saņemat pietiekami daudz olbaltumvielu un dzelzs, jo tie ir būtiski matu augšanai. Apsveriet iespēju lietot B12 papildinājumu, jo tas nav atrodams augu izcelsmes pārtikas produktos.\n\n";
            }
            else if (cbvegans.Checked)
            {
                recommendations += "ēšanas paradumi: Vegāns\n";
                recommendations += "ieteikums: Pārliecinieties, ka uzturā saņemat pietiekami daudz olbaltumvielu un dzelzs, jo tie ir būtiski matu augšanai. Apsveriet iespēju lietot B12 papildinājumu, jo tas nav atrodams augu izcelsmes pārtikas produktos.\n\n";
            }

            // Water Drinking
            if (cb01.Checked)
            {
                recommendations += "ūdens uzņemšana: 0-1 litri dienā\n";
                recommendations += "ieteikums: dzer vismaz 2l ūdens dienā, lai galvas āda un mati būtu mitrināti.\n\n";
            }
            else if (cb12.Checked)
            {
                recommendations += "ūdens uzņemšana: 1-2 litri dienā\n";
                recommendations += "ieteikums: dzer vismaz 2l ūdens dienā, lai galvas āda un mati būtu mitrināti.\n\n";
            }
            else if (cb23.Checked)
            {
                recommendations += "ūdens uzņemšana: 2-3 litri dienā\n";
                recommendations += "ieteikums: turpini dzert tik pat daudz udeni, lai mati butu mitrināti.\n\n";
            }

            richTextBox1.Text = recommendations;
        }

        
    }
}
