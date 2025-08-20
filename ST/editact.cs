using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace ST
{
    public partial class editact : Form
    {

        ildaldact il;
        public editact(ildaldact i)
        {
            InitializeComponent();
            il = i;
        }
        BaseUrl Url = new BaseUrl();
        private void simpleButton1_Click(object sender, EventArgs e)
        {
           try
            {
                string actID = actIDEdit.Text.Trim(); // 📌 Actdata ID авах
                string rtfText;
                using (MemoryStream ms = new MemoryStream())
                {
                    richEditControl1.SaveDocument(ms, DevExpress.XtraRichEdit.DocumentFormat.Rtf);
                    rtfText = Encoding.UTF8.GetString(ms.ToArray());
                }
                var jsonData = new Dictionary<string, string>
        {
            { "rtfContent", rtfText }, // 📌 RTF өгөгдлийг JSON дотор хадгалах
            { "created_at", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") }
        };
                string jsonString = JsonConvert.SerializeObject(jsonData);
                using (WebClient client = new WebClient())
                {
                    client.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                    NameValueCollection values = new NameValueCollection();
                    values["id"] = actID;
                    values["actnamefromuser"] = actnamefromuser.Text.Trim();
                    values["actdata"] = jsonString; // 📌 JSON өгөгдлийг `actdata` баганад хадгалах
                    byte[] response = client.UploadValues(Url.GetUrl() + "api/editactdata.php", "POST", values);
                    string responseText = Encoding.UTF8.GetString(response);
                    string decodedResponse = System.Text.RegularExpressions.Regex.Unescape(responseText);
                    MessageBox.Show("Өгөгдөл амжилттай илгээгдлээ! \n" + decodedResponse, "Амжилттай", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    il.grid2_refresh();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("Алдаа: " + ee.ToString(), "Алдаа", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



    }
}
