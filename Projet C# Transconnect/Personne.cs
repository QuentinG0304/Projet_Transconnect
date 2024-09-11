using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quentin_Guignard_Transconnect
{

    public abstract class Personne
    {
        private int id;
        private string nom;
        private string prenom;
        private string adresse;
        private string telephone;
        private string email;
        private DateTime dateNaissance;

        #region Propriétés
        public int Id { get { return id; } set { id = value; } }
        public string Nom { get { return nom; } set { nom = value; } }
        public string Prenom { get { return prenom; } set { prenom = value; } }
        public string Adresse { get { return adresse; } set { adresse = value; } }
        public string Telephone { get { return telephone; } set { telephone = value; } }
        public string Email { get { return email; } set { email = value; } }
        public DateTime DateNaissance { get { return dateNaissance; } set { dateNaissance = value; } }

        #endregion

        public Personne(int id, string nom, string prenom, string adresse, string telephone, string email, DateTime dateNaissance)
        {
            this.id = id;
            this.nom = nom;
            this.prenom = prenom;
            this.adresse = adresse;
            this.telephone = telephone;
            this.email = email;
            this.dateNaissance = dateNaissance;
        }

        public override string ToString()
        {
            return $"{nom} {prenom} {adresse} {telephone} {email} {dateNaissance}";
        }

        public string NomComplet()
        {
            return $"{prenom} {nom} ";
        }
    }
}
