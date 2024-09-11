using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quentin_Guignard_Transconnect
{
    public partial class Form_Organigramme : Form
    {
        public Form_Organigramme()
        {
            InitializeComponent();

        }

        protected override void OnPaint(PaintEventArgs e)
        {

            base.OnPaint(e);
            Organigramme organigramme = new Organigramme();
            List<Hierarchie> salaries = organigramme.Tous_Les_Salaries(organigramme.Chef, new List<Hierarchie>());
            Dictionary<Hierarchie, Button> salaries_places = new Dictionary<Hierarchie, Button>();
            int nb_rangées = 0;
            foreach (Hierarchie h in salaries)
            {
                if (organigramme.Profondeur_orga(h) == 3 || (organigramme.Profondeur_orga(h) == 2 && h.Subordonnes.Count == 0))
                {
                    nb_rangées += 1;
                }
            }
            int largeur_bouton = 200;
            int longueur_bouton = 50;
            int base_largeur = 1830 - largeur_bouton;
            int espace_hauteur = (1000 - (organigramme.Profondeur_orga_max(salaries) * 50)) / organigramme.Profondeur_orga_max(salaries);

            salaries_places = Initialisation_Boutons(organigramme, salaries, largeur_bouton, longueur_bouton, base_largeur, nb_rangées, espace_hauteur);

            Graphics g = e.Graphics;
            Dessiner_lignes(salaries, salaries_places, g, organigramme);

            Ajouter_Description(salaries_places);
        }

        // Ajouter la description des employés
        private void Ajouter_Description(Dictionary<Hierarchie, Button> salaries_places)
        {
            foreach (var clé in salaries_places)
            {
                Button bouton = clé.Value;
                bouton.Click += (sender, e) => MessageBox.Show(clé.Key.Employe.ToString());
                bouton.BackColor = Color.PeachPuff;
            }
        }

        // Dessiner les lignes
        private void Dessiner_lignes(List<Hierarchie> salaries, Dictionary<Hierarchie, Button> salaries_places, Graphics g, Organigramme organigramme)
        {

            // Créer un pinceau noir
            Pen pen = new Pen(Color.Black);
            pen.Width = 2;
            Hierarchie plus_eloigne = null;
            foreach (Hierarchie h in salaries)
            {
                if (h.Subordonnes.Count != 0)
                {
                    // Si les subordonnés sont à la même profondeur
                    if (organigramme.Meme_Profondeur(h.Subordonnes))
                    {
                        foreach (Hierarchie subordonne in h.Subordonnes)
                        {
                            g.DrawLine(pen, salaries_places[h].Location.X + salaries_places[h].Width / 2, salaries_places[h].Location.Y + salaries_places[h].Height, salaries_places[subordonne].Location.X + salaries_places[subordonne].Width / 2, salaries_places[subordonne].Location.Y);
                        }
                    }
                    else
                    {
                        // Si les subordonnés ne sont pas à la même profondeur
                        foreach (Hierarchie subordonne in h.Subordonnes)
                        {
                            // Dessiner la ligne horizontale pour chaque subordonné
                            g.DrawLine(pen, salaries_places[subordonne].Location.X - 10, salaries_places[subordonne].Location.Y + (salaries_places[subordonne].Height / 2), salaries_places[subordonne].Location.X, salaries_places[subordonne].Location.Y + (salaries_places[subordonne].Height / 2));
                            if (plus_eloigne == null)
                            {
                                plus_eloigne = subordonne;
                            }
                            else if (organigramme.Profondeur_orga(plus_eloigne) < organigramme.Profondeur_orga(subordonne))
                            {
                                plus_eloigne = subordonne;
                            }
                        }
                        // Dessiner la ligne verticale qui va du manager au subordonné le plus éloigné
                        g.DrawLine(pen, salaries_places[h].Location.X + 10, salaries_places[h].Location.Y + salaries_places[h].Height, salaries_places[h].Location.X + 10, salaries_places[plus_eloigne].Location.Y + (salaries_places[plus_eloigne].Height / 2));
                    }
                    plus_eloigne = null;
                }

            }





            // Libérer les ressources
            pen.Dispose();
            g.Dispose();
        }

        // Initialiser les boutons
        private Dictionary<Hierarchie, Button> Initialisation_Boutons(Organigramme organigramme, List<Hierarchie> salaries, int largeur_bouton, int longueur_bouton, int base_largeur, int nb_rangées, int espace_hauteur)
        {
            int posy;
            Dictionary<Hierarchie, Button> salaries_places = new Dictionary<Hierarchie, Button>();
            //Ligne la plus fournie
            int cpt = 0;
            foreach (Hierarchie h in salaries)
            {
                posy = 2 * (espace_hauteur + 50);
                if (organigramme.Profondeur_orga(h) == 3)
                {
                    Button bouton;
                    if (h.Subordonnes.Count == 0)
                    {
                        bouton = CreerNoeud(h.Employe.Nom, largeur_bouton, longueur_bouton, 20 + (base_largeur / (nb_rangées - 1)) * cpt, posy);
                    }
                    else
                    {
                        bouton = CreerNoeud(h.Employe.Nom, largeur_bouton, longueur_bouton, (base_largeur / (nb_rangées - 1)) * cpt, posy);
                    }
                    Controls.Add(bouton);
                    salaries_places.Add(h, bouton);
                    cpt++;
                }

            }

            //Lignes supérieur
            int posx;
            int nb_subordonnes;
            int cpt_0 = 1;
            //Juste quand y'a que 1 subordonné
            for (int i = 2; i > 0; i--)
            {
                posy = (i - 1) * (espace_hauteur + 50);
                foreach (Hierarchie h in salaries)
                {
                    posx = 0;
                    nb_subordonnes = 0;
                    if (organigramme.Profondeur_orga(h) == i)
                    {
                        //Calcul de la position x en prenant la moyenne des positions x des subordonnés
                        foreach (Hierarchie hierarchie in salaries_places.Keys)
                        {
                            if (hierarchie.Employe.Idnplus1 == h.Employe.Id)
                            {
                                posx += salaries_places[hierarchie].Left;
                                nb_subordonnes++;
                            }
                        }
                        if (nb_subordonnes == 1)
                        {
                            posx -= 20 * nb_subordonnes;
                        }
                        if (nb_subordonnes == 0)
                        {
                            posx = salaries_places.Max(x => x.Value.Right) + 50 * cpt_0;
                            nb_subordonnes = 1;
                            cpt_0++;
                        }
                        Button bouton = CreerNoeud(h.Employe.Nom, largeur_bouton, longueur_bouton, posx / nb_subordonnes, posy);
                        salaries_places.Add(h, bouton);
                        Controls.Add(bouton);
                    }
                }
            }


            //Lignes inférieur
            Dictionary<Hierarchie, Button> subordonnes_places_temp = new Dictionary<Hierarchie, Button>();
            for (int i = 4; i <= organigramme.Profondeur_orga_max(salaries); i++)
            {
                posy = (i - 1) * (espace_hauteur + 50);
                foreach (Hierarchie h in salaries)
                {
                    posx = 0;
                    if (organigramme.Profondeur_orga(h) == i)
                    {
                        foreach (Hierarchie hierarchie in salaries_places.Keys)
                        {

                            if (hierarchie.Employe.Idnplus1 == h.Employe.Idnplus1)
                            {
                                posx = salaries_places[hierarchie].Left;
                            }
                            else if (hierarchie.Employe.Id == h.Employe.Idnplus1)
                            {
                                //S'il ont le même manager on décale de 20 pixel pour laisser la place à la ligne horizontale
                                posx = salaries_places[hierarchie].Left + 20;
                            }

                        }
                        Button bouton = CreerNoeud(h.Employe.Nom, largeur_bouton, longueur_bouton, posx, posy);
                        subordonnes_places_temp.Add(h, bouton);
                        Controls.Add(bouton);
                    }
                }
                foreach (var clé in subordonnes_places_temp)
                {
                    salaries_places[clé.Key] = clé.Value;
                }
                subordonnes_places_temp.Clear();

            }

            return salaries_places;
        }
        private Button CreerNoeud(string texte, int x, int y, int posx, int posy)
        {
            Button node = new Button();
            node.Text = texte;
            node.Size = new Size(x, y);
            node.Location = new Point(posx, posy);
            node.FlatStyle = FlatStyle.Flat;
            node.BackColor = Color.LightGray;
            node.TextAlign = ContentAlignment.MiddleCenter;
            return node;
        }
        private void Form_Organigramme_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Page_PDG page_PDG = new Page_PDG();
            page_PDG.Show();
        }
    }
}
