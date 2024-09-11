namespace Quentin_Guignard_Transconnect
{
    partial class Création_Commande
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
            button1 = new Button();
            comboBox1 = new ComboBox();
            comboBox2 = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            comboBox3 = new ComboBox();
            label4 = new Label();
            numericUpDown8 = new NumericUpDown();
            label16 = new Label();
            numericUpDown7 = new NumericUpDown();
            label15 = new Label();
            numericUpDown6 = new NumericUpDown();
            label14 = new Label();
            label5 = new Label();
            numericUpDown1 = new NumericUpDown();
            label6 = new Label();
            textBox1 = new TextBox();
            label7 = new Label();
            label8 = new Label();
            textBox2 = new TextBox();
            comboBox4 = new ComboBox();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)numericUpDown8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(701, 439);
            button1.Name = "button1";
            button1.Size = new Size(200, 34);
            button1.TabIndex = 0;
            button1.Text = "Ajouter Commande";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(177, 54);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(231, 33);
            comboBox1.TabIndex = 1;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(177, 137);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(231, 33);
            comboBox2.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(40, 54);
            label1.Name = "label1";
            label1.Size = new Size(112, 25);
            label1.TabIndex = 3;
            label1.Text = "Ville Départ :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(40, 137);
            label2.Name = "label2";
            label2.Size = new Size(108, 25);
            label2.TabIndex = 4;
            label2.Text = "Ville Arrivée:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(36, 218);
            label3.Name = "label3";
            label3.Size = new Size(178, 25);
            label3.TabIndex = 5;
            label3.Text = "Type de commande :";
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(220, 215);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(231, 33);
            comboBox3.TabIndex = 6;
            comboBox3.SelectedIndexChanged += comboBox3_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(40, 295);
            label4.Name = "label4";
            label4.Size = new Size(58, 25);
            label4.TabIndex = 7;
            label4.Text = "Date :";
            // 
            // numericUpDown8
            // 
            numericUpDown8.Location = new Point(337, 302);
            numericUpDown8.Maximum = new decimal(new int[] { 2050, 0, 0, 0 });
            numericUpDown8.Minimum = new decimal(new int[] { 2024, 0, 0, 0 });
            numericUpDown8.Name = "numericUpDown8";
            numericUpDown8.Size = new Size(99, 31);
            numericUpDown8.TabIndex = 37;
            numericUpDown8.Value = new decimal(new int[] { 2024, 0, 0, 0 });
            numericUpDown8.ValueChanged += numericUpDown8_ValueChanged;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(337, 274);
            label16.Name = "label16";
            label16.Size = new Size(71, 25);
            label16.TabIndex = 36;
            label16.Text = "Année :";
            // 
            // numericUpDown7
            // 
            numericUpDown7.Location = new Point(251, 302);
            numericUpDown7.Maximum = new decimal(new int[] { 12, 0, 0, 0 });
            numericUpDown7.Name = "numericUpDown7";
            numericUpDown7.Size = new Size(57, 31);
            numericUpDown7.TabIndex = 35;
            numericUpDown7.Value = new decimal(new int[] { DateTime.Now.Month, 0, 0, 0 });
            numericUpDown7.ValueChanged += numericUpDown7_ValueChanged;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(248, 274);
            label15.Name = "label15";
            label15.Size = new Size(60, 25);
            label15.TabIndex = 34;
            label15.Text = "Mois :";
            // 
            // numericUpDown6
            // 
            numericUpDown6.Location = new Point(155, 302);
            numericUpDown6.Maximum = new decimal(new int[] { 31, 0, 0, 0 });
            numericUpDown6.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown6.Name = "numericUpDown6";
            numericUpDown6.Size = new Size(64, 31);
            numericUpDown6.TabIndex = 33;
            numericUpDown6.Value = new decimal(new int[] { DateTime.Now.Day, 0, 0, 0 });
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(155, 274);
            label14.Name = "label14";
            label14.Size = new Size(59, 25);
            label14.TabIndex = 32;
            label14.Text = "Jour : ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(538, 57);
            label5.Name = "label5";
            label5.Size = new Size(196, 25);
            label5.TabIndex = 38;
            label5.Text = "Nombre de passagers :";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(740, 55);
            numericUpDown1.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            numericUpDown1.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(59, 31);
            numericUpDown1.TabIndex = 39;
            numericUpDown1.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(538, 82);
            label6.Name = "label6";
            label6.Size = new Size(70, 25);
            label6.TabIndex = 40;
            label6.Text = "Usage :";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(538, 110);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(363, 31);
            textBox1.TabIndex = 41;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(538, 82);
            label7.Name = "label7";
            label7.Size = new Size(188, 25);
            label7.TabIndex = 42;
            label7.Text = "Type de marchandise :";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(538, 145);
            label8.Name = "label8";
            label8.Size = new Size(104, 25);
            label8.TabIndex = 43;
            label8.Text = "Volume (L) :";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(538, 173);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(150, 31);
            textBox2.TabIndex = 44;
            // 
            // comboBox4
            // 
            comboBox4.FormattingEnabled = true;
            comboBox4.Location = new Point(538, 110);
            comboBox4.Name = "comboBox4";
            comboBox4.Size = new Size(363, 33);
            comboBox4.TabIndex = 45;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(12, 439);
            button2.Name = "button2";
            button2.Size = new Size(184, 34);
            button2.TabIndex = 46;
            button2.Text = "Revenir en Arrière";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Création_Commande
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(913, 485);
            Controls.Add(button2);
            Controls.Add(comboBox4);
            Controls.Add(textBox2);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(textBox1);
            Controls.Add(label6);
            Controls.Add(numericUpDown1);
            Controls.Add(label5);
            Controls.Add(numericUpDown8);
            Controls.Add(label16);
            Controls.Add(numericUpDown7);
            Controls.Add(label15);
            Controls.Add(numericUpDown6);
            Controls.Add(label14);
            Controls.Add(label4);
            Controls.Add(comboBox3);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(comboBox2);
            Controls.Add(comboBox1);
            Controls.Add(button1);
            Name = "Création_Commande";
            Text = "Création_Commande";
            Load += Création_Commande_Load;
            ((System.ComponentModel.ISupportInitialize)numericUpDown8).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown7).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown6).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private Label label1;
        private Label label2;
        private Label label3;
        private ComboBox comboBox3;
        private Label label4;
        private NumericUpDown numericUpDown8;
        private Label label16;
        private NumericUpDown numericUpDown7;
        private Label label15;
        private NumericUpDown numericUpDown6;
        private Label label14;
        private Label label5;
        private NumericUpDown numericUpDown1;
        private Label label6;
        private TextBox textBox1;
        private Label label7;
        private Label label8;
        private TextBox textBox2;
        private ComboBox comboBox4;
        private Button button2;
    }
}