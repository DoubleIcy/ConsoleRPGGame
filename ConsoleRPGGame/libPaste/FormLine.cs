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
    public partial class FormLine : Form
    {
        public FormLine()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = richTextBox1.Text;


            string[] sArray = Regex.Split(str, "\n", RegexOptions.IgnoreCase);
            StringBuilder sb = new StringBuilder();
            for (int x = 0; x < sArray.Length; x++)
            {
                if (!sArray[x].Contains(textFrom.Text))
                {
                    sb.Append(sArray[x]);
                    sb.Append("\n");
                    continue;
                }

                int left;
                if (string.IsNullOrEmpty(tLeft.Text))
                    left = 0;
                else
                    left = sArray[x].IndexOf(tLeft.Text);

                left = left == -1 ? 0 : left;

                int right=sArray[x].IndexOf(tRight.Text);


                string s1 = sArray[x].Substring(0,left);
                string s2;
                if (right == -1)
                    s2 = sArray[x].Substring( left );
                else
                    s2 = sArray[x].Substring( left, right - left);

                string s3;
                if(right==-1)
                    s3 = null;
                else 
                    s3=sArray[x].Substring(right);


                sArray[x] = s1 + s2.Replace(textFrom.Text, textTo.Text) + s3;
                sb.Append(sArray[x]);
                sb.Append("\n");
            }

            richTextBox1.Text = sb.ToString();
        }
    }
}
