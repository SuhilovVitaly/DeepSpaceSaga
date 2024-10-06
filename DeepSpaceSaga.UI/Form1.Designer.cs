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
            CrlZoomOut = new Button();
            CrlZoomIn = new Button();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
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
            panel1.Controls.Add(CrlZoomOut);
            panel1.Controls.Add(CrlZoomIn);
            panel1.Controls.Add(button4);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(crlLabelTurns);
            panel1.Controls.Add(crlRunButton);
            panel1.Controls.Add(crlTacticalMap);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1317, 636);
            panel1.TabIndex = 1;
            // 
            // CrlZoomOut
            // 
            CrlZoomOut.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CrlZoomOut.Location = new Point(57, 11);
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
            CrlZoomIn.Location = new Point(11, 11);
            CrlZoomIn.Name = "CrlZoomIn";
            CrlZoomIn.Size = new Size(40, 39);
            CrlZoomIn.TabIndex = 8;
            CrlZoomIn.Text = "+";
            CrlZoomIn.UseVisualStyleBackColor = true;
            CrlZoomIn.Click += CrlZoomIn_Click;
            // 
            // button4
            // 
            button4.Location = new Point(11, 595);
            button4.Name = "button4";
            button4.Size = new Size(94, 29);
            button4.TabIndex = 7;
            button4.Text = " X + 1000";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.Location = new Point(111, 560);
            button3.Name = "button3";
            button3.Size = new Size(94, 29);
            button3.TabIndex = 6;
            button3.Text = " Y + 100";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Location = new Point(11, 560);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 5;
            button2.Text = " X + 100";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
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
        private Button button3;
        private Button button2;
        private Button button4;
        private Button CrlZoomIn;
        private Button CrlZoomOut;
    }
}
