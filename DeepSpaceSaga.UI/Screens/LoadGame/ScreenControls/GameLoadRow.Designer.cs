namespace DeepSpaceSaga.UI.Screens.LoadGame.ScreenControls
{
    partial class GameLoadRow
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
            cmdDelete = new Button();
            cmdLoadGame = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // cmdDelete
            // 
            cmdDelete.BackColor = Color.FromArgb(18, 18, 18);
            cmdDelete.Cursor = Cursors.Hand;
            cmdDelete.FlatAppearance.BorderColor = Color.FromArgb(42, 42, 42);
            cmdDelete.FlatAppearance.MouseDownBackColor = Color.FromArgb(78, 78, 78);
            cmdDelete.FlatAppearance.MouseOverBackColor = Color.FromArgb(58, 58, 58);
            cmdDelete.FlatStyle = FlatStyle.Flat;
            cmdDelete.Font = new Font("Verdana", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cmdDelete.ForeColor = Color.Gainsboro;
            cmdDelete.Image = Properties.Resources.trash;
            cmdDelete.Location = new Point(689, 9);
            cmdDelete.Name = "cmdDelete";
            cmdDelete.Size = new Size(52, 52);
            cmdDelete.TabIndex = 10;
            cmdDelete.UseVisualStyleBackColor = false;
            // 
            // cmdLoadGame
            // 
            cmdLoadGame.BackColor = Color.FromArgb(18, 18, 18);
            cmdLoadGame.Cursor = Cursors.Hand;
            cmdLoadGame.FlatAppearance.BorderColor = Color.FromArgb(42, 42, 42);
            cmdLoadGame.FlatAppearance.MouseDownBackColor = Color.FromArgb(78, 78, 78);
            cmdLoadGame.FlatAppearance.MouseOverBackColor = Color.FromArgb(58, 58, 58);
            cmdLoadGame.FlatStyle = FlatStyle.Flat;
            cmdLoadGame.Font = new Font("Verdana", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cmdLoadGame.ForeColor = Color.Gainsboro;
            cmdLoadGame.Image = Properties.Resources.load;
            cmdLoadGame.Location = new Point(631, 9);
            cmdLoadGame.Name = "cmdLoadGame";
            cmdLoadGame.Size = new Size(52, 52);
            cmdLoadGame.TabIndex = 9;
            cmdLoadGame.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.Font = new Font("Verdana", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.WhiteSmoke;
            label1.Location = new Point(14, 19);
            label1.Name = "label1";
            label1.Size = new Size(440, 35);
            label1.TabIndex = 8;
            label1.Text = "New Save";
            // 
            // GameLoadRow
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            Controls.Add(cmdDelete);
            Controls.Add(cmdLoadGame);
            Controls.Add(label1);
            DoubleBuffered = true;
            Name = "GameLoadRow";
            Size = new Size(755, 70);
            ResumeLayout(false);
        }

        #endregion

        private Button cmdDelete;
        private Button cmdLoadGame;
        private Label label1;
    }
}
