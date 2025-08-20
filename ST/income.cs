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
    public partial class income : Form
    {
        Form1 f;
        public income(Form1 ff)
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
                data["projectID"] = projectID.Text.Trim();
                data["incomename"] = incomename.Text;
                data["income"] = textEdit3.Text;
                data["ognoo"] = ognoo.DateTime.ToString("yyyy-MM-dd");
                data["userID"] = UserSession.LoggedUserID.ToString();
                
                MessageBox.Show(dcd.exec_command("addincome", data));
            }
            catch (Exception ee)
            { 
                MessageBox.Show(ee.ToString()); 
            }
            finally 
            {
                f.FillGridIncome(Convert.ToInt16(projectID.Text));
                f.FillGridDuussan();
                f.FillGridOdoo();
            }
        }

        private void income_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) // Enter товч дарагдсан эсэхийг шалгана
            {
                simpleButton1.PerformClick(); // simpleButton1_Click функцыг дуудаж байна
            }
        }
    }
}
