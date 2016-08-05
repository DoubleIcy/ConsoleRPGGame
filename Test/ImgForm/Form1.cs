using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
namespace ImgForm
{
    public partial class Form1 : Form
    {
        Bitmap bmp;
        public Form1()
        {
            InitializeComponent();
            bmp = new Bitmap(@"r:\1.jpg");
            this.pictureEdit1.Properties.InitialImage = bmp;

        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {
            int x;
            if (Int32.TryParse(textEdit1.Text, out x))
                textEdit1.Width = x;
        }
    }
}
