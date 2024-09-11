using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quentin_Guignard_Transconnect
{
    interface IDisponibilite
    {
        public bool Est_Disponible(DateTime date);
    }
}
