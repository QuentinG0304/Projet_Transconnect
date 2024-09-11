namespace Quentin_Guignard_Transconnect
{
    partial class Garage
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
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            panel1.Location = new Point(40, 43);
            panel1.Name = "panel1";
            panel1.Size = new Size(722, 556);
            panel1.TabIndex = 0;
            // 
            // Garage
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 633);
            Controls.Add(panel1);
            Name = "Garage";
            Text = "Garage";
            Load += Garage_Load;
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
    }
}