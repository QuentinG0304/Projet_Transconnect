using MySql.Data.MySqlClient;
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
    public partial class Page_Client : Form
    {
        bool chef;
        int idCLient;
        Client client_actuel;

        public Page_Client(int idClient, bool chef)
        {
            this.chef = chef;
            this.idCLient = idClient;
            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=TransConnect;UID=root;PASSWORD=root;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            client_actuel = Client.Client_actuel(connection, idCLient);
            InitializeComponent();
            if(chef)
            {
                button2.Visible = false;
            }
            
        }

        private void Page_Client_Load(object sender, EventArgs e)
        {
            labelhist.AutoSize = true;
            // Création d'un panel
            labelhist.Text = client_actuel.ToStringCommandes();
            // Ajout du label au panel
            panel1.Controls.Add(labelhist);
            panel1.AutoScroll = true;
            // Ajout du panel au formulaire
            Controls.Add(panel1);

            //
            if(chef)
            {
                label3.Text = client_actuel.NomComplet();
            }
            else
            {
                label3.Text = "Bonjour " + client_actuel.NomComplet();
            }
            label5.Text = client_actuel.Nom;
            label6.Text = client_actuel.Prenom;
            label8.Text = client_actuel.DateNaissance.ToShortDateString();
            label10.Text = client_actuel.Email;
            label12.Text = client_actuel.Telephone;
            label13.Text = client_actuel.Statut;
            if (label13.Text == "Bronze")
            {
                label13.ForeColor = Color.FromArgb(205, 127, 50);
            }
            else if (label13.Text == "Argent")
            {
                label13.ForeColor = Color.FromArgb(192, 192, 192);
            }
            else if (label13.Text == "Or")
            {
                label13.ForeColor = Color.FromArgb(255, 255, 255, 0);
            }
            else if (label13.Text == " Platine")
            {
                label13.ForeColor = Color.FromArgb(229, 228, 226);
            }
            //Changer la police de label13
            label13.Font = new Font("Arial", 12, FontStyle.Bold);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Création_Commande création_Commande = new Création_Commande(this.idCLient,chef);
            création_Commande.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Accueil accueil = new Accueil();
            accueil.Show();
        }

        
    }
}
