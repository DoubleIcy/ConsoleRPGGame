using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Drawing.Imaging;

namespace ImgForm
{
    public partial class Form2 : Form
    {
        Random rd = new Random();

        DataTable dt = new DataTable();
        
        public Form2()
        {
            InitializeComponent();
            gridView1.RowCellStyle += gridView1_RowCellStyle;

            dt.Columns.Add("A"); 
            dt.Columns.Add("B");
            dt.Columns.Add("C");
            dt.Columns.Add("D");
            for (int i = 0; i < 20; i++)
            {
                DataRow dr = dt.NewRow();
                dr["a"] = rd.Next(i);
                dr["b"] = rd.Next(i);
                dr["C"] = rd.Next(i);
                dr["D"] = rd.Next(i);
                dt.Rows.Add(dr);
            }
            gridControl1.DataSource = dt;
        }

        private int sj(int i)
        {
            return rd.Next(i);
        }
        private Color sjColor()
        {
            if (sj(5) < 3)
                return System.Drawing.Color.FromArgb(sj(255), sj(255), sj(255));
            else

                return System.Drawing.Color.FromArgb(sj(255), sj(255), sj(255),sj(255)); 
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            //if (e.RowHandle < 0 || e.Column.Caption != "结果") return;
            DataRow Row = gridView1.GetDataRow(e.RowHandle);
            if (Row == null) return;
            
            string str=Convert.ToString(((DevExpress.XtraGrid.Views.Base.CustomRowCellEventArgs)(e)).CellValue);
            if(!bl.HasValue)
                switch (str)
                {
                    case "1": e.Appearance.BackColor = System.Drawing.Color.Red; break;
                    case "2": e.Appearance.BackColor = System.Drawing.Color.Green; break;
                    case "3": e.Appearance.BackColor = System.Drawing.Color.Blue; break;

                    case "4": e.Appearance.BackColor = System.Drawing.Color.BlanchedAlmond; break;
                    case "5": e.Appearance.BackColor = System.Drawing.Color.BlueViolet; break;
                    case "6": e.Appearance.BackColor = System.Drawing.Color.BurlyWood; break;

                    case "7": e.Appearance.BackColor = System.Drawing.Color.Chartreuse; break;
                    case "8": e.Appearance.BackColor = System.Drawing.Color.DarkGreen; break;
                    case "9": e.Appearance.BackColor = System.Drawing.Color.Chocolate; break;
                    default: break;
                }
            if (bl.HasValue && bl.Value)
                e.Appearance.BackColor = sjColor();
            Color c = new Color();
        }
        bool? bl = false;
        private void button1_Click(object sender, EventArgs e)
        {
            if (bl.HasValue && bl.Value)
                bl = false;
            else if (bl.HasValue && !bl.Value)
                bl = null;
            else if (!bl.HasValue)
                bl = true;
        }
    }
}
