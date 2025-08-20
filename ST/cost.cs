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
    public partial class cost : Form
    {
        Form1 f;
        public cost(Form1 ff)
        {
            InitializeComponent();
            f = ff;
        }

        private void cost_Load(object sender, EventArgs e)
        {
            ognoo.EditValue = DateTime.Now;
            costname.Text = "";
            textEdit3.Text = "";
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                dataSetFill dcd = new dataSetFill();
                var data = new NameValueCollection();
                data["projectID"] = projectID.Text.Trim();
                data["costname"] = costname.Text;
                data["cost"] = textEdit3.Text;
                data["ognoo"] = ognoo.DateTime.ToString("yyyy-MM-dd hh:mm:ss");
                //MessageBox.Show(UserSession.LoggedUserID.ToString());
                data["userID"] = UserSession.LoggedUserID.ToString();
                var jsonstring = dcd.exec_command("addcost", data);
                MessageBox.Show("Зардлын мэдээлэл амжилттай бүртгэгдсэн!");
            }
            catch (Exception ee)
            { 
                MessageBox.Show(ee.ToString()); 
            }
            finally 
            {
                f.FillGridCost(Convert.ToInt16(projectID.Text));
                f.FillGridDuussan();
                f.FillGridOdoo();
            }
        }

        private void cost_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) // Enter товч дарагдсан эсэхийг шалгана
            {
                simpleButton1.PerformClick(); // simpleButton1_Click функцыг дуудаж байна
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
           
        }
    }
}
