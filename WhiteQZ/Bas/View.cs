using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DoProxy;
namespace Bas
{
    public partial class View : Form
    {
        protected string Bal = "balView", tableName = "bas_user";
        protected dll.dllView dal = new dll.dllView(); 
        public View()
        {
            InitializeComponent();
            BindEvent();
        }
        public void BindEvent()
        {
            this.Load+=PageLoad;
        }
        protected void PageLoad(object sender,EventArgs e)
        {
            Query();
        }
        protected virtual void Query()
        {
            if (!string.IsNullOrEmpty(Bal))
            {
                dsList = dal.GetData(tableName, null);
            }
            else
            {
                dsList = (DataSet)DoProxy.Pxy.DllLoad("BAL", Bal, "GetData", new object[] { }); 
            }
            gridControl1.DataSource = dsList.Tables[0];
        }
    }
}
