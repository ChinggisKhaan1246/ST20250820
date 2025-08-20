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

namespace ST
{
    public partial class addincome : Form
    {
        Form1 f;
        public addincome(Form1 ff)
        {
            InitializeComponent();
            f = ff;
        }

        private void income_Load(object sender, EventArgs e)
        {
            ognoo.EditValue = DateTime.Now;
            textEdit3.Text = "";
            incomename.Text = "";

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                dataSetFill dcd = new dataSetFill();
                var data = new NameValueCollection();
                data["projectID"] = projectID.Text;
                data["incomename"] = incomename.Text;
                data["income"] = textEdit3.Text;
                data["ognoo"] = ognoo.DateTime.ToString("yyyy-MM-dd");
                MessageBox.Show(dcd.exec_command("addincome", data));
            }
            catch (Exception ee)
            { MessageBox.Show(ee.ToString()); }
            finally { f.fillGridIncome(); }
        }
    }
}
