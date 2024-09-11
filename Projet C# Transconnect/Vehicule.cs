using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quentin_Guignard_Transconnect
{
    public class Vehicule : IDisponibilite
    {
        private string immatriculation;
        private float prix_par_litre;

        public string Immatriculation { get => immatriculation; set => immatriculation = value; }
        

        //Constructeur
        public Vehicule(string immatriculation, float prix_par_litre)
        {
            this.immatriculation = immatriculation;
            this.prix_par_litre = prix_par_litre;
        }

        # region Propriétés
        public float Prix_par_litre 
        { 
            get { return prix_par_litre; } 
            set { prix_par_litre = value; } 
        }

        #endregion


        //Méthodes
        public static Vehicule NewVehicule(string immatriculation)
        {
            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=TransConnect;UID=root;PASSWORD=root;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = $" SELECT * FROM vehicule WHERE imma = '{immatriculation}';";
            MySqlDataReader reader = command.ExecuteReader();
            reader.Read();
            Vehicule new_vehicule = new Vehicule(
                                    Convert.ToString(immatriculation),
                                    reader.GetFloat("prix_par_litre"));
            reader.Close();
            return new_vehicule;
        }


        //Disponibilité du véhicule 
        public bool Est_Disponible(DateTime date) 
        {
            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=TransConnect;UID=root;PASSWORD=root;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = $" SELECT count(*) FROM Vehicule " +
                $" INNER JOIN Commande ON Vehicule.imma = Commande.imma " +
                $" WHERE Day(jour) = {date.Day} AND Month(jour) = {date.Month} AND Year(jour)= {date.Year} AND Vehicule.imma = '{immatriculation}';";
            MySqlDataReader reader = command.ExecuteReader();
            reader.Read();
            bool dispo = false;
            if(reader.GetInt32(0) == 0)
            {
                dispo = true;
            }
            reader.Close();
            return dispo;
        }


    }
}
