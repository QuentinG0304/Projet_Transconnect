using Google.Protobuf.Reflection;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quentin_Guignard_Transconnect
{
    public class Salarie : Personne, IDisponibilite
    {
        private DateTime dateEmbauche;
        private double salaire;
        private string poste;
        private int idnplus1;

        public Salarie(int id, string nom, string prenom, string adresse, string telephone, string email, DateTime dateNaissance, DateTime dateEmbauche, double salaire, string poste, int idnplus1) : base(id, nom, prenom, adresse, telephone, email, dateNaissance)
        {
            this.dateEmbauche = dateEmbauche;
            this.salaire = salaire;
            this.poste = poste;
            this.idnplus1 = idnplus1;
        }
        public int Idnplus1 { get => idnplus1; set => idnplus1 = value; }
        public string Poste { get => poste; set => poste = value; }
        public double Salaire { get => salaire; set => salaire = value; }
        public DateTime DateEmbauche { get => dateEmbauche; set => dateEmbauche = value; }

        public static Salarie NewSalarie(int id)
        {
            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=TransConnect;UID=root;PASSWORD=root;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            MySqlCommand command = connection.CreateCommand();

            //Creation du client

            command.CommandText = $" SELECT * FROM salarie WHERE n_ss = {id};";
            MySqlDataReader reader = command.ExecuteReader();
            reader.Read();
            Salarie new_salarie = new Salarie(
                             id,
                             reader.GetString("nom"),
                             reader.GetString("prenom"),
                             reader.GetString("adresse"),
                             reader.GetString("num_tel"),
                             reader.GetString("mail"),
                             reader.GetDateTime("naissance"),
                             reader.GetDateTime("date_entree"),
                             reader.GetDouble("salaire"),
                             reader.GetString("poste"),
                             reader.GetInt32("id_nplus1"));
            reader.Close();
            return new_salarie;
        }

        // Disponibilité du chauffeur
        public bool Est_Disponible(DateTime date)
        {
            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=TransConnect;UID=root;PASSWORD=root;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = $" SELECT count(*) FROM Chauffeur " +
                                $" INNER JOIN Commande ON n_ss_chauffeur = n_ss " +
                                $" WHERE Day(jour) = {date.Day} AND Month(jour) = {date.Month} AND Year(jour)= {date.Year} and n_ss = '{Id}';";
            MySqlDataReader reader = command.ExecuteReader();
            reader.Read();
            bool dispo = false;
            if (reader.GetInt32(0) == 0)
            {
                dispo = true;
            }
            reader.Close();
            return dispo;
        }

        // Connexion pour le chef (mdp = azerty)
        static public bool SignIn(MySqlConnection connection, string mail, string pass)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = $" SELECT * FROM Salarie WHERE mail = '{mail}' AND n_ss = 1;";
            MySqlDataReader reader;
            reader = command.ExecuteReader();
            bool cond = reader.Read();
            if (cond && pass == "azerty")
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

        public override string ToString()
        {
            return base.NomComplet() + $": {poste}";
        }

    }
}
