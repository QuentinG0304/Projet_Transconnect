using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quentin_Guignard_Transconnect
{
    internal class Voiture : Vehicule
    {
        int nb_places;

        public Voiture(string immatriculation, float prix_par_litre, int nb_places) : base(immatriculation, prix_par_litre)
        {
            this.nb_places = nb_places;
        }
    }
}
