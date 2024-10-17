namespace WinFormsApp1
{
    partial class SolarSystemForm
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
            crlCoordinates = new Label();
            SuspendLayout();
            // 
            // crlCoordinates
            // 
            crlCoordinates.AutoSize = true;
            crlCoordinates.ForeColor = Color.WhiteSmoke;
            crlCoordinates.Location = new Point(37, 26);
            crlCoordinates.Name = "crlCoordinates";
            crlCoordinates.Size = new Size(50, 20);
            crlCoordinates.TabIndex = 0;
            crlCoordinates.Text = "label1";
            // 
            // SolarSystemForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(1800, 1050);
            Controls.Add(crlCoordinates);
            DoubleBuffered = true;
            ForeColor = Color.Black;
            Name = "SolarSystemForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SolarSystemForm";
            MouseMove += SolarSystemForm_MouseMove;
            Resize += SolarSystemForm_Resize;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label crlCoordinates;
    }
}