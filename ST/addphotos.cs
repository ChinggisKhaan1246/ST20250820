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
    public partial class addphotos : Form
    {
        dailypic f;
        public addphotos(dailypic ff)
        {
            InitializeComponent();
            f = ff;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            URL11.Text = openFileDialog1.SafeFileName;
        }
        BaseUrl Url = new BaseUrl();
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Ztailbar.Text != "")
                {
                    
                    dataSetFill dcd = new dataSetFill();
                    var data = new NameValueCollection();
                    data["dailyID"] = dailyID.Text;
                    data["Ztailbar"] = Ztailbar.Text;
                    data["URL11"] = URL11.Text;
                    data["projectID"] = projectID.Text;
                    data["URL11"] = URL11.Text;
                    data["checkbox"] = "0";
                    data["ognoo"] = dateEdit1.DateTime.ToString("yyyy-MM-dd hh:mm:ss");
                    data["userID"] = UserSession.LoggedUserID.ToString();
                       

                    if (URL11.Text != "")
                    {
                        ServicePointManager.Expect100Continue = true;
                        ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
                        WebClient Client = new System.Net.WebClient();
                        Client.Headers.Add("Content-Type", "binary/octet-stream");
                        string tusulid = "daily";
                        string url = Url.GetUrl()+"api/fileupload.php?id=" + tusulid + "&projectID=" + projectID.Text;
                        byte[] result = Client.UploadFile(url, "POST", openFileDialog1.FileName.ToString());
                        string s = System.Text.Encoding.UTF8.GetString(result, 0, result.Length);
                       // MessageBox.Show(result.ToString());
                        MessageBox.Show(dcd.exec_command("adddailypic", data)); 
                    }
                    else
                    {
                        MessageBox.Show("Зураг файл сонгож өгөөгүй байна.");
                    }
                }
                else
                {
                    MessageBox.Show("Тайлбар оруулна уу.");
                }
            }
            catch (Exception ee)
            { MessageBox.Show(ee.ToString()); }
            finally
            {
                f.fillgriddailyPic();
            }
        }

        private void addphotos_Load(object sender, EventArgs e)
        {
            dateEdit1.DateTime = DateTime.Now;
        }

        private void addphotos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) // Enter товч дарагдсан эсэхийг шалгана
            {
                simpleButton1.PerformClick(); // simpleButton1_Click функцыг дуудаж байна
            }
        }
    }
}
