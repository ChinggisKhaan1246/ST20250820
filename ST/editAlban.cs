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
    public partial class editAlban : Form
    {
        alban a;
        public editAlban(alban aa)
        {
            InitializeComponent();
            a = aa;
        }

        dataSetFill ds = new dataSetFill();
        BaseUrl Url = new BaseUrl();
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
               
                var data = new NameValueCollection();
                data["id"] = ID.Text.Trim();
                data["Bnumber"] = Bnumber.Text;
                data["ognooDoc"] = ognooDoc.DateTime.ToString("yyyy-MM-dd");
                data["tuhai"] = tuhai.Text;
                data["haanaas"] = haanaas.Text;
                data["Utga"] = Utga.Text; ;
                data["signTushaal"] = signTushaal.Text;
                data["signName"] = signName.Text;
                data["URL11"] = URL11.Text.Trim();
                MessageBox.Show(ds.exec_command("editalban", data));
                if (URL11.Text != "")
                {
                    ServicePointManager.Expect100Continue = true;
                    ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
                    WebClient Client = new System.Net.WebClient();
                    Client.Headers.Add("Content-Type", "binary/octet-stream");
                    string tusulid = "yavsan";
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
                a.labelload.Text += "1";
                this.Hide();
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
        private void editAlban_Load(object sender, EventArgs e)
        {
            // Form load үед хийгдэх үйлдлийг энд бичнэ үү
        }

        private void editAlban_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) // Enter товч дарагдсан эсэхийг шалгана
            {
                simpleButton1.PerformClick(); // simpleButton1_Click функцыг дуудаж байна
            }
        }
    }
}
