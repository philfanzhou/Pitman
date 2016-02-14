namespace Pitman.HistoryDataTool
{
    partial class HistoryDataCollection
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnGetKLine = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGetKLine
            // 
            this.btnGetKLine.Location = new System.Drawing.Point(12, 12);
            this.btnGetKLine.Name = "btnGetKLine";
            this.btnGetKLine.Size = new System.Drawing.Size(110, 23);
            this.btnGetKLine.TabIndex = 0;
            this.btnGetKLine.Text = "获取历史日线数据";
            this.btnGetKLine.UseVisualStyleBackColor = true;
            this.btnGetKLine.Click += new System.EventHandler(this.btnGetKLine_Click);
            // 
            // HistoryDataCollection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 178);
            this.Controls.Add(this.btnGetKLine);
            this.Name = "HistoryDataCollection";
            this.Text = "历史数据获取";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGetKLine;
    }
}

