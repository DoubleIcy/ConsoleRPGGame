using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Text.RegularExpressions;

 

namespace libPaste
{
    public partial class Form1Cut : Form
    {
        public Form1Cut()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((string.IsNullOrEmpty(tLeft.Text)) && (string.IsNullOrEmpty(tRight.Text)))
            {
                richTextBox1.Text = richTextBox1.Text.Replace(str1.Text, str2.Text);
                return;
            }

            if ((!string.IsNullOrEmpty(tLeft.Text)) && (string.IsNullOrEmpty(tRight.Text)))
            {
                tLeft.Text = tRight.Text;
                tRight.Text = null;
            }

            if ((string.IsNullOrEmpty(tLeft.Text)) && (!string.IsNullOrEmpty(tRight.Text)))
                tRight.Text = null;

            //if ((!string.IsNullOrEmpty(tLeft.Text)) && (!string.IsNullOrEmpty(tRight.Text))) 
            string str = richTextBox1.Text;
    
            string[] sArray = Regex.Split(str, tLeft.Text, RegexOptions.IgnoreCase);

            #region add head
            if (str.Substring(0, tLeft.Text.Length) == tLeft.Text)
                sArray[0] = tLeft.Text+sArray[0];
            #endregion

 
            for (int x = 0; x < sArray.Length; x++)
            {
                if (sArray[x].Contains(tRight.Text))
                {
                    sArray[x] = tLeft.Text + sArray[x];
                    int len = sArray[x].IndexOf(tRight.Text);

                    string i2 = sArray[x].Substring(len);
                    string i1 = sArray[x].Substring(0, len).Replace(str1.Text, str2.Text);
                    sArray[x] = i1 + i2;
                }
            }
            StringBuilder sb = new StringBuilder();
            for (int x = 0; x < sArray.Length; x++)
            {
                sb.Append(sArray[x]);
            }
            richTextBox1.Text = sb.ToString();

        }

        private void Form1Cut_Load(object sender, EventArgs e) { }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {
            switch (textEdit1.Text)
            {
                case "line": new FormLine().ShowDialog(); break;
                default: break;
            }
        }


    }
}
