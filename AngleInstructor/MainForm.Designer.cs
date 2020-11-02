using System;

namespace AngleInstructor
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.drawingCanvas = new System.Windows.Forms.Panel();
            this.InstructionText = new System.Windows.Forms.TextBox();
            this.AngleDropDown = new System.Windows.Forms.ComboBox();
            this.AngleLabel = new System.Windows.Forms.Label();
            this.SpeedTrackBar = new System.Windows.Forms.TrackBar();
            this.SpeedLabel = new System.Windows.Forms.Label();
            this.DrawButton = new System.Windows.Forms.Button();
            this.RunFrame = new System.Windows.Forms.Timer(this.components);
            this.HelpButton = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.SpeedTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HelpButton)).BeginInit();
            this.SuspendLayout();
            // 
            // drawingCanvas
            // 
            this.drawingCanvas.BackColor = System.Drawing.SystemColors.Window;
            this.drawingCanvas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.drawingCanvas.Location = new System.Drawing.Point(8, 55);
            this.drawingCanvas.Name = "drawingCanvas";
            this.drawingCanvas.Size = new System.Drawing.Size(600, 400);
            this.drawingCanvas.TabIndex = 0;
            this.drawingCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.drawingCanvas_Paint);
            // 
            // InstructionText
            // 
            this.InstructionText.BackColor = System.Drawing.SystemColors.Window;
            this.InstructionText.Location = new System.Drawing.Point(616, 55);
            this.InstructionText.Multiline = true;
            this.InstructionText.Name = "InstructionText";
            this.InstructionText.ReadOnly = true;
            this.InstructionText.Size = new System.Drawing.Size(260, 400);
            this.InstructionText.TabIndex = 1;
            // 
            // AngleDropDown
            // 
            this.AngleDropDown.FormattingEnabled = true;
            this.AngleDropDown.Location = new System.Drawing.Point(82, 17);
            this.AngleDropDown.Name = "AngleDropDown";
            this.AngleDropDown.Size = new System.Drawing.Size(60, 21);
            this.AngleDropDown.TabIndex = 2;
            // 
            // AngleLabel
            // 
            this.AngleLabel.AutoSize = true;
            this.AngleLabel.Location = new System.Drawing.Point(8, 20);
            this.AngleLabel.Name = "AngleLabel";
            this.AngleLabel.Size = new System.Drawing.Size(70, 13);
            this.AngleLabel.TabIndex = 3;
            this.AngleLabel.Text = "Select Angle:";
            // 
            // SpeedTrackBar
            // 
            this.SpeedTrackBar.LargeChange = 1;
            this.SpeedTrackBar.Location = new System.Drawing.Point(259, 12);
            this.SpeedTrackBar.Maximum = 2;
            this.SpeedTrackBar.Name = "SpeedTrackBar";
            this.SpeedTrackBar.Size = new System.Drawing.Size(141, 45);
            this.SpeedTrackBar.TabIndex = 4;
            this.SpeedTrackBar.Value = 1;
            // 
            // SpeedLabel
            // 
            this.SpeedLabel.AutoSize = true;
            this.SpeedLabel.Location = new System.Drawing.Point(179, 20);
            this.SpeedLabel.Name = "SpeedLabel";
            this.SpeedLabel.Size = new System.Drawing.Size(74, 13);
            this.SpeedLabel.TabIndex = 5;
            this.SpeedLabel.Text = "Select Speed:";
            // 
            // DrawButton
            // 
            this.DrawButton.BackColor = System.Drawing.Color.Transparent;
            this.DrawButton.Location = new System.Drawing.Point(412, 20);
            this.DrawButton.Name = "DrawButton";
            this.DrawButton.Size = new System.Drawing.Size(104, 22);
            this.DrawButton.TabIndex = 6;
            this.DrawButton.Text = "Instruct Me!";
            this.DrawButton.UseVisualStyleBackColor = false;
            this.DrawButton.Click += new System.EventHandler(this.DrawButton_Click);
            // 
            // RunFrame
            // 
            this.RunFrame.Interval = 150;
            this.RunFrame.Tick += new System.EventHandler(this.RunFrame_Tick);
            // 
            // HelpButton
            // 
            this.HelpButton.BackColor = System.Drawing.Color.Transparent;
            this.HelpButton.Image = ((System.Drawing.Image)(resources.GetObject("HelpButton.Image")));
            this.HelpButton.Location = new System.Drawing.Point(830, 3);
            this.HelpButton.Name = "HelpButton";
            this.HelpButton.Size = new System.Drawing.Size(42, 39);
            this.HelpButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.HelpButton.TabIndex = 7;
            this.HelpButton.TabStop = false;
            this.HelpButton.Click += new EventHandler(MainForm_HelpRequested);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 461);
            this.Controls.Add(this.HelpButton);
            this.Controls.Add(this.DrawButton);
            this.Controls.Add(this.SpeedLabel);
            this.Controls.Add(this.drawingCanvas);
            this.Controls.Add(this.SpeedTrackBar);
            this.Controls.Add(this.AngleLabel);
            this.Controls.Add(this.AngleDropDown);
            this.Controls.Add(this.InstructionText);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "Angles Instructor";
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.MainForm_HelpRequested);
            ((System.ComponentModel.ISupportInitialize)(this.SpeedTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HelpButton)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel drawingCanvas;
        private System.Windows.Forms.TextBox InstructionText;
        private System.Windows.Forms.ComboBox AngleDropDown;
        private System.Windows.Forms.Label AngleLabel;
        private System.Windows.Forms.TrackBar SpeedTrackBar;
        private System.Windows.Forms.Label SpeedLabel;
        private System.Windows.Forms.Button DrawButton;
        private System.Windows.Forms.Timer RunFrame;
        private System.Windows.Forms.PictureBox HelpButton;

    }
}

