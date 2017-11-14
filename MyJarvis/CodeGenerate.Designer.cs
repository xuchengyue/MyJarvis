namespace MyJarvis
{
    partial class CodeGenerate
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
            this.DataBaseList = new System.Windows.Forms.ListBox();
            this.btnChoose = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnGo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DataBaseList
            // 
            this.DataBaseList.FormattingEnabled = true;
            this.DataBaseList.ItemHeight = 12;
            this.DataBaseList.Location = new System.Drawing.Point(239, 63);
            this.DataBaseList.Name = "DataBaseList";
            this.DataBaseList.Size = new System.Drawing.Size(400, 232);
            this.DataBaseList.TabIndex = 0;
            this.DataBaseList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.DataBaseList_MouseDoubleClick);
            // 
            // btnChoose
            // 
            this.btnChoose.Location = new System.Drawing.Point(327, 325);
            this.btnChoose.Name = "btnChoose";
            this.btnChoose.Size = new System.Drawing.Size(75, 23);
            this.btnChoose.TabIndex = 1;
            this.btnChoose.Text = "选择";
            this.btnChoose.UseVisualStyleBackColor = true;
            this.btnChoose.Click += new System.EventHandler(this.btnChoose_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(98, 37);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 2;
            this.btnBack.Text = "返回";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(463, 325);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 3;
            this.btnGo.Text = "生成";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // CodeGenerate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 445);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnChoose);
            this.Controls.Add(this.DataBaseList);
            this.Name = "CodeGenerate";
            this.Text = "CodeGenerate";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox DataBaseList;
        private System.Windows.Forms.Button btnChoose;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnGo;
    }
}

