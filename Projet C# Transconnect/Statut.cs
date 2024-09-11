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
    public partial class Statut : Form
    {
        public Statut()
        {
            InitializeComponent();
        }

        private void Statut_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Ordre Alphabetique");
            comboBox1.Items.Add("Dépense Totale");
            comboBox1.Items.Add("Ville");
            Label label = new Label();
            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=TransConnect;UID=root;PASSWORD=root;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = $" SELECT * FROM client;";
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                List<string> list = new List<string>();
                list = reader.GetString("adresse").Split(' ').ToList();
                string ville = list[list.Count - 1];
                label.Text += $"{reader.GetInt32("n_ss")} : {reader.GetString("nom")} {reader.GetString("prenom")} - {reader.GetString("statut")} - Ville : {ville} - Dépense Totale : {Client.PrixTotal_BDD(reader.GetInt32("n_ss"))} €\n";
            }
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
                Form form = new Page_Client(Convert.ToInt32(textBox1.Text), true);
                form.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("Veuillez entrer un numéro de sécurité sociale valide");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            Label label = new Label();
            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=TransConnect;UID=root;PASSWORD=root;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            if (comboBox1.SelectedItem.ToString() == "Ordre Alphabetique")
            {
                command.CommandText = $" SELECT * FROM client ORDER BY Nom;";
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    List<string> list = new List<string>();
                    list = reader.GetString("adresse").Split(' ').ToList();
                    string ville = list[list.Count - 1];
                    label.Text += $"{reader.GetInt32("n_ss")} : {reader.GetString("nom")} {reader.GetString("prenom")} - {reader.GetString("statut")} - Ville : {ville} - Dépense Totale : {Client.PrixTotal_BDD(reader.GetInt32("n_ss"))} €\n";
                }
                reader.Close();
                command.Dispose();
                label.Location = new Point(10, 10);
                label.AutoSize = true;
                panel1.Controls.Add(label);
            }
            else if(comboBox1.SelectedItem.ToString() == "Ville")
            {
                command.CommandText = $" SELECT * FROM client;";
                Dictionary<string, string> texte = new Dictionary<string, string>();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    List<string> list = new List<string>();
                    list = reader.GetString("adresse").Split(' ').ToList();
                    string ville = list[list.Count - 1];
                    float prix = Client.PrixTotal_BDD(reader.GetInt32("n_ss"));
                    if (!texte.ContainsKey(ville))
                    {
                        texte.Add(ville, $"{reader.GetInt32("n_ss")} : {reader.GetString("nom")} {reader.GetString("prenom")} - {reader.GetString("statut")} - Ville : {ville} - Dépense Totale : {prix} €\n");
                    }
                    else
                    {
                        texte[ville] += $"{reader.GetInt32("n_ss")} : {reader.GetString("nom")} {reader.GetString("prenom")} - {reader.GetString("statut")} - Ville : {ville} - Dépense Totale : {prix} €\n";
                    }
                }
                texte = texte.OrderByDescending(kvp => kvp.Key).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
                foreach (KeyValuePair<string, string> entry in texte)
                {
                    label.Text += entry.Value;
                }
                reader.Close();
                command.Dispose();
                label.Location = new Point(10, 10);
                label.AutoSize = true;
                panel1.Controls.Add(label);
            }
            else
            {
                command.CommandText = $" SELECT * FROM client;";
                Dictionary<float, string> texte = new Dictionary<float, string>();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    List<string> list = new List<string>();
                    list = reader.GetString("adresse").Split(' ').ToList();
                    string ville = list[list.Count - 1];
                    float prix = Client.PrixTotal_BDD(reader.GetInt32("n_ss"));
                    if (!texte.ContainsKey(prix))
                    {
                        texte.Add(prix, $"{reader.GetInt32("n_ss")} : {reader.GetString("nom")} {reader.GetString("prenom")} - {reader.GetString("statut")} - Ville : {ville} - Dépense Totale : {prix} €\n");
                    }
                    else
                    {
                        texte[prix] += $"{reader.GetInt32("n_ss")} : {reader.GetString("nom")} {reader.GetString("prenom")} - {reader.GetString("statut")} - Ville : {ville} - Dépense Totale : {prix} €\n";
                    }
                }
                texte = texte.OrderByDescending(kvp => kvp.Key).ToDictionary(kvp => kvp.Key, kvp => kvp.Value); 
                foreach (KeyValuePair<float, string> entry in texte)
                {
                    label.Text += entry.Value;
                }
                reader.Close();
                command.Dispose();
                label.Location = new Point(10, 10);
                label.AutoSize = true;
                panel1.Controls.Add(label);
            }
        }
    }
}
