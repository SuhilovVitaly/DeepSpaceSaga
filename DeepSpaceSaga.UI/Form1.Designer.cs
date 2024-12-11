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
            gameSpeedControl1 = new Screens.MainGameScreen.GameSpeedControl();
            crlCommands = new Screens.MainGameScreen.CommandsControl();
            crlSelectedCelestialObjectInfo = new Screens.MainGameScreen.CelestialObjectInfo();
            crlActiveCelestialObjectInfo = new Screens.MainGameScreen.CelestialObjectInfo();
            panel3 = new Panel();
            logbookControl1 = new Screens.MainGameScreen.LogbookControl();
            spacecraftTelemetryControl1 = new Screens.MainGameScreen.SpacecraftTelemetryControl();
            panel2 = new Panel();
            crlMousePosition = new Label();
            crlTacticalMap = new Screens.MainGameScreen.StellarTacticalMap();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button1.Cursor = Cursors.Hand;
            button1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(2583, 11);
            button1.Name = "button1";
            button1.Size = new Size(28, 29);
            button1.TabIndex = 0;
            button1.TabStop = false;
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
            panel1.Controls.Add(gameSpeedControl1);
            panel1.Controls.Add(crlCommands);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(crlSelectedCelestialObjectInfo);
            panel1.Controls.Add(crlActiveCelestialObjectInfo);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(spacecraftTelemetryControl1);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(crlTacticalMap);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(2624, 1105);
            panel1.TabIndex = 1;
            // 
            // gameSpeedControl1
            // 
            gameSpeedControl1.BackColor = Color.FromArgb(12, 12, 12);
            gameSpeedControl1.Location = new Point(2261, 1016);
            gameSpeedControl1.Name = "gameSpeedControl1";
            gameSpeedControl1.Size = new Size(350, 76);
            gameSpeedControl1.TabIndex = 17;
            // 
            // crlCommands
            // 
            crlCommands.Anchor = AnchorStyles.Bottom;
            crlCommands.BackColor = Color.FromArgb(12, 12, 12);
            crlCommands.Location = new Point(1060, 977);
            crlCommands.Name = "crlCommands";
            crlCommands.Size = new Size(505, 115);
            crlCommands.TabIndex = 16;
            // 
            // crlSelectedCelestialObjectInfo
            // 
            crlSelectedCelestialObjectInfo.BackColor = Color.Black;
            crlSelectedCelestialObjectInfo.BorderStyle = BorderStyle.Fixed3D;
            crlSelectedCelestialObjectInfo.Location = new Point(279, 4);
            crlSelectedCelestialObjectInfo.Name = "crlSelectedCelestialObjectInfo";
            crlSelectedCelestialObjectInfo.Size = new Size(267, 389);
            crlSelectedCelestialObjectInfo.TabIndex = 15;
            // 
            // crlActiveCelestialObjectInfo
            // 
            crlActiveCelestialObjectInfo.BackColor = Color.Black;
            crlActiveCelestialObjectInfo.BorderStyle = BorderStyle.Fixed3D;
            crlActiveCelestialObjectInfo.Location = new Point(6, 4);
            crlActiveCelestialObjectInfo.Name = "crlActiveCelestialObjectInfo";
            crlActiveCelestialObjectInfo.Size = new Size(267, 389);
            crlActiveCelestialObjectInfo.TabIndex = 14;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel3.Controls.Add(logbookControl1);
            panel3.Location = new Point(2310, 283);
            panel3.Name = "panel3";
            panel3.Size = new Size(301, 177);
            panel3.TabIndex = 13;
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
            // spacecraftTelemetryControl1
            // 
            spacecraftTelemetryControl1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            spacecraftTelemetryControl1.Location = new Point(2309, 11);
            spacecraftTelemetryControl1.Name = "spacecraftTelemetryControl1";
            spacecraftTelemetryControl1.Size = new Size(302, 260);
            spacecraftTelemetryControl1.TabIndex = 12;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            panel2.Controls.Add(crlMousePosition);
            panel2.Controls.Add(crlLabelTurns);
            panel2.Location = new Point(11, 778);
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
            // crlTacticalMap
            // 
            crlTacticalMap.BackColor = Color.DimGray;
            crlTacticalMap.Location = new Point(382, 22);
            crlTacticalMap.Name = "crlTacticalMap";
            crlTacticalMap.Size = new Size(652, 578);
            crlTacticalMap.TabIndex = 4;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(2624, 1105);
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
        private Panel panel2;
        private Label crlMousePosition;
        private Screens.MainGameScreen.SpacecraftTelemetryControl spacecraftTelemetryControl1;
        private Panel panel3;
        private Screens.MainGameScreen.LogbookControl logbookControl1;
        private Screens.MainGameScreen.CelestialObjectInfo crlSelectedCelestialObjectInfo;
        private Screens.MainGameScreen.CelestialObjectInfo crlActiveCelestialObjectInfo;
        private Screens.MainGameScreen.CommandsControl crlCommands;
        private Screens.MainGameScreen.GameSpeedControl gameSpeedControl1;
    }
}
