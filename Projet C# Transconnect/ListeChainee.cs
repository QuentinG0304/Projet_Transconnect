using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_C__Transconnect
{
    internal class ListeChainee<T>
    {
        private Noeud<T> head;

        public Noeud<T> Head
        {
            get { return head; }
            set { head = value; }
        }

        public ListeChainee(Noeud<T> t)
        {
            head = t;
        }

        public ListeChainee()
        {
            head = null;
        }

        public void AddHead(T t)
        {
            Noeud<T> noeud = new Noeud<T>(t);
            noeud.Prochain_noeud = head;
            head = noeud;
        }

        public void AddQueue(T t)
        {
            Noeud<T> nvnoeud = new Noeud<T>(t);
            Noeud<T> noeud = head;
            while (noeud.Prochain_noeud != null)
            {
                noeud = noeud.Prochain_noeud;
            }
            noeud.Prochain_noeud = nvnoeud;
        }

        public void Insert(T t, int index)
        {
            Noeud<T> noeudavant = head;
            bool b = true;
            int cpt = 2;
            if (noeudavant != null)
            {
                while (noeudavant.Prochain_noeud != null && b)
                {
                    if (cpt < index)
                    {
                        noeudavant = noeudavant.Prochain_noeud;
                        cpt++;
                    }
                    else
                    {
                        b = false;
                    }
                }
                if (noeudavant.Prochain_noeud != null && index != 1)
                {
                    Noeud<T> noeudapres = noeudavant.Prochain_noeud;
                    noeudavant.Prochain_noeud = new Noeud<T>(t, noeudapres);
                }
                else if (index == 1)
                {
                    head = new Noeud<T>(t, noeudavant);
                }
                else
                {
                    noeudavant.Prochain_noeud = new Noeud<T>(t);
                }
            }
            else
            {
                head = new Noeud<T>(t);
            }
        }
    }
}
