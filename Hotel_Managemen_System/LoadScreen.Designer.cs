namespace Hotel_Managemen_System
{
    partial class LoadScreen
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.ProgressCirc = new Bunifu.UI.WinForms.BunifuCircleProgress();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.ProgressCirc);
            this.panel1.Location = new System.Drawing.Point(16, 15);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(635, 463);
            this.panel1.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label8.Location = new System.Drawing.Point(121, 27);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(368, 36);
            this.label8.TabIndex = 17;
            this.label8.Text = "Hotel Management System";
            // 
            // ProgressCirc
            // 
            this.ProgressCirc.Animated = false;
            this.ProgressCirc.AnimationInterval = 1;
            this.ProgressCirc.AnimationSpeed = 1;
            this.ProgressCirc.BackColor = System.Drawing.Color.Transparent;
            this.ProgressCirc.CircleMargin = 10;
            this.ProgressCirc.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProgressCirc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ProgressCirc.IsPercentage = false;
            this.ProgressCirc.LineProgressThickness = 10;
            this.ProgressCirc.LineThickness = 10;
            this.ProgressCirc.Location = new System.Drawing.Point(169, 95);
            this.ProgressCirc.Margin = new System.Windows.Forms.Padding(4);
            this.ProgressCirc.Name = "ProgressCirc";
            this.ProgressCirc.ProgressAnimationSpeed = 200;
            this.ProgressCirc.ProgressBackColor = System.Drawing.SystemColors.Control;
            this.ProgressCirc.ProgressColor = System.Drawing.Color.Blue;
            this.ProgressCirc.ProgressColor2 = System.Drawing.Color.Cyan;
            this.ProgressCirc.ProgressEndCap = Bunifu.UI.WinForms.BunifuCircleProgress.CapStyles.Round;
            this.ProgressCirc.ProgressFillStyle = Bunifu.UI.WinForms.BunifuCircleProgress.FillStyles.Gradient;
            this.ProgressCirc.ProgressStartCap = Bunifu.UI.WinForms.BunifuCircleProgress.CapStyles.Flat;
            this.ProgressCirc.SecondaryFont = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.ProgressCirc.Size = new System.Drawing.Size(297, 297);
            this.ProgressCirc.SubScriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.ProgressCirc.SubScriptMargin = new System.Windows.Forms.Padding(5, -20, 0, 0);
            this.ProgressCirc.SubScriptText = "";
            this.ProgressCirc.SuperScriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.ProgressCirc.SuperScriptMargin = new System.Windows.Forms.Padding(5, 20, 0, 0);
            this.ProgressCirc.SuperScriptText = "";
            this.ProgressCirc.TabIndex = 16;
            this.ProgressCirc.Text = "30";
            this.ProgressCirc.TextMargin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.ProgressCirc.Value = 30;
            this.ProgressCirc.ValueByTransition = 30;
            this.ProgressCirc.ValueMargin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // LoadScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(667, 492);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoadScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LoadScreen";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label8;
        private Bunifu.UI.WinForms.BunifuCircleProgress ProgressCirc;
        private System.Windows.Forms.Timer timer1;
    }
}