using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quentin_Guignard_Transconnect
{
    internal class Poids_Lourd : Vehicule
    {
        int volume_max;
        string matière;
        string type;

        public int Volume_max { get => volume_max; set => volume_max = value; }
        public Poids_Lourd(string immatriculation, float prix_par_litre, int volume, string matière, string type) : base(immatriculation, prix_par_litre)
        {
            this.volume_max = volume;
            this.matière = matière;
            this.type = Determine_type(matière);
        }

        public string Determine_type(string matière)
        {
            if (matière == "liquide" || matière == "gaz")
            {
                return "camion-citerne";
            }
            else if (matière == "solide")
            {
                return "camion-benne";
            }
            else 
            {
                return "camion-frigotifique";
            }
        }

    }
}
