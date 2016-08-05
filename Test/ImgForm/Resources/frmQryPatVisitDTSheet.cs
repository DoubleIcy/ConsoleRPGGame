using System;
using System.Data; 
using System.Windows.Forms;
using System.Drawing;

namespace ImgForm
{
    public partial class frmQryPatVisitDTSheet : Form
    {  

        Bitmap bmp = null;

        public frmQryPatVisitDTSheet()
        {
            InitializeComponent();
        }

        private void frmQryPatVisitDTSheet_Load(object sender, EventArgs e)
        {
            bmp = new Bitmap(@"r:\1.jpg");
            pictureBox1.Image = bmp; 
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form1 a = new Form1();
            Image i = bmp; 
        }
         
    }
}