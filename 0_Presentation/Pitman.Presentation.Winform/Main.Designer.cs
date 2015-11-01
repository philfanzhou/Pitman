namespace Pitman.Presentation.Winform
{
    partial class Main
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
            this.ucServiceStatus = new Pitman.Presentation.Winform.UCServiceStatus();
            this.SuspendLayout();
            // 
            // ucServiceStatus
            // 
            this.ucServiceStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucServiceStatus.Location = new System.Drawing.Point(0, 0);
            this.ucServiceStatus.Name = "ucServiceStatus";
            this.ucServiceStatus.Size = new System.Drawing.Size(719, 359);
            this.ucServiceStatus.TabIndex = 0;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 427);
            this.Controls.Add(this.ucServiceStatus);
            this.Name = "Main";
            this.Text = "PitMan";
            this.ResumeLayout(false);

        }

        #endregion

        private UCServiceStatus ucServiceStatus;
    }
}

