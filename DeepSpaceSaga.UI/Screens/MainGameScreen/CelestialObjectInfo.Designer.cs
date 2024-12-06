namespace DeepSpaceSaga.UI.Screens.MainGameScreen
{
    partial class CelestialObjectInfo
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
            crlCelestialObjectName = new Label();
            label1 = new Label();
            lblType = new Label();
            lblSize = new Label();
            label4 = new Label();
            lblSpeed = new Label();
            label6 = new Label();
            lblDirection = new Label();
            label8 = new Label();
            lblDistance = new Label();
            label10 = new Label();
            imageCelestialObject = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)imageCelestialObject).BeginInit();
            SuspendLayout();
            // 
            // crlCelestialObjectName
            // 
            crlCelestialObjectName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            crlCelestialObjectName.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            crlCelestialObjectName.ForeColor = Color.OrangeRed;
            crlCelestialObjectName.Location = new Point(3, 0);
            crlCelestialObjectName.Name = "crlCelestialObjectName";
            crlCelestialObjectName.Size = new Size(236, 25);
            crlCelestialObjectName.TabIndex = 0;
            crlCelestialObjectName.Text = "label1";
            crlCelestialObjectName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.ForeColor = Color.WhiteSmoke;
            label1.Location = new Point(3, 96);
            label1.Name = "label1";
            label1.Size = new Size(109, 25);
            label1.TabIndex = 1;
            label1.Text = "Type";
            label1.TextAlign = ContentAlignment.TopRight;
            // 
            // lblType
            // 
            lblType.ForeColor = Color.Silver;
            lblType.Location = new Point(127, 96);
            lblType.Name = "lblType";
            lblType.Size = new Size(109, 25);
            lblType.TabIndex = 2;
            lblType.Text = "Unknown";
            // 
            // lblSize
            // 
            lblSize.ForeColor = Color.Silver;
            lblSize.Location = new Point(127, 121);
            lblSize.Name = "lblSize";
            lblSize.Size = new Size(109, 25);
            lblSize.TabIndex = 4;
            lblSize.Text = "Unknown";
            // 
            // label4
            // 
            label4.ForeColor = Color.WhiteSmoke;
            label4.Location = new Point(3, 121);
            label4.Name = "label4";
            label4.Size = new Size(109, 25);
            label4.TabIndex = 3;
            label4.Text = "Size";
            label4.TextAlign = ContentAlignment.TopRight;
            // 
            // lblSpeed
            // 
            lblSpeed.ForeColor = Color.Silver;
            lblSpeed.Location = new Point(127, 146);
            lblSpeed.Name = "lblSpeed";
            lblSpeed.Size = new Size(109, 25);
            lblSpeed.TabIndex = 6;
            lblSpeed.Text = "Unknown";
            // 
            // label6
            // 
            label6.ForeColor = Color.WhiteSmoke;
            label6.Location = new Point(3, 146);
            label6.Name = "label6";
            label6.Size = new Size(109, 25);
            label6.TabIndex = 5;
            label6.Text = "Speed";
            label6.TextAlign = ContentAlignment.TopRight;
            // 
            // lblDirection
            // 
            lblDirection.ForeColor = Color.Silver;
            lblDirection.Location = new Point(127, 171);
            lblDirection.Name = "lblDirection";
            lblDirection.Size = new Size(109, 25);
            lblDirection.TabIndex = 8;
            lblDirection.Text = "Unknown";
            // 
            // label8
            // 
            label8.ForeColor = Color.WhiteSmoke;
            label8.Location = new Point(3, 171);
            label8.Name = "label8";
            label8.Size = new Size(109, 25);
            label8.TabIndex = 7;
            label8.Text = "Direction";
            label8.TextAlign = ContentAlignment.TopRight;
            // 
            // lblDistance
            // 
            lblDistance.ForeColor = Color.Silver;
            lblDistance.Location = new Point(127, 196);
            lblDistance.Name = "lblDistance";
            lblDistance.Size = new Size(109, 25);
            lblDistance.TabIndex = 10;
            lblDistance.Text = "Unknown";
            // 
            // label10
            // 
            label10.ForeColor = Color.WhiteSmoke;
            label10.Location = new Point(3, 196);
            label10.Name = "label10";
            label10.Size = new Size(109, 25);
            label10.TabIndex = 9;
            label10.Text = "Distance";
            label10.TextAlign = ContentAlignment.TopRight;
            // 
            // imageCelestialObject
            // 
            imageCelestialObject.BackColor = Color.Transparent;
            imageCelestialObject.Location = new Point(87, 29);
            imageCelestialObject.Name = "imageCelestialObject";
            imageCelestialObject.Size = new Size(63, 56);
            imageCelestialObject.SizeMode = PictureBoxSizeMode.StretchImage;
            imageCelestialObject.TabIndex = 12;
            imageCelestialObject.TabStop = false;
            // 
            // CelestialObjectInfo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(12, 12, 12);
            Controls.Add(imageCelestialObject);
            Controls.Add(lblDistance);
            Controls.Add(label10);
            Controls.Add(lblDirection);
            Controls.Add(label8);
            Controls.Add(lblSpeed);
            Controls.Add(label6);
            Controls.Add(lblSize);
            Controls.Add(label4);
            Controls.Add(lblType);
            Controls.Add(label1);
            Controls.Add(crlCelestialObjectName);
            Name = "CelestialObjectInfo";
            Size = new Size(239, 223);
            ((System.ComponentModel.ISupportInitialize)imageCelestialObject).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label crlCelestialObjectName;
        private Label label1;
        private Label lblType;
        private Label lblSize;
        private Label label4;
        private Label lblSpeed;
        private Label label6;
        private Label lblDirection;
        private Label label8;
        private Label lblDistance;
        private Label label10;
        private PictureBox imageCelestialObject;
    }
}
