namespace DeepSpaceSaga.UI.Screens.LoadGame
{
    partial class LoadGameScreen
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
            crlExitScreen = new Button();
            SuspendLayout();
            // 
            // crlExitScreen
            // 
            crlExitScreen.BackColor = Color.FromArgb(18, 18, 18);
            crlExitScreen.Cursor = Cursors.Hand;
            crlExitScreen.FlatAppearance.BorderColor = Color.FromArgb(42, 42, 42);
            crlExitScreen.FlatAppearance.MouseDownBackColor = Color.FromArgb(78, 78, 78);
            crlExitScreen.FlatAppearance.MouseOverBackColor = Color.FromArgb(58, 58, 58);
            crlExitScreen.FlatStyle = FlatStyle.Flat;
            crlExitScreen.Font = new Font("Verdana", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            crlExitScreen.ForeColor = Color.Gainsboro;
            crlExitScreen.Location = new Point(325, 538);
            crlExitScreen.Name = "crlExitScreen";
            crlExitScreen.Size = new Size(150, 46);
            crlExitScreen.TabIndex = 2;
            crlExitScreen.Text = "EXIT";
            crlExitScreen.UseVisualStyleBackColor = false;
            crlExitScreen.Click += Event_CloseScreen;
            // 
            // LoadGameScreen
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(800, 619);
            Controls.Add(crlExitScreen);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "LoadGameScreen";
            Text = "LoadGameScreen";
            ResumeLayout(false);
        }

        #endregion

        private Button crlExitScreen;
    }
}