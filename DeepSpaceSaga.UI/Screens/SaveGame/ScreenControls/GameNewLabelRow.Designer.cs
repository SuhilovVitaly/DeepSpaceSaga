namespace DeepSpaceSaga.UI.Screens.SaveGame.ScreenControls
{
    partial class GameNewLabelRow
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
            SuspendLayout();
            // 
            // label1
            // 
            label1.Font = new Font("Verdana", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.WhiteSmoke;
            label1.Location = new Point(39, 18);
            label1.Name = "label1";
            label1.Size = new Size(228, 35);
            label1.TabIndex = 0;
            label1.Text = "label1";
            // 
            // GameNewLabelRow
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            Controls.Add(label1);
            DoubleBuffered = true;
            Name = "GameNewLabelRow";
            Size = new Size(500, 70);
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
    }
}
