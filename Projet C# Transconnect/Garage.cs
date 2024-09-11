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
    public partial class Garage : Form
    {
        public Garage()
        {
            InitializeComponent();
            Label label = new Label();
            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=TransConnect;UID=root;PASSWORD=root;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = connection.CreateCommand();
            command.CommandText = $"SELECT * FROM Vehicule WHERE type_vehicule = 'Voiture';";
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                label.Text += reader.GetString("type_vehicule") +":  "+ reader.GetString("imma")+"\n";
            }
            reader.Close();
            command.CommandText = $"SELECT * FROM Vehicule WHERE type_vehicule = 'Camionnette';";
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                label.Text += reader.GetString("type_vehicule") + ":  " + reader.GetString("imma") + "\n";
            }
            reader.Close();
            command.CommandText = $"SELECT * FROM Vehicule WHERE type_vehicule = 'Camion Benne';";
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                label.Text += reader.GetString("type_vehicule") + ":  " + reader.GetString("imma") + "\n";
            }
            reader.Close();
            command.CommandText = $"SELECT * FROM Vehicule WHERE type_vehicule = 'Camion-Citerne';";
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                label.Text += reader.GetString("type_vehicule") + ":  " + reader.GetString("imma") + "\n";
            }
            reader.Close();
            command.CommandText = $"SELECT * FROM Vehicule WHERE type_vehicule = 'Camion Frigorifique';";
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                label.Text += reader.GetString("type_vehicule") + ":  " + reader.GetString("imma") + "\n";
            }
            reader.Close();
            label.Location = new Point(10, 10);
            label.AutoSize = true;
            panel1.Controls.Add(label);
            panel1.AutoScroll = true;
        }

        private void Garage_Load(object sender, EventArgs e)
        {

        }
    }
}
