namespace Pitman.Application.Import
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblOrgPercent = new System.Windows.Forms.Label();
            this.pbOrgPercent = new System.Windows.Forms.ProgressBar();
            this.btnOrgPercent = new System.Windows.Forms.Button();
            this.lblMktIdxd = new System.Windows.Forms.Label();
            this.pbMktIdxd = new System.Windows.Forms.ProgressBar();
            this.btnMktIdxd = new System.Windows.Forms.Button();
            this.lblMktEqud = new System.Windows.Forms.Label();
            this.pbMktEqud = new System.Windows.Forms.ProgressBar();
            this.btnMktEqud = new System.Windows.Forms.Button();
            this.lblEqu = new System.Windows.Forms.Label();
            this.btnEqu = new System.Windows.Forms.Button();
            this.pbEqu = new System.Windows.Forms.ProgressBar();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblOrgPercent);
            this.groupBox1.Controls.Add(this.pbOrgPercent);
            this.groupBox1.Controls.Add(this.btnOrgPercent);
            this.groupBox1.Controls.Add(this.lblMktIdxd);
            this.groupBox1.Controls.Add(this.pbMktIdxd);
            this.groupBox1.Controls.Add(this.btnMktIdxd);
            this.groupBox1.Controls.Add(this.lblMktEqud);
            this.groupBox1.Controls.Add(this.pbMktEqud);
            this.groupBox1.Controls.Add(this.btnMktEqud);
            this.groupBox1.Controls.Add(this.lblEqu);
            this.groupBox1.Controls.Add(this.btnEqu);
            this.groupBox1.Controls.Add(this.pbEqu);
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(689, 153);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "获取股票数据";
            // 
            // lblOrgPercent
            // 
            this.lblOrgPercent.AutoSize = true;
            this.lblOrgPercent.Location = new System.Drawing.Point(624, 122);
            this.lblOrgPercent.Name = "lblOrgPercent";
            this.lblOrgPercent.Size = new System.Drawing.Size(53, 12);
            this.lblOrgPercent.TabIndex = 11;
            this.lblOrgPercent.Text = "等待下载";
            // 
            // pbOrgPercent
            // 
            this.pbOrgPercent.Location = new System.Drawing.Point(99, 117);
            this.pbOrgPercent.Name = "pbOrgPercent";
            this.pbOrgPercent.Size = new System.Drawing.Size(521, 23);
            this.pbOrgPercent.TabIndex = 10;
            // 
            // btnOrgPercent
            // 
            this.btnOrgPercent.Location = new System.Drawing.Point(6, 117);
            this.btnOrgPercent.Name = "btnOrgPercent";
            this.btnOrgPercent.Size = new System.Drawing.Size(87, 23);
            this.btnOrgPercent.TabIndex = 9;
            this.btnOrgPercent.Text = "机构参与度";
            this.btnOrgPercent.UseVisualStyleBackColor = true;
            this.btnOrgPercent.Click += new System.EventHandler(this.btnOrgPercent_Click);
            // 
            // lblMktIdxd
            // 
            this.lblMktIdxd.AutoSize = true;
            this.lblMktIdxd.Location = new System.Drawing.Point(624, 93);
            this.lblMktIdxd.Name = "lblMktIdxd";
            this.lblMktIdxd.Size = new System.Drawing.Size(53, 12);
            this.lblMktIdxd.TabIndex = 8;
            this.lblMktIdxd.Text = "等待下载";
            // 
            // pbMktIdxd
            // 
            this.pbMktIdxd.Location = new System.Drawing.Point(99, 88);
            this.pbMktIdxd.Name = "pbMktIdxd";
            this.pbMktIdxd.Size = new System.Drawing.Size(521, 23);
            this.pbMktIdxd.TabIndex = 7;
            // 
            // btnMktIdxd
            // 
            this.btnMktIdxd.Location = new System.Drawing.Point(6, 88);
            this.btnMktIdxd.Name = "btnMktIdxd";
            this.btnMktIdxd.Size = new System.Drawing.Size(87, 23);
            this.btnMktIdxd.TabIndex = 6;
            this.btnMktIdxd.Text = "指数日线行情";
            this.btnMktIdxd.UseVisualStyleBackColor = true;
            this.btnMktIdxd.Click += new System.EventHandler(this.btnMktIdxd_Click);
            // 
            // lblMktEqud
            // 
            this.lblMktEqud.AutoSize = true;
            this.lblMktEqud.Location = new System.Drawing.Point(624, 64);
            this.lblMktEqud.Name = "lblMktEqud";
            this.lblMktEqud.Size = new System.Drawing.Size(53, 12);
            this.lblMktEqud.TabIndex = 5;
            this.lblMktEqud.Text = "等待下载";
            // 
            // pbMktEqud
            // 
            this.pbMktEqud.Location = new System.Drawing.Point(99, 59);
            this.pbMktEqud.Name = "pbMktEqud";
            this.pbMktEqud.Size = new System.Drawing.Size(521, 23);
            this.pbMktEqud.TabIndex = 4;
            // 
            // btnMktEqud
            // 
            this.btnMktEqud.Location = new System.Drawing.Point(6, 59);
            this.btnMktEqud.Name = "btnMktEqud";
            this.btnMktEqud.Size = new System.Drawing.Size(87, 23);
            this.btnMktEqud.TabIndex = 3;
            this.btnMktEqud.Text = "股票日线行情";
            this.btnMktEqud.UseVisualStyleBackColor = true;
            this.btnMktEqud.Click += new System.EventHandler(this.btnMktEqud_Click);
            // 
            // lblEqu
            // 
            this.lblEqu.AutoSize = true;
            this.lblEqu.Location = new System.Drawing.Point(624, 35);
            this.lblEqu.Name = "lblEqu";
            this.lblEqu.Size = new System.Drawing.Size(53, 12);
            this.lblEqu.TabIndex = 2;
            this.lblEqu.Text = "等待下载";
            // 
            // btnEqu
            // 
            this.btnEqu.Location = new System.Drawing.Point(6, 30);
            this.btnEqu.Name = "btnEqu";
            this.btnEqu.Size = new System.Drawing.Size(87, 23);
            this.btnEqu.TabIndex = 1;
            this.btnEqu.Text = "股票基本信息";
            this.btnEqu.UseVisualStyleBackColor = true;
            this.btnEqu.Click += new System.EventHandler(this.btnEqu_Click);
            // 
            // pbEqu
            // 
            this.pbEqu.Location = new System.Drawing.Point(99, 30);
            this.pbEqu.Name = "pbEqu";
            this.pbEqu.Size = new System.Drawing.Size(521, 23);
            this.pbEqu.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 173);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblMktIdxd;
        private System.Windows.Forms.ProgressBar pbMktIdxd;
        private System.Windows.Forms.Button btnMktIdxd;
        private System.Windows.Forms.Label lblMktEqud;
        private System.Windows.Forms.ProgressBar pbMktEqud;
        private System.Windows.Forms.Button btnMktEqud;
        private System.Windows.Forms.Label lblEqu;
        private System.Windows.Forms.Button btnEqu;
        private System.Windows.Forms.ProgressBar pbEqu;
        private System.Windows.Forms.Label lblOrgPercent;
        private System.Windows.Forms.ProgressBar pbOrgPercent;
        private System.Windows.Forms.Button btnOrgPercent;

    }
}