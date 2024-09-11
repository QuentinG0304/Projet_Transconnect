using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_C__Transconnect
{
    internal class Noeud<T>
    {
        private T data;
        private Noeud<T> prochain_noeud;

        public Noeud<T> Prochain_noeud
        {
            get { return prochain_noeud; }
            set { prochain_noeud = value; }
        }

        public T Data
        {
            get { return data; }
            set { data = value; }
        }

        public Noeud(T t)
        {
            data = t;
            prochain_noeud = null;
        }

        public Noeud(T t, Noeud<T> prochain)
        {
            data = t;
            prochain_noeud = prochain;
        }
    }
}
