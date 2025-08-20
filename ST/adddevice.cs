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
    public partial class adddevice : Form
    {
        devices f;
        public adddevice(devices ff)
        {
            InitializeComponent();
            f = ff;
        }
        BaseUrl Url = new BaseUrl();
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                dataSetFill dcd = new dataSetFill();
                var data = new NameValueCollection();
                data["ner"] = ner.Text;
                data["mark"] = mark.Text;
                data["made"] = made.Text;
                data["too"] = too.Text;
                data["ready"] = ready.Text;
                data["ooriin"] = ooriin.Text;
                data["ulsdugaar"] = ulsdugaar.Text;
                data["producted"] = producted.Text;
                data["power"] = power.Text;
                data["devicetype"] = devicetype.Text.Trim();
                data["ognoo"] = ognoo.DateTime.ToString("yyyy-MM-dd HH:mm:ss");
                data["URL11"] = URL11.Text;
                MessageBox.Show(dcd.exec_command("adddevices", data));

                if (URL11.Text != "")
                {
                    ServicePointManager.Expect100Continue = true;
                    ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
                    WebClient Client = new System.Net.WebClient();
                    Client.Headers.Add("Content-Type", "binary/octet-stream");
                    string tusulid = "devices";
                    //MessageBox.Show(Url.GetUrl() + "api/flieupload.php?id=" + tusulid);
                    byte[] result = Client.UploadFile(Url.GetUrl() + "api/fileupload.php?id=" + tusulid, "POST", openFileDialog1.FileName.ToString());
                    string s = System.Text.Encoding.UTF8.GetString(result, 0, result.Length);
                }
            }
            catch (Exception ee)
            { 
                MessageBox.Show(ee.ToString()); 
            }
            finally 
            { 
                this.Hide();
                f.fillgridDevices();  
            }
        }

        private void simpleButtonFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            URL11.Text = openFileDialog1.SafeFileName;
        }
        
        private void devicetype_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void adddevice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) // Enter товч дарагдсан эсэхийг шалгана
            {
                simpleButton1.PerformClick(); // simpleButton1_Click функцыг дуудаж байна
            }
        }

        private void adddevice_Load(object sender, EventArgs e)
        {

        }

        private void ognoo_EditValueChanged(object sender, EventArgs e)
        {

        }


    }
}
