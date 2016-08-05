using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Bas
{
    public partial class View_1 : View // Form
    {
        public View_1()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            object obj = (DataSet)dal.com_Get1();
            obj = null;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
              object obj = (DataSet)dal.com_Get2();
              obj = null;
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {

        }

        protected override void Query()
        {

        }

    }
}
