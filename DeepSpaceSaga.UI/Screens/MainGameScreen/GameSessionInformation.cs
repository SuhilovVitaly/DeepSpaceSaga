namespace DeepSpaceSaga.UI.Screens.MainGameScreen;

public partial class GameSessionInformation : UserControl
{
    private bool isDragging = false;
    private Point dragStartPoint;
    private bool isResizing = false;
    private Point resizeStartPoint;
    private Size originalSize;

    private enum ResizeDirection
    {
        None,
        Top,
        TopRight,
        Right,
        BottomRight,
        Bottom,
        BottomLeft,
        Left,
        TopLeft
    }

    private ResizeDirection currentResizeDirection = ResizeDirection.None;
    private const int RESIZE_BORDER = 5; // Ширина области для изменения размера

    public GameSessionInformation()
    {
        InitializeComponent();

        this.MinimumSize = new Size(100, 100);
        this.MaximumSize = new Size(2000, 2000);

        this.ResizeRedraw = true;
        this.SetStyle(ControlStyles.ResizeRedraw, true);
        this.SetStyle(ControlStyles.FixedWidth, false);
        this.SetStyle(ControlStyles.FixedHeight, false);

        if (Global.GameManager is null) return;

        Global.GameManager.EventController.OnRefreshData += Worker_RefreshData;
        Global.GameManager.EventController.OnTacticalMapMouseMove += CrlTacticalMap_OnMouseMove;

        // Добавляем обработчики для panel1
        panel1.MouseDown += Panel1_MouseDown;
        panel1.MouseMove += Panel1_MouseMove;
        panel1.MouseUp += Panel1_MouseUp;

        label2.MouseDown += Panel1_MouseDown;
        label2.MouseMove += Panel1_MouseMove;
        label2.MouseUp += Panel1_MouseUp;

        // Отключаем Dock для panel2
        panel2.Dock = DockStyle.None;
        // Устанавливаем отступы от краев
        panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        panel2.SetBounds(
            RESIZE_BORDER,           // Left
            RESIZE_BORDER,           // Top
            Width - RESIZE_BORDER * 2,  // Width
            Height - RESIZE_BORDER * 2  // Height
        );

        this.MouseDown += GameSessionInformation_MouseDown;
        this.MouseMove += GameSessionInformation_MouseMove;
        this.MouseUp += GameSessionInformation_MouseUp;

        // Добавляем дополнительные стили для корректной перерисовки
        this.SetStyle(ControlStyles.ResizeRedraw, true);
        this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        this.SetStyle(ControlStyles.UserPaint, true);
        this.SetStyle(ControlStyles.DoubleBuffer, true);
        this.UpdateStyles();

        // Добавляем обработку фона
        this.BackColor = Color.FromArgb(64, 64, 64); // или любой другой цвет
        panel2.BackColor = Color.FromArgb(64, 64, 64);
    }

    private void Worker_RefreshData(GameSession session)
    {
        //CrossThreadExtensions.PerformSafely(this, RereshControls, session);
    }

    private void RereshControls(GameSession session)
    {
        txtTurn.Text = session.TurnTick + "";
        txtSpeed.Text = session.State.IsPaused ? "Pause" : session.State.Speed + "";
        txtCelestialObjects.Text = session.SpaceMap.Count() + "";
    }

    private void CrlTacticalMap_OnMouseMove(SpaceMapPoint e)
    {
        var screenCoordinates = UiTools.ToScreenCoordinates(Global.ScreenData, e);
        crlGameCoordinates.Text = $"{(int)e.X} : {(int)e.Y}";
        crlScreenCoordinates.Text = $"{(int)screenCoordinates.X} : {(int)screenCoordinates.Y}";
    }

