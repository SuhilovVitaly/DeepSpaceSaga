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
            crlTacticalMap = new StellarTacticalMap();
            spacecraftTelemetryControl1 = new SpacecraftTelemetryControl();
            crlActiveCelestialObjectInfo = new CelestialObjectInfo();
            crlSelectedCelestialObjectInfo = new CelestialObjectInfo();
            button1 = new Button();
            crlCommands = new CommandsControl();
            gameSpeedControl1 = new GameSpeedControl();
            panel1 = new Panel();
            CommandOpenCargo = new Screens.CommonControls.ToolbarButton();
            gameSessionInformation2 = new GameSessionInformation();
            logbookControl2 = new LogbookControl();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // crlTacticalMap
            // 
            crlTacticalMap.BackColor = Color.DimGray;
            crlTacticalMap.Location = new Point(382, 22);
            crlTacticalMap.Name = "crlTacticalMap";
            crlTacticalMap.Size = new Size(652, 578);
            crlTacticalMap.TabIndex = 4;
            // 
            // spacecraftTelemetryControl1
            // 
            spacecraftTelemetryControl1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            spacecraftTelemetryControl1.Location = new Point(2309, 11);
            spacecraftTelemetryControl1.Name = "spacecraftTelemetryControl1";
            spacecraftTelemetryControl1.Size = new Size(302, 260);
            spacecraftTelemetryControl1.TabIndex = 12;
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
            // crlSelectedCelestialObjectInfo
            // 
            crlSelectedCelestialObjectInfo.BackColor = Color.Black;
            crlSelectedCelestialObjectInfo.BorderStyle = BorderStyle.Fixed3D;
            crlSelectedCelestialObjectInfo.Location = new Point(279, 4);
            crlSelectedCelestialObjectInfo.Name = "crlSelectedCelestialObjectInfo";
            crlSelectedCelestialObjectInfo.Size = new Size(267, 389);
            crlSelectedCelestialObjectInfo.TabIndex = 15;
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
            // crlCommands
            // 
            crlCommands.Anchor = AnchorStyles.Bottom;
            crlCommands.BackColor = Color.FromArgb(12, 12, 12);
            crlCommands.Location = new Point(1060, 977);
            crlCommands.Name = "crlCommands";
            crlCommands.Size = new Size(505, 115);
            crlCommands.TabIndex = 16;
            // 
            // gameSpeedControl1
            // 
            gameSpeedControl1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            gameSpeedControl1.BackColor = Color.FromArgb(12, 12, 12);
            gameSpeedControl1.Location = new Point(2261, 1016);
            gameSpeedControl1.Name = "gameSpeedControl1";
            gameSpeedControl1.Size = new Size(350, 76);
            gameSpeedControl1.TabIndex = 17;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(CommandOpenCargo);
            panel1.Controls.Add(gameSessionInformation2);
            panel1.Controls.Add(logbookControl2);
            panel1.Controls.Add(gameSpeedControl1);
            panel1.Controls.Add(crlCommands);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(crlSelectedCelestialObjectInfo);
            panel1.Controls.Add(crlActiveCelestialObjectInfo);
            panel1.Controls.Add(spacecraftTelemetryControl1);
            panel1.Controls.Add(crlTacticalMap);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(2624, 1105);
            panel1.TabIndex = 1;
            // 
            // CommandOpenCargo
            // 
            CommandOpenCargo.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            CommandOpenCargo.BackColor = Color.Black;
            CommandOpenCargo.BackgroundImageLayout = ImageLayout.Center;
            CommandOpenCargo.Location = new Point(279, 903);
            CommandOpenCargo.Name = "CommandOpenCargo";
            CommandOpenCargo.Size = new Size(80, 80);
            CommandOpenCargo.TabIndex = 22;
            CommandOpenCargo.Click += Event_OpenSpacecraftCargo;
            // 
            // gameSessionInformation2
            // 
            gameSessionInformation2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            gameSessionInformation2.BackColor = Color.FromArgb(12, 12, 12);
            gameSessionInformation2.BorderStyle = BorderStyle.FixedSingle;
            gameSessionInformation2.IsDraggible = true;
            gameSessionInformation2.IsResizible = true;
            gameSessionInformation2.Location = new Point(14, 903);
            gameSessionInformation2.Name = "gameSessionInformation2";
            gameSessionInformation2.Size = new Size(259, 189);
            gameSessionInformation2.TabIndex = 21;
            gameSessionInformation2.Title = "Game Session Info";
            // 
            // logbookControl2
            // 
            logbookControl2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            logbookControl2.BackColor = Color.FromArgb(20, 20, 20);
            logbookControl2.BorderStyle = BorderStyle.FixedSingle;
            logbookControl2.IsDraggible = false;
            logbookControl2.IsResizible = false;
            logbookControl2.Location = new Point(2130, 277);
            logbookControl2.Name = "logbookControl2";
            logbookControl2.Size = new Size(481, 196);
            logbookControl2.TabIndex = 20;
            logbookControl2.Title = "Logbook";
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
            ResumeLayout(false);
        }

        #endregion

        private Screens.MainGameScreen.StellarTacticalMap crlTacticalMap;
        private Screens.MainGameScreen.SpacecraftTelemetryControl spacecraftTelemetryControl1;
        private Screens.MainGameScreen.CelestialObjectInfo crlActiveCelestialObjectInfo;
        private Screens.MainGameScreen.CelestialObjectInfo crlSelectedCelestialObjectInfo;
        private Button button1;
        private Screens.MainGameScreen.CommandsControl crlCommands;
        private Screens.MainGameScreen.GameSpeedControl gameSpeedControl1;
        private Panel panel1;
        private Screens.MainGameScreen.LogbookControl logbookControl2;
        private Screens.MainGameScreen.GameSessionInformation gameSessionInformation2;
        private Screens.CommonControls.ToolbarButton CommandOpenCargo;
    }
}
