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
    
    public partial class Création_Commande : Form
    {
        public bool chef;
        public List<string> villes = new List<string>();
        public int idClient;
        public Création_Commande(int idClient,bool chef)
        {
            this.chef = chef;
            InitializeComponent();
            this.idClient = idClient;
            RemplirComboBox(comboBox1);
            RemplirComboBox(comboBox2);
            comboBox3.Items.Add("Transport de passager");
            comboBox3.Items.Add("Besoins d'artisans");
            comboBox3.Items.Add("Transport de marchandise");

            comboBox4.Items.Add("Liquide / Gaz");
            comboBox4.Items.Add("Sable / Terre / Gravier / Béton");
            comboBox4.Items.Add("Marchandises périssables");
            //A ne pas afficher au début
            numericUpDown1.Visible = false;
            label5.Visible = false;

            label6.Visible = false;
            textBox1.Visible = false;

            label7.Visible = false;
            textBox2.Visible = false;
            label8.Visible = false;
            comboBox4.Visible = false;
        }

        public void RemplirComboBox(ComboBox combo)
        {
            this.villes = new List<string>();
            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=TransConnect;UID=root;PASSWORD=root;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            MySqlDataReader reader;
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Plus_Court_Chemin";
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                if (villes.Contains(reader.GetString("ville_depart")) == false)
                {
                    villes.Add(reader.GetString("ville_depart"));
                }
                if (villes.Contains(reader.GetString("ville_arrivee")) == false)
                {
                    villes.Add(reader.GetString("ville_arrivee"));
                }
            }
            reader.Close();
            foreach (string ville in villes)
            {
                combo.Items.Add(ville);
            }


        }

        private void numericUpDown8_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown8.Value == 2024 && numericUpDown7.Value == DateTime.Now.Month)
            {
                numericUpDown7.Minimum = DateTime.Now.Month;
                numericUpDown6.Minimum = DateTime.Now.Day;
            }
            else if (numericUpDown8.Value == 2024)
            {
                numericUpDown7.Minimum = DateTime.Now.Month;
                numericUpDown6.Minimum = 0;
            }
            else
            {
                numericUpDown6.Minimum = 0;
                numericUpDown7.Minimum = 0;
            }
        }

        private void numericUpDown7_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown8.Value == 2024 && numericUpDown7.Value == DateTime.Now.Month)
            {
                numericUpDown7.Minimum = DateTime.Now.Month;
                numericUpDown6.Minimum = DateTime.Now.Day;
            }
            else if (numericUpDown8.Value == 2024)
            {
                numericUpDown7.Minimum = DateTime.Now.Month;
                numericUpDown6.Minimum = 0;
            }
            else
            {
                numericUpDown6.Minimum = 0;
                numericUpDown7.Minimum = 0;
            }
            if (numericUpDown7.Value == 1 || numericUpDown7.Value == 3 || numericUpDown7.Value == 5 || numericUpDown7.Value == 7 || numericUpDown7.Value == 8 || numericUpDown7.Value == 10 || numericUpDown7.Value == 12)
            {
                numericUpDown6.Maximum = 31;
            }
            else if (numericUpDown7.Value == 2 && numericUpDown8.Value % 4 == 0)
            {
                numericUpDown6.Maximum = 29;
            }
            else if (numericUpDown7.Value == 2 && numericUpDown8.Value % 4 == 0)
            {
                numericUpDown6.Maximum = 28;
            }
            else
            {
                numericUpDown6.Maximum = 30;
            }

        }

        private void numericUpDown6_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown8.Value == 2024 && numericUpDown7.Value == DateTime.Now.Month && numericUpDown6.Value == DateTime.Now.Day)
            {
                numericUpDown7.Minimum = DateTime.Now.Month;
                numericUpDown6.Minimum = DateTime.Now.Day;
            }
            else if (numericUpDown8.Value == 2024)
            {
                numericUpDown7.Minimum = DateTime.Now.Month;
                numericUpDown6.Minimum = 1;
            }
            else
            {
                numericUpDown6.Minimum = 1;
                numericUpDown7.Minimum = 1;
            }
        }

        //Création de la commande
        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=TransConnect;UID=root;PASSWORD=root;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            MySqlCommand command = connection.CreateCommand();

            try
            {
                if (!(this.villes.Contains(comboBox1.SelectedItem.ToString()) && this.villes.Contains(comboBox2.SelectedItem.ToString())))
                {
                    MessageBox.Show("Ville non disponible");
                }
                else
                {
                    if (comboBox1.SelectedItem.ToString() == comboBox2.SelectedItem.ToString())
                    {
                        MessageBox.Show("Ville de départ et d'arrivée identiques");
                    }
                    else
                    {
                        string ville_depart = comboBox1.SelectedItem.ToString();
                        string ville_arrivee = comboBox2.SelectedItem.ToString();
                        bool vehicule_dispo = false;
                        bool chauffeur_dispo = false;
                        int id_chauffeur = 0;
                        string imma_vehicule = "";
                        DateTime date = new DateTime(Convert.ToInt32(numericUpDown8.Value), Convert.ToInt32(numericUpDown7.Value), Convert.ToInt32(numericUpDown6.Value));

                        if (comboBox3.SelectedItem.ToString() == "Transport de passager")
                        {
                            int nb_passager = Convert.ToInt32(numericUpDown1.Value);
                            command.CommandText = $" SELECT * FROM chauffeur;";
                            MySqlDataReader reader;
                            reader = command.ExecuteReader();
                            while (reader.Read() && !chauffeur_dispo)
                            {
                                Salarie chauffeur = Salarie.NewSalarie(reader.GetInt32("n_ss"));
                                if (chauffeur.Est_Disponible(date))
                                {
                                    chauffeur_dispo = true;
                                    id_chauffeur = chauffeur.Id;
                                    break;
                                }
                            }
                            command.Dispose();
                            reader.Close();
                            float prix_par_litre = 0;
                            if (chauffeur_dispo)
                            {
                                command.CommandText = $" SELECT * FROM vehicule;";
                                reader = command.ExecuteReader();
                                while (reader.Read() && !vehicule_dispo)
                                {
                                    if (reader.GetString("type_vehicule") == "Voiture")
                                    {
                                        Voiture voiture = new Voiture(reader.GetString("imma"), reader.GetFloat("prix_par_litre"), reader.GetInt32("nb_passager"));
                                        if (voiture.Est_Disponible(date))
                                        {
                                            vehicule_dispo = true;
                                            imma_vehicule = voiture.Immatriculation;
                                            prix_par_litre = voiture.Prix_par_litre;
                                        }
                                    }
                                }
                                command.Dispose();
                                reader.Close();
                                if (vehicule_dispo)
                                {
                                    command.Dispose();
                                    reader.Close();

                                    command.CommandText = $" SELECT max(id_commande) FROM Commande;";
                                    reader = command.ExecuteReader();
                                    reader.Read();
                                    int id_commande = reader.GetInt32(0) + 1;

                                    Commande commande = new Commande(id_commande, Client.Client_pour_commande(idClient), Salarie.NewSalarie(id_chauffeur), date, ville_depart, ville_arrivee, Vehicule.NewVehicule(imma_vehicule));
                                    command.Dispose();
                                    reader.Close();

                                    Paiement paiement = new Paiement(commande, nb_passager, 0, "");
                                    paiement.Show();
                                }
                                else
                                {
                                    MessageBox.Show("Véhicule non disponible");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Chauffeur non disponible");
                            }
                            command.Dispose();
                            reader.Close();
                        }


                        else if (comboBox3.SelectedItem.ToString() == "Besoins d'artisans")
                        {
                            string usage = textBox1.Text;
                            command.CommandText = $" SELECT * FROM chauffeur;";
                            MySqlDataReader reader;
                            reader = command.ExecuteReader();
                            while (reader.Read() && !chauffeur_dispo)
                            {
                                Salarie chauffeur = Salarie.NewSalarie(reader.GetInt32("n_ss"));
                                if (chauffeur.Est_Disponible(date))
                                {
                                    chauffeur_dispo = true;
                                    id_chauffeur = chauffeur.Id;
                                    break;
                                }
                            }
                            command.Dispose();
                            reader.Close();
                            float prix_par_litre = 0;
                            if (chauffeur_dispo)
                            {
                                command.CommandText = $" SELECT * FROM vehicule;";
                                reader = command.ExecuteReader();
                                while (reader.Read() && !vehicule_dispo)
                                {
                                    if (reader.GetString("type_vehicule") == "Camionnette")
                                    {
                                        Camionnette camionnette = new Camionnette(reader.GetString("imma"), reader.GetFloat("prix_par_litre"), usage);
                                        if (camionnette.Est_Disponible(date))
                                        {
                                            vehicule_dispo = true;
                                            imma_vehicule = camionnette.Immatriculation;
                                            prix_par_litre = camionnette.Prix_par_litre;
                                        }
                                    }
                                }
                                command.Dispose();
                                reader.Close();
                                if (vehicule_dispo)
                                {
                                    command.Dispose();
                                    reader.Close();

                                    command.CommandText = $" SELECT max(id_commande) FROM Commande;";
                                    reader = command.ExecuteReader();
                                    reader.Read();
                                    int id_commande = reader.GetInt32(0) + 1;

                                    Commande commande = new Commande(id_commande, Client.Client_pour_commande(idClient), Salarie.NewSalarie(id_chauffeur), date, ville_depart, ville_arrivee, Vehicule.NewVehicule(imma_vehicule));
                                    command.Dispose();
                                    reader.Close();

                                    Paiement paiement = new Paiement(commande, 0, 0, usage);
                                    paiement.Show();
                                }
                                else
                                {
                                    MessageBox.Show("Véhicule non disponible");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Chauffeur non disponible");
                            }
                            command.Dispose();
                            reader.Close();
                        }


                        else if (comboBox3.SelectedItem.ToString() == "Transport de marchandise")
                        {
                            bool correct = true;
                            if (textBox2.Text == "" || comboBox4.Text == "")
                            {
                                MessageBox.Show("Veuillez remplir tous les champs");
                                correct = false;
                            }
                            for (int i = 0; i < textBox2.TextLength && correct; i++)
                            {
                                if (textBox2.Text[i] != '1' && textBox2.Text[i] != '2' && textBox2.Text[i] != '3' && textBox2.Text[i] != '4' && textBox2.Text[i] != '5' && textBox2.Text[i] != '6' && textBox2.Text[i] != '7' && textBox2.Text[i] != '8' && textBox2.Text[i] != '9' && textBox2.Text[i] != '0')
                                {
                                    MessageBox.Show("Veuillez entrer volume valide");
                                    correct = false;
                                }
                            }
                            if (correct)
                            {
                                if (comboBox4.SelectedItem.ToString() == "Liquide / Gaz")
                                {
                                    string type = "Camion-Citerne";
                                    command.CommandText = $" SELECT * FROM chauffeur;";
                                    MySqlDataReader reader;
                                    reader = command.ExecuteReader();
                                    while (reader.Read() && !chauffeur_dispo)
                                    {
                                        Salarie chauffeur = Salarie.NewSalarie(reader.GetInt32("n_ss"));
                                        if (chauffeur.Est_Disponible(date))
                                        {
                                            chauffeur_dispo = true;
                                            id_chauffeur = chauffeur.Id;
                                            break;
                                        }
                                    }
                                    command.Dispose();
                                    reader.Close();
                                    float prix_par_litre = 0;
                                    if (chauffeur_dispo)
                                    {
                                        command.CommandText = $" SELECT * FROM vehicule;";
                                        reader = command.ExecuteReader();
                                        while (reader.Read() && !vehicule_dispo)
                                        {
                                            if (reader.GetString("type_vehicule") == type)
                                            {
                                                Poids_Lourd camion_citerne = new Poids_Lourd(reader.GetString("imma"), reader.GetFloat("prix_par_litre"), reader.GetInt32("volume"), textBox1.Text, type);
                                                if (camion_citerne.Est_Disponible(date) && camion_citerne.Volume_max > Convert.ToInt32(textBox2.Text))
                                                {
                                                    vehicule_dispo = true;
                                                    imma_vehicule = camion_citerne.Immatriculation;
                                                    prix_par_litre = camion_citerne.Prix_par_litre;
                                                }
                                            }
                                        }
                                        command.Dispose();
                                        reader.Close();
                                        if (vehicule_dispo)
                                        {
                                            command.Dispose();
                                            reader.Close();

                                            command.CommandText = $" SELECT max(id_commande) FROM Commande;";
                                            reader = command.ExecuteReader();
                                            reader.Read();
                                            int id_commande = reader.GetInt32(0) + 1;

                                            Commande commande = new Commande(id_commande, Client.Client_pour_commande(idClient), Salarie.NewSalarie(id_chauffeur), date, ville_depart, ville_arrivee, Vehicule.NewVehicule(imma_vehicule));
                                            command.Dispose();
                                            reader.Close();

                                            Paiement paiement = new Paiement(commande, 0, Convert.ToInt32(textBox2.Text), "");
                                            paiement.Show();
                                        }
                                        else
                                        {
                                            MessageBox.Show("Véhicule non disponible");
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Chauffeur non disponible");
                                    }
                                    command.Dispose();
                                    reader.Close();
                                }

                                else if (comboBox4.SelectedItem.ToString() == "Sable / Terre / Gravier / Béton")
                                {
                                    string type = "Camion Benne";
                                    command.CommandText = $" SELECT * FROM chauffeur;";
                                    MySqlDataReader reader;
                                    reader = command.ExecuteReader();
                                    while (reader.Read() && !chauffeur_dispo)
                                    {
                                        Salarie chauffeur = Salarie.NewSalarie(reader.GetInt32("n_ss"));
                                        if (chauffeur.Est_Disponible(date))
                                        {
                                            chauffeur_dispo = true;
                                            id_chauffeur = chauffeur.Id;
                                            break;
                                        }
                                    }
                                    command.Dispose();
                                    reader.Close();
                                    float prix_par_litre = 0;
                                    if (chauffeur_dispo)
                                    {
                                        command.CommandText = $" SELECT * FROM vehicule;";
                                        reader = command.ExecuteReader();
                                        while (reader.Read() && !vehicule_dispo)
                                        {
                                            if (reader.GetString("type_vehicule") == type)
                                            {
                                                Poids_Lourd camion_benne = new Poids_Lourd(reader.GetString("imma"), reader.GetFloat("prix_par_litre"), reader.GetInt32("volume"), textBox1.Text, type);
                                                if (camion_benne.Est_Disponible(date) && camion_benne.Volume_max > Convert.ToInt32(textBox2.Text))
                                                {
                                                    vehicule_dispo = true;
                                                    imma_vehicule = camion_benne.Immatriculation;
                                                    prix_par_litre = camion_benne.Prix_par_litre;
                                                }
                                            }
                                        }
                                        command.Dispose();
                                        reader.Close();
                                        if (vehicule_dispo)
                                        {
                                            command.Dispose();
                                            reader.Close();

                                            command.CommandText = $" SELECT max(id_commande) FROM Commande;";
                                            reader = command.ExecuteReader();
                                            reader.Read();
                                            int id_commande = reader.GetInt32(0) + 1;

                                            Commande commande = new Commande(id_commande, Client.Client_pour_commande(idClient), Salarie.NewSalarie(id_chauffeur), date, ville_depart, ville_arrivee, Vehicule.NewVehicule(imma_vehicule));
                                            command.Dispose();
                                            reader.Close();

                                            Paiement paiement = new Paiement(commande, 0, Convert.ToInt32(textBox2.Text), "");
                                            paiement.Show();
                                        }
                                        else
                                        {
                                            MessageBox.Show("Véhicule non disponible");
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Chauffeur non disponible");
                                    }
                                    command.Dispose();
                                    reader.Close();
                                }

                                else if (comboBox4.SelectedItem.ToString() == "Marchandises périssables")
                                {
                                    string type = "Camion Frigorifique";
                                    command.CommandText = $" SELECT * FROM chauffeur;";
                                    MySqlDataReader reader;
                                    reader = command.ExecuteReader();
                                    while (reader.Read() && !chauffeur_dispo)
                                    {
                                        Salarie chauffeur = Salarie.NewSalarie(reader.GetInt32("n_ss"));
                                        if (chauffeur.Est_Disponible(date))
                                        {
                                            chauffeur_dispo = true;
                                            id_chauffeur = chauffeur.Id;
                                            break;
                                        }
                                    }
                                    command.Dispose();
                                    reader.Close();
                                    float prix_par_litre = 0;
                                    if (chauffeur_dispo)
                                    {
                                        command.CommandText = $" SELECT * FROM vehicule;";
                                        reader = command.ExecuteReader();
                                        while (reader.Read() && !vehicule_dispo)
                                        {
                                            if (reader.GetString("type_vehicule") == type)
                                            {
                                                Poids_Lourd camion_benne = new Poids_Lourd(reader.GetString("imma"), reader.GetFloat("prix_par_litre"), reader.GetInt32("volume"), textBox1.Text, type);
                                                if (camion_benne.Est_Disponible(date) && camion_benne.Volume_max > Convert.ToInt32(textBox2.Text))
                                                {
                                                    vehicule_dispo = true;
                                                    imma_vehicule = camion_benne.Immatriculation;
                                                    prix_par_litre = camion_benne.Prix_par_litre;
                                                }
                                            }
                                        }
                                        command.Dispose();
                                        reader.Close();
                                        if (vehicule_dispo)
                                        {
                                            command.Dispose();
                                            reader.Close();

                                            command.CommandText = $" SELECT max(id_commande) FROM Commande;";
                                            reader = command.ExecuteReader();
                                            reader.Read();
                                            int id_commande = reader.GetInt32(0) + 1;

                                            Commande commande = new Commande(id_commande, Client.Client_pour_commande(idClient), Salarie.NewSalarie(id_chauffeur), date, ville_depart, ville_arrivee, Vehicule.NewVehicule(imma_vehicule));
                                            command.Dispose();
                                            reader.Close();

                                            Paiement paiement = new Paiement(commande, 0, Convert.ToInt32(textBox2.Text), "");
                                            paiement.Show();
                                        }
                                        else
                                        {
                                            MessageBox.Show("Véhicule non disponible");
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Chauffeur non disponible");
                                    }
                                    command.Dispose();
                                    reader.Close();
                                }
                            }
                        }


                        else
                        {
                            MessageBox.Show("Type de commande Incorrect");
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Veuillez remplir les cases");
            }

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.SelectedItem.ToString() == "Transport de passager")
            {
                numericUpDown1.Visible = true;
                label5.Visible = true;
                label7.Visible = false;
                textBox2.Visible = false;
                label8.Visible = false;
                label6.Visible = false;
                textBox1.Visible = false;
                comboBox4.Visible = false;
            }
            else if (comboBox3.SelectedItem.ToString() == "Besoins d'artisans")
            {
                numericUpDown1.Visible = false;
                label5.Visible = false;
                label7.Visible = false;
                textBox2.Visible = false;
                label8.Visible = false;
                label6.Visible = true;
                textBox1.Visible = true;
                comboBox4.Visible = false;

            }
            else
            {
                numericUpDown1.Visible = false;
                label5.Visible = false;
                label7.Visible = true;
                textBox2.Visible = true;
                label8.Visible = true;
                label6.Visible = false;
                textBox1.Visible = false;
                comboBox4.Visible = true;

            }
        }


        //Retour à la page client
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Page_Client page_Client = new Page_Client(idClient,chef);
            page_Client.Show();
        }

        private void Création_Commande_Load(object sender, EventArgs e)
        {

        }
    }
}
