namespace DeepSpaceSaga.UI.Screens.SaveGame.ScreenControls
{
    partial class GameLabelRow
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
            cmdOverride = new Button();
            label1 = new Label();
            cmdDelete = new Button();
            SuspendLayout();
            // 
            // cmdOverride
            // 
            cmdOverride.BackColor = Color.FromArgb(18, 18, 18);
            cmdOverride.Cursor = Cursors.Hand;
            cmdOverride.FlatAppearance.BorderColor = Color.FromArgb(42, 42, 42);
            cmdOverride.FlatAppearance.MouseDownBackColor = Color.FromArgb(78, 78, 78);
            cmdOverride.FlatAppearance.MouseOverBackColor = Color.FromArgb(58, 58, 58);
            cmdOverride.FlatStyle = FlatStyle.Flat;
            cmdOverride.Font = new Font("Verdana", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cmdOverride.ForeColor = Color.Gainsboro;
            cmdOverride.Image = Properties.Resources.save;
            cmdOverride.Location = new Point(632, 9);
            cmdOverride.Name = "cmdOverride";
            cmdOverride.Size = new Size(52, 52);
            cmdOverride.TabIndex = 6;
            cmdOverride.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.Font = new Font("Verdana", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.WhiteSmoke;
            label1.Location = new Point(15, 19);
            label1.Name = "label1";
            label1.Size = new Size(440, 35);
            label1.TabIndex = 5;
            label1.Text = "New Save";
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
            cmdDelete.Location = new Point(690, 9);
            cmdDelete.Name = "cmdDelete";
            cmdDelete.Size = new Size(52, 52);
            cmdDelete.TabIndex = 7;
            cmdDelete.UseVisualStyleBackColor = false;
            // 
            // GameLabelRow
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            Controls.Add(cmdDelete);
            Controls.Add(cmdOverride);
            Controls.Add(label1);
            DoubleBuffered = true;
            Name = "GameLabelRow";
            Size = new Size(755, 70);
            ResumeLayout(false);
        }

        #endregion

        private Button cmdOverride;
        private Label label1;
        private Button cmdDelete;
    }
}
