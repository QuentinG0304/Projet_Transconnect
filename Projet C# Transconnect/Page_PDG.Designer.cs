namespace Quentin_Guignard_Transconnect
{
    partial class Page_PDG
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            salariésToolStripMenuItem = new ToolStripMenuItem();
            organigrammeToolStripMenuItem = new ToolStripMenuItem();
            recrutementToolStripMenuItem = new ToolStripMenuItem();
            CommandesToolStripMenuItem = new ToolStripMenuItem();
            statistiquesToolStripMenuItem = new ToolStripMenuItem();
            historiqueToolStripMenuItem = new ToolStripMenuItem();
            clientsToolStripMenuItem = new ToolStripMenuItem();
            statutToolStripMenuItem = new ToolStripMenuItem();
            véhiculesToolStripMenuItem = new ToolStripMenuItem();
            visualisationToolStripMenuItem = new ToolStripMenuItem();
            button1 = new Button();
            chauffeursToolStripMenuItem1 = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { salariésToolStripMenuItem, CommandesToolStripMenuItem, clientsToolStripMenuItem, véhiculesToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1188, 36);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // salariésToolStripMenuItem
            // 
            salariésToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { organigrammeToolStripMenuItem, recrutementToolStripMenuItem, chauffeursToolStripMenuItem1 });
            salariésToolStripMenuItem.Name = "salariésToolStripMenuItem";
            salariésToolStripMenuItem.Size = new Size(96, 32);
            salariésToolStripMenuItem.Text = "Salariés";
            salariésToolStripMenuItem.Click += salariésToolStripMenuItem_Click;
            // 
            // organigrammeToolStripMenuItem
            // 
            organigrammeToolStripMenuItem.Name = "organigrammeToolStripMenuItem";
            organigrammeToolStripMenuItem.Size = new Size(270, 36);
            organigrammeToolStripMenuItem.Text = "Organigramme";
            organigrammeToolStripMenuItem.Click += organigrammeToolStripMenuItem_Click;
            // 
            // recrutementToolStripMenuItem
            // 
            recrutementToolStripMenuItem.Name = "recrutementToolStripMenuItem";
            recrutementToolStripMenuItem.Size = new Size(270, 36);
            recrutementToolStripMenuItem.Text = "Gérer les salariés";
            recrutementToolStripMenuItem.Click += recrutementToolStripMenuItem_Click;
            // 
            // CommandesToolStripMenuItem
            // 
            CommandesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { statistiquesToolStripMenuItem, historiqueToolStripMenuItem });
            CommandesToolStripMenuItem.Name = "CommandesToolStripMenuItem";
            CommandesToolStripMenuItem.Size = new Size(142, 32);
            CommandesToolStripMenuItem.Text = "Commandes";
            // 
            // statistiquesToolStripMenuItem
            // 
            statistiquesToolStripMenuItem.Name = "statistiquesToolStripMenuItem";
            statistiquesToolStripMenuItem.Size = new Size(218, 36);
            statistiquesToolStripMenuItem.Text = "Statistiques";
            statistiquesToolStripMenuItem.Click += statistiquesToolStripMenuItem_Click;
            // 
            // historiqueToolStripMenuItem
            // 
            historiqueToolStripMenuItem.Name = "historiqueToolStripMenuItem";
            historiqueToolStripMenuItem.Size = new Size(218, 36);
            historiqueToolStripMenuItem.Text = "Historique";
            historiqueToolStripMenuItem.Click += historiqueToolStripMenuItem_Click;
            // 
            // clientsToolStripMenuItem
            // 
            clientsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { statutToolStripMenuItem });
            clientsToolStripMenuItem.Name = "clientsToolStripMenuItem";
            clientsToolStripMenuItem.Size = new Size(89, 32);
            clientsToolStripMenuItem.Text = "Clients";
            // 
            // statutToolStripMenuItem
            // 
            statutToolStripMenuItem.Name = "statutToolStripMenuItem";
            statutToolStripMenuItem.Size = new Size(167, 36);
            statutToolStripMenuItem.Text = "Statut";
            statutToolStripMenuItem.Click += statutToolStripMenuItem_Click;
            // 
            // véhiculesToolStripMenuItem
            // 
            véhiculesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { visualisationToolStripMenuItem });
            véhiculesToolStripMenuItem.Name = "véhiculesToolStripMenuItem";
            véhiculesToolStripMenuItem.Size = new Size(114, 32);
            véhiculesToolStripMenuItem.Text = "Véhicules";
            // 
            // visualisationToolStripMenuItem
            // 
            visualisationToolStripMenuItem.Name = "visualisationToolStripMenuItem";
            visualisationToolStripMenuItem.Size = new Size(270, 36);
            visualisationToolStripMenuItem.Text = "Garage";
            visualisationToolStripMenuItem.Click += visualisationToolStripMenuItem_Click;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(12, 542);
            button1.Name = "button1";
            button1.Size = new Size(198, 41);
            button1.TabIndex = 2;
            button1.Text = "Revenir en Arrière";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // chauffeursToolStripMenuItem1
            // 
            chauffeursToolStripMenuItem1.Name = "chauffeursToolStripMenuItem1";
            chauffeursToolStripMenuItem1.Size = new Size(270, 36);
            chauffeursToolStripMenuItem1.Text = "Chauffeurs";
            chauffeursToolStripMenuItem1.Click += chauffeursToolStripMenuItem1_Click;
            // 
            // Page_PDG
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1188, 595);
            Controls.Add(button1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Page_PDG";
            Text = "Page_PDG";
            Load += Page_PDG_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MenuStrip menuStrip1;
        private ToolStripMenuItem salariésToolStripMenuItem;
        private ToolStripMenuItem CommandesToolStripMenuItem;
        private ToolStripMenuItem clientsToolStripMenuItem;
        private ToolStripMenuItem véhiculesToolStripMenuItem;
        private ToolStripMenuItem organigrammeToolStripMenuItem;
        private ToolStripMenuItem recrutementToolStripMenuItem;
        private ToolStripMenuItem licenciementToolStripMenuItem;
        private ToolStripMenuItem statistiquesToolStripMenuItem;
        private ToolStripMenuItem historiqueToolStripMenuItem;
        private ToolStripMenuItem statutToolStripMenuItem;
        private ToolStripMenuItem visualisationToolStripMenuItem;
        private Button button1;
        private ToolStripMenuItem chauffeursToolStripMenuItem1;
    }
}