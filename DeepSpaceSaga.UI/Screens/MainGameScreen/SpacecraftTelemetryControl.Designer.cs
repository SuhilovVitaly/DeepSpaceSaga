namespace DeepSpaceSaga.UI.Screens.MainGameScreen
{
    partial class SpacecraftTelemetryControl
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
            crlSpacecraftName = new Label();
            crlAgility = new Label();
            crlVelocity = new Label();
            crlDirection = new Label();
            label5 = new Label();
            label3 = new Label();
            label1 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Black;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(crlSpacecraftName);
            panel1.Controls.Add(crlAgility);
            panel1.Controls.Add(crlVelocity);
            panel1.Controls.Add(crlDirection);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(242, 137);
            panel1.TabIndex = 0;
            // 
            // crlSpacecraftName
            // 
            crlSpacecraftName.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            crlSpacecraftName.ForeColor = Color.OrangeRed;
            crlSpacecraftName.Location = new Point(9, -1);
            crlSpacecraftName.Name = "crlSpacecraftName";
            crlSpacecraftName.Size = new Size(225, 42);
            crlSpacecraftName.TabIndex = 2;
            crlSpacecraftName.Text = "No Spacecraft Name";
            crlSpacecraftName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // crlAgility
            // 
            crlAgility.ForeColor = Color.WhiteSmoke;
            crlAgility.Location = new Point(182, 95);
            crlAgility.Name = "crlAgility";
            crlAgility.Size = new Size(52, 20);
            crlAgility.TabIndex = 1;
            crlAgility.Text = "0";
            // 
            // crlVelocity
            // 
            crlVelocity.ForeColor = Color.WhiteSmoke;
            crlVelocity.Location = new Point(182, 70);
            crlVelocity.Name = "crlVelocity";
            crlVelocity.Size = new Size(52, 20);
            crlVelocity.TabIndex = 1;
            crlVelocity.Text = "0";
            // 
            // crlDirection
            // 
            crlDirection.ForeColor = Color.WhiteSmoke;
            crlDirection.Location = new Point(182, 45);
            crlDirection.Name = "crlDirection";
            crlDirection.Size = new Size(52, 20);
            crlDirection.TabIndex = 1;
            crlDirection.Text = "360";
            // 
            // label5
            // 
            label5.ForeColor = Color.WhiteSmoke;
            label5.Location = new Point(9, 95);
            label5.Name = "label5";
            label5.Size = new Size(167, 25);
            label5.TabIndex = 0;
            label5.Text = "Agility";
            // 
            // label3
            // 
            label3.ForeColor = Color.WhiteSmoke;
            label3.Location = new Point(9, 70);
            label3.Name = "label3";
            label3.Size = new Size(167, 25);
            label3.TabIndex = 0;
            label3.Text = "Velocity";
            // 
            // label1
            // 
            label1.ForeColor = Color.WhiteSmoke;
            label1.Location = new Point(9, 45);
            label1.Name = "label1";
            label1.Size = new Size(167, 25);
            label1.TabIndex = 0;
            label1.Text = "Direction";
            // 
            // SpacecraftTelemetryControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Name = "SpacecraftTelemetryControl";
            Size = new Size(242, 137);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label crlAgility;
        private Label crlVelocity;
        private Label crlDirection;
        private Label label5;
        private Label label3;
        private Label label1;
        private Label crlSpacecraftName;
    }
}
