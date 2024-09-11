using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quentin_Guignard_Transconnect
{
    internal class Camionnette : Vehicule
    {
        string usage;

        public Camionnette(string immatriculation, float prix_par_litre, string usage) : base(immatriculation, prix_par_litre)
        {
            this.usage = usage;
        }
    }
}
