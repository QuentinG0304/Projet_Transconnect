namespace Quentin_Guignard_Transconnect
{
    partial class Statut
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
            panel1 = new Panel();
            label1 = new Label();
            textBox1 = new TextBox();
            button1 = new Button();
            comboBox1 = new ComboBox();
            label2 = new Label();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Location = new Point(33, 21);
            panel1.Name = "panel1";
            panel1.Size = new Size(736, 404);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(520, 428);
            label1.Name = "label1";
            label1.Size = new Size(249, 30);
            label1.TabIndex = 1;
            label1.Text = "Rentrer le n° du client :";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(520, 461);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(150, 31);
            textBox1.TabIndex = 2;
            // 
            // button1
            // 
            button1.Location = new Point(676, 461);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 3;
            button1.Text = "Valider";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(33, 459);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(182, 33);
            comboBox1.TabIndex = 0;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(33, 433);
            label2.Name = "label2";
            label2.Size = new Size(129, 25);
            label2.TabIndex = 4;
            label2.Text = "Ordonner par :";
            // 
            // Statut
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 507);
            Controls.Add(label2);
            Controls.Add(comboBox1);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(panel1);
            Name = "Statut";
            Text = "Statut";
            Load += Statut_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private TextBox textBox1;
        private Button button1;
        private ComboBox comboBox1;
        private Label label2;
    }
}