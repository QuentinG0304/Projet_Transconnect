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
    public partial class Page_PDG : Form
    {
        public Page_PDG()
        {
            InitializeComponent();
        }

        private void Page_PDG_Load(object sender, EventArgs e)
        {

        }

        private void salariésToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void organigrammeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new Form_Organigramme();
            form.Show();
        }

        private void recrutementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new Recrutement_Licenciement();
            form.Show();
        }

        private void statistiquesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new Statistiques();
            form.Show();
        }

        private void historiqueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new Historique();
            form.Show();
        }

        private void visualisationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new Garage();
            form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form form = new Accueil();
            form.Show();
        }

        private void statutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new Statut();
            form.Show();
        }

        private void chauffeursToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form form = new Chauffeurs();
            form.Show();
        }
    }
}
