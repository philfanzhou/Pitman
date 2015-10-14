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
            this.ucServiceStatus1 = new Pitman.Presentation.Winform.UCServiceStatus();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ucServiceStatus1
            // 
            this.ucServiceStatus1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucServiceStatus1.Location = new System.Drawing.Point(0, 0);
            this.ucServiceStatus1.Name = "ucServiceStatus1";
            this.ucServiceStatus1.Size = new System.Drawing.Size(719, 359);
            this.ucServiceStatus1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(615, 382);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 427);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ucServiceStatus1);
            this.Name = "Main";
            this.Text = "PitMan";
            this.ResumeLayout(false);

        }

        #endregion

        private UCServiceStatus ucServiceStatus1;
        private System.Windows.Forms.Button button1;
    }
}

