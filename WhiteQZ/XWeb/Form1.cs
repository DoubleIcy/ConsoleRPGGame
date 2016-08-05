using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XWeb
{
    public partial class Form1 : Form
    {
        DataSet ds = new DataSet();
        public string file = @"d:\d\XWeb.dll";
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_load; 
        }

        public void Form1_load(object sender, EventArgs e)
        {
            BindTree();
        } 

        private void BindTree()
        {
            ds.ReadXml(file);
            treeList1.DataSource = ds.Tables[0];
        }
        private void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            string str = Convert.ToString(treeList1.FocusedNode.GetValue(treeListColumn2));
            
            this.memoEdit1.Text = str;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            ds.WriteXml(file);   
        }
    }
}
