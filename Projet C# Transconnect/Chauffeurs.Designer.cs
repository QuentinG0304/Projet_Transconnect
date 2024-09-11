namespace Quentin_Guignard_Transconnect
{
    partial class Chauffeurs
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
            comboBox1 = new ComboBox();
            label1 = new Label();
            panel1 = new Panel();
            textBox1 = new TextBox();
            label2 = new Label();
            button1 = new Button();
            label3 = new Label();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(12, 51);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(182, 33);
            comboBox1.TabIndex = 0;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 23);
            label1.Name = "label1";
            label1.Size = new Size(188, 25);
            label1.TabIndex = 1;
            label1.Text = "Choisir un chauffeur :";
            // 
            // panel1
            // 
            panel1.Location = new Point(12, 90);
            panel1.Name = "panel1";
            panel1.Size = new Size(430, 348);
            panel1.TabIndex = 2;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(512, 406);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(138, 31);
            textBox1.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(512, 376);
            label2.Name = "label2";
            label2.Size = new Size(254, 25);
            label2.TabIndex = 3;
            label2.Text = "ID de la course pour Parcours :";
            // 
            // button1
            // 
            button1.Location = new Point(676, 404);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 4;
            button1.Text = "Valider";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(465, 90);
            label3.Name = "label3";
            label3.Size = new Size(66, 28);
            label3.TabIndex = 5;
            label3.Text = "label3";
            // 
            // Chauffeurs
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label3);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(panel1);
            Controls.Add(label1);
            Controls.Add(comboBox1);
            Name = "Chauffeurs";
            Text = "Chauffeurs";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBox1;
        private Label label1;
        private Panel panel1;
        private TextBox textBox1;
        private Label label2;
        private Button button1;
        private Label label3;
    }
}