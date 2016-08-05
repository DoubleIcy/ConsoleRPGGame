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
    public partial class FormT : Form
    {

        protected string Bal = "balView", tableName = "bas_user";
        protected dll.dllView dal = new dll.dllView(); 

        public FormT()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            object obj = dal.com_Get1();
            obj = (DataSet)obj;
            obj = null;  
             obj = dal.com_Get2();
            obj = null;
        }
    }
}
