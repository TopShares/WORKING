namespace ServerApp
{
    partial class Form1
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.txtRecMsgs = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtRecMsgs
            // 
            this.txtRecMsgs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRecMsgs.Location = new System.Drawing.Point(0, 0);
            this.txtRecMsgs.Multiline = true;
            this.txtRecMsgs.Name = "txtRecMsgs";
            this.txtRecMsgs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtRecMsgs.Size = new System.Drawing.Size(367, 258);
            this.txtRecMsgs.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 258);
            this.Controls.Add(this.txtRecMsgs);
            this.Name = "Form1";
            this.Text = "服务器";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtRecMsgs;
    }
}

