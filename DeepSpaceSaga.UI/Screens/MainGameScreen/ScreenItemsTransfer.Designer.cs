﻿namespace DeepSpaceSaga.UI.Screens.MainGameScreen
{
    partial class ScreenItemsTransfer
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(ScreenItemsTransfer));
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            pictureBox4 = new PictureBox();
            crlNameSourceCelestialObject = new Label();
            crlNameTargetCelestialObject = new Label();
            crlSourceCargoContainerCapacity = new Label();
            pictureBox1 = new PictureBox();
            crlNameSourceCargoContainer = new Label();
            pictureBox11 = new PictureBox();
            pictureBox12 = new PictureBox();
            pictureBox10 = new PictureBox();
            pictureBox9 = new PictureBox();
            cargoContainerTarget = new CargoContainer();
            cargoContainerSource = new CargoContainer();
            commandCloseScreen = new Button();
            ((ISupportInitialize)pictureBox2).BeginInit();
            ((ISupportInitialize)pictureBox3).BeginInit();
            ((ISupportInitialize)pictureBox4).BeginInit();
            ((ISupportInitialize)pictureBox1).BeginInit();
            ((ISupportInitialize)pictureBox11).BeginInit();
            ((ISupportInitialize)pictureBox12).BeginInit();
            ((ISupportInitialize)pictureBox10).BeginInit();
            ((ISupportInitialize)pictureBox9).BeginInit();
            SuspendLayout();
            // 
            // pictureBox2
            // 
            pictureBox2.BorderStyle = BorderStyle.FixedSingle;
            pictureBox2.Location = new Point(580, 348);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(64, 64);
            pictureBox2.TabIndex = 3;
            pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.BorderStyle = BorderStyle.FixedSingle;
            pictureBox3.Location = new Point(42, 54);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(90, 90);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 4;
            pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.BorderStyle = BorderStyle.FixedSingle;
            pictureBox4.Location = new Point(1090, 54);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(90, 90);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 5;
            pictureBox4.TabStop = false;
            // 
            // crlNameSourceCelestialObject
            // 
            crlNameSourceCelestialObject.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            crlNameSourceCelestialObject.ForeColor = Color.WhiteSmoke;
            crlNameSourceCelestialObject.Location = new Point(138, 54);
            crlNameSourceCelestialObject.Name = "crlNameSourceCelestialObject";
            crlNameSourceCelestialObject.Size = new Size(404, 29);
            crlNameSourceCelestialObject.TabIndex = 6;
            crlNameSourceCelestialObject.Text = "Source Container Name";
            // 
            // crlNameTargetCelestialObject
            // 
            crlNameTargetCelestialObject.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            crlNameTargetCelestialObject.ForeColor = Color.WhiteSmoke;
            crlNameTargetCelestialObject.Location = new Point(680, 54);
            crlNameTargetCelestialObject.Name = "crlNameTargetCelestialObject";
            crlNameTargetCelestialObject.Size = new Size(404, 29);
            crlNameTargetCelestialObject.TabIndex = 7;
            crlNameTargetCelestialObject.Text = "Target Container Name";
            crlNameTargetCelestialObject.TextAlign = ContentAlignment.TopRight;
            // 
            // crlSourceCargoContainerCapacity
            // 
            crlSourceCargoContainerCapacity.Font = new Font("Verdana", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            crlSourceCargoContainerCapacity.ForeColor = Color.WhiteSmoke;
            crlSourceCargoContainerCapacity.Location = new Point(680, 115);
            crlSourceCargoContainerCapacity.Name = "crlSourceCargoContainerCapacity";
            crlSourceCargoContainerCapacity.Size = new Size(404, 29);
            crlSourceCargoContainerCapacity.TabIndex = 8;
            crlSourceCargoContainerCapacity.Text = "Capacity ( Free/Full )";
            crlSourceCargoContainerCapacity.TextAlign = ContentAlignment.TopRight;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Top;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1230, 38);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // crlNameSourceCargoContainer
            // 
            crlNameSourceCargoContainer.Font = new Font("Verdana", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            crlNameSourceCargoContainer.ForeColor = Color.WhiteSmoke;
            crlNameSourceCargoContainer.Location = new Point(680, 83);
            crlNameSourceCargoContainer.Name = "crlNameSourceCargoContainer";
            crlNameSourceCargoContainer.Size = new Size(404, 29);
            crlNameSourceCargoContainer.TabIndex = 8;
            crlNameSourceCargoContainer.Text = "Capacity ( Free/Full )";
            crlNameSourceCargoContainer.TextAlign = ContentAlignment.TopRight;
            // 
            // pictureBox11
            // 
            pictureBox11.BorderStyle = BorderStyle.FixedSingle;
            pictureBox11.Location = new Point(1142, 592);
            pictureBox11.Name = "pictureBox11";
            pictureBox11.Size = new Size(36, 31);
            pictureBox11.TabIndex = 14;
            pictureBox11.TabStop = false;
            // 
            // pictureBox12
            // 
            pictureBox12.BorderStyle = BorderStyle.FixedSingle;
            pictureBox12.Location = new Point(1142, 156);
            pictureBox12.Name = "pictureBox12";
            pictureBox12.Size = new Size(36, 31);
            pictureBox12.TabIndex = 13;
            pictureBox12.TabStop = false;
            // 
            // pictureBox10
            // 
            pictureBox10.BorderStyle = BorderStyle.FixedSingle;
            pictureBox10.Location = new Point(1142, 214);
            pictureBox10.Name = "pictureBox10";
            pictureBox10.Size = new Size(36, 379);
            pictureBox10.TabIndex = 15;
            pictureBox10.TabStop = false;
            // 
            // pictureBox9
            // 
            pictureBox9.BackColor = Color.DimGray;
            pictureBox9.BorderStyle = BorderStyle.FixedSingle;
            pictureBox9.Location = new Point(1142, 191);
            pictureBox9.Name = "pictureBox9";
            pictureBox9.Size = new Size(36, 31);
            pictureBox9.TabIndex = 16;
            pictureBox9.TabStop = false;
            // 
            // cargoContainerTarget
            // 
            cargoContainerTarget.BackColor = Color.Black;
            cargoContainerTarget.BorderStyle = BorderStyle.FixedSingle;
            cargoContainerTarget.Location = new Point(777, 150);
            cargoContainerTarget.Name = "cargoContainerTarget";
            cargoContainerTarget.Size = new Size(403, 476);
            cargoContainerTarget.TabIndex = 17;
            // 
            // cargoContainerSource
            // 
            cargoContainerSource.BackColor = Color.Black;
            cargoContainerSource.BorderStyle = BorderStyle.FixedSingle;
            cargoContainerSource.Location = new Point(42, 156);
            cargoContainerSource.Name = "cargoContainerSource";
            cargoContainerSource.Size = new Size(403, 476);
            cargoContainerSource.TabIndex = 18;
            // 
            // commandCloseScreen
            // 
            commandCloseScreen.Location = new Point(547, 603);
            commandCloseScreen.Name = "commandCloseScreen";
            commandCloseScreen.Size = new Size(136, 29);
            commandCloseScreen.TabIndex = 19;
            commandCloseScreen.Text = "button1";
            commandCloseScreen.UseVisualStyleBackColor = true;
            commandCloseScreen.Click += Event_CloseScreenAndSendCommands;
            // 
            // ScreenItemsTransfer
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(commandCloseScreen);
            Controls.Add(cargoContainerSource);
            Controls.Add(pictureBox9);
            Controls.Add(pictureBox10);
            Controls.Add(pictureBox12);
            Controls.Add(crlNameSourceCargoContainer);
            Controls.Add(pictureBox11);
            Controls.Add(crlSourceCargoContainerCapacity);
            Controls.Add(crlNameTargetCelestialObject);
            Controls.Add(crlNameSourceCelestialObject);
            Controls.Add(pictureBox4);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(cargoContainerTarget);
            Name = "ScreenItemsTransfer";
            Size = new Size(1230, 716);
            ((ISupportInitialize)pictureBox2).EndInit();
            ((ISupportInitialize)pictureBox3).EndInit();
            ((ISupportInitialize)pictureBox4).EndInit();
            ((ISupportInitialize)pictureBox1).EndInit();
            ((ISupportInitialize)pictureBox11).EndInit();
            ((ISupportInitialize)pictureBox12).EndInit();
            ((ISupportInitialize)pictureBox10).EndInit();
            ((ISupportInitialize)pictureBox9).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
        private Label crlNameSourceCelestialObject;
        private Label crlNameTargetCelestialObject;
        private Label crlSourceCargoContainerCapacity;
        private PictureBox pictureBox1;
        private Label crlNameSourceCargoContainer;
        private PictureBox pictureBox11;
        private PictureBox pictureBox12;
        private PictureBox pictureBox10;
        private PictureBox pictureBox9;
        private CargoContainer cargoContainerTarget;
        private CargoContainer cargoContainerSource;
        private Button commandCloseScreen;
    }
}
