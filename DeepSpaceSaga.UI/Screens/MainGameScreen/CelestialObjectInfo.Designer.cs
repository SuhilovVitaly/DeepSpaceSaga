﻿namespace DeepSpaceSaga.UI.Screens.MainGameScreen
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
            // CelestialObjectInfo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            Controls.Add(crlCelestialObjectName);
            Name = "CelestialObjectInfo";
            Size = new Size(239, 223);
            ResumeLayout(false);
        }

        #endregion

        private Label crlCelestialObjectName;
    }
}
