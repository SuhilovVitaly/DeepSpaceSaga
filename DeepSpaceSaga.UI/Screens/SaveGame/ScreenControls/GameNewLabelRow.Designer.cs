namespace DeepSpaceSaga.UI.Screens.SaveGame.ScreenControls
{
    partial class GameNewLabelRow
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
            crlSaveGame = new Button();
            txtSaveName = new TextBox();
            SuspendLayout();
            // 
            // crlSaveGame
            // 
            crlSaveGame.BackColor = Color.FromArgb(18, 18, 18);
            crlSaveGame.Cursor = Cursors.Hand;
            crlSaveGame.FlatAppearance.BorderColor = Color.FromArgb(42, 42, 42);
            crlSaveGame.FlatAppearance.MouseDownBackColor = Color.FromArgb(78, 78, 78);
            crlSaveGame.FlatAppearance.MouseOverBackColor = Color.FromArgb(58, 58, 58);
            crlSaveGame.FlatStyle = FlatStyle.Flat;
            crlSaveGame.Font = new Font("Verdana", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            crlSaveGame.ForeColor = Color.Gainsboro;
            crlSaveGame.Image = Properties.Resources.save;
            crlSaveGame.Location = new Point(690, 8);
            crlSaveGame.Name = "crlSaveGame";
            crlSaveGame.Size = new Size(52, 52);
            crlSaveGame.TabIndex = 4;
            crlSaveGame.UseVisualStyleBackColor = false;
            crlSaveGame.Click += Event_SaveGame;
            // 
            // txtSaveName
            // 
            txtSaveName.BackColor = Color.Black;
            txtSaveName.Font = new Font("Verdana", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtSaveName.ForeColor = Color.WhiteSmoke;
            txtSaveName.Location = new Point(14, 15);
            txtSaveName.Name = "txtSaveName";
            txtSaveName.Size = new Size(652, 35);
            txtSaveName.TabIndex = 5;
            txtSaveName.Text = "New Save";
            // 
            // GameNewLabelRow
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            Controls.Add(txtSaveName);
            Controls.Add(crlSaveGame);
            DoubleBuffered = true;
            Name = "GameNewLabelRow";
            Size = new Size(755, 70);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button crlSaveGame;
        private TextBox txtSaveName;
    }
}
