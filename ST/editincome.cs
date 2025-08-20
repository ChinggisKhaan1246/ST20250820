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
    public partial class editincome : Form
    {
        Form1 f;
        public editincome(Form1 ff)
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
                data["id"] = incomeID.Text.Trim();
                data["ognoo"] = ognoo.DateTime.ToString("yyyy-MM-dd");
                data["incomename"] = incomename.Text.Trim();
                data["income"] = income.Text.Trim();
                MessageBox.Show(ds.exec_command("editincome", data));
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            finally
            {
                f.FillGridIncome(Convert.ToInt16(projectID.Text));
                this.Hide();
            }
        }

        private void editincome_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) // Enter товч дарагдсан эсэхийг шалгана
            {
                simpleButton1.PerformClick(); // simpleButton1_Click функцыг дуудаж байна
            }
        }

    }
}
