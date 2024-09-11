using Google.Protobuf;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quentin_Guignard_Transconnect
{
    public partial class Recrutement_Licenciement : Form
    {
        List<Hierarchie> salaries = new List<Hierarchie>();
        MySqlConnection connection;
        List<Label> label_licenciement = new List<Label>();
        List<Label> label_recrutement = new List<Label>();
        List<TextBox> textbox_recrutement = new List<TextBox>();
        Organigramme organigramme;
        public Recrutement_Licenciement()
        {
            this.organigramme = new Organigramme();
            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=TransConnect;UID=root;PASSWORD=root;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            this.connection = connection;
            this.salaries = organigramme.Tous_Les_Salaries(organigramme.Chef, new List<Hierarchie>());


            InitializeComponent();
            //Ajout des items dans la comboBox 1
            comboBox1.Items.Add("Recrutement");
            comboBox1.Items.Add("Licenciement");
            comboBox1.Items.Add("Changement salaire / Promotion");

            //Ajout des items dans la comboBox 2
            comboBox2.Visible = false;
            foreach (Hierarchie h in salaries)
            {
                if (h.Employe.Id > 0)
                {
                    comboBox2.Items.Add(h.Employe.Nom + " " + h.Employe.Prenom + " :  " + h.Employe.Poste);
                }
            }

            # region Ajout des items dans la comboBox 3
            List<string> postes = new List<string>();
            comboBox3.Visible = false;
            comboBox3.Items.Add("Chef d Équipe");
            postes.Add("Chef d Équipe");
            comboBox3.Items.Add("Chauffeur");
            postes.Add("Chauffeur");
            comboBox3.Items.Add("Commercial");
            postes.Add("Commercial");
            comboBox3.Items.Add("Comptable");
            postes.Add("Comptable");
            comboBox3.Items.Add("Contrats");
            postes.Add("Contrats");
            comboBox3.Items.Add("Formation");
            postes.Add("Formation");
            //Pour les postes vacants
            MySqlCommand command = this.connection.CreateCommand();
            command.CommandText = $"SELECT * FROM Salarie WHERE n_ss < 0;";
            MySqlDataReader reader = command.ExecuteReader();
            string poste = "";
            while (reader.Read())
            {
                poste = reader.GetString("poste"); ;
                if (!postes.Contains(poste))
                {
                    comboBox3.Items.Add(poste);
                    postes.Add(poste);
                }
            }
            reader.Close();
            command.Dispose();
            #endregion


            comboBox4.Visible = false;


            //Label
            List<Label> list = new List<Label>();
            foreach (Label label in this.Controls.OfType<Label>())
            {
                list.Add(label);
            }
            List<Label> label_licenciement = new List<Label>();
            List<Label> label_recrutement = new List<Label>();
            #region ajout des labels dans les listes
            label_licenciement.Add(label3);
            label_licenciement.Add(label4);
            label_licenciement.Add(label5);
            label_licenciement.Add(label6);
            label_licenciement.Add(label7);
            label_licenciement.Add(label8);
            label_licenciement.Add(label9);
            label_licenciement.Add(label10);
            label_licenciement.Add(label11);
            label_licenciement.Add(label12);
            label_licenciement.Add(label13);
            label_licenciement.Add(label14);
            label_recrutement.Add(label16);
            label_recrutement.Add(label17);
            label_recrutement.Add(label18);
            label_recrutement.Add(label19);
            label_recrutement.Add(label20);
            label_recrutement.Add(label21);
            label_recrutement.Add(label22);
            label_recrutement.Add(label23);
            #endregion
            this.label_licenciement = label_licenciement;
            this.label_recrutement = label_recrutement;
            label15.Visible = false;
            label2.Visible = false;
            foreach (Label label in label_licenciement)
            {
                label.Visible = false;
            }
            foreach (Label label in label_recrutement)
            {
                label.Visible = false;
            }

            //Button
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;

            //TextBox
            List<TextBox> textbox_recrutement = new List<TextBox>();
            foreach (TextBox textbox in this.Controls.OfType<TextBox>())
            {
                textbox.Visible = false;
                textbox_recrutement.Add(textbox);
            }
            this.textbox_recrutement = textbox_recrutement;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.organigramme = new Organigramme();
            if (comboBox1.Text == "Recrutement")
            {
                label15.Visible = true;
                comboBox3.Visible = true;
                label2.Visible = false;
                comboBox2.Visible = false;
                Recrutement_invisible();
                licenciement_invisible();
                button3.Visible = false;
                button4.Visible = false;
                comboBox4.Visible = false;

            }
            else if (comboBox1.Text == "Licenciement")
            {
                label2.Visible = true;
                comboBox2.Visible = true;
                label15.Visible = false;
                comboBox3.Visible = false;
                Recrutement_invisible();
                licenciement_invisible();
                button3.Visible = false;
                button4.Visible = false;
                comboBox4.Visible = false;
            }
            else if (comboBox1.Text == "Changement salaire / Promotion")
            {
                label2.Visible = true;
                comboBox2.Visible = true;
                label15.Visible = false;
                comboBox3.Visible = false;
                Recrutement_invisible();
                licenciement_invisible();
                button3.Visible = false;
                button4.Visible = false;
                comboBox4.Visible = false;

            }
        }
        private void Recrutement_Licenciement_Load(object sender, EventArgs e)
        {

        }
        private void Remplir_label(int id)
        {
            MySqlCommand command = this.connection.CreateCommand();
            command.CommandText = $"SELECT * FROM Salarie WHERE n_ss = {id}";
            MySqlDataReader reader = command.ExecuteReader();
            reader.Read();
            foreach (Label label in label_licenciement)
            {
                if (label.Name == "label9")
                {
                    label.Text = reader.GetString("nom");
                }
                else if (label.Name == "label10")
                {
                    label.Text = reader.GetString("prenom");
                }
                else if (label.Name == "label12")
                {
                    label.Text = reader.GetString("num_tel");
                }
                else if (label.Name == "label11")
                {
                    label.Text = reader.GetDateTime("date_entree").ToString();
                }
                else if (label.Name == "label14")
                {
                    label.Text = reader.GetDouble("salaire").ToString();
                }
                else if (label.Name == "label13")
                {
                    label.Text = reader.GetString("poste");
                }
            }
            reader.Close();
            command.Dispose();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            List<string> liste = comboBox2.Text.Split(' ').ToList();
            MySqlCommand command = this.connection.CreateCommand();
            command.CommandText = $"SELECT * FROM Salarie WHERE nom = '{liste[0]}' AND prenom = '{liste[1]}'";
            MySqlDataReader reader = command.ExecuteReader();
            reader.Read();
            int id = reader.GetInt32("n_ss");
            reader.Close();
            command.Dispose();
            if (comboBox1.Text == "Licenciement")
            {
                //Licenciement
                Remplir_label(id);
                licenciement_visible();
                Recrutement_invisible();
                button3.Visible = false;
                button4.Visible = false;


            }
            else if (comboBox1.Text == "Changement salaire / Promotion")
            {
                Remplir_label(id);
                licenciement_visible();
                Recrutement_invisible();
                button3.Visible = true;
                button4.Visible = true;
                button1.Visible = false;

            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

            #region Ajout des items dans la comboBox 4
            string poste_nplus1 = organigramme.Recherche_Poste_du_superieur(comboBox3.Text);
            List<string> noms = new List<string>();
            MySqlCommand command = this.connection.CreateCommand();
            command.CommandText = $"SELECT * FROM Salarie WHERE poste = '{poste_nplus1}' AND actif = true AND n_ss >0;";
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                noms.Add(reader.GetString("Prenom") + " " + reader.GetString("nom"));
            }
            reader.Close();
            command.Dispose();
            if (noms.Count == 0)
            {
                comboBox4.Text = "Aucun supérieur disponible, choix automatique";
            }
            else
            {
                comboBox4.Text = "Choisir un supérieur";
            }
            foreach (string nom in noms)
            {
                comboBox4.Items.Add(nom);
            }
            comboBox4.Visible = true;
            Recrutement_visible();
            #endregion
        }



        //Licensiement
        private void button1_Click(object sender, EventArgs e)
        {
            List<string> liste = comboBox2.Text.Split(' ').ToList();
            MySqlCommand command = this.connection.CreateCommand();
            command.CommandText = $"SELECT * FROM Salarie WHERE nom = '{liste[0]}' AND prenom = '{liste[1]}'";
            MySqlDataReader reader = command.ExecuteReader();
            reader.Read();
            int id = reader.GetInt32("n_ss");
            reader.Close();
            command.Dispose();
            organigramme.LicensierSubordonne(organigramme.Recherche_Hierarchie(organigramme.Chef, id));
            this.Hide();
            Recrutement_Licenciement form = new Recrutement_Licenciement();
            form.Show();
        }

        //Recrutement
        private void button2_Click(object sender, EventArgs e)
        {
            bool ok = true;
            string poste = comboBox3.Text;
            string nom = textBox1.Text;
            string prenom = textBox2.Text;
            //Naissance
            string naissance = textBox3.Text;
            DateTime date = new DateTime();
            try
            {
                date = DateTime.ParseExact(naissance, "MM/dd/yyyy", CultureInfo.InvariantCulture);
            }
            catch (Exception)
            {
                ok = false;
                MessageBox.Show("Date de naissance invalide");
            }
            if (ok)
            {
                string adresse = textBox4.Text;
                string mail = textBox5.Text;
                string num_tel = textBox6.Text;
                bool inva = true;
                foreach (char s in num_tel)
                {
                    if (!char.IsDigit(s) && inva)
                    {
                        inva = false;
                        ok = false;
                        MessageBox.Show("Numéro de téléphone invalide");
                    }
                }
                if (ok)
                {
                    MySqlCommand command;
                    MySqlDataReader reader;
                    string salaire = textBox7.Text;
                    int id_chef = 0;
                    foreach (char s in salaire)
                    {
                        if (!char.IsDigit(s))
                        {
                            ok = false;
                            MessageBox.Show("Salaire invalide");
                        }
                    }
                    if (ok)
                    {
                        Hierarchie vacant = null;
                        List<string> combotexte = comboBox4.Text.Split(' ').ToList();
                        if (combotexte.Count == 2)
                        {
                            command = this.connection.CreateCommand();
                            command.CommandText = $"SELECT * FROM Salarie WHERE prenom = '{combotexte[0]}' AND actif = true AND nom = '{combotexte[1]}';";
                            reader = command.ExecuteReader();
                            //Si nom prénom existe
                            if (reader.Read())
                            {
                                id_chef = reader.GetInt32("n_ss");
                            }
                            reader.Close();
                            command.Dispose();
                        }
                        else
                        {

                            string poste_nplus1 = organigramme.Recherche_Poste_du_superieur(poste);
                            command = this.connection.CreateCommand();
                            command.CommandText = $"SELECT * FROM Salarie WHERE poste = '{poste}' AND actif = true AND n_ss<0;";
                            reader = command.ExecuteReader();
                            //On check s'il y a un vacant
                            if (reader.Read())
                            {
                                vacant = organigramme.Recherche_Hierarchie(organigramme.Chef, reader.GetInt32("n_ss"));
                            }
                            else
                            {
                                reader.Close();
                                //On prend le premier poste
                                command.CommandText = $"SELECT * FROM Salarie WHERE poste = '{poste_nplus1}' AND actif = true AND n_ss>0;";
                                reader = command.ExecuteReader();
                                reader.Read();
                                id_chef = reader.GetInt32("n_ss");
                            }
                            reader.Close();
                            command.Dispose();
                        }
                        command.CommandText = $"SELECT max(n_ss) FROM Salarie;";
                        reader = command.ExecuteReader();
                        reader.Read();
                        int id = reader.GetInt32(0) + 1;
                        reader.Close();
                        command.Dispose();
                        if (vacant != null)
                        {
                            organigramme.RemplacerSubordonne(organigramme.Recherche_Chef_de_Subordonne(organigramme.Chef, vacant.Employe), vacant, new Hierarchie(new Salarie(id, nom, prenom, adresse, mail, num_tel, date, DateTime.Now, double.Parse(salaire), poste, id_chef), true));
                            command.CommandText = $"DELETE FROM Salarie WHERE n_ss = {vacant.Employe.Id};";
                            reader = command.ExecuteReader();
                            reader.Close();
                            command.Dispose();
                        }
                        else
                        {
                            new Hierarchie(new Salarie(id, nom, prenom, adresse, mail, num_tel, date, DateTime.Now, double.Parse(salaire), poste, id_chef), true);
                        }
                        MessageBox.Show("Employé recruté");
                    }
                }
            }
        }
        private void Recrutement_visible()
        {
            foreach (Label label in label_recrutement)
            {
                label.Visible = true;
            }
            foreach (TextBox textbox in textbox_recrutement)
            {
                textbox.Visible = true;
            }
            button2.Visible = true;
        }

        private void Recrutement_invisible()
        {
            foreach (Label label in label_recrutement)
            {
                label.Visible = false;
            }
            foreach (TextBox textbox in textbox_recrutement)
            {
                textbox.Visible = false;
            }
            button2.Visible = false;
        }

        private void licenciement_visible()
        {
            foreach (Label label in label_licenciement)
            {
                label.Visible = true;
            }
            button1.Visible = true;
        }

        private void licenciement_invisible()
        {
            foreach (Label label in label_licenciement)
            {
                label.Visible = false;
            }
            button1.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<string> liste = comboBox2.Text.Split(' ').ToList();
            MySqlCommand command = this.connection.CreateCommand();
            command.CommandText = $"SELECT * FROM Salarie WHERE nom = '{liste[0]}' AND prenom = '{liste[1]}'";
            MySqlDataReader reader = command.ExecuteReader();
            reader.Read();
            int id = reader.GetInt32("n_ss");
            reader.Close();
            command.Dispose();
            bool done = organigramme.Promouvoir(id);
            if (done)
            {
                MessageBox.Show("Promotion effectuée");
            }
            else
            {
                MessageBox.Show("Promotion impossible");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            List<string> liste = comboBox2.Text.Split(' ').ToList();
            MySqlCommand command = this.connection.CreateCommand();
            command.CommandText = $"SELECT * FROM Salarie WHERE nom = '{liste[0]}' AND prenom = '{liste[1]}'";
            MySqlDataReader reader = command.ExecuteReader();
            reader.Read();
            int id = reader.GetInt32("n_ss");
            reader.Close();
            command.Dispose();
            Changement_salaire changement_Salaire = new Changement_salaire(id);
            changement_Salaire.Show();
        }
    }
}