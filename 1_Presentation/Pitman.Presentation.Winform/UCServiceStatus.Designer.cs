﻿namespace Pitman.Presentation.Winform
{
    partial class UCServiceStatus
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
            this.grpBoxServices = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // grpBoxServices
            // 
            this.grpBoxServices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBoxServices.Location = new System.Drawing.Point(0, 0);
            this.grpBoxServices.Name = "grpBoxServices";
            this.grpBoxServices.Size = new System.Drawing.Size(673, 372);
            this.grpBoxServices.TabIndex = 0;
            this.grpBoxServices.TabStop = false;
            this.grpBoxServices.Text = "数据收集服务";
            // 
            // UCServiceStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpBoxServices);
            this.Name = "UCServiceStatus";
            this.Size = new System.Drawing.Size(673, 372);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBoxServices;
    }
}
