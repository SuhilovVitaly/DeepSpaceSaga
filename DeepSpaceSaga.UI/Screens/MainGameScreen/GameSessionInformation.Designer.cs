namespace DeepSpaceSaga.UI.Screens.MainGameScreen
{
    partial class GameSessionInformation
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
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            txtTurn = new Label();
            cmdExitGame = new Button();
            cmdPauseResume = new Button();
            panel2 = new Panel();
            crlGameCoordinates = new Label();
            crlScreenCoordinates = new Label();
            label7 = new Label();
            label6 = new Label();
            pictureBox1 = new PictureBox();
            txtCelestialObjects = new Label();
            label5 = new Label();
            txtSpeed = new Label();
            label4 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Black;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(218, 34);
            panel1.TabIndex = 2;
            // 
            // label3
            // 
            label3.Cursor = Cursors.Hand;
            label3.ForeColor = Color.White;
            label3.Location = new Point(258, 5);
            label3.Name = "label3";
            label3.Size = new Size(13, 21);
            label3.TabIndex = 6;
            label3.Text = "x";
            // 
            // label2
            // 
            label2.ForeColor = Color.DarkGray;
            label2.Location = new Point(3, 5);
            label2.Name = "label2";
            label2.Size = new Size(189, 20);
            label2.TabIndex = 5;
            label2.Text = "Information";
            // 
            // label1
            // 
            label1.ForeColor = Color.White;
            label1.Location = new Point(14, 51);
            label1.Name = "label1";
            label1.Size = new Size(158, 20);
            label1.TabIndex = 0;
            label1.Text = "Turn....................................";
            // 
            // txtTurn
            // 
            txtTurn.ForeColor = Color.White;
            txtTurn.Location = new Point(178, 51);
            txtTurn.Name = "txtTurn";
            txtTurn.Size = new Size(43, 20);
            txtTurn.TabIndex = 1;
            txtTurn.Text = "0";
            // 
            // cmdExitGame
            // 
            cmdExitGame.BackColor = Color.FromArgb(29, 29, 29);
            cmdExitGame.Cursor = Cursors.Hand;
            cmdExitGame.FlatAppearance.BorderColor = Color.FromArgb(43, 43, 43);
            cmdExitGame.FlatAppearance.MouseOverBackColor = Color.FromArgb(47, 47, 47);
            cmdExitGame.FlatStyle = FlatStyle.Flat;
            cmdExitGame.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            cmdExitGame.ForeColor = Color.FromArgb(161, 161, 161);
            cmdExitGame.Location = new Point(686, 363);
            cmdExitGame.Margin = new Padding(3, 4, 3, 4);
            cmdExitGame.Name = "cmdExitGame";
            cmdExitGame.Size = new Size(122, 31);
            cmdExitGame.TabIndex = 4;
            cmdExitGame.Text = "Exit game";
            cmdExitGame.UseVisualStyleBackColor = false;
            // 
            // cmdPauseResume
            // 
            cmdPauseResume.BackColor = Color.FromArgb(29, 29, 29);
            cmdPauseResume.Cursor = Cursors.Hand;
            cmdPauseResume.FlatAppearance.BorderColor = Color.FromArgb(43, 43, 43);
            cmdPauseResume.FlatAppearance.MouseOverBackColor = Color.FromArgb(47, 47, 47);
            cmdPauseResume.FlatStyle = FlatStyle.Flat;
            cmdPauseResume.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            cmdPauseResume.ForeColor = Color.FromArgb(161, 161, 161);
            cmdPauseResume.Location = new Point(557, 363);
            cmdPauseResume.Margin = new Padding(3, 4, 3, 4);
            cmdPauseResume.Name = "cmdPauseResume";
            cmdPauseResume.Size = new Size(122, 31);
            cmdPauseResume.TabIndex = 3;
            cmdPauseResume.Text = "Pause";
            cmdPauseResume.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(crlGameCoordinates);
            panel2.Controls.Add(crlScreenCoordinates);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(pictureBox1);
            panel2.Controls.Add(txtCelestialObjects);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(txtSpeed);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(panel1);
            panel2.Controls.Add(cmdExitGame);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(cmdPauseResume);
            panel2.Controls.Add(txtTurn);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 0);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(220, 207);
            panel2.TabIndex = 6;
            // 
            // crlGameCoordinates
            // 
            crlGameCoordinates.ForeColor = Color.White;
            crlGameCoordinates.Location = new Point(105, 152);
            crlGameCoordinates.Name = "crlGameCoordinates";
            crlGameCoordinates.Size = new Size(104, 20);
            crlGameCoordinates.TabIndex = 13;
            crlGameCoordinates.Text = "10000:10000";
            crlGameCoordinates.TextAlign = ContentAlignment.TopCenter;
            // 
            // crlScreenCoordinates
            // 
            crlScreenCoordinates.ForeColor = Color.White;
            crlScreenCoordinates.Location = new Point(105, 132);
            crlScreenCoordinates.Name = "crlScreenCoordinates";
            crlScreenCoordinates.Size = new Size(104, 20);
            crlScreenCoordinates.TabIndex = 12;
            crlScreenCoordinates.Text = "10000:10000";
            crlScreenCoordinates.TextAlign = ContentAlignment.TopCenter;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.ForeColor = Color.White;
            label7.Location = new Point(19, 152);
            label7.Name = "label7";
            label7.Size = new Size(69, 20);
            label7.TabIndex = 11;
            label7.Text = "XY Game";
            label7.TextAlign = ContentAlignment.TopRight;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ForeColor = Color.White;
            label6.Location = new Point(19, 132);
            label6.Name = "label6";
            label6.Size = new Size(74, 20);
            label6.TabIndex = 10;
            label6.Text = "XY Screen";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.FromArgb(64, 64, 64);
            pictureBox1.Location = new Point(14, 123);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(230, 1);
            pictureBox1.TabIndex = 9;
            pictureBox1.TabStop = false;
            // 
            // txtCelestialObjects
            // 
            txtCelestialObjects.ForeColor = Color.White;
            txtCelestialObjects.Location = new Point(178, 91);
            txtCelestialObjects.Name = "txtCelestialObjects";
            txtCelestialObjects.Size = new Size(94, 20);
            txtCelestialObjects.TabIndex = 8;
            txtCelestialObjects.Text = "0";
            // 
            // label5
            // 
            label5.ForeColor = Color.White;
            label5.Location = new Point(14, 91);
            label5.Name = "label5";
            label5.Size = new Size(158, 20);
            label5.TabIndex = 7;
            label5.Text = "Celestial objects..........";
            // 
            // txtSpeed
            // 
            txtSpeed.ForeColor = Color.White;
            txtSpeed.Location = new Point(178, 71);
            txtSpeed.Name = "txtSpeed";
            txtSpeed.Size = new Size(87, 20);
            txtSpeed.TabIndex = 6;
            txtSpeed.Text = "0";
            // 
            // label4
            // 
            label4.ForeColor = Color.White;
            label4.Location = new Point(14, 71);
            label4.Name = "label4";
            label4.Size = new Size(158, 20);
            label4.TabIndex = 5;
            label4.Text = "Speed................................";
            // 
            // GameSessionInformation
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(12, 12, 12);
            Controls.Add(panel2);
            Name = "GameSessionInformation";
            Size = new Size(220, 207);
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label txtTurn;
        private Button cmdExitGame;
        private Button cmdPauseResume;
        private Panel panel2;
        private Label txtCelestialObjects;
        private Label label5;
        private Label txtSpeed;
        private Label label4;
        private Label crlGameCoordinates;
        private Label crlScreenCoordinates;
        private Label label7;
        private Label label6;
        private PictureBox pictureBox1;
    }
}