    private void Panel1_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            isDragging = true;
            dragStartPoint = e.Location;
            panel1.Capture = true;
        }
    }

    private void Panel1_MouseMove(object sender, MouseEventArgs e)
    {
        if (isDragging)
        {
            Point newLocation = this.Location;
            newLocation.X += e.X - dragStartPoint.X;
            newLocation.Y += e.Y - dragStartPoint.Y;
            this.Location = newLocation;
        }
    }

    private void Panel1_MouseUp(object sender, MouseEventArgs e)
    {
        isDragging = false;
        panel1.Capture = false;
    }

    private void GameSessionInformation_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left && currentResizeDirection != ResizeDirection.None)
        {
            isResizing = true;
            resizeStartPoint = this.PointToScreen(e.Location);
            originalSize = this.Size;
        }
    }

    private void GameSessionInformation_MouseMove(object sender, MouseEventArgs e)
    {
        if (isResizing)
        {
            // Сразу меняем размер при движении мыши
            Point currentPoint = this.PointToScreen(e.Location);
            int deltaX = currentPoint.X - resizeStartPoint.X;
            int deltaY = currentPoint.Y - resizeStartPoint.Y;
            
            Size newSize = this.Size;
            Point newLocation = this.Location;

            switch (currentResizeDirection)
            {
                case ResizeDirection.TopLeft:
                    newSize.Width = originalSize.Width - deltaX;
                    newSize.Height = originalSize.Height - deltaY;
                    newLocation.X = this.Left + deltaX;
                    newLocation.Y = this.Top + deltaY;
                    break;
                case ResizeDirection.Top:
                    newSize.Height = originalSize.Height - deltaY;
                    newLocation.Y = this.Top + deltaY;
                    break;
                case ResizeDirection.TopRight:
                    newSize.Width = originalSize.Width + deltaX;
                    newSize.Height = originalSize.Height - deltaY;
                    newLocation.Y = this.Top + deltaY;
                    break;
                case ResizeDirection.Right:
                    newSize.Width = originalSize.Width + deltaX;
                    break;
                case ResizeDirection.BottomRight:
                    newSize.Width = originalSize.Width + deltaX;
                    newSize.Height = originalSize.Height + deltaY;
                    break;
                case ResizeDirection.Bottom:
                    newSize.Height = originalSize.Height + deltaY;
                    break;
                case ResizeDirection.BottomLeft:
                    newSize.Width = originalSize.Width - deltaX;
                    newSize.Height = originalSize.Height + deltaY;
                    newLocation.X = this.Left + deltaX;
                    break;
                case ResizeDirection.Left:
                    newSize.Width = originalSize.Width - deltaX;
                    newLocation.X = this.Left + deltaX;
                    break;
            }

            // Проверяем минимальные размеры
            if (newSize.Width >= MinimumSize.Width && newSize.Height >= MinimumSize.Height)
            {
                this.SuspendLayout();
                this.Location = newLocation;
                this.Size = newSize;
                
                // Обновляем panel2
                if (panel2 != null)
                {
                    panel2.SetBounds(
                        RESIZE_BORDER,
                        RESIZE_BORDER,
                        this.Width - RESIZE_BORDER * 2,
                        this.Height - RESIZE_BORDER * 2
                    );
                }
                
                this.ResumeLayout(true);
                this.Invalidate();
                
                // Обновляем начальную точку для следующего изменения
                resizeStartPoint = currentPoint;
                originalSize = newSize;
            }
        }
        else
        {
            UpdateResizeDirection(e.Location);
        }
    }

    private void UpdateResizeDirection(Point mousePosition)
    {
        bool left = mousePosition.X <= RESIZE_BORDER;
        bool right = mousePosition.X >= ClientRectangle.Width - RESIZE_BORDER;
        bool top = mousePosition.Y <= RESIZE_BORDER;
        bool bottom = mousePosition.Y >= ClientRectangle.Height - RESIZE_BORDER;

        currentResizeDirection = ResizeDirection.None;
        
        if (top && left) { currentResizeDirection = ResizeDirection.TopLeft; this.Cursor = Cursors.SizeNWSE; }
        else if (top && right) { currentResizeDirection = ResizeDirection.TopRight; this.Cursor = Cursors.SizeNESW; }
        else if (bottom && left) { currentResizeDirection = ResizeDirection.BottomLeft; this.Cursor = Cursors.SizeNESW; }
        else if (bottom && right) { currentResizeDirection = ResizeDirection.BottomRight; this.Cursor = Cursors.SizeNWSE; }
        else if (left) { currentResizeDirection = ResizeDirection.Left; this.Cursor = Cursors.SizeWE; }
        else if (right) { currentResizeDirection = ResizeDirection.Right; this.Cursor = Cursors.SizeWE; }
        else if (top) { currentResizeDirection = ResizeDirection.Top; this.Cursor = Cursors.SizeNS; }
        else if (bottom) { currentResizeDirection = ResizeDirection.Bottom; this.Cursor = Cursors.SizeNS; }
        else { this.Cursor = Cursors.Default; }
    }

    private void GameSessionInformation_MouseUp(object sender, MouseEventArgs e)
    {
        isResizing = false;
        this.Cursor = Cursors.Default;
    }

    protected override void WndProc(ref Message m)
    {
        const int WM_NCHITTEST = 0x0084;
        const int HTLEFT = 10;
        const int HTRIGHT = 11;
        const int HTTOP = 12;
        const int HTTOPLEFT = 13;
        const int HTTOPRIGHT = 14;
        const int HTBOTTOM = 15;
        const int HTBOTTOMLEFT = 16;
        const int HTBOTTOMRIGHT = 17;

        if (m.Msg == WM_NCHITTEST)
        {
            Point pos = new Point(m.LParam.ToInt32() & 0xFFFF, m.LParam.ToInt32() >> 16);
            pos = this.PointToClient(pos);

            if (pos.X <= RESIZE_BORDER && pos.Y <= RESIZE_BORDER)
                m.Result = (IntPtr)HTTOPLEFT;
            else if (pos.X >= ClientSize.Width - RESIZE_BORDER && pos.Y <= RESIZE_BORDER)
                m.Result = (IntPtr)HTTOPRIGHT;
            else if (pos.X <= RESIZE_BORDER && pos.Y >= ClientSize.Height - RESIZE_BORDER)
                m.Result = (IntPtr)HTBOTTOMLEFT;
            else if (pos.X >= ClientSize.Width - RESIZE_BORDER && pos.Y >= ClientSize.Height - RESIZE_BORDER)
                m.Result = (IntPtr)HTBOTTOMRIGHT;
            else if (pos.X <= RESIZE_BORDER)
                m.Result = (IntPtr)HTLEFT;
            else if (pos.X >= ClientSize.Width - RESIZE_BORDER)
                m.Result = (IntPtr)HTRIGHT;
            else if (pos.Y <= RESIZE_BORDER)
                m.Result = (IntPtr)HTTOP;
            else if (pos.Y >= ClientSize.Height - RESIZE_BORDER)
                m.Result = (IntPtr)HTBOTTOM;
            else
                base.WndProc(ref m);
            return;
        }
        base.WndProc(ref m);
    }

    // Добавьте обработку изменения размера контрола
    protected override void OnSizeChanged(EventArgs e)
    {
        base.OnSizeChanged(e);
        if (panel2 != null)
        {
            panel2.SuspendLayout();
            panel2.SetBounds(
                RESIZE_BORDER,
                RESIZE_BORDER,
                Width - RESIZE_BORDER * 2,
                Height - RESIZE_BORDER * 2
            );
            panel2.ResumeLayout(true);
        }
        this.Invalidate();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        
        // Добавляем отрисовку рамки
        //using (Pen pen = new Pen(Color.Gray, 1))
        //{
        //    e.Graphics.DrawRectangle(pen, 0, 0, Width - 1, Height - 1);
        //}
    }
}
