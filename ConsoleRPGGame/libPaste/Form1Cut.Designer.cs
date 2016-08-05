namespace libPaste
{
    partial class Form1Cut
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
            this.tLeft = new System.Windows.Forms.TextBox();
            this.str1 = new System.Windows.Forms.TextBox();
            this.tRight = new System.Windows.Forms.TextBox();
            this.str2 = new System.Windows.Forms.TextBox();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(34, 73);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(477, 201);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(401, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tLeft
            // 
            this.tLeft.Location = new System.Drawing.Point(36, 9);
            this.tLeft.Name = "tLeft";
            this.tLeft.Size = new System.Drawing.Size(100, 21);
            this.tLeft.TabIndex = 2;
            // 
            // str1
            // 
            this.str1.Location = new System.Drawing.Point(36, 36);
            this.str1.Name = "str1";
            this.str1.Size = new System.Drawing.Size(217, 21);
            this.str1.TabIndex = 3;
            // 
            // tRight
            // 
            this.tRight.Location = new System.Drawing.Point(153, 9);
            this.tRight.Name = "tRight";
            this.tRight.Size = new System.Drawing.Size(100, 21);
            this.tRight.TabIndex = 4;
            // 
            // str2
            // 
            this.str2.Location = new System.Drawing.Point(259, 36);
            this.str2.Name = "str2";
            this.str2.Size = new System.Drawing.Size(217, 21);
            this.str2.TabIndex = 3;
            // 
            // textEdit1
            // 
            this.textEdit1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.textEdit1.Location = new System.Drawing.Point(-1, 279);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new System.Drawing.Size(566, 21);
            this.textEdit1.TabIndex = 5;
            this.textEdit1.EditValueChanged += new System.EventHandler(this.textEdit1_EditValueChanged);
            // 
            // Form1Cut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 302);
            this.Controls.Add(this.textEdit1);
            this.Controls.Add(this.tRight);
            this.Controls.Add(this.str2);
            this.Controls.Add(this.str1);
            this.Controls.Add(this.tLeft);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.richTextBox1);
            this.Name = "Form1Cut";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1Cut_Load);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tLeft;
        private System.Windows.Forms.TextBox str1;
        private System.Windows.Forms.TextBox tRight;
        private System.Windows.Forms.TextBox str2;
        private DevExpress.XtraEditors.TextEdit textEdit1;
    }
}

