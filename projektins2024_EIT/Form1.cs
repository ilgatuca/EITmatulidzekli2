using System;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

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

            httpClient = new HttpClient();
        }
        private SQLiteConnection connection;

        static SQLiteConnection CreateConeection()
        {
            SQLiteConnection mansjauns;
            mansjauns = new SQLiteConnection("Data Source=mansjauns.db; Version = 3; New = true; Compress = True;");
            try
            {
                mansjauns.Open();

            }
            catch
            {

            }
            return mansjauns;
        }
        //dzēst no datubāzes
        

        private void Button1_Click(object sender, EventArgs e)
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

        private void dzest_Click(object sender, EventArgs e)
        {
            if (int.TryParse(dzestid.Text, out int id))
            {
                {
                    SQLiteConnection sqlite_conn;
                    sqlite_conn = CreateConeection();

                    SQLiteCommand sqlite_cmd;
                    sqlite_cmd = sqlite_conn.CreateCommand();
                    sqlite_cmd.CommandText = "DELETE FROM mansjauns WHERE id=" + dzestid.Text + ";";
                    sqlite_cmd.ExecuteNonQuery();
                    dzestid.Clear();

                    MessageBox.Show("Izdzēsts no datubāzes");

                }
            }
            else
            { // izvada ziņojumu ja ir nepareiza vertība ievadīta
                MessageBox.Show("Ievadiet id ko vēlaties dzēst");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                 if (cbsieviete.Text != "")
                  {
                    using (SQLiteConnection sqlite_conn = CreateConnection())
                  {
                    sqlite_conn.Open();

                    using (SQLiteCommand sqlite_cmd = sqlite_conn.CreateCommand())
                    {
                        // Pievieno dataubazei notiektas kolonas
                        sqlite_cmd.CommandText = "INSERT INTO mansjauns(dzimums, vecums, matu_krasa, matu_vesture, struktura, matu_sausums, esanas_paradumi, cik_daudz_udeni_tu_dzer) " +
                                                 "VALUES(@dzimums, @vecums, @matu_krasa, @matu_vesture, @struktura, @matu_sausums, @esanas_paradumi, @cik_daudz_udeni_tu_dzer);";

                        // pievieno tb vertibas datubazes kolonam
                        if (cbsieviete.Checked == true)
                        {
                            sqlite_cmd.Parameters.AddWithValue("@dzimums", cbsieviete.Text);
                        }
                        if (cbvirietis.Checked == true)
                        {
                            sqlite_cmd.Parameters.AddWithValue("@dzimums", cbvirietis.Text);
                        }
                        if (cbvecums1.Checked == true)
                        {
                            sqlite_cmd.Parameters.AddWithValue("@vecums", cbvecums1.Text);
                        }
                        if (cbvecums2.Checked == true)
                        {
                            sqlite_cmd.Parameters.AddWithValue("@vecums", cbvecums2.Text);
                        }
                        if (cbgaisi.Checked == true)
                        {
                            sqlite_cmd.Parameters.AddWithValue("@matu_krasa", cbgaisi.Text);
                        }
                        if (cbtumsi.Checked == true)
                        {
                            sqlite_cmd.Parameters.AddWithValue("@matu_krasa", cbtumsi.Text);
                        }
                        if (cbnekrasoti.Checked == true)
                        {
                            sqlite_cmd.Parameters.AddWithValue("@matu_krasa", cbnekrasoti.Text);
                        }
                        if (cbkrasoti.Checked == true)
                        {
                            sqlite_cmd.Parameters.AddWithValue("@matu_krasa", cbkrasoti.Text);
                        }
                        if (cbbalinati.Checked == true)
                        {
                            sqlite_cmd.Parameters.AddWithValue("@matu_krasa", cbbalinati.Text);
                        }
                        if (cbtrausli.Checked == true)
                        {
                            sqlite_cmd.Parameters.AddWithValue("@struktura", cbtrausli.Text);
                        }
                        if (cbbojati.Checked == true)
                        {
                            sqlite_cmd.Parameters.AddWithValue("@struktura", cbbojati.Text);
                        }
                        if (cbplani.Checked == true)
                        {
                            sqlite_cmd.Parameters.AddWithValue("@struktura", cbplani.Text);
                        }
                        if (cbtaukaini.Checked == true)
                        {
                            sqlite_cmd.Parameters.AddWithValue("@struktura", cbtaukaini.Text);
                        }
                        if (cb13.Checked == true)
                        {
                            sqlite_cmd.Parameters.AddWithValue("@matu_sausums", cb13.Text);
                        }
                        if (cb47.Checked == true)
                        {
                            sqlite_cmd.Parameters.AddWithValue("@matu_sausums", cb47.Text);
                        }
                        if (cb810.Checked == true)
                        {
                            sqlite_cmd.Parameters.AddWithValue("@matu_sausums", cb810.Text);
                        }
                        if (cbvisedajs.Checked == true)
                        {
                            sqlite_cmd.Parameters.AddWithValue("@esanas_paradumi", cbvisedajs.Text);
                        }
                        if (cbvegetarietis.Checked == true)
                        {
                            sqlite_cmd.Parameters.AddWithValue("@esanas_paradumi", cbvegetarietis.Text);
                        }
                        if (cbvegans.Checked == true)
                        {
                            sqlite_cmd.Parameters.AddWithValue("@esanas_paradumi", cbvegans.Text);
                        }
                        if (cb01.Checked == true)
                        {
                            sqlite_cmd.Parameters.AddWithValue("@cik_daudz_udeni_tu_dzer", cb01.Text);
                        }
                        if (cb12.Checked == true)
                        {
                            sqlite_cmd.Parameters.AddWithValue("@cik_daudz_udeni_tu_dzer", cb12.Text);
                        }
                        if (cb23.Checked == true)
                        {
                            sqlite_cmd.Parameters.AddWithValue("@cik_daudz_udeni_tu_dzer", cb23.Text);
                        }
                        // šaujam
                        sqlite_cmd.ExecuteNonQuery();
                        MessageBox.Show("Saglabāts datubāzē");

                    }
                }
               }
                else
                {
                    MessageBox.Show("Lūdzu ievadiet nosaukumu");
                }

            }
        }

        private SQLiteConnection CreateConnection()
        {
            throw new NotImplementedException();
        }

        private async void api_Click(object sender, EventArgs e)
        {
            // Izveidojam URL, lai saņemtu datus no API
            string apiUrl = "https://world.openfoodfacts.org/api/v0/product/737628064502.json";

            // Iegūstam datus no API, izmantojot HttpClient
            HttpResponseMessage response = await httpClient.GetAsync(apiUrl);
            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                // Šeit varat veikt datu apstrādi un saglabāt tos datubāzē
                // Piemēram, varat deserializēt JSON un izmantot saņemtos datus

                // Pēc datu apstrādes saglabājam datus datubāzē
                await SaveDataToDatabase(data);
            }
            else
            {
                MessageBox.Show("Neizdevās iegūt datus no API");
            }
        }
    }
}
