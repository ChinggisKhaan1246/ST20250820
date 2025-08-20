using System;
using System.Configuration;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.LookAndFeel;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrintingLinks;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.Utils;
using System.Net;

namespace ST
{
    public partial class editcosts : Form
    {
        Form1 f;
        public editcosts(Form1 ff)
        {
            InitializeComponent();
            f = ff;
        }
        dataSetFill ds = new dataSetFill();
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                var data = new NameValueCollection();
                data["id"] = costID.Text.Trim();
                data["ognoo"] = ognoo.DateTime.ToString("yyyy-MM-dd");
                data["costname"] = costname.Text.Trim();
                data["cost"] = costs.Text.Trim();
                MessageBox.Show(ds.exec_command("editcost", data));
            }
            catch (Exception ee)
            { 
                MessageBox.Show(ee.ToString()); 
            }
            finally 
            {
                f.FillGridCost(Convert.ToInt16(projectID.Text)); 
                this.Hide(); 
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void editcosts_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) // Enter товч дарагдсан эсэхийг шалгана
            {
                simpleButton1.PerformClick(); // simpleButton1_Click функцыг дуудаж байна
            }
        }

    }
}
