namespace DeepSpaceSaga.UI.Screens.MainGameScreen
{
    partial class CommandsControl
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
            commandSyncSpeedWithTarget = new Button();
            button2 = new Button();
            crlFullSpeed = new Button();
            button4 = new Button();
            commandSyncDirectionWithTarget = new Button();
            button6 = new Button();
            button7 = new Button();
            button8 = new Button();
            crlFullStop = new Button();
            button10 = new Button();
            commandRotateToTarget = new Button();
            commandHarvestAsteroid = new Button();
            commandOpenContainer = new Button();
            button14 = new Button();
            SuspendLayout();
            // 
            // commandSyncSpeedWithTarget
            // 
            commandSyncSpeedWithTarget.BackColor = Color.FromArgb(64, 64, 64);
            commandSyncSpeedWithTarget.Enabled = false;
            commandSyncSpeedWithTarget.FlatAppearance.BorderSize = 0;
            commandSyncSpeedWithTarget.FlatAppearance.MouseDownBackColor = Color.Gray;
            commandSyncSpeedWithTarget.FlatAppearance.MouseOverBackColor = Color.Silver;
            commandSyncSpeedWithTarget.FlatStyle = FlatStyle.Flat;
            commandSyncSpeedWithTarget.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            commandSyncSpeedWithTarget.ForeColor = Color.DimGray;
            commandSyncSpeedWithTarget.Location = new Point(219, 3);
            commandSyncSpeedWithTarget.Name = "commandSyncSpeedWithTarget";
            commandSyncSpeedWithTarget.Size = new Size(66, 51);
            commandSyncSpeedWithTarget.TabIndex = 0;
            commandSyncSpeedWithTarget.TabStop = false;
            commandSyncSpeedWithTarget.Text = "SYNC V";
            commandSyncSpeedWithTarget.UseVisualStyleBackColor = false;
            commandSyncSpeedWithTarget.Click += Event_SyncSpeedWithTarget;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(64, 64, 64);
            button2.Enabled = false;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatAppearance.MouseDownBackColor = Color.Gray;
            button2.FlatAppearance.MouseOverBackColor = Color.Silver;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button2.ForeColor = Color.DimGray;
            button2.Location = new Point(147, 3);
            button2.Name = "button2";
            button2.Size = new Size(66, 51);
            button2.TabIndex = 1;
            button2.TabStop = false;
            button2.UseVisualStyleBackColor = false;
            // 
            // crlFullSpeed
            // 
            crlFullSpeed.BackColor = Color.FromArgb(64, 64, 64);
            crlFullSpeed.Cursor = Cursors.Hand;
            crlFullSpeed.FlatAppearance.BorderSize = 0;
            crlFullSpeed.FlatAppearance.MouseDownBackColor = Color.Gray;
            crlFullSpeed.FlatAppearance.MouseOverBackColor = Color.Silver;
            crlFullSpeed.FlatStyle = FlatStyle.Flat;
            crlFullSpeed.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            crlFullSpeed.ForeColor = Color.WhiteSmoke;
            crlFullSpeed.Location = new Point(75, 3);
            crlFullSpeed.Name = "crlFullSpeed";
            crlFullSpeed.Size = new Size(66, 51);
            crlFullSpeed.TabIndex = 2;
            crlFullSpeed.TabStop = false;
            crlFullSpeed.Text = "FSP";
            crlFullSpeed.UseVisualStyleBackColor = false;
            crlFullSpeed.Click += crlFullSpeed_Click;
            // 
            // button4
            // 
            button4.BackColor = Color.FromArgb(64, 64, 64);
            button4.Enabled = false;
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatAppearance.MouseDownBackColor = Color.Gray;
            button4.FlatAppearance.MouseOverBackColor = Color.Silver;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button4.ForeColor = Color.DimGray;
            button4.Location = new Point(3, 3);
            button4.Name = "button4";
            button4.Size = new Size(66, 51);
            button4.TabIndex = 3;
            button4.TabStop = false;
            button4.UseVisualStyleBackColor = false;
            // 
            // commandSyncDirectionWithTarget
            // 
            commandSyncDirectionWithTarget.BackColor = Color.FromArgb(64, 64, 64);
            commandSyncDirectionWithTarget.Enabled = false;
            commandSyncDirectionWithTarget.FlatAppearance.BorderSize = 0;
            commandSyncDirectionWithTarget.FlatAppearance.MouseDownBackColor = Color.Gray;
            commandSyncDirectionWithTarget.FlatAppearance.MouseOverBackColor = Color.Silver;
            commandSyncDirectionWithTarget.FlatStyle = FlatStyle.Flat;
            commandSyncDirectionWithTarget.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            commandSyncDirectionWithTarget.ForeColor = Color.DimGray;
            commandSyncDirectionWithTarget.Location = new Point(291, 3);
            commandSyncDirectionWithTarget.Name = "commandSyncDirectionWithTarget";
            commandSyncDirectionWithTarget.Size = new Size(66, 51);
            commandSyncDirectionWithTarget.TabIndex = 4;
            commandSyncDirectionWithTarget.TabStop = false;
            commandSyncDirectionWithTarget.Text = "SYNC D";
            commandSyncDirectionWithTarget.UseVisualStyleBackColor = false;
            commandSyncDirectionWithTarget.Click += Event_SyncDirectionWithTarget;
            // 
            // button6
            // 
            button6.BackColor = Color.FromArgb(64, 64, 64);
            button6.Enabled = false;
            button6.FlatAppearance.BorderSize = 0;
            button6.FlatAppearance.MouseDownBackColor = Color.Gray;
            button6.FlatAppearance.MouseOverBackColor = Color.Silver;
            button6.FlatStyle = FlatStyle.Flat;
            button6.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button6.ForeColor = Color.DimGray;
            button6.Location = new Point(363, 3);
            button6.Name = "button6";
            button6.Size = new Size(66, 51);
            button6.TabIndex = 5;
            button6.TabStop = false;
            button6.UseVisualStyleBackColor = false;
            // 
            // button7
            // 
            button7.BackColor = Color.FromArgb(64, 64, 64);
            button7.Enabled = false;
            button7.FlatAppearance.BorderSize = 0;
            button7.FlatAppearance.MouseDownBackColor = Color.Gray;
            button7.FlatAppearance.MouseOverBackColor = Color.Silver;
            button7.FlatStyle = FlatStyle.Flat;
            button7.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button7.ForeColor = Color.DimGray;
            button7.Location = new Point(435, 3);
            button7.Name = "button7";
            button7.Size = new Size(66, 51);
            button7.TabIndex = 6;
            button7.TabStop = false;
            button7.UseVisualStyleBackColor = false;
            // 
            // button8
            // 
            button8.BackColor = Color.FromArgb(64, 64, 64);
            button8.Enabled = false;
            button8.FlatAppearance.BorderSize = 0;
            button8.FlatAppearance.MouseDownBackColor = Color.Gray;
            button8.FlatAppearance.MouseOverBackColor = Color.Silver;
            button8.FlatStyle = FlatStyle.Flat;
            button8.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button8.ForeColor = Color.DimGray;
            button8.Location = new Point(3, 60);
            button8.Name = "button8";
            button8.Size = new Size(66, 51);
            button8.TabIndex = 7;
            button8.TabStop = false;
            button8.UseVisualStyleBackColor = false;
            // 
            // crlFullStop
            // 
            crlFullStop.BackColor = Color.FromArgb(64, 64, 64);
            crlFullStop.Cursor = Cursors.Hand;
            crlFullStop.FlatAppearance.BorderSize = 0;
            crlFullStop.FlatAppearance.MouseDownBackColor = Color.Gray;
            crlFullStop.FlatAppearance.MouseOverBackColor = Color.Silver;
            crlFullStop.FlatStyle = FlatStyle.Flat;
            crlFullStop.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            crlFullStop.ForeColor = Color.WhiteSmoke;
            crlFullStop.Location = new Point(75, 60);
            crlFullStop.Name = "crlFullStop";
            crlFullStop.Size = new Size(66, 51);
            crlFullStop.TabIndex = 8;
            crlFullStop.TabStop = false;
            crlFullStop.Text = "FST";
            crlFullStop.UseVisualStyleBackColor = false;
            crlFullStop.Click += crlFullStop_Click;
            // 
            // button10
            // 
            button10.BackColor = Color.FromArgb(64, 64, 64);
            button10.Enabled = false;
            button10.FlatAppearance.BorderSize = 0;
            button10.FlatAppearance.MouseDownBackColor = Color.Gray;
            button10.FlatAppearance.MouseOverBackColor = Color.Silver;
            button10.FlatStyle = FlatStyle.Flat;
            button10.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button10.ForeColor = Color.DimGray;
            button10.Location = new Point(147, 60);
            button10.Name = "button10";
            button10.Size = new Size(66, 51);
            button10.TabIndex = 9;
            button10.TabStop = false;
            button10.UseVisualStyleBackColor = false;
            // 
            // commandRotateToTarget
            // 
            commandRotateToTarget.BackColor = Color.FromArgb(64, 64, 64);
            commandRotateToTarget.Enabled = false;
            commandRotateToTarget.FlatAppearance.BorderSize = 0;
            commandRotateToTarget.FlatAppearance.MouseDownBackColor = Color.Gray;
            commandRotateToTarget.FlatAppearance.MouseOverBackColor = Color.Silver;
            commandRotateToTarget.FlatStyle = FlatStyle.Flat;
            commandRotateToTarget.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            commandRotateToTarget.ForeColor = Color.DimGray;
            commandRotateToTarget.Location = new Point(219, 60);
            commandRotateToTarget.Name = "commandRotateToTarget";
            commandRotateToTarget.Size = new Size(66, 51);
            commandRotateToTarget.TabIndex = 10;
            commandRotateToTarget.TabStop = false;
            commandRotateToTarget.Text = "ROTT";
            commandRotateToTarget.UseVisualStyleBackColor = false;
            commandRotateToTarget.Click += Event_RotateToTarget;
            // 
            // commandHarvestAsteroid
            // 
            commandHarvestAsteroid.BackColor = Color.FromArgb(64, 64, 64);
            commandHarvestAsteroid.Enabled = false;
            commandHarvestAsteroid.FlatAppearance.BorderSize = 0;
            commandHarvestAsteroid.FlatAppearance.MouseDownBackColor = Color.Gray;
            commandHarvestAsteroid.FlatAppearance.MouseOverBackColor = Color.Silver;
            commandHarvestAsteroid.FlatStyle = FlatStyle.Flat;
            commandHarvestAsteroid.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            commandHarvestAsteroid.ForeColor = Color.DimGray;
            commandHarvestAsteroid.Location = new Point(291, 60);
            commandHarvestAsteroid.Name = "commandHarvestAsteroid";
            commandHarvestAsteroid.Size = new Size(66, 51);
            commandHarvestAsteroid.TabIndex = 11;
            commandHarvestAsteroid.TabStop = false;
            commandHarvestAsteroid.Text = "HRVS";
            commandHarvestAsteroid.UseVisualStyleBackColor = false;
            commandHarvestAsteroid.Click += Event_HarvestAsteroid;
            // 
            // commandOpenContainer
            // 
            commandOpenContainer.BackColor = Color.FromArgb(64, 64, 64);
            commandOpenContainer.Enabled = false;
            commandOpenContainer.FlatAppearance.BorderSize = 0;
            commandOpenContainer.FlatAppearance.MouseDownBackColor = Color.Gray;
            commandOpenContainer.FlatAppearance.MouseOverBackColor = Color.Silver;
            commandOpenContainer.FlatStyle = FlatStyle.Flat;
            commandOpenContainer.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            commandOpenContainer.ForeColor = Color.DimGray;
            commandOpenContainer.Location = new Point(363, 60);
            commandOpenContainer.Name = "commandOpenContainer";
            commandOpenContainer.Size = new Size(66, 51);
            commandOpenContainer.TabIndex = 12;
            commandOpenContainer.TabStop = false;
            commandOpenContainer.Text = "OCON";
            commandOpenContainer.UseVisualStyleBackColor = false;
            commandOpenContainer.Click += Event_OpenContainer;
            // 
            // button14
            // 
            button14.BackColor = Color.Black;
            button14.Cursor = Cursors.Hand;
            button14.FlatAppearance.BorderSize = 0;
            button14.FlatAppearance.MouseDownBackColor = Color.Black;
            button14.FlatAppearance.MouseOverBackColor = Color.Black;
            button14.FlatStyle = FlatStyle.Flat;
            button14.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button14.ForeColor = Color.DimGray;
            button14.Location = new Point(435, 60);
            button14.Name = "button14";
            button14.Size = new Size(66, 51);
            button14.TabIndex = 13;
            button14.TabStop = false;
            button14.UseVisualStyleBackColor = false;
            // 
            // CommandsControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(12, 12, 12);
            Controls.Add(button14);
            Controls.Add(commandOpenContainer);
            Controls.Add(commandHarvestAsteroid);
            Controls.Add(commandRotateToTarget);
            Controls.Add(button10);
            Controls.Add(crlFullStop);
            Controls.Add(button8);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(commandSyncDirectionWithTarget);
            Controls.Add(button4);
            Controls.Add(crlFullSpeed);
            Controls.Add(button2);
            Controls.Add(commandSyncSpeedWithTarget);
            DoubleBuffered = true;
            Name = "CommandsControl";
            Size = new Size(505, 115);
            ResumeLayout(false);
        }

        #endregion

        private Button commandSyncSpeedWithTarget;
        private Button button2;
        private Button crlFullSpeed;
        private Button button4;
        private Button commandSyncDirectionWithTarget;
        private Button button6;
        private Button button7;
        private Button button8;
        private Button crlFullStop;
        private Button button10;
        private Button commandRotateToTarget;
        private Button commandHarvestAsteroid;
        private Button commandOpenContainer;
        private Button button14;
    }
}
