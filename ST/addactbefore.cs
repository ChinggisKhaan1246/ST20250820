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
using System.Net;
using Newtonsoft.Json.Linq;
using System.IO;
using DevExpress.XtraRichEdit;
using DevExpress.XtraRichEdit.API.Native;


namespace ST
{
    public partial class addactbefore : Form
    {
        ildaldact il;
        public addactbefore(ildaldact i)
        {
            InitializeComponent();
            il = i;
        }

        private void addactbefore_Load(object sender, EventArgs e)
        {
            lookupMyeng();
        }

        private void lookupMyeng()
        {
            dataSetFillnew dsn = new dataSetFillnew();
            dataSetFill ds = new dataSetFill();
            DataTable result;

            result = ds.gridFill("getita", "itatype=daily");
            if (result != null && result.Rows.Count > 0)
            {
                engname.Properties.DataSource = result;
                engname.Properties.ValueMember = "id";
                engname.Properties.DisplayMember = "ner";
                engname.Properties.Columns.Clear();
                engname.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ner", "Нэр"));
                engname.Properties.DropDownRows = result.Rows.Count;
                daamalname.Properties.DataSource = result;
                daamalname.Properties.ValueMember = "id";
                daamalname.Properties.DisplayMember = "ner";
                daamalname.Properties.Columns.Clear();
                daamalname.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ner", "Нэр"));
                daamalname.Properties.DropDownRows = result.Rows.Count;
            }
            try
            {
                var parameters = new Dictionary<string, string> { { "projectID", projectID.Text.Trim() } };
                result = dsn.getData("getacteng", parameters);

                if (result != null && result.Rows.Count > 0)
                {
                    foreach (DataRow row in result.Rows)
                    {
                        string engType = row["engtype"].ToString();
                        string ovog = row["ovog"].ToString();
                        string ner = row["ner"].ToString();

                        string formattedName = (ovog.Length > 0 ? char.ToUpper(ovog[0]).ToString() : "") + "." + ner;

                        switch (engType)
                        {
                            case "ZAH":
                                ZAH.Text = formattedName;
                                break;
                            case "ZOH":
                                ZOH.Text = formattedName;
                                break;
                            case "ERCHIM":
                                erchim.Text = formattedName;
                                break;
                            case "USSUVAG":
                                USSUVAG.Text = formattedName;
                                break;
                            case "DULAAN":
                                DULAAN.Text = formattedName;
                                break;
                            case "ONTSGOI":
                                ONTSGOI.Text = formattedName;
                                break;
                            case "HOLBOO":
                                HOLBOO.Text = formattedName;
                                break;
                            case "ASHIGLAGCH":
                                ashiglagch.Text = formattedName;
                                break;
                        }

                    }

                }
                else
                { }
            }
            catch (Exception)
            {
                MessageBox.Show("acteng error");
            }
            

         
        }

        private void ognoo_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                dataSetFill ds = new dataSetFill();
                var data = new NameValueCollection();
               
                data["aimag"] = aimag.Text.Trim();
                data["city"] = sumname.Text.Trim();
                data["date"] = ognoo.DateTime.ToString("yyyy-MM-dd");
                weather.Text = ds.exec_command("getweather", data);
               

            }
            catch (Exception ee)
            {
                // Алдаа гарвал харуулах
                MessageBox.Show("Алдаа гарлаа: " + ee.Message);
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                
                string exePath = AppDomain.CurrentDomain.BaseDirectory;
                string originalFilePath = Path.Combine(exePath, "images", "acts", rtffilename.Text.Trim());
                string tempFilePath = Path.Combine(exePath, "images", "acts", "temp_" + rtffilename.Text.Trim());

                 
                addact adda = new addact(il);

                if (System.IO.File.Exists(originalFilePath))
                {

                    File.Copy(originalFilePath, tempFilePath, true);
                    using (RichEditDocumentServer rtfDoc = new RichEditDocumentServer())
                    {
                        rtfDoc.LoadDocument(tempFilePath, DocumentFormat.Rtf);
                        rtfDoc.Document.BeginUpdate();
                        FindAndReplace(rtfDoc, "YEAR", ognoo.DateTime.ToString("yyyy"));
                        FindAndReplace(rtfDoc, "MONTH", ognoo.DateTime.ToString("MM"));
                        FindAndReplace(rtfDoc, "DAY", ognoo.DateTime.ToString("dd"));
                        FindAndReplace(rtfDoc, "AIMAG", aimag.Text);
                        FindAndReplace(rtfDoc, "SUMNAME", sumname.Text);
                        FindAndReplace(rtfDoc, "NUMBER", actnumber.Text);
                        FindAndReplace(rtfDoc, "PROJECTNAME", projectName.Text);
                        FindAndReplace(rtfDoc, "SUBNAME", actnamefromuser.Text);
                        FindAndReplace(rtfDoc, "ENG", engname.Text);
                        FindAndReplace(rtfDoc, "DAAMAL", daamalname.Text);
                        FindAndReplace(rtfDoc, "ZOH", ZOH.Text);
                        FindAndReplace(rtfDoc, "ZAH", ZAH.Text);
                        FindAndReplace(rtfDoc, "COMPANYNAME", companyname.Text);
                        FindAndReplace(rtfDoc, "AUTHOR", zohorg.Text);
                        FindAndReplace(rtfDoc, "ZAHORG", zahorg.Text);
                        FindAndReplace(rtfDoc, "WEATHER", weather.Text);
                        FindAndReplace(rtfDoc, "ERCHIM", erchim.Text);
                        FindAndReplace(rtfDoc, "ASHIGLAGCH", ashiglagch.Text);
                        FindAndReplace(rtfDoc, "ERCHIM", erchim.Text);
                        rtfDoc.Document.EndUpdate();
                        rtfDoc.SaveDocument(tempFilePath, DocumentFormat.Rtf);
                    }
                    adda.projectID.Text = projectID.Text;
                    adda.bookID.Text = bookID.Text;
                    adda.projectName.Text = projectName.Text;
                    adda.actname.Text = actname.Text;
                    adda.actnamefromuser.Text = actnamefromuser.Text;
                    adda.richEditControl1.LoadDocument(tempFilePath, DocumentFormat.Rtf);
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Файл олдсонгүй: " + originalFilePath, "Алдаа", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                adda.ShowDialog();
            }
            catch (Exception ee)
            {
                MessageBox.Show("Aldaa", ee.ToString());
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
           
        }

        private void FindAndReplace(RichEditDocumentServer docServer, string search, string replace)
        {
            DocumentRange[] ranges = docServer.Document.FindAll(search, SearchOptions.None);
            foreach (var range in ranges)
            {
                docServer.Document.Replace(range, replace);
            }
        }
    }


}
