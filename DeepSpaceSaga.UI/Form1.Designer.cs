namespace DeepSpaceSaga.UI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            crlLabelTurns = new Label();
            panel1 = new Panel();
            panel3 = new Panel();
            spacecraftTelemetryControl1 = new Screens.MainGameScreen.SpacecraftTelemetryControl();
            panel2 = new Panel();
            crlMousePosition = new Label();
            crlGamePause = new Button();
            crlResumeGame = new Button();
            CrlZoomOut = new Button();
            CrlZoomIn = new Button();
            crlTacticalMap = new Screens.MainGameScreen.StellarTacticalMap();
            logbookControl1 = new Screens.MainGameScreen.LogbookControl();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Cursor = Cursors.Hand;
            button1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(3, 3);
            button1.Name = "button1";
            button1.Size = new Size(28, 29);
            button1.TabIndex = 0;
            button1.Text = "X";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // crlLabelTurns
            // 
            crlLabelTurns.AutoSize = true;
            crlLabelTurns.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            crlLabelTurns.ForeColor = Color.WhiteSmoke;
            crlLabelTurns.Location = new Point(15, 64);
            crlLabelTurns.Name = "crlLabelTurns";
            crlLabelTurns.Size = new Size(51, 20);
            crlLabelTurns.TabIndex = 3;
            crlLabelTurns.Text = "label1";
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(spacecraftTelemetryControl1);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(CrlZoomOut);
            panel1.Controls.Add(CrlZoomIn);
            panel1.Controls.Add(crlTacticalMap);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1317, 636);
            panel1.TabIndex = 1;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel3.Controls.Add(logbookControl1);
            panel3.Location = new Point(1003, 283);
            panel3.Name = "panel3";
            panel3.Size = new Size(301, 177);
            panel3.TabIndex = 13;
            // 
            // spacecraftTelemetryControl1
            // 
            spacecraftTelemetryControl1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            spacecraftTelemetryControl1.Location = new Point(1002, 11);
            spacecraftTelemetryControl1.Name = "spacecraftTelemetryControl1";
            spacecraftTelemetryControl1.Size = new Size(302, 260);
            spacecraftTelemetryControl1.TabIndex = 12;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            panel2.Controls.Add(crlMousePosition);
            panel2.Controls.Add(crlGamePause);
            panel2.Controls.Add(crlResumeGame);
            panel2.Controls.Add(crlLabelTurns);
            panel2.Location = new Point(11, 309);
            panel2.Name = "panel2";
            panel2.Size = new Size(250, 314);
            panel2.TabIndex = 11;
            // 
            // crlMousePosition
            // 
            crlMousePosition.AutoSize = true;
            crlMousePosition.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            crlMousePosition.ForeColor = Color.WhiteSmoke;
            crlMousePosition.Location = new Point(15, 13);
            crlMousePosition.Name = "crlMousePosition";
            crlMousePosition.Size = new Size(51, 20);
            crlMousePosition.TabIndex = 11;
            crlMousePosition.Text = "label1";
            // 
            // crlGamePause
            // 
            crlGamePause.Location = new Point(139, 138);
            crlGamePause.Name = "crlGamePause";
            crlGamePause.Size = new Size(94, 29);
            crlGamePause.TabIndex = 10;
            crlGamePause.Text = "Pause";
            crlGamePause.UseVisualStyleBackColor = true;
            crlGamePause.Click += crlGamePause_Click;
            // 
            // crlResumeGame
            // 
            crlResumeGame.Location = new Point(15, 138);
            crlResumeGame.Name = "crlResumeGame";
            crlResumeGame.Size = new Size(94, 29);
            crlResumeGame.TabIndex = 10;
            crlResumeGame.Text = "Resume";
            crlResumeGame.UseVisualStyleBackColor = true;
            crlResumeGame.Click += crlResumeGame_Click;
            // 
            // CrlZoomOut
            // 
            CrlZoomOut.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CrlZoomOut.Location = new Point(57, 251);
            CrlZoomOut.Name = "CrlZoomOut";
            CrlZoomOut.Size = new Size(40, 39);
            CrlZoomOut.TabIndex = 9;
            CrlZoomOut.Text = "-";
            CrlZoomOut.UseVisualStyleBackColor = true;
            CrlZoomOut.Click += CrlZoomOut_Click;
            // 
            // CrlZoomIn
            // 
            CrlZoomIn.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CrlZoomIn.Location = new Point(11, 251);
            CrlZoomIn.Name = "CrlZoomIn";
            CrlZoomIn.Size = new Size(40, 39);
            CrlZoomIn.TabIndex = 8;
            CrlZoomIn.Text = "+";
            CrlZoomIn.UseVisualStyleBackColor = true;
            CrlZoomIn.Click += CrlZoomIn_Click;
            // 
            // crlTacticalMap
            // 
            crlTacticalMap.BackColor = Color.DimGray;
            crlTacticalMap.Location = new Point(382, 22);
            crlTacticalMap.Name = "crlTacticalMap";
            crlTacticalMap.Size = new Size(652, 578);
            crlTacticalMap.TabIndex = 4;
            // 
            // logbookControl1
            // 
            logbookControl1.BackColor = Color.Black;
            logbookControl1.Dock = DockStyle.Fill;
            logbookControl1.Location = new Point(0, 0);
            logbookControl1.Name = "logbookControl1";
            logbookControl1.Size = new Size(301, 177);
            logbookControl1.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(1317, 636);
            Controls.Add(panel1);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            WindowState = FormWindowState.Maximized;
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Label crlLabelTurns;
        private Panel panel1;
        private Screens.MainGameScreen.StellarTacticalMap crlTacticalMap;
        private Button CrlZoomIn;
        private Button CrlZoomOut;
        private Button crlGamePause;
        private Button crlResumeGame;
        private Panel panel2;
        private Label crlMousePosition;
        private Screens.MainGameScreen.SpacecraftTelemetryControl spacecraftTelemetryControl1;
        private Panel panel3;
        private Screens.MainGameScreen.LogbookControl logbookControl1;
    }
}
