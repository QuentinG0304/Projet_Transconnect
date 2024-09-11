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

namespace Quentin_Guignard_Transconnect
{
    public partial class Statistiques : Form
    {
        public Statistiques()
        {
            InitializeComponent();
            Nb_total_de_commande(label2);
            Prix_moyen(label4);
            Meilleur_client(label6);
            Meilleur_vehicule(label7);
            Meilleur_chauffeur(label10);

        }

        private void Nb_total_de_commande(Label label)
        {
            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=TransConnect;UID=root;PASSWORD=root;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = $" SELECT COUNT(*) FROM commande;";
            MySqlDataReader reader = command.ExecuteReader();
            reader.Read();
            label.Text = Convert.ToString(reader.GetInt32("COUNT(*)"));
            reader.Close();
            command.Dispose();
        }

        private void Prix_moyen(Label label)
        {
            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=TransConnect;UID=root;PASSWORD=root;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = $" SELECT AVG(prix) FROM commande;";
            MySqlDataReader reader = command.ExecuteReader();
            reader.Read();
            label.Text = Convert.ToString(reader.GetFloat("AVG(prix)")) +" €";
            reader.Close();
            command.Dispose();
        }

        private void Meilleur_client(Label label)
        {
            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=TransConnect;UID=root;PASSWORD=root;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = $" SELECT nom, prenom FROM client WHERE n_ss = (SELECT n_ss_client FROM commande GROUP BY n_ss_client ORDER BY SUM(prix) DESC LIMIT 1);";
            MySqlDataReader reader = command.ExecuteReader();
            reader.Read();
            label.Text = reader.GetString("nom") + " " + reader.GetString("prenom");
            reader.Close();
            command.Dispose();
        }

        private void Meilleur_vehicule(Label label)
        {
            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=TransConnect;UID=root;PASSWORD=root;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = $"SELECT type_vehicule, SUM(prix) AS revenus_totaux FROM Vehicule JOIN Commande ON Vehicule.imma = Commande.imma GROUP BY type_vehicule ORDER BY revenus_totaux DESC LIMIT 1;";
            MySqlDataReader reader = command.ExecuteReader();
            reader.Read();
            label.Text = reader.GetString("type_vehicule");
            reader.Close();
            command.Dispose();
        }

        private void Meilleur_chauffeur(Label label)
        {
            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=TransConnect;UID=root;PASSWORD=root;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = $" SELECT nom, prenom FROM salarie WHERE n_ss = (SELECT n_ss_chauffeur FROM commande GROUP BY n_ss_chauffeur ORDER BY SUM(prix) DESC LIMIT 1);";
            MySqlDataReader reader = command.ExecuteReader();
            reader.Read();
            label.Text = reader.GetString("nom") + " " + reader.GetString("prenom");
            reader.Close();
            command.Dispose();
        }

        private void Statistiques_Load(object sender, EventArgs e)
        {

        }
    }
}
