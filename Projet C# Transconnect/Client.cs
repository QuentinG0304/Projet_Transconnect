using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quentin_Guignard_Transconnect
{
    public class Client : Personne
    {
        List<Commande> commandes;
        string statut;
        string ville;

        public Client(int id, string nom, string prenom, string adresse, string telephone, string email, DateTime dateNaissance, string statut) : base(id, nom, prenom, adresse, telephone, email, dateNaissance)
        {
            commandes = new List<Commande>();
            this.statut = statut;
            List<string> adresse_split = adresse.Split(' ').ToList();
            this.ville = adresse_split[adresse_split.Count - 1];
        }

        public string Statut { get => statut; set => statut = value; }

        public static Client Client_pour_commande(int id)
        {
            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=TransConnect;UID=root;PASSWORD=root;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            MySqlDataReader reader;
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = $" SELECT * FROM client WHERE n_ss = {id};";
            reader = command.ExecuteReader();
            reader.Read();

            Client new_client = new Client(
                id,
                reader.GetString("nom"),
                reader.GetString("prenom"),
                reader.GetString("adresse"),
                reader.GetString("num_tel"),
                reader.GetString("mail"),
                reader.GetDateTime("naissance"),
                reader.GetString("statut")
            );
            reader.Close();
            command.CommandText = $" SELECT * FROM Commande WHERE n_ss_client = {id};";
            reader = command.ExecuteReader();
            int id_commande=0;
            while (reader.Read())
            {
                new_client.AjouterCommande(Commande.new_Commande(reader.GetInt32("id_commande"), new_client, false));
            }
            return new_client;
        }

        //Création d'un nouveau client pour la page client
        public static Client Client_actuel(MySqlConnection connection, int id)
        {
            //Initialisation de la connection
            MySqlCommand command = connection.CreateCommand();
            MySqlDataReader reader;
            
            //Creation du client
            command.CommandText = $" SELECT * FROM client WHERE n_ss = {id};";
            reader = command.ExecuteReader();
            reader.Read();
            Client new_client = new Client(
                id,
                reader.GetString("nom"),
                reader.GetString("prenom"),
                reader.GetString("adresse"),
                reader.GetString("num_tel"),
                reader.GetString("mail"),
                reader.GetDateTime("naissance"),
                reader.GetString("statut")
            );
            reader.Close();

            //Ajout des commandes
            command.CommandText = $" SELECT id_commande FROM Commande INNER join client on n_ss = n_ss_client WHERE n_ss = {id};";
            reader = command.ExecuteReader();
            List<int> id_commandes = new List<int>();
            while (reader.Read())
            {
                id_commandes.Add(reader.GetInt32("id_commande"));
            }
            //Fermeture de la connection
            reader.Close();
            command.Dispose();
            //Ajout des commandes
            foreach (int id_commande in id_commandes)
            {
                new_client.AjouterCommande(Commande.new_Commande(id_commande,new_client,true));
            }
            return new_client;
        }

        //Vérification que le client existe
        static public bool SignIn(MySqlConnection connection, string mail, string pass)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = $" SELECT * FROM client WHERE mail = '{mail}' and mdp = '{pass}';";
            MySqlDataReader reader;
            reader = command.ExecuteReader();
            bool cond = reader.Read();
            if (cond)
            {
                reader.Close();
                command.Dispose();
                return true;
            }
            else
            {
                reader.Close();
                command.Dispose();
                return false;
            }


        }

        //Inscription d'un nouveau client
        public bool Register(MySqlConnection connection,string mdp)
        {
            bool ret;
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = $" SELECT mail FROM client WHERE mail = '{Email}';";
            MySqlDataReader reader;
            reader = command.ExecuteReader();
            command.Dispose();
            bool cond = !reader.Read();
            if (cond)
            {
                reader.Close();
                MySqlCommand add = connection.CreateCommand();
                add.CommandText = $"INSERT INTO client VALUES({Id},'{Nom}', '{Prenom}', '{DateNaissance.Year}-{DateNaissance.Month}-{DateNaissance.Day}', '{Adresse}', '{Email}', '{Telephone}','{mdp}','{statut}');";
                add.ExecuteNonQuery();
                //ret = ("Le compte a été crée avec succès.");
                ret = true;
                add.Dispose();
            }
            else
            {
                reader.Close();
                ret = false;
                //ret = "Adresse mail déjà utilisée. \nVeuillez en saisir une nouvelle ou vous connecter.";
            }
            return ret;
        }


        public void AjouterCommande(Commande commande)
        {
            if (!commandes.Contains(commande))
            {
                commandes.Add(commande);
            }
        }


        //Affichage des commandes
        public string ToStringCommandes()
        {
            string res = "";
            foreach (Commande c in commandes)
            {
                res += c.ToString() +"\n";
            }
            return res;
        }

        public static float PrixTotal_BDD(int id)
        {
            float prix = 0;
            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=TransConnect;UID=root;PASSWORD=root;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            MySqlDataReader reader;
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = $" SELECT * FROM commande WHERE n_ss_client = {id};";
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                prix += reader.GetFloat("prix");
            }
            reader.Close();
            return prix;
        }



    }
}
