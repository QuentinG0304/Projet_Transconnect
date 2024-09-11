using MySql.Data.MySqlClient;
using Org.BouncyCastle.Tls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;


namespace Quentin_Guignard_Transconnect
{
    public class Commande
    {
        public int id;
        public Client client;
        public Salarie chauffeur;
        public DateTime dateCommande;
        public string adresseDepart;
        public string adresseArrivee;
        public Vehicule vehicule;
        public float prix;

        public float Prix { get { return (float)prix; } }
        public Commande(int id, Client client, Salarie chauffeur, DateTime dateCommande, string adresseDepart, string adresseArrivee, Vehicule vehicule)
        {
            this.id = id;
            this.client = client;
            this.chauffeur = chauffeur;
            this.dateCommande = dateCommande;
            this.adresseDepart = adresseDepart;
            this.adresseArrivee = adresseArrivee;
            this.vehicule = vehicule;
            this.prix = CalculerPrix(adresseDepart,adresseArrivee,vehicule);
        }

        public static Commande new_Commande(int id ,Client client_actu, bool prix_present)
        {
            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=TransConnect;UID=root;PASSWORD=root;";
            MySqlConnection newConnection = new MySqlConnection(connectionString);
            newConnection.Open();

            MySqlCommand command1 = newConnection.CreateCommand();
            command1.CommandText = $"SELECT * FROM commande WHERE id_commande = {id};";
            MySqlDataReader reader1 = command1.ExecuteReader();
            reader1.Read();

            //Récupération des informations
            int id_chauffeur = reader1.GetInt32("n_ss_chauffeur");
            string id_vehicule = reader1.GetString("imma");
            DateTime date_commande = reader1.GetDateTime("jour");
            string adresse_depart = reader1.GetString("depart");
            string adresse_arrivee = reader1.GetString("arrivee");
            float prix = 0;
            if(prix_present)
            {
                prix = reader1.GetFloat("prix");
            }
            

            //Fermeture de la connection
            reader1.Close();

            //Création de la commande
            Commande new_commande = new Commande(
                               id,
                               client_actu,
                               Salarie.NewSalarie(id_chauffeur),
                               date_commande,
                               adresse_depart,
                               adresse_arrivee,
                               Vehicule.NewVehicule(id_vehicule)
                               );
            if(!prix_present)
            {
                new_commande.prix = new_commande.CalculerPrix(new_commande.adresseDepart, new_commande.adresseArrivee, new_commande.vehicule);
            }
            else
            {
                new_commande.prix = prix;
            }
            return new_commande;
        }
        
        public float CalculerPrix(string villed, string villa,Vehicule vehicule)
        {
            double salaire_chauffeur = chauffeur.Salaire;
            int prix_voiture;
            if(this.vehicule is Voiture)
            {
                prix_voiture = 100;
            }
            else if(this.vehicule is Camionnette)
            {
                prix_voiture = 200;
            }
            else
            {
                prix_voiture = 300;
            }

            double reduction = 1;
            if(this.client.Statut == "Argent")
            {
                reduction = 0.85;
            }
            else if(this.client.Statut == "Or")
            {
                reduction = 0.75;
            }
            else if(this.client.Statut == "Platine")
            {
                reduction = 0.5;
            }
            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=TransConnect;UID=root;PASSWORD=root;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            MySqlDataReader reader;
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = $"SELECT distance, temp FROM Plus_Court_Chemin WHERE (ville_depart = '{villed}' AND ville_arrivee = '{villa}') OR (ville_depart = '{villa}' AND ville_arrivee = '{villed}');";
            reader = command.ExecuteReader();
            reader.Read();
            int distance = reader.GetInt32(0);
            DateTime temps = reader.GetDateTime(1);
            return (float)(((distance * vehicule.Prix_par_litre + salaire_chauffeur * temps.Hour + salaire_chauffeur * temps.Minute / 60)+prix_voiture)*reduction)*110/100;
        }


        // Méthode ToString Pour afficher les informations de la commande
        public override string ToString()
        {
            string Date;
            string adresseDepart_;
            string adresseArrivee_;
            string chauffeur_;
            string prix_;

            // Vérifier que chaque chaîne a une longueur de 15 caractères exactement
            Date = dateCommande.ToString("yyyy-MM-dd");
            adresseDepart_ = adresseDepart;
            adresseArrivee_ = adresseArrivee;
            chauffeur_ = chauffeur.Nom;
            prix_ = prix.ToString();

            // Concaténation avec le séparateur "|"
            return $"{Date} | {adresseDepart_} -> {adresseArrivee_} | {chauffeur_} | {prix_} €";
        }
    }
}
