using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using System.Net.Sockets;
using System.Net;
using System;
using MySql.Data.MySqlClient;


namespace Quentin_Guignard_Transconnect
{
    public partial class Accueil : Form
    {

        public int idClient;
        public string connectionString = "SERVER=localhost;PORT=3306;DATABASE=TransConnect;UID=root;PASSWORD=root;";
        public Accueil()
        {
            InitializeComponent();
        }


        private void Accueil_Load(object sender, EventArgs e)
        {
            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=TransConnect;UID=root;PASSWORD=root;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            #region Initialisation des villes
            List<string> villes_nom = new List<string>();
            string cheminFichierCSV = "Distances.csv";
            if (File.Exists(cheminFichierCSV))
            {
                Console.WriteLine("Le fichier existe");
                // Initialisation des listes pour stocker les valeurs de chaque colonne
                List<string> colonne1 = new List<string>();
                List<string> colonne2 = new List<string>();

                // Lecture du fichier CSV à l'aide de StreamReader
                StreamReader sr = new StreamReader(cheminFichierCSV);
                string ligne;
                while ((ligne = sr.ReadLine()) != null)
                {
                    // Séparer la ligne en champs en utilisant une virgule comme délimiteur
                    string[] champs = ligne.Split(';');

                    // Stocker les valeurs des colonnes dans les listes appropriées
                    colonne1.Add(champs[0]);
                    colonne2.Add(champs[1]);
                }
                // Fermer le StreamReader
                sr.Close();
                for (int i = 0; i < colonne1.Count; i++)
                {
                    if (!villes_nom.Contains(colonne1[i]))
                    {
                        villes_nom.Add(colonne1[i]);
                    }
                    if (!villes_nom.Contains(colonne2[i]))
                    {
                        villes_nom.Add(colonne2[i]);
                    }
                }
            }

            List<Ville> villes = new List<Ville>();

            foreach (string nom in villes_nom)
            {
                Ville ville = new Ville(nom);
                villes.Add(ville);

            }
            MySqlCommand command = connection.CreateCommand();
            MySqlDataReader reader;

            //Effacer les données de la table
            command.CommandText = $" DELETE FROM Plus_Court_Chemin;";
            reader = command.ExecuteReader();
            reader.Close();
            //Dijkstra
            for (int i = 0; i < villes.Count; i++)
            {

                villes[i].Ajouter_à_bdd((villes[i].Plus_Courte_Distance(villes)), connection);
            }
            #endregion
        }

        public void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            string mail = textBox1.Text;
            string mdp = textBox2.Text;
            if (Client.SignIn(connection, mail, mdp))
            {
                command.CommandText = $" SELECT n_ss FROM client WHERE mail = '{mail}' AND mdp = '{mdp}';";
                MySqlDataReader reader;
                reader = command.ExecuteReader();
                reader.Read();
                idClient = reader.GetInt32(0);
                command.Dispose();
                reader.Close();
                this.Hide();
                Page_Client form3 = new Page_Client(idClient,false);
                form3.Show();
            }
            else if(Salarie.SignIn( connection, mail, mdp))
            {
                command.CommandText = $" SELECT n_ss FROM salarie WHERE mail = '{mail}';";
                MySqlDataReader reader;
                reader = command.ExecuteReader();
                reader.Read();
                idClient = reader.GetInt32(0);
                command.Dispose();
                reader.Close();
                this.Hide();
                Page_PDG form4 = new Page_PDG();
                form4.Show();
            }
            else
            {
                MessageBox.Show("Adresse mail ou mot de passe incorrect");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Inscription form2 = new Inscription();
            this.Hide();
            form2.Show();
        }
    }
}
