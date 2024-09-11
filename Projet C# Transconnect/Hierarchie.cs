using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quentin_Guignard_Transconnect
{
    internal class Hierarchie
    {
        Salarie employe;
        List<Hierarchie> subordonnes;

        public Salarie Employe { get => employe; set => employe = value; }
        public List<Hierarchie> Subordonnes { get => subordonnes; set => subordonnes = value; }

        public Hierarchie(Salarie employe, bool ajouter)
        {
            this.employe = employe;
            if (ajouter)
            {
                string connectionString = "SERVER=localhost;PORT=3306;DATABASE=TransConnect;UID=root;PASSWORD=root;";
                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();

                MySqlCommand command = connection.CreateCommand();
                command.CommandText = $"SELECT * FROM Salarie WHERE n_ss ={employe.Id}";
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    reader.Close();
                    command.Dispose();
                    command = connection.CreateCommand();
                    command.CommandText = $"UPDATE Salarie SET poste = '{employe.Poste}', id_nplus1 = {employe.Idnplus1}, actif = true WHERE n_ss ={employe.Id};";
                    reader = command.ExecuteReader();
                    reader.Close();
                    command.Dispose();


                }
                else
                {
                    reader.Close();
                    command.Dispose();
                    command = connection.CreateCommand();
                    command.CommandText = $"INSERT INTO Salarie (n_ss, nom, prenom, naissance, adresse, mail, num_tel, date_entree, poste, salaire, id_nplus1, actif) VALUES" +
                    $"({employe.Id}, '{employe.Nom}', '{employe.Prenom}', '{employe.DateNaissance.ToString("yyyy-MM-dd")}', '{employe.Adresse}', '{employe.Email}', '{employe.Telephone}', '{employe.DateEmbauche.ToString("yyyy-MM-dd")}', '{employe.Poste}', {employe.Salaire}, {employe.Idnplus1}, true);";
                    reader = command.ExecuteReader();

                    reader.Close();
                    command.Dispose();
                }




            }
            subordonnes = new List<Hierarchie>();
        }

        public Hierarchie(Salarie employe, List<Salarie> salarie)
        {
            this.employe = employe;
            subordonnes = new List<Hierarchie>();
            foreach (Salarie s in salarie)
            {
                if (s.Idnplus1 == employe.Id)
                {
                    subordonnes.Add(new Hierarchie(s, salarie));
                }
            }
        }

        public delegate void OperationSubordonne(Hierarchie subordonne);

        public void AppliqueFonction (OperationSubordonne operation, Hierarchie h)
        {
            operation(h);
        }

        public void AjouterSubordonne(List<Hierarchie> subordonne)
        {
            foreach (Hierarchie s in subordonne)
            {
                if (s.Employe.Idnplus1 == this.Employe.Id)
                {
                    subordonnes.Add(s);
                }
            }
            int i = 0;
        }

        //Ajouter un subordonné dans la base de données
        public void AjouterSubordonne(Hierarchie subordonne)
        {
            subordonne.Employe.Idnplus1 = this.Employe.Id;
            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=TransConnect;UID=root;PASSWORD=root;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = $"UPDATE Salarie SET id_nplus1 = {subordonne.Employe.Idnplus1} WHERE n_ss = {subordonne.Employe.Id};";
            MySqlDataReader reader = command.ExecuteReader();
            reader.Close();
            command.Dispose();
            subordonnes.Add(subordonne);
        }

        public void SupprimerSubordonne(Hierarchie subordonne)
        {
            subordonnes.Remove(subordonne);
            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=TransConnect;UID=root;PASSWORD=root;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = $"UPDATE Salarie SET actif = false WHERE n_ss = {subordonne.Employe.Id};";
            MySqlDataReader reader = command.ExecuteReader();
            reader.Close();
            command.Dispose();
        }
        public override string ToString()
        {
            return employe.ToString();
        }


       
        public void Sort(Comparison<Hierarchie> comparison)
        {
            subordonnes.Sort(comparison);
            foreach (Hierarchie h in subordonnes)
            {
                h.Sort(comparison);
            }
        }
        //hierarchie.Sort((x, y) => x.Employe.Salaire.CompareTo(y.Employe.Salaire)); Pour trier par salaire par exemple


        public List<Hierarchie> FindAll(Predicate<Hierarchie> match)
        {
            List<Hierarchie> result = new List<Hierarchie>();
            if (match(this))
            {
                result.Add(this);
            }

            foreach (Hierarchie subordonne in subordonnes)
            {
                result.AddRange(subordonne.FindAll(match));
            }

            return result;
        }
        //List<Hierarchie> subordonnes = hierarchieMrDupond.FindAll(x => x.Employe.Nom == "Mr"); Pour trouver tous les employés dont le nom est Mr par exemple



    }
}
