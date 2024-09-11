using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using Projet_C__Transconnect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quentin_Guignard_Transconnect
{
    internal class Organigramme
    {
        Hierarchie chef;
        public Organigramme(Hierarchie chef)
        {
            this.chef = chef;
        }

        public Organigramme(Salarie chef)
        {
            this.chef = new Hierarchie(chef,false);
        }

        //Constructeur pour récupérer les données de la base de données
        public Organigramme()
        {
            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=TransConnect;UID=root;PASSWORD=root;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            MySqlDataReader reader;
            MySqlCommand command = connection.CreateCommand();
            List<Salarie> salaries = new List<Salarie>();
            List<Hierarchie> hierarchies = new List<Hierarchie>();
            command.CommandText = "SELECT * FROM salarie WHERE actif = true";
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Salarie salarie = new Salarie(
                reader.GetInt32("n_ss"),
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
                salaries.Add(salarie);
                hierarchies.Add(new Hierarchie(salarie, false));
            }
            reader.Close();
            Salarie chef = null;
            foreach (Salarie s in salaries)
            {
                if (s.Poste == "Directeur Général")
                {
                    chef = s;
                }
            }
            foreach (Hierarchie h in hierarchies)
            {
                if (h.Employe == chef)
                {
                    h.AjouterSubordonne(hierarchies);
                    this.chef = h;
                }
                else
                {
                    h.AjouterSubordonne(hierarchies);
                }
            }

        }
        public Hierarchie Chef { get => chef; set => chef = value; }
        
        public bool Promouvoir(int id)
        {
            bool res = false;
            Hierarchie subordonne = Recherche_Hierarchie(this.chef, id);
            Hierarchie chef_ = Recherche_Chef_de_Subordonne(this.chef, subordonne.Employe);
            if (chef_ == null)
            {
                return false;
            }
            else
            {
                Hierarchie chef_superieur = Recherche_Hierarchie(this.chef, chef_.Employe.Idnplus1);
                if (chef_superieur == null)
                {
                    return false;
                }
                else
                {
                    Salarie nv_employe = new Salarie(subordonne.Employe.Id, subordonne.Employe.Nom, subordonne.Employe.Prenom, subordonne.Employe.Adresse, subordonne.Employe.Telephone, subordonne.Employe.Email, subordonne.Employe.DateNaissance, subordonne.Employe.DateEmbauche, subordonne.Employe.Salaire, chef_.Employe.Poste , chef_.Employe.Idnplus1);
                    LicensierSubordonne(subordonne);
                    new Hierarchie(nv_employe, true);
                    return true;
                }
            }
        }

        public void Orga_salarie()
        {
            ListeChainee<int> a = new ListeChainee<int>();
            a.AddHead(5);
            a.AddHead(6);
            a.AddQueue(7);
            Noeud<int> b = a.Head;
            b.Prochain_noeud = null;
            a.Insert(4, 1);
        }
        public void LicensierSubordonne(Hierarchie subordonne)
        {
            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=TransConnect;UID=root;PASSWORD=root;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            List<int> chemin = Trouver_Chemin(this.chef, subordonne.Employe, new List<int>());
            Hierarchie chef_ = Recherche_Hierarchie(this.chef, chemin[0]);
            if (subordonne.Subordonnes.Count == 0)
            {
                chef_.AppliqueFonction(chef_.SupprimerSubordonne, subordonne);
            }
            else
            {
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = $"SELECT min(n_ss) FROM Salarie;";
                MySqlDataReader reader = command.ExecuteReader();
                reader.Read();
                int temp = reader.GetInt32(0);
                int id = 0;
                if(temp ==1)
                {
                    id = -1;
                }
                else
                {
                    id = temp - 1;
                }
                reader.Close();
                command.Dispose();
                Hierarchie vacant = new Hierarchie(new Salarie(id, "Vacant", "Vacant", "Vacant", "Vacant", "Vacant", DateTime.Now, DateTime.Now, 0, subordonne.Employe.Poste, subordonne.Employe.Idnplus1),true);
                RemplacerSubordonne(chef_, subordonne, vacant);
                
            }
        }
        public void RemplacerSubordonne(Hierarchie chef, Hierarchie subordonne, Hierarchie remplacement)
        {
            foreach (Hierarchie h in subordonne.Subordonnes)
            {
                remplacement.AppliqueFonction(remplacement.AjouterSubordonne,h);
            }
            chef.AppliqueFonction(chef.SupprimerSubordonne, subordonne);
            chef.AppliqueFonction(chef.AjouterSubordonne, remplacement);
        }

        public Hierarchie Recherche_Chef_de_Subordonne(Hierarchie chef, Salarie subordonne)
        {
            if (chef.Subordonnes.Count == 0)
            {
                return null;
            }
            else
            {
                foreach (Hierarchie h in chef.Subordonnes)
                {
                    if (h.Employe == subordonne)
                    {
                        return chef;
                    }
                    else
                    {
                        Hierarchie res = Recherche_Chef_de_Subordonne(h, subordonne);
                        if (res != null)
                        {
                            return res;
                        }
                    }
                }
                return null;
            }

        }
        // Méthode pour trouver le chef d'un poste (2 possibilités mais la deuxième ne fonctionne pas si le poste n'existe pas donc on utilisera la 1)
        public string Recherche_Poste_du_superieur(string poste)
        {
            if (poste == "Comptable")
            {
                return "Direction Comptable";
            }
            if (poste == "Direction Comptable" || poste == "Contrôleur de Gestion")
            {
                return "Directeur Financier";
            }
            if (poste == "Formation")
            {
                return "Directeur Ressources Humaines";
            }
            if (poste == "Chauffeur")
            {
                return "Chef d Équipe";
            }
            if (poste == "Chef d Équipe")
            {
                return "Directeur des Opérations";
            }
            if (poste == "Commercial")
            {
                return "Directeur Commercial";
            }
            if (poste == "Contrat")
            {
                return "Directeur des Ressources Humaines";
            }
            if (poste == "Directeur Commercial" || poste == "Directeur des Opérations" || poste == "Directeur des Ressources Humaines" || poste == "Directeur Financier")
            {
                return "Directeur Général";
            }
            else
            {
                return null;
            }
        }
        public string Recherche_Poste_du_superieur(Hierarchie chef, string poste)
        {
            if (chef.Employe.Poste == poste)
            {
                Hierarchie rep = Recherche_Hierarchie(this.chef, Trouver_Chemin(this.chef, chef.Employe, new List<int>())[0]);
                return rep.Employe.Poste;
            }
            else
            {
                foreach (Hierarchie h in chef.Subordonnes)
                {
                    string res = Recherche_Poste_du_superieur(h, poste);
                    if (res != null)
                    {
                        return res;
                    }
                }
                return null;
            }
        }
        //Recherche les chefs possibles pour un poste
        public List<Hierarchie> Recherche_Chefs_Possibles(Hierarchie chef, string poste, List<Hierarchie> possible_chef)
        {


            if (chef.Employe.Poste == poste)
            {
                possible_chef.Add(chef);
                return possible_chef;
            }
            else if (chef.Subordonnes.Count == 0)
            {
                return null;
            }
            else
            {
                foreach (Hierarchie h in chef.Subordonnes)
                {
                    Recherche_Chefs_Possibles(h, poste, possible_chef);
                }
                return possible_chef;
            }
        }
        
        //Trouve le chemin pour aller à un employé
        public List<int> Trouver_Chemin(Hierarchie chef, Salarie employe, List<int> chemin)
        {
            if (chef.Employe == employe)
            {
                return chemin;
            }
            else
            {
                foreach (Hierarchie h in chef.Subordonnes)
                {
                    List<int> res = Trouver_Chemin(h, employe, chemin);
                    if (res != null)
                    {
                        res.Add(chef.Employe.Id);
                        return res;
                    }
                }
                return null;
            }
        }

        //Trouver un employé dans l'organigramme à l'aide de son id
        public Hierarchie Recherche_Hierarchie(Hierarchie chef, int id)
        {
            if (chef.Employe.Id == id)
            {
                return chef;
            }
            else
            {
                foreach (Hierarchie h in chef.Subordonnes)
                {
                    Hierarchie res = Recherche_Hierarchie(h, id);
                    if (res != null)
                    {
                        return res;
                    }
                }
                return null;
            }
        }

        //Afficher l'organigramme pour une class Program utilisée pour des tests
        public string AfficherOrganigramme(Hierarchie chef, string tabulation)
        {
            string res = tabulation + chef.Employe.Id + ":" + chef.Employe.NomComplet() + " - " + chef.Employe.Poste + "\n";
            foreach (Hierarchie h in chef.Subordonnes)
            {
                res += AfficherOrganigramme(h, tabulation + "\t");
            }
            return res;
        }

        //Trouver la profondeur d'un employé dans l'entreprise
        public int Profondeur(Hierarchie chef, Hierarchie hierarchie, int profondeur = 1)
        {
            if (chef == hierarchie)
            {
                return profondeur;
            }
            else
            {
                foreach (Hierarchie h in chef.Subordonnes)
                {
                    int res = Profondeur(h, hierarchie, profondeur + 1);
                    if (res != -1)
                    {
                        return res;
                    }
                }
                return -1;
            }
        }

        //Trouver la profondeur d'un employé dans l'organigramme différent de celle de l'entreprise
        public int Profondeur_orga(Hierarchie hierarchie)
        {
            int cpt = 0;
            Hierarchie chef = Recherche_Hierarchie(this.chef, hierarchie.Employe.Idnplus1);
            if (chef == null)
            {
                return 1;
            }
            else
            {
                int nb_sub = chef.Subordonnes.Count;
                if (nb_sub >= 1)
                {
                    for (int i = 0; i < nb_sub; i++)
                    {
                        if (chef.Subordonnes[i].Subordonnes.Count == 0)
                        {
                            cpt += 1;
                        }
                    }
                    if (cpt == nb_sub)
                    {
                        for (int i = 0; i < nb_sub; i++)
                        {
                            if (chef.Subordonnes[i].Employe == hierarchie.Employe)
                            {
                                return i + Profondeur(this.chef, hierarchie);
                            }
                        }
                    }
                    return Profondeur(this.chef, hierarchie);
                }
                else
                {
                    return Profondeur(this.chef, hierarchie);
                }
            }
        }

        //Trouver la profondeur maximale de l'organigramme
        public int Profondeur_orga_max(List<Hierarchie> salaries, int profondeur = 1)
        {
            int max = profondeur;
            foreach (Hierarchie h in salaries)
            {
                int res = Profondeur_orga(h);
                if (res > max)
                {
                    max = res;
                }
            }
            return max;
        }

        //Méthode pour vérifier si des employés ont la même profondeur
        public bool Meme_Profondeur(List<Hierarchie> salaries)
        {
            int profondeur = Profondeur_orga(salaries[0]);
            foreach (Hierarchie h in salaries)
            {
                if (Profondeur_orga(h) != profondeur)
                {
                    return false;
                }
            }
            return true;
        }

        //Trouver le nombre de subordonnés d'un employé souvent utiliser avec le chef pour trouver le nombre de subordonnés total
        public List<Hierarchie> Tous_Les_Salaries(Hierarchie chef, List<Hierarchie> salaries)
        {
            salaries.Add(chef);
            foreach (Hierarchie h in chef.Subordonnes)
            {
                Tous_Les_Salaries(h, salaries);
            }
            return salaries;
        }


    }
}
