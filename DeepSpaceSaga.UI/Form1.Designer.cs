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
            crlRunButton = new Button();
            crlLabelTurns = new Label();
            panel1 = new Panel();
            crlTacticalMap = new Screens.MainGameScreen.StellarTacticalMap();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(1211, 22);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 0;
            button1.Text = "Exit";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // crlRunButton
            // 
            crlRunButton.Location = new Point(357, 46);
            crlRunButton.Name = "crlRunButton";
            crlRunButton.Size = new Size(94, 29);
            crlRunButton.TabIndex = 2;
            crlRunButton.Text = "Run";
            crlRunButton.UseVisualStyleBackColor = true;
            crlRunButton.Click += crlRunButton_Click;
            // 
            // crlLabelTurns
            // 
            crlLabelTurns.AutoSize = true;
            crlLabelTurns.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            crlLabelTurns.ForeColor = Color.WhiteSmoke;
            crlLabelTurns.Location = new Point(175, 137);
            crlLabelTurns.Name = "crlLabelTurns";
            crlLabelTurns.Size = new Size(51, 20);
            crlLabelTurns.TabIndex = 3;
            crlLabelTurns.Text = "label1";
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(crlLabelTurns);
            panel1.Controls.Add(crlRunButton);
            panel1.Controls.Add(crlTacticalMap);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1317, 636);
            panel1.TabIndex = 1;
            // 
            // crlTacticalMap
            // 
            crlTacticalMap.BackColor = Color.DimGray;
            crlTacticalMap.Location = new Point(385, 11);
            crlTacticalMap.Name = "crlTacticalMap";
            crlTacticalMap.Size = new Size(652, 578);
            crlTacticalMap.TabIndex = 4;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(1317, 636);
            Controls.Add(button1);
            Controls.Add(panel1);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            WindowState = FormWindowState.Maximized;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Button crlRunButton;
        private Label crlLabelTurns;
        private Panel panel1;
        private Screens.MainGameScreen.StellarTacticalMap crlTacticalMap;
    }
}
