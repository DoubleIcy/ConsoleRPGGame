namespace libPaste
{
    partial class FormLine
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textFrom = new System.Windows.Forms.TextBox();
            this.textTo = new System.Windows.Forms.TextBox();
            this.tLeft = new System.Windows.Forms.TextBox();
            this.tRight = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(26, 89);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(477, 201);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(391, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textFrom
            // 
            this.textFrom.Location = new System.Drawing.Point(26, 39);
            this.textFrom.Name = "textFrom";
            this.textFrom.Size = new System.Drawing.Size(217, 21);
            this.textFrom.TabIndex = 3;
            // 
            // textTo
            // 
            this.textTo.Location = new System.Drawing.Point(249, 39);
            this.textTo.Name = "textTo";
            this.textTo.Size = new System.Drawing.Size(217, 21);
            this.textTo.TabIndex = 3;
            // 
            // tLeft
            // 
            this.tLeft.Location = new System.Drawing.Point(26, 12);
            this.tLeft.Name = "tLeft";
            this.tLeft.Size = new System.Drawing.Size(100, 21);
            this.tLeft.TabIndex = 2;
            // 
            // tRight
            // 
            this.tRight.Location = new System.Drawing.Point(143, 12);
            this.tRight.Name = "tRight";
            this.tRight.Size = new System.Drawing.Size(100, 21);
            this.tRight.TabIndex = 4;
            // 
            // FormLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 302);
            this.Controls.Add(this.tRight);
            this.Controls.Add(this.textTo);
            this.Controls.Add(this.textFrom);
            this.Controls.Add(this.tLeft);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.richTextBox1);
            this.Name = "FormLine";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textFrom;
        private System.Windows.Forms.TextBox textTo;
        private System.Windows.Forms.TextBox tLeft;
        private System.Windows.Forms.TextBox tRight;
    }
}

