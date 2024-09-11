using MySql.Data.MySqlClient;
using Quentin_Guignard_Transconnect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Quentin_Guignard_Transconnect
{
    internal class Ville
    {
        private string nom;
        private Dictionary<string, int> distances;
        private Dictionary<string, DateTime> temps;
        private List<Dictionary<string, string>> chemins;

        public string Nom { get { return nom; } }
        public Dictionary<string, int> Distances { get { return distances; } }
        public Dictionary<string, DateTime> Temps { get { return temps; } }

        #region Constructeur
        public Ville(string nom)
        {
            this.nom = nom;
            distances = new Dictionary<string, int>();
            temps = new Dictionary<string, DateTime>();
            AjouterDistances();
            AjouterTemps();
            this.chemins = new List<Dictionary<string, string>>();
        }

        public void AjouterDistances()
        {
            string cheminFichierCSV = "Distances.csv";

            // Vérifier si le fichier existe
            if (File.Exists(cheminFichierCSV))
            {
                // Initialisation des listes pour stocker les valeurs de chaque colonne
                List<string> colonne1 = new List<string>();
                List<string> colonne2 = new List<string>();
                List<int> colonne3 = new List<int>();

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
                    colonne3.Add(int.Parse(champs[2]));
                }
                // Fermer le StreamReader
                sr.Close();
                for (int i = 0; i < colonne1.Count; i++)
                {
                    if (colonne1[i] == Nom)
                    {
                        string ville = colonne2[i];
                        int distance = colonne3[i];
                        distances.Add(ville, distance);
                    }
                    else if (colonne2[i] == Nom)
                    {
                        string ville = colonne1[i];
                        int distance = colonne3[i];
                        distances.Add(ville, distance);
                    }
                }

            }
        }

        public void AjouterTemps()
        {
            string cheminFichierCSV = "Distances.csv";

            // Vérifier si le fichier existe
            if (File.Exists(cheminFichierCSV))
            {
                // Initialisation des listes pour stocker les valeurs de chaque colonne
                List<string> colonne1 = new List<string>();
                List<string> colonne2 = new List<string>();
                List<DateTime> colonne3 = new List<DateTime>();

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
                    if (champs[3].Contains("h"))
                    {
                        string[] temps_csv = champs[3].Split('h');
                        if (temps_csv[1] != "")
                        {
                            colonne3.Add(new DateTime(1, 1, 1, int.Parse(temps_csv[0]), int.Parse(temps_csv[1]), 0));
                        }
                        else
                        {
                            colonne3.Add(new DateTime(1, 1, 1, int.Parse(temps_csv[0]), 0, 0));
                        }
                    }
                    else
                    {
                        champs[3] = champs[3].Replace("mn", "");
                        colonne3.Add(new DateTime(1, 1, 1, 0, int.Parse(champs[3]), 0));
                    }

                }
                // Fermer le StreamReader
                sr.Close();
                for (int i = 0; i < colonne1.Count; i++)
                {
                    if (colonne1[i] == Nom)
                    {
                        string ville = colonne2[i];
                        DateTime temps_final = colonne3[i];
                        temps.Add(ville, temps_final);
                    }
                    else if (colonne2[i] == Nom)
                    {
                        string ville = colonne1[i];
                        DateTime temps_final = colonne3[i];
                        temps.Add(ville, temps_final);
                    }
                }

            }
        }

        #endregion


        # region Pour l'ajout des villes à la base de données
        public int Date_to_int(DateTime date)
        {
            return date.Hour * 60 + date.Minute;
        }
        public DateTime int_to_date(int date)
        {
            if (date / 60 >= 24)
            {
                return new DateTime(1, 1, 2, (date / 60) - 24, date % 60, 0);
            }
            else
            {
                return new DateTime(1, 1, 1, date / 60, date % 60, 0);
            }

        }

        //Dijkstra
        public List<Dictionary<string, int>> Plus_Courte_Distance(List<Ville> villes)
        {
            List<Dictionary<string, string>> chemins = new List<Dictionary<string, string>>();
            List<Ville> villes_ = new List<Ville>(villes); // Copie de la liste des villes
            int cpt = villes_.Count; // Nombre total de villes
            Dictionary<string, int> distances = new Dictionary<string, int>(); // Dictionnaire pour les distances minimales trouvées
            Dictionary<string, int> distances_finale = new Dictionary<string, int>(); // Dictionnaire pour les distances finales
            Dictionary<string, int> distances_restantes = new Dictionary<string, int>(); // Dictionnaire pour les distances restantes à traiter
            Dictionary<string, int> temps = new Dictionary<string, int>(); // Dictionnaire pour les temps de parcours
            Dictionary<string, string> precedents = new Dictionary<string, string>(); // Dictionnaire pour garder la trace des précédents pour reconstruire les chemins
            Ville ville_depart = this; // La ville de départ est l'instance courante de Ville

            // Initialisation des dictionnaires pour chaque ville
            foreach (Ville ville in villes_)
            {
                if (ville.Nom != ville_depart.Nom)
                {
                    distances.Add(ville.Nom, int.MaxValue); // Distance initiale infinie (représentée par int.MaxValue)
                    temps.Add(ville.Nom, 0); // Temps initial zéro
                    distances_restantes.Add(ville.Nom, int.MaxValue); // Distance restante initiale infinie
                    precedents.Add(ville.Nom, null); // Aucun précédent au début
                }
            }

            // Initialisation pour la ville de départ
            distances.Add(ville_depart.Nom, 0);
            temps.Add(ville_depart.Nom, 0);
            distances_restantes.Add(ville_depart.Nom, 0);
            precedents.Add(ville_depart.Nom, null);

            Ville ville_actuelle = ville_depart; // Commencer avec la ville de départ
            string nom_ville_a_enleve; // Nom de la prochaine ville à retirer des distances restantes
            int distance_min; // Distance minimale actuelle

            // Algorithme principal pour trouver les plus courtes distances, on utilise cpt car la liste change de taille après chaque itération
            for (int j = 0; j < cpt; j++)
            {
                // Mettre à jour les distances pour chaque ville adjacente comme dans l'algo de Dijkstra
                for (int i = 0; i < villes_.Count; i++)
                {
                    if (ville_actuelle.Distances.Keys.Contains(villes_[i].Nom))
                    {
                        int nouvelle_distance = ville_actuelle.Distances[villes_[i].Nom] + distances[ville_actuelle.Nom];
                        if (distances[villes_[i].Nom] == int.MaxValue || nouvelle_distance < distances[villes_[i].Nom])
                        {
                            distances[villes_[i].Nom] = nouvelle_distance;
                            temps[villes_[i].Nom] = Date_to_int(ville_actuelle.Temps[villes_[i].Nom]) + temps[ville_actuelle.Nom];
                            distances_restantes[villes_[i].Nom] = nouvelle_distance;
                            precedents[villes_[i].Nom] = ville_actuelle.Nom;
                        }
                    }
                }

                // Trouver la prochaine ville avec la distance minimale
                distance_min = distances_restantes.Values.Min();
                nom_ville_a_enleve = distances_restantes.FirstOrDefault(x => x.Value == distance_min).Key;
                distances_finale.Add(nom_ville_a_enleve, distance_min); // Ajouter la distance finale
                ville_actuelle = villes_.FirstOrDefault(x => x.Nom == nom_ville_a_enleve); // Mettre à jour la ville actuelle
                villes_.RemoveAt(villes_.IndexOf(villes_.FirstOrDefault(x => x.Nom == nom_ville_a_enleve))); // Retirer la ville de la liste des villes restantes
                distances_restantes.Remove(nom_ville_a_enleve); // Retirer la distance restante pour cette ville
            }

            // Construire les chemins complets à partir des précédents
            foreach (var ville in villes)
            {
                List<string> chemin_complet = new List<string>();
                string ville_courante = ville.Nom;
                while (ville_courante != null)
                {
                    chemin_complet.Insert(0, ville_courante); // Ajouter la ville courante au début du chemin
                    precedents.TryGetValue(ville_courante, out ville_courante); // Passer à la ville précédente
                }
                chemins.Add(new Dictionary<string, string> { { ville.Nom, string.Join(" -> ", chemin_complet) } }); // Ajouter le chemin complet au résultat
            }

            this.chemins = chemins; // Mettre à jour les chemins de l'instance courante
            List<Dictionary<string, int>> rep = new List<Dictionary<string, int>>(); 
            rep.Add(distances); 
            rep.Add(temps); 
            return rep; 
        }


        public void Ajouter_à_bdd(List<Dictionary<string, int>> dictionnaire, MySqlConnection connection)
        {
            using (MySqlCommand command = connection.CreateCommand())
            {
                MySqlDataReader reader;
                int val;
                DateTime date;
                string heure;
                string minute;

                foreach (KeyValuePair<string, int> villes_a_ajouter in dictionnaire[0])
                {
                    if (villes_a_ajouter.Key != this.Nom)
                    {
                        command.CommandText = $"SELECT count(*) FROM Plus_Court_Chemin WHERE (ville_depart = '{this.Nom}' AND ville_arrivee = '{villes_a_ajouter.Key}') OR (ville_depart = '{villes_a_ajouter.Key}' AND ville_arrivee = '{this.Nom}');";
                        reader = command.ExecuteReader();
                        reader.Read();
                        val = reader.GetInt32(0);
                        reader.Close();

                        // Ajouter les données
                        date = int_to_date(dictionnaire[1][villes_a_ajouter.Key]);
                        heure = date.Hour < 10 ? "0" + date.Hour : date.Hour.ToString();
                        minute = date.Minute < 10 ? "0" + date.Minute : date.Minute.ToString();

                        if (val == 0)
                        {
                            // Rechercher le chemin correspondant
                            string chemin_a_ajouter = "";
                            foreach (var chemin in this.chemins)
                            {
                                if (chemin.ContainsKey(villes_a_ajouter.Key))
                                {
                                    chemin_a_ajouter = chemin[villes_a_ajouter.Key];
                                    break;
                                }
                            }

                            command.CommandText = $"INSERT INTO Plus_Court_Chemin (ville_depart, ville_arrivee, distance, temp, chemin) VALUES ('{this.Nom}', '{villes_a_ajouter.Key}', {villes_a_ajouter.Value}, '0001-01-{date.Day} {heure}:{minute}:00', '{chemin_a_ajouter}');";
                            command.ExecuteNonQuery();
                        }
                    }
                }
            }
        }
        #endregion

        public override string ToString()
        {
            string result = "Ville: " + Nom + "\n";
            result += "Distances:\n";
            foreach (KeyValuePair<string, int> distance in Distances)
            {
                result += distance.Key + ": " + distance.Value + " km\n";
            }
            result += "Temps:\n";
            foreach (KeyValuePair<string, DateTime> temps in Temps)
            {
                result += temps.Key + ": " + temps.Value.Hour + "h" + temps.Value.Minute + "mn\n";
            }
            return result;
        }

        
    }
}
