﻿namespace DeepSpaceSaga.UI.Screens.MainGameScreen
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
            label1 = new Label();
            txtTurn = new Label();
            crlGameCoordinates = new Label();
            crlScreenCoordinates = new Label();
            label7 = new Label();
            label6 = new Label();
            pictureBox1 = new PictureBox();
            txtCelestialObjects = new Label();
            label5 = new Label();
            txtSpeed = new Label();
            label4 = new Label();
            ((ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.ForeColor = Color.White;
            label1.Location = new Point(14, 53);
            label1.Name = "label1";
            label1.Size = new Size(158, 20);
            label1.TabIndex = 0;
            label1.Text = "Turn....................................";
            // 
            // txtTurn
            // 
            txtTurn.ForeColor = Color.White;
            txtTurn.Location = new Point(178, 53);
            txtTurn.Name = "txtTurn";
            txtTurn.Size = new Size(43, 20);
            txtTurn.TabIndex = 1;
            txtTurn.Text = "0";
            // 
            // crlGameCoordinates
            // 
            crlGameCoordinates.ForeColor = Color.White;
            crlGameCoordinates.Location = new Point(105, 154);
            crlGameCoordinates.Name = "crlGameCoordinates";
            crlGameCoordinates.Size = new Size(104, 20);
            crlGameCoordinates.TabIndex = 13;
            crlGameCoordinates.Text = "10000:10000";
            crlGameCoordinates.TextAlign = ContentAlignment.TopCenter;
            // 
            // crlScreenCoordinates
            // 
            crlScreenCoordinates.ForeColor = Color.White;
            crlScreenCoordinates.Location = new Point(105, 134);
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
            label7.Location = new Point(19, 154);
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
            label6.Location = new Point(19, 134);
            label6.Name = "label6";
            label6.Size = new Size(74, 20);
            label6.TabIndex = 10;
            label6.Text = "XY Screen";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.FromArgb(64, 64, 64);
            pictureBox1.Location = new Point(14, 125);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(230, 1);
            pictureBox1.TabIndex = 9;
            pictureBox1.TabStop = false;
            // 
            // txtCelestialObjects
            // 
            txtCelestialObjects.ForeColor = Color.White;
            txtCelestialObjects.Location = new Point(178, 93);
            txtCelestialObjects.Name = "txtCelestialObjects";
            txtCelestialObjects.Size = new Size(94, 20);
            txtCelestialObjects.TabIndex = 8;
            txtCelestialObjects.Text = "0";
            // 
            // label5
            // 
            label5.ForeColor = Color.White;
            label5.Location = new Point(14, 93);
            label5.Name = "label5";
            label5.Size = new Size(158, 20);
            label5.TabIndex = 7;
            label5.Text = "Celestial objects..........";
            // 
            // txtSpeed
            // 
            txtSpeed.ForeColor = Color.White;
            txtSpeed.Location = new Point(178, 73);
            txtSpeed.Name = "txtSpeed";
            txtSpeed.Size = new Size(87, 20);
            txtSpeed.TabIndex = 6;
            txtSpeed.Text = "0";
            // 
            // label4
            // 
            label4.ForeColor = Color.White;
            label4.Location = new Point(14, 73);
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
            Controls.Add(txtSpeed);
            Controls.Add(crlGameCoordinates);
            Controls.Add(label4);
            Controls.Add(crlScreenCoordinates);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            Controls.Add(txtCelestialObjects);
            Controls.Add(txtTurn);
            Controls.Add(label5);
            Name = "GameSessionInformation";
            Size = new Size(257, 191);
            Controls.SetChildIndex(label5, 0);
            Controls.SetChildIndex(txtTurn, 0);
            Controls.SetChildIndex(txtCelestialObjects, 0);
            Controls.SetChildIndex(label1, 0);
            Controls.SetChildIndex(pictureBox1, 0);
            Controls.SetChildIndex(label6, 0);
            Controls.SetChildIndex(label7, 0);
            Controls.SetChildIndex(crlScreenCoordinates, 0);
            Controls.SetChildIndex(label4, 0);
            Controls.SetChildIndex(crlGameCoordinates, 0);
            Controls.SetChildIndex(txtSpeed, 0);
            ((ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Label txtTurn;
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
