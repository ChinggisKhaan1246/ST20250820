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
    public partial class addcomdoc : Form
    {
        comdoc f;
        public addcomdoc(comdoc ff)
        {
            InitializeComponent();
            f = ff;
        }

        private void addcomdoc_Load(object sender, EventArgs e)
        {
            ognoo.EditValue = DateTime.Now;
        }
        BaseUrl Url = new BaseUrl();
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                dataSetFill dcd = new dataSetFill();
                var data = new NameValueCollection();
                data["projectID"] = projectID.Text;
                data["docname"] = docname.Text;
                data["tailbar"] = tailbar.Text;
                data["URL11"] = URL11.Text;
                data["doctype"] =doctype.Text;
                data["ognoo"] = DateTime.Now.ToString("yyyy-MM-dd");
                MessageBox.Show(dcd.exec_command("addcomdoc", data));

                if (URL11.Text != "")
                {
                    ServicePointManager.Expect100Continue = true;
                    ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
                    WebClient Client = new System.Net.WebClient();
                    Client.Headers.Add("Content-Type", "binary/octet-stream");
                    string tusulid = "comdoc";
                    byte[] result = Client.UploadFile(Url.GetUrl()+"api/fileupload.php?id=" + tusulid, "POST", openFileDialog1.FileName.ToString());
                    string s = System.Text.Encoding.UTF8.GetString(result, 0, result.Length);
                }

            }
            catch (Exception ee)
            { 
                MessageBox.Show(ee.ToString()); 
            }
            finally 
            {
                if (doctype.Text == "companyM")
                {
                    f.fillgridComM();
                }
                if (doctype.Text == "companyS")
                {
                    f.fillgridComS();
                }
                if (doctype.Text == "companyA")
                {
                    f.fillgridComA();
                }
                if (doctype.Text == "companyN")
                {
                    f.fillgridComN();
                }

            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            URL11.Text = openFileDialog1.SafeFileName;
        }

        private void addcomdoc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) // Enter товч дарагдсан эсэхийг шалгана
            {
                simpleButton1.PerformClick(); // simpleButton1_Click функцыг дуудаж байна
            }
        }
    }
}
