namespace DeepSpaceSaga.UI.Screens.MainGameScreen
{
    partial class SpacecraftCargo
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            SuspendLayout();
            // 
            // crlCloseButton
            // 
            crlCloseButton.Location = new Point(390, 7);
            // 
            // panel1
            // 
            panel1.BackColor = Color.Black;
            panel1.Dock = DockStyle.Bottom;
            panel1.Enabled = false;
            panel1.Location = new Point(0, 262);
            panel1.Name = "panel1";
            panel1.Size = new Size(417, 36);
            panel1.TabIndex = 3;
            // 
            // SpacecraftCargo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            DoubleBuffered = true;
            Name = "SpacecraftCargo";
            Size = new Size(417, 298);
            Title = "Spacecraft Cargo";
            Resize += SpacecraftCargo_Resize;
            Controls.SetChildIndex(crlCloseButton, 0);
            Controls.SetChildIndex(panel1, 0);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
    }
}
