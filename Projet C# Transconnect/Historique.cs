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
    public partial class Historique : Form
    {
        public Historique()
        {
            InitializeComponent();
            Label label = new Label();
            label.Text = Historique_des_commandes();
            label.Location = new Point(10, 10);
            label.AutoSize = true;
            panel1.Controls.Add(label);
            //Rendre le panel scrollable
            panel1.AutoScroll = true;

            //Replir la combobox
            comboBox1.Items.Add("Dernière semaine");
            comboBox1.Items.Add("Dernier Mois");
            comboBox1.Items.Add("Total");
        }

        private string Historique_des_commandes_mois()
        {
            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=TransConnect;UID=root;PASSWORD=root;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM commande WHERE jour > NOW() - INTERVAL 1 MONTH AND jour < NOW();";
            MySqlDataReader reader = command.ExecuteReader();
            string historique = "";
            while (reader.Read())
            {
                historique += $"Commande n°{reader.GetInt32("id_commande")} : {reader.GetDateTime("jour")} - {reader.GetFloat("prix")} €\n";
            }
            reader.Close();
            command.Dispose();
            return historique;
        }
        private string Historique_des_commandes_semaine()
        {
            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=TransConnect;UID=root;PASSWORD=root;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM commande WHERE jour > NOW() - INTERVAL 7 DAY AND jour < NOW();";
            MySqlDataReader reader = command.ExecuteReader();
            string historique = "";
            while (reader.Read())
            {
                historique += $"Commande n°{reader.GetInt32("id_commande")} : {reader.GetDateTime("jour")} - {reader.GetFloat("prix")} €\n";
            }
            reader.Close();
            command.Dispose();
            return historique;
        }
        private string Historique_des_commandes()
        {
            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=TransConnect;UID=root;PASSWORD=root;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = $" SELECT * FROM commande;";
            MySqlDataReader reader = command.ExecuteReader();
            string historique = "";
            while (reader.Read())
            {
                historique += $"Commande n°{reader.GetInt32("id_commande")} : {reader.GetDateTime("jour")} - {reader.GetFloat("prix")} €\n";
            }
            reader.Close();
            command.Dispose();
            return historique;
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedItem.ToString() == "Dernière semaine")
            {
                Label label = new Label();
                label.Text = Historique_des_commandes_semaine();
                label.Location = new Point(10, 10);
                label.AutoSize = true;
                panel1.Controls.Clear();
                panel1.Controls.Add(label);
            }
            else if (comboBox1.SelectedItem.ToString() == "Dernier Mois")
            {
                Label label = new Label();
                label.Text = Historique_des_commandes_mois();
                label.Location = new Point(10, 10);
                label.AutoSize = true;
                panel1.Controls.Clear();
                panel1.Controls.Add(label);
            }
            else if (comboBox1.SelectedItem.ToString() == "Total")
            {
                Label label = new Label();
                label.Text = Historique_des_commandes();
                label.Location = new Point(10, 10);
                label.AutoSize = true;
                panel1.Controls.Clear();
                panel1.Controls.Add(label);
            }
        }
    }
}
