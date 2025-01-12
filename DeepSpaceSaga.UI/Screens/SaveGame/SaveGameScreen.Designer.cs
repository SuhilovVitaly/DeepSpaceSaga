namespace DeepSpaceSaga.UI.Screens.SaveGame
{
    partial class SaveGameScreen
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
            gameNewLabelRow2 = new ScreenControls.GameNewLabelRow();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(18, 18, 18);
            button1.Cursor = Cursors.Hand;
            button1.FlatAppearance.BorderColor = Color.FromArgb(42, 42, 42);
            button1.FlatAppearance.MouseDownBackColor = Color.FromArgb(78, 78, 78);
            button1.FlatAppearance.MouseOverBackColor = Color.FromArgb(58, 58, 58);
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Verdana", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.Gainsboro;
            button1.Location = new Point(325, 538);
            button1.Name = "button1";
            button1.Size = new Size(150, 46);
            button1.TabIndex = 1;
            button1.Text = "EXIT";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // gameNewLabelRow2
            // 
            gameNewLabelRow2.BackColor = Color.Black;
            gameNewLabelRow2.Location = new Point(23, 421);
            gameNewLabelRow2.Name = "gameNewLabelRow2";
            gameNewLabelRow2.Size = new Size(755, 70);
            gameNewLabelRow2.TabIndex = 2;
            // 
            // SaveGameScreen
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(800, 619);
            Controls.Add(gameNewLabelRow2);
            Controls.Add(button1);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "SaveGameScreen";
            Text = "SaveGameScreen";
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private ScreenControls.GameLabelRow gameLabelRow2;
        private ScreenControls.GameNewLabelRow gameNewLabelRow1;
        private ScreenControls.GameNewLabelRow gameNewLabelRow2;
    }
}