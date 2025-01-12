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
            button3 = new Button();
            label1 = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(18, 18, 18);
            button3.Cursor = Cursors.Hand;
            button3.FlatAppearance.BorderColor = Color.FromArgb(42, 42, 42);
            button3.FlatAppearance.MouseDownBackColor = Color.FromArgb(78, 78, 78);
            button3.FlatAppearance.MouseOverBackColor = Color.FromArgb(58, 58, 58);
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Verdana", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.ForeColor = Color.Gainsboro;
            button3.Image = Properties.Resources.save;
            button3.Location = new Point(632, 9);
            button3.Name = "button3";
            button3.Size = new Size(52, 52);
            button3.TabIndex = 6;
            button3.UseVisualStyleBackColor = false;
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
            button1.Image = Properties.Resources.trash;
            button1.Location = new Point(690, 9);
            button1.Name = "button1";
            button1.Size = new Size(52, 52);
            button1.TabIndex = 7;
            button1.UseVisualStyleBackColor = false;
            // 
            // GameLabelRow
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            Controls.Add(button1);
            Controls.Add(button3);
            Controls.Add(label1);
            DoubleBuffered = true;
            Name = "GameLabelRow";
            Size = new Size(755, 70);
            ResumeLayout(false);
        }

        #endregion

        private Button button3;
        private Label label1;
        private Button button1;
    }
}
