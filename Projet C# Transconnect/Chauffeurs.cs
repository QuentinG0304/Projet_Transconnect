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
    public partial class Chauffeurs : Form
    {
        public Chauffeurs()
        {
            InitializeComponent();
            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=TransConnect;UID=root;PASSWORD=root;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            MySqlDataReader reader;
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Chauffeur";
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                string nom = reader.GetString("nom");
                string prenom = reader.GetString("prenom");

                comboBox1.Items.Add(prenom + " " + nom);
            }

            label2.Visible = false;
            button1.Visible = false;
            textBox1.Visible = false;
            label3.Visible = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            label2.Visible = true;
            button1.Visible = true;
            textBox1.Visible = true;

            List<string> list = new List<string>();
            list = comboBox1.SelectedItem.ToString().Split(' ').ToList();
            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=TransConnect;UID=root;PASSWORD=root;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            MySqlDataReader reader;
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = $"SELECT n_ss FROM Chauffeur WHERE prenom = '{list[0]}' AND nom = '{list[1]}'";
            reader = command.ExecuteReader();
            reader.Read();
            int id = reader.GetInt32("n_ss");
            reader.Close();
            Label label = new Label();
            label.Text = "";
            command.CommandText = $"SELECT * FROM Commande WHERE n_ss_chauffeur = {id}";
            reader = command.ExecuteReader();

            //Cpt pour le nombre de commande
            int cpt = 0;
            while (reader.Read())
            {
                label.Text += $"Commande n°{reader.GetInt32("id_commande")} : {reader.GetDateTime("jour")} - {reader.GetFloat("prix")} €\n";
                cpt++;
            }
            label3.Text = $"Nombre de commandes : {cpt}";
            label3.Visible = true;
            reader.Close();
            command.Dispose();
            label.Location = new Point(10, 10);
            label.AutoSize = true;
            panel1.Controls.Add(label);


        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int id_commande = Convert.ToInt32(textBox1.Text);
                string connectionString = "SERVER=localhost;PORT=3306;DATABASE=TransConnect;UID=root;PASSWORD=root;";
                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();
                MySqlDataReader reader;
                MySqlCommand command = connection.CreateCommand();
                string chemin = "";
                command.CommandText = $"SELECT chemin FROM Plus_Court_Chemin " +
                        $"JOIN Commande ON Commande.depart = ville_arrivee AND commande.arrivee = ville_depart " +
                        $"WHERE id_commande ={id_commande};";
                reader = command.ExecuteReader();
                try
                {
                    reader.Read();
                    chemin = reader.GetString("chemin");
                    List<string> list = new List<string>();
                    list = chemin.Split(" -> ").ToList();
                    chemin = "";
                    for (int i = list.Count - 1; i >= 0; i--)
                    {
                        if (i == 0)
                        {
                            chemin += list[i];
                        }
                        else
                        {
                            chemin += list[i] + " -> ";
                        }
                    }

                }
                catch
                {
                    reader.Close();
                    command.CommandText = $"SELECT chemin FROM Plus_Court_Chemin " +
                        $"JOIN Commande ON Commande.depart = ville_depart AND commande.arrivee = ville_arrivee " +
                        $"WHERE id_commande ={id_commande};";
                    reader = command.ExecuteReader();
                    reader.Read();
                    chemin = reader.GetString("chemin");
                }

                reader.Close();
                command.Dispose();
                MessageBox.Show(chemin);
            }
            catch
            {
                MessageBox.Show("Mauvaise entrée");
            }
            
        }
    }
}
