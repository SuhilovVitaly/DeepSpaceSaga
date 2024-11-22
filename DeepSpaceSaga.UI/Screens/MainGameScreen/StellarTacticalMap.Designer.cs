namespace DeepSpaceSaga.UI.Screens.MainGameScreen
{
    partial class StellarTacticalMap
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
            imageTacticalMap = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)imageTacticalMap).BeginInit();
            SuspendLayout();
            // 
            // imageTacticalMap
            // 
            imageTacticalMap.BackColor = Color.FromArgb(15, 15, 15);
            imageTacticalMap.Dock = DockStyle.Fill;
            imageTacticalMap.Location = new Point(0, 0);
            imageTacticalMap.Name = "imageTacticalMap";
            imageTacticalMap.Size = new Size(522, 462);
            imageTacticalMap.TabIndex = 0;
            imageTacticalMap.TabStop = false;
            imageTacticalMap.MouseMove += imageTacticalMap_MouseMove;
            // 
            // StellarTacticalMap
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DimGray;
            Controls.Add(imageTacticalMap);
            DoubleBuffered = true;
            Name = "StellarTacticalMap";
            Size = new Size(522, 462);
            ((System.ComponentModel.ISupportInitialize)imageTacticalMap).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox imageTacticalMap;
    }
}
