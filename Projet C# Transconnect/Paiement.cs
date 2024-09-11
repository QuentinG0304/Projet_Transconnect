using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Quentin_Guignard_Transconnect
{
    public partial class Paiement : Form
    {
        public Commande commande;
        public int nb_passagers;
        public int volume;
        public string usage;
        public Paiement(Commande commande, int nb_passagers, int volume, string usage)
        {
            this.nb_passagers = nb_passagers;
            this.volume = volume;
            this.usage = usage;
            this.commande = commande;
            InitializeComponent();
            label2.Text = commande.Prix.ToString() + " €";
            this.nb_passagers = nb_passagers;
            this.volume = volume;
            this.usage = usage;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Replace(" ", "");
            bool correct = true;
            for (int i = 0; i < textBox1.TextLength && correct; i++)
            {
                if (textBox1.Text[i] != '1' && textBox1.Text[i] != '2' && textBox1.Text[i] != '3' && textBox1.Text[i] != '4' && textBox1.Text[i] != '5' && textBox1.Text[i] != '6' && textBox1.Text[i] != '7' && textBox1.Text[i] != '8' && textBox1.Text[i] != '9' && textBox1.Text[i] != '0')
                {
                    MessageBox.Show("Veuillez entrer un numéro de carte valide");
                    correct = false;
                }
            }
            if (correct)
            {
                string connectionString = "SERVER=localhost;PORT=3306;DATABASE=TransConnect;UID=root;PASSWORD=root;";
                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                MySqlDataReader reader;
                command.CommandText = $"SELECT count(*) FROM commande WHERE n_ss_client = {commande.client.Id};";
                reader = command.ExecuteReader();
                int nb_commandes = 0;
                if (reader.Read())
                {
                    nb_commandes = reader.GetInt32(0);
                }
                reader.Close();

                float total = 0;
                if(nb_commandes != 0)
                {
                    command.CommandText = $" SELECT sum(prix) FROM commande where n_ss_client = {commande.client.Id} ;";
                    reader = command.ExecuteReader();
                    reader.Read();
                    total = reader.GetFloat(0);
                }
                reader.Close();
                if (total < 10000 && total+commande.prix>10000)
                {
                    command.CommandText = $" UPDATE Client SET statut = 'Platine' WHERE n_ss = {commande.client.Id};";
                    reader = command.ExecuteReader();
                    reader.Close();
                    command.Dispose();
                }
                else if(total <6000 && total+commande.prix >6000)
                {
                    command.CommandText = $" UPDATE Client SET statut = 'OR' WHERE n_ss = {commande.client.Id};";
                    reader = command.ExecuteReader();
                    reader.Close();
                    command.Dispose();
                }
                else if(total < 3000 && total + commande.prix > 3000)
                {
                    command.CommandText = $" UPDATE Client SET statut = 'Argent' WHERE n_ss = {commande.client.Id};";
                    reader = command.ExecuteReader();
                    reader.Close();
                    command.Dispose();
                }
                
                int partie_entiere = (int)commande.prix;
                int partie_decimale = (int)((commande.prix - partie_entiere) * 100);

                command = connection.CreateCommand();

                //Faire un pour chaque véhicule 
                if (nb_passagers != 0)
                {
                    command.CommandText = $" INSERT INTO Commande (id_commande, n_ss_client, n_ss_chauffeur, imma, depart, arrivee, jour, prix,nb_passagers,usage_,volume) VALUES ('{commande.id}',{commande.client.Id},{commande.chauffeur.Id},'{commande.vehicule.Immatriculation}','{commande.adresseDepart}','{commande.adresseArrivee}','{commande.dateCommande.Year}-{commande.dateCommande.Month}-{commande.dateCommande.Day}',{partie_entiere}.{partie_decimale},{nb_passagers},'',0);";
                }
                else if (volume != 0)
                {
                    command.CommandText = $" INSERT INTO Commande (id_commande, n_ss_client, n_ss_chauffeur, imma, depart, arrivee, jour, prix,nb_passagers,usage_,volume) VALUES ('{commande.id}',{commande.client.Id},{commande.chauffeur.Id},'{commande.vehicule.Immatriculation}','{commande.adresseDepart}','{commande.adresseArrivee}','{commande.dateCommande.Year}-{commande.dateCommande.Month}-{commande.dateCommande.Day}',{partie_entiere}.{partie_decimale},0,'',{volume});";
                }
                else
                {
                    command.CommandText = $" INSERT INTO Commande (id_commande, n_ss_client, n_ss_chauffeur, imma, depart, arrivee, jour, prix,nb_passagers,usage_,volume) VALUES ('{commande.id}',{commande.client.Id},{commande.chauffeur.Id},'{commande.vehicule.Immatriculation}','{commande.adresseDepart}','{commande.adresseArrivee}','{commande.dateCommande.Year}-{commande.dateCommande.Month}-{commande.dateCommande.Day}',{partie_entiere}.{partie_decimale},0,'{usage}',0);";
                }
                reader = command.ExecuteReader();
                MessageBox.Show("Paiement effectué, Commande réussie");
                this.Hide();
            }

        }

        private void Paiement_Load(object sender, EventArgs e)
        {

        }
    }
}
