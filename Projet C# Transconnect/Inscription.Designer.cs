namespace Quentin_Guignard_Transconnect
{
    partial class Inscription
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            textBox6 = new TextBox();
            button1 = new Button();
            label7 = new Label();
            textBox7 = new TextBox();
            button2 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(109, 23);
            label1.Name = "label1";
            label1.Size = new Size(52, 25);
            label1.TabIndex = 0;
            label1.Text = "Nom";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(109, 139);
            label2.Name = "label2";
            label2.Size = new Size(74, 25);
            label2.TabIndex = 1;
            label2.Text = "Prénom";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(109, 256);
            label3.Name = "label3";
            label3.Size = new Size(75, 25);
            label3.TabIndex = 2;
            label3.Text = "Adresse";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(109, 368);
            label4.Name = "label4";
            label4.Size = new Size(45, 25);
            label4.TabIndex = 3;
            label4.Text = "Mail";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(523, 23);
            label5.Name = "label5";
            label5.Size = new Size(92, 25);
            label5.TabIndex = 4;
            label5.Text = "Telephone";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(523, 139);
            label6.Name = "label6";
            label6.Size = new Size(259, 25);
            label6.TabIndex = 5;
            label6.Text = "Date de naissance (jj/mm/aaaa)";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(109, 51);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(259, 31);
            textBox1.TabIndex = 6;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(109, 167);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(259, 31);
            textBox2.TabIndex = 7;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(109, 284);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(259, 31);
            textBox3.TabIndex = 8;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(109, 396);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(259, 31);
            textBox4.TabIndex = 9;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(523, 51);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(259, 31);
            textBox5.TabIndex = 10;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(523, 167);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(259, 31);
            textBox6.TabIndex = 11;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(523, 381);
            button1.Name = "button1";
            button1.Size = new Size(112, 46);
            button1.TabIndex = 12;
            button1.Text = "Valider";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(523, 256);
            label7.Name = "label7";
            label7.Size = new Size(129, 25);
            label7.TabIndex = 13;
            label7.Text = "Mot de passe :";
            // 
            // textBox7
            // 
            textBox7.Location = new Point(523, 284);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(259, 31);
            textBox7.TabIndex = 14;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(781, 526);
            button2.Name = "button2";
            button2.Size = new Size(112, 34);
            button2.TabIndex = 15;
            button2.Text = "Annuler";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Inscription
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(905, 560);
            Controls.Add(button2);
            Controls.Add(textBox7);
            Controls.Add(label7);
            Controls.Add(button1);
            Controls.Add(textBox6);
            Controls.Add(textBox5);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Inscription";
            Text = "Inscription";
            Load += Inscription_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private TextBox textBox6;
        private Button button1;
        private Label label7;
        private TextBox textBox7;
        private Button button2;
    }
}