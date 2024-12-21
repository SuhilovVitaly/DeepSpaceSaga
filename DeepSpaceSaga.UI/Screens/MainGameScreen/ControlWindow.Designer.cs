namespace DeepSpaceSaga.UI.Screens.MainGameScreen;

partial class ControlWindow
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
        crlTitleBar = new PictureBox();
        crlWindowTitle = new Label();
        crlCloseButton = new Label();
        ((System.ComponentModel.ISupportInitialize)crlTitleBar).BeginInit();
        SuspendLayout();
        // 
        // crlTitleBar
        // 
        crlTitleBar.BackColor = Color.Black;
        crlTitleBar.Dock = DockStyle.Top;
        crlTitleBar.Location = new Point(0, 0);
        crlTitleBar.Name = "crlTitleBar";
        crlTitleBar.Size = new Size(290, 38);
        crlTitleBar.TabIndex = 0;
        crlTitleBar.TabStop = false;
        // 
        // crlWindowTitle
        // 
        crlWindowTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        crlWindowTitle.BackColor = Color.Black;
        crlWindowTitle.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        crlWindowTitle.ForeColor = Color.WhiteSmoke;
        crlWindowTitle.Location = new Point(14, 8);
        crlWindowTitle.Name = "crlWindowTitle";
        crlWindowTitle.Size = new Size(259, 25);
        crlWindowTitle.TabIndex = 1;
        crlWindowTitle.Text = "Window Title";
        // 
        // crlCloseButton
        // 
        crlCloseButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        crlCloseButton.BackColor = Color.Black;
        crlCloseButton.Cursor = Cursors.Hand;
        crlCloseButton.Font = new Font("Cambria", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
        crlCloseButton.ForeColor = Color.WhiteSmoke;
        crlCloseButton.Location = new Point(265, 7);
        crlCloseButton.Name = "crlCloseButton";
        crlCloseButton.Size = new Size(19, 25);
        crlCloseButton.TabIndex = 2;
        crlCloseButton.Text = "x";
        crlCloseButton.Click += Event_CloseWindow;
        // 
        // ControlWindow
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(20, 20, 20);
        BorderStyle = BorderStyle.FixedSingle;
        Controls.Add(crlCloseButton);
        Controls.Add(crlWindowTitle);
        Controls.Add(crlTitleBar);
        Name = "ControlWindow";
        Size = new Size(290, 182);
        ((System.ComponentModel.ISupportInitialize)crlTitleBar).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private PictureBox crlTitleBar;
    private Label crlWindowTitle;
    private Label crlCloseButton;
}
