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
    public partial class Inscription : Form
    {
        private string connectionString = "SERVER=localhost;PORT=3306;DATABASE=TransConnect;UID=root;PASSWORD=root;";

        public Inscription()
        {
            InitializeComponent();
        }

        private void Inscription_Load(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "")
            {
                MessageBox.Show("Veuillez remplir tous les champs");
            }
            else
            {
                //Date de naissance
                string[] date = textBox6.Text.Split('/');
                DateTime naissance = new DateTime(int.Parse(date[2]), int.Parse(date[1]), int.Parse(date[0]), 0, 0, 0);

                //ID du client
                int id_client = 1;
                MySqlCommand command = connection.CreateCommand();
                MySqlDataReader reader;
                command.CommandText = $" SELECT max(n_ss) FROM client ;";
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    id_client = reader.GetInt32(0) + 1;
                }
                reader.Close();
                Client temp = new Client(id_client, textBox2.Text, textBox1.Text, textBox3.Text, textBox5.Text, textBox4.Text, naissance, "Bronze");
                temp.Register(connection, textBox7.Text);
                Accueil form1 = new Accueil();
                this.Hide();
                form1.Show();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Accueil form1 = new Accueil();
            form1.Show();
        }
    }
}
