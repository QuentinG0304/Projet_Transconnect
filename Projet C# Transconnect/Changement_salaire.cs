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
    public partial class Changement_salaire : Form
    {
        Hierarchie employe;
        Organigramme org = new Organigramme();
        public Changement_salaire(int id)
        {
            Organigramme org = new Organigramme();
            this.employe = org.Recherche_Hierarchie(org.Chef,id);
            InitializeComponent();
        }

        private void Changement_salaire_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nv_salaire = textBox1.Text;
            bool est_nb = true;
            foreach(char c in nv_salaire)
            {
                if (!char.IsDigit(c) && est_nb)
                {
                    MessageBox.Show("Le salaire doit être un nombre");
                    est_nb = false;
                }
            }
            if (est_nb)
            {
                string connectionString = "SERVER=localhost;PORT=3306;DATABASE=TransConnect;UID=root;PASSWORD=root;";
                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();
                connection = connection;
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = $"UPDATE Salarie SET Salaire = {Convert.ToInt32(nv_salaire)} WHERE n_ss = {employe.Employe.Id};";
                MySqlDataReader reader = command.ExecuteReader();
                this.Hide();
                MessageBox.Show("Le salaire a bien été changé");
            }
        }
    }
}
