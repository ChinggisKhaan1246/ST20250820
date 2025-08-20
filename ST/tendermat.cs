using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Diagnostics;
using System.Web;
using System.Collections.Specialized;
using System.Text.RegularExpressions;
using System.Globalization;
using DevExpress.XtraRichEdit;
using DevExpress.XtraRichEdit.API.Native;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using DevExpress.XtraPrintingLinks;
using DevExpress.Utils;

using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;


namespace ST
{
    public partial class tendermat : Form
    {
        public tendermat()
        {
            InitializeComponent();
        }

        dataSetFill ds = new dataSetFill();
        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            
        }
        private void FillRadioGroup(DataTable dataTable)
        {
            if (dataTable == null || dataTable.Rows.Count == 0)
            {
                MessageBox.Show("Хүснэгтэд өгөгдөл алга.");
                return;
            }

            // dxRadioGroup-ыг цэвэрлэх
            radioGroup1.Properties.Items.Clear();

            // DataTable-ийн listname баганаас утгуудыг авах
            foreach (DataRow row in dataTable.Rows)
            {
                if (row["ner"] != DBNull.Value)
                {
                    string listName = row["ner"].ToString() + " : " + row["atushaal"].ToString();
                    radioGroup1.Properties.Items.Add(new DevExpress.XtraEditors.Controls.RadioGroupItem(null, listName));
                }
            }
        }
        DataTable result;
        private void fillchecklistAlban()
        {
            result = ds.gridFill("getbooktender", "status=0");
            if (result != null)
            {
                checkedListBoxControl1.DataSource = result;
                checkedListBoxControl1.DisplayMember = "listName";
                checkedListBoxControl1.ValueMember = "listName";
            }
         }
        private void fillchecklistITA()
        {
            result = ds.gridFill("getita", "itatype=ITA");
            if (result != null)
            {
                checkedListBoxControl2.DataSource = result;
                result.Columns.Add("DisplayValue", typeof(string));

                foreach (DataRow row in result.Rows)
                {
                    row["DisplayValue"] = row["ner"].ToString() + " : " + row["proff"].ToString()+ " : "+ row["docu"];

                }
                checkedListBoxControl2.DisplayMember = "DisplayValue";
                checkedListBoxControl2.ValueMember = "id";
                FillRadioGroup(result);
            }
        }
        private void fillchecklistMA()
        {
            result = ds.gridFill("getita", "itatype=MA");
            if (result != null)
            {
                checkedListBoxControl4.DataSource = result;
                result.Columns.Add("DisplayValue", typeof(string));
                foreach (DataRow row in result.Rows)
                {

                    row["DisplayValue"] = row["ner"].ToString() + " : " + row["proff"].ToString();
                }
                checkedListBoxControl4.DisplayMember = "DisplayValue";
                checkedListBoxControl4.ValueMember = "id";
            }
        }
        private void  fillchecklistOP()
        {
            result = ds.gridFill("getita", "itatype=OP");
            if (result != null)
            {
                checkedListBoxControl3.DataSource = result;
                result.Columns.Add("DisplayValue", typeof(string));
                foreach (DataRow row in result.Rows)
                {
                    row["DisplayValue"] = row["ner"].ToString() + " : " + row["proff"].ToString();
                }
                checkedListBoxControl3.DisplayMember = "DisplayValue";
                checkedListBoxControl3.ValueMember = "id";
            }
        }
        private void fillcheckdevice()
        {
            result = ds.gridFill("getdevices", "status=0");
            if (result != null)
            {
                checkedListBoxControl5.DataSource = result;
                result.Columns.Add("DisplayValue", typeof(string));
                foreach (DataRow row in result.Rows)
                {

                    row["DisplayValue"] = row["ner"].ToString() + " : " + row["mark"].ToString() + " : " + row["power"].ToString();
                }
                checkedListBoxControl5.DisplayMember = "DisplayValue";
                checkedListBoxControl5.ValueMember = "id";
            }
        }
        private void fillcheckproject4()
        {
            try
            {
                result = ds.gridFill("getproject", "status=4&comID=" + UserSession.LoggedComID);
                if (result != null)
                {
                    checkedListBoxControl7.DataSource = result;
                    result.Columns.Add("DisplayValue", typeof(string));
                    long budgetValue;
                    foreach (DataRow row in result.Rows)
                    {
                        budgetValue = long.Parse(row["budget"].ToString());
                        string budget = budgetValue.ToString("#,0");
                        row["DisplayValue"] = row["projectName"].ToString() + " : " + budget + " : " + row["ognoo2"].ToString();
                    }
                    checkedListBoxControl7.DisplayMember = "DisplayValue";
                    checkedListBoxControl7.ValueMember = "id";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Алдаа: Дууссан гэрээний мэдээлэл татах үед алдаа гарлаа.", ex.ToString());
            }
        }

        private void fillcheckproject9()
        {
            try
            {
                result = ds.gridFill("getproject", "status=9&comID=" + UserSession.LoggedComID);
                if (result != null)
                {
                    checkedListBoxControl6.DataSource = result;
                    result.Columns.Add("DisplayValue", typeof(string));
                    long budgetValue;
                    foreach (DataRow row in result.Rows)
                    {
                        budgetValue = long.Parse(row["budget"].ToString());
                        string budget = budgetValue.ToString("#,0");
                        row["DisplayValue"] = row["projectName"].ToString() + " : " + budget + " : " + row["ognoo2"].ToString();
                    }
                    checkedListBoxControl6.DisplayMember = "DisplayValue";
                    checkedListBoxControl6.ValueMember = "id";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Алдаа: Идэвхтэй гэрээний мэдээлэл татах үед алдаа гарлаа.", ex.ToString());
            }
        }
        private void tendermat_Load(object sender, EventArgs e)
        {
            try
            {
                fillchecklistAlban();
                fillchecklistITA();
                fillchecklistOP();
                fillchecklistMA();
                fillcheckdevice();
                fillcheckproject9();
                fillcheckproject4();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            finally { }

        }
        private void checkedListBoxControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
               
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            finally
            { }
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkEdit1.Checked)
                {
                    checkedListBoxControl1.CheckAll();
                }
                else
                {
                    checkedListBoxControl1.UnCheckAll();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            finally { }

        }

        private void checkEdit3_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkEdit3.Checked)
                {
                    checkedListBoxControl3.CheckAll();
                }
                else
                {
                    checkedListBoxControl3.UnCheckAll();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            finally { }
        }

        private void checkEdit4_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkEdit4.Checked)
                {
                    checkedListBoxControl4.CheckAll();
                }
                else
                {
                    checkedListBoxControl4.UnCheckAll();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            finally { }
        }

        private void checkEdit5_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkEdit5.Checked)
                {
                    checkedListBoxControl5.CheckAll();
                }
                else
                {
                    checkedListBoxControl5.UnCheckAll();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            finally { }
        }

        private void checkEdit7_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkEdit7.Checked)
                {
                    checkedListBoxControl7.CheckAll();
                }
                else
                {
                    checkedListBoxControl7.UnCheckAll();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            finally { }
        }

        private void checkEdit6_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkEdit6.Checked)
                {
                    checkedListBoxControl6.CheckAll();
                }
                else
                {
                    checkedListBoxControl6.UnCheckAll();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            finally { }
        }
        private void groupControl1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                string status = "";
                for (int i = 0; i < checkedListBoxControl1.CheckedIndices.Count; i++)
                {
                    status += "listID =" + checkedListBoxControl1.CheckedIndices[i].ToString() + " OR ";
                }
                if (status.EndsWith(" OR "))
                {
                    status = status.Substring(0, status.Length - 4);
                }
                if (status == "")
                {
                    MessageBox.Show("Ямар ч өгөгдөл сонгогдоогүй байна.");
                }
                else
                {
                   // MessageBox.Show(status);
                    gridControl1.DataSource = ds.gridFill("getbooktender", "status=" + status + "");
                    reporttendermat rptT = new reporttendermat();
                    List<ReportData> reportDataList = new List<ReportData>();
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        reportDataList.Add(new ReportData
                        {
                            classhaashaa = tendZahi.Text + "-Т",
                            classBnumber = DateTime.Now.ToString("yyyy-MM-dd").Substring(2, 2) + "/0" + (Convert.ToInt16(gridView1.GetRowCellValue(i, "listID").ToString()) + 1).ToString(),
                            classtuhai = gridView1.GetRowCellValue(i, "tuhai").ToString(),
                            classognoo = ognoo.DateTime.ToString("yyyy-MM-dd"),
                            classUtga = "          Бид " + tendZahi.Text + "-с зарласан \"№" + tendCode.Text + "\" дугаар бүхий \"" + tendName.Text + "\" ажлын гүйцэтгэгчийг сонгон шалгаруулах тендерт оролцож байгаа бөгөөд " + gridView1.GetRowCellValue(i, "Utga").ToString().Replace("Zahialagch$$", tendZahi.Text).Replace("money$$", turgen.Text).Replace("ChbatTime$$", ChbatTime.Text),
                        });
                    }
                    rptT.DataSource = reportDataList;
                    rptT.haashaa.DataBindings.Add(new XRBinding("Text", null, "classhaashaa"));
                    rptT.ognoo.DataBindings.Add(new XRBinding("Text", null, "classognoo"));
                    rptT.Bdugaar.DataBindings.Add(new XRBinding("Text", null, "classBnumber"));
                    rptT.tuhai.DataBindings.Add(new XRBinding("Text", null, "classtuhai"));
                    rptT.utga.DataBindings.Add(new XRBinding("Text", null, "classUtga"));
                   
                   // rptT.ShowPreview();

                    reportM1 rpt1 = new reportM1();

                    // 1. Үнэ хөрвүүлэлт
                    long tusuv = 0;
                    string longune = "";
                    string formatedune="";
                    if (long.TryParse(une.Text, out tusuv))
                    {
                        longune = MongolianNumberConverter.ToMongolianWords(tusuv);
                        if (!string.IsNullOrWhiteSpace(longune))
                        {
                            longune = char.ToUpper(longune[0]) + longune.Substring(1);
                        }

                        string formattedNumber = tusuv.ToString("N0");
                        string formattedCurrency = formattedNumber + " ₮";
                        formatedune = formattedCurrency;
                    }
                    else
                    {
                        MessageBox.Show("Тендерийн үнийн мэдээллийг зөв оруулна уу.", "Алдаа", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // 2. Хоног тоо хөрвүүлэлт
                    int honogToo;
                    if (int.TryParse(honog.Text, out honogToo))
                    {
                        honog.Text = honogToo.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Хоногийн зөв тоо оруулна уу.", "Алдаа", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // 3. RichEdit доторх текстүүдийг орлуулах
                    RichEditDocumentServer server = new RichEditDocumentServer();

                    // RTF эх хувь оноох
                    if (!string.IsNullOrEmpty(rpt1.xrRichText1.RtfText.ToString()))
                    {
                        server.RtfText = rpt1.xrRichText1.RtfText.ToString();
                    }
                    else
                    {
                        MessageBox.Show("RTF эх текст олдсонгүй.", "Алдаа", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    string formattedOgnoo = ognoo.DateTime.ToString("yyyy-MM-dd");
                    string rtf = rpt1.xrRichText1.RtfText.Value;

                    rtf = rtf.Replace("ognoo", EscapeToRtf(formattedOgnoo))
                             .Replace("zahialagch", EscapeToRtf(tendZahi.Text))
                             .Replace("dugaar", EscapeToRtf(tendCode.Text))
                             .Replace("ajil", EscapeToRtf(tendName.Text))
                             .Replace("une", EscapeToRtf(formatedune))
                             .Replace("long", EscapeToRtf(longune))
                             .Replace("time", EscapeToRtf(honog.Text));

                    rpt1.xrRichText1.RtfText = new DevExpress.XtraReports.UI.SerializableString(rtf);
                   
                  //  rpt1.ShowPreview();


                    //нэгтгэж харуулах

                    // 1. XtraReport бүрийн Document үүсгэх
                    rptT.CreateDocument();
                    rpt1.CreateDocument();

                    // 2. Нэгэн шинэ PrintingSystem үүсгээд хоёуланг нэгтгэх
                    PrintingSystem ps = new PrintingSystem();
                    ps.Pages.AddRange(rpt1.PrintingSystem.Pages);
                    ps.Pages.AddRange(rptT.PrintingSystem.Pages);

                    // 3. Preview
                    PrintTool printTool = new PrintTool(ps);
                    printTool.ShowPreviewDialog();


                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            finally
            { }
        }

        string EscapeToRtf(string input)
        {
            var sb = new StringBuilder();
            foreach (char c in input)
            {
                if (c <= 127)
                    sb.Append(c);
                else
                    sb.Append(string.Format("\\u{0}?", Convert.ToUInt32(c)));
            }
            return sb.ToString();
        }


        public static class MongolianNumberConverter
        {
            private static readonly string[] Units = { "", "нэг", "хоёр", "гурав", "дөрөв", "тав", "зургаа", "долоо", "найм", "ес" };
            private static readonly string[] UnitsWithSuffix = { "", "нэгэн", "хоёр", "гурав", "дөрөв", "таван", "зургаан", "долоон", "найман", "есөн" };
            private static readonly string[] Tens = { "", "арав", "хорь", "гуч", "дөч", "тавин", "жаран", "дал", "ная", "ер" };
            private static readonly string[] TensWithSuffix = { "", "арван", "хорин", "гучин", "дөчин", "тавин", "жаран", "далан", "наян", "ерөн" };
            private static readonly string[] Magnitudes = { "", "мянга", "сая", "тэрбум", "их наяд" };

            public static string ToMongolianWords(long tusuv)
            {
                if (tusuv < 0)
                    throw new ArgumentException("Тоо 0 буюу түүнээс их байх ёстой");

                if (tusuv == 0)
                    return "тэг төгрөг";

                string result = ConvertNumberToWords(tusuv).Trim();
                return result ;
            }

            private static string ConvertNumberToWords(long number)
            {
                if (number == 0) return "";

                List<string> parts = new List<string>();
                int magnitudeIndex = 0;

                while (number > 0)
                {
                    int group = (int)(number % 1000);
                    if (group != 0)
                    {
                        string groupWords = ConvertGroupToWords(group, isSuffix: magnitudeIndex > 0);
                        if (!string.IsNullOrEmpty(Magnitudes[magnitudeIndex]))
                        {
                            groupWords += " " + Magnitudes[magnitudeIndex];
                        }
                        parts.Insert(0, groupWords);
                    }

                    number /= 1000;
                    magnitudeIndex++;
                }

                return string.Join(" ", parts);
            }

            private static string ConvertGroupToWords(int number, bool isSuffix)
            {
                List<string> words = new List<string>();

                int hundreds = number / 100;
                int tensUnits = number % 100;
                int tens = tensUnits / 10;
                int units = tensUnits % 10;

                if (hundreds > 0)
                {
                    words.Add(UnitsWithSuffix[hundreds] + " зуун");
                }

                if (tensUnits > 0)
                {
                    if (tens > 0)
                    {
                        words.Add(TensWithSuffix[tens]);
                    }

                    if (units > 0)
                    {
                        if (tens > 0)
                        {
                            words.Add(Units[units]); // 25: "хорин тав"
                        }
                        else
                        {
                            words.Add(UnitsWithSuffix[units]); // 5: "таван", 9: "есөн"
                        }
                    }
                }

                return string.Join(" ", words);
            }
        }



        private void groupControl2_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                string status = "";
                for (int i = 0; i < checkedListBoxControl2.CheckedIndices.Count; i++)
                {
                    int index = checkedListBoxControl2.CheckedIndices[i];
                    string itemText = checkedListBoxControl2.GetItemText(index);
                    itemText = itemText.Split(':')[0].Trim();
                    status += itemText + "q";
                }

                if (status.EndsWith("q"))
                {
                    status = status.Substring(0, status.Length - 1);
                }

                if (string.IsNullOrWhiteSpace(status))
                {
                    MessageBox.Show("Ямар ч өгөгдөл сонгогдоогүй байна.");
                    return;
                }

                // Өгөгдөл татах
                gridControl2.DataSource = ds.gridFill("getitaT", "condition=" + status);

                // Тайлангийн өгөгдөл цуглуулах
                List<ReportData> reportDataList = new List<ReportData>();
                List<string> docuList = new List<string>();
                for (int i = 0; i < gridView2.RowCount; i++)
                {
                    string docuName = gridView2.GetRowCellValue(i, "docu").ToString();

                    reportDataList.Add(new ReportData
                    {
                        classatushaal = gridView2.GetRowCellValue(i, "atushaal").ToString(),
                        classner = gridView2.GetRowCellValue(i, "ner").ToString(),
                        classproff = gridView2.GetRowCellValue(i, "proff").ToString(),
                        classniitAjilsan = gridView2.GetRowCellValue(i, "niitAjilsan").ToString(),
                        classajillsan = gridView2.GetRowCellValue(i, "ajillsan").ToString(),
                        classdocuITA = docuName
                    });

                    if (!string.IsNullOrWhiteSpace(docuName))
                    {
                        docuList.Add(docuName);
                    }
                }

                // Тайлан үүсгэх
                reportM2 rpt21 = new reportM2();
                rpt21.DataSource = reportDataList;
                rpt21.mayagtnumber.Text = "Маягт №2-1";
                rpt21.titletext.Text = "Инженер техникийн ажилчдын мэдээлэл";

                rpt21.atushaal.DataBindings.Add(new XRBinding("Text", null, "classatushaal"));
                rpt21.ner.DataBindings.Add(new XRBinding("Text", null, "classner"));
                rpt21.proff.DataBindings.Add(new XRBinding("Text", null, "classproff"));
                rpt21.niitAjilsan.DataBindings.Add(new XRBinding("Text", null, "classniitAjilsan"));
                rpt21.ajillsan.DataBindings.Add(new XRBinding("Text", null, "classajillsan"));

                rpt21.CreateDocument();

                // Тайлан + хавсралт PDF-ийг нэгтгэх
                MergeITAReportWithAttachments(rpt21, docuList); // энэ функц өмнө өгсөн

            }
            catch (Exception ee)
            {
                MessageBox.Show("Алдаа гарлаа: " + ee.Message);
            }
        }


private void MergeITAReportWithAttachments(XtraReport rpt21, List<string> docuList)
{
    string basePath = @"C:\Temp\ITAReport\";
    if (!Directory.Exists(basePath)) Directory.CreateDirectory(basePath);

    string reportPdfPath = Path.Combine(basePath, "rpt21.pdf");
    string finalPdfPath = Path.Combine(basePath, "FinalMergedITAReport.pdf");

    // 1. rpt тайланг PDF хэлбэрт хадгалах
    rpt21.ExportToPdf(reportPdfPath);

    // 2. Хавсралтуудыг татах
    List<string> attachmentPaths = new List<string>();
    foreach (string fileName in docuList)
    {
        if (string.IsNullOrWhiteSpace(fileName)) continue;

        string fileUrl = "https://etusul.com/dist/uploads/ita/docu/" + fileName;
        string localPath = Path.Combine(basePath, fileName);

        try
        {
            using (WebClient client = new WebClient())
            {
                client.DownloadFile(fileUrl, localPath);
                attachmentPaths.Add(localPath);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("PDF татахад алдаа:\n" + fileUrl + "\n" + ex.Message);
        }
    }

    // 3. Тайлан + хавсралтуудыг нэг PDF болгон нэгтгэх
    PdfDocument outputDoc = new PdfDocument();

    PdfDocument reportDoc = PdfReader.Open(reportPdfPath, PdfDocumentOpenMode.Import);
    for (int i = 0; i < reportDoc.PageCount; i++)
    {
        outputDoc.AddPage(reportDoc.Pages[i]);
    }

    foreach (string attachPath in attachmentPaths)
    {
        PdfDocument attachDoc = PdfReader.Open(attachPath, PdfDocumentOpenMode.Import);
        for (int i = 0; i < attachDoc.PageCount; i++)
        {
            outputDoc.AddPage(attachDoc.Pages[i]);
        }
    }

    outputDoc.Save(finalPdfPath);
    Process.Start(finalPdfPath);
}

        private void groupControl3_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                string status = "";
                for (int i = 0; i < checkedListBoxControl3.CheckedIndices.Count; i++)
                {
                    int index = checkedListBoxControl3.CheckedIndices[i];
                    string itemText = checkedListBoxControl3.GetItemText(index);
                    itemText = itemText.Split(':')[0].Trim();
                    status += itemText + "q";
                }
                if (status.EndsWith("q"))
                {
                    status = status.Substring(0, status.Length - 1);
                }
                if (status != "")
                {
                    //MessageBox.Show(status);
                    gridControl3.DataSource = ds.gridFill("getitaT", "condition=" + status);
                      reportM2 rpt21 = new reportM2();
                      List<ReportData> reportDataList = new List<ReportData>();
                      for (int i = 0; i < gridView3.RowCount; i++)
                      {
                          reportDataList.Add(new ReportData
                          {
                              classatushaal = gridView3.GetRowCellValue(i, "atushaal").ToString(),
                              classner = gridView3.GetRowCellValue(i, "ner").ToString(),
                              classproff = gridView3.GetRowCellValue(i, "proff").ToString(),
                              classniitAjilsan = gridView3.GetRowCellValue(i, "niitAjilsan").ToString(),
                              classajillsan = gridView3.GetRowCellValue(i, "ajillsan").ToString(),
                          });
                      }
                      rpt21.DataSource = reportDataList;
                      rpt21.mayagtnumber.Text = "Маягт №2-2";
                      rpt21.titletext.Text = "Машин механизм дээр ажиллах боловсон хүчний мэдээлэл";
                      rpt21.atushaal.DataBindings.Add(new XRBinding("Text", null, "classatushaal"));
                      rpt21.ner.DataBindings.Add(new XRBinding("Text", null, "classner"));
                      rpt21.proff.DataBindings.Add(new XRBinding("Text", null, "classproff"));
                      rpt21.niitAjilsan.DataBindings.Add(new XRBinding("Text", null, "classniitAjilsan"));
                      rpt21.ajillsan.DataBindings.Add(new XRBinding("Text", null, "classajillsan"));
                      rpt21.ShowPreview(); 
                }
                else
                {
                    MessageBox.Show("Ямар ч өгөгдөл сонгогдоогүй байна.");
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            finally { }
        }
        private void groupControl4_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                string status = "";
                for (int i = 0; i < checkedListBoxControl4.CheckedIndices.Count; i++)
                {
                    int index = checkedListBoxControl4.CheckedIndices[i];
                    string itemText = checkedListBoxControl4.GetItemText(index);
                    itemText = itemText.Split(':')[0].Trim();
                    status += itemText + "q";
                }
                if (status.EndsWith("q"))
                {
                    status = status.Substring(0, status.Length - 1);
                }
                if (status != "")
                {
                    //MessageBox.Show(status);
                    gridControl4.DataSource = ds.gridFill("getitaT", "condition=" + status);
                    reportM2 rpt21 = new reportM2();
                    List<ReportData> reportDataList = new List<ReportData>();
                    for (int i = 0; i < gridView4.RowCount; i++)
                    {
                        reportDataList.Add(new ReportData
                        {
                            classatushaal = gridView4.GetRowCellValue(i, "atushaal").ToString(),
                            classner = gridView4.GetRowCellValue(i, "ner").ToString(),
                            classproff = gridView4.GetRowCellValue(i, "proff").ToString(),
                            classniitAjilsan = gridView4.GetRowCellValue(i, "niitAjilsan").ToString(),
                            classajillsan = gridView4.GetRowCellValue(i, "ajillsan").ToString(),
                        });
                    }
                    rpt21.DataSource = reportDataList;
                    rpt21.mayagtnumber.Text = "Маягт №2-2";
                    rpt21.titletext.Text = "Мэргэжилтэй ажилтнуудын мэдээлэл";
                    rpt21.atushaal.DataBindings.Add(new XRBinding("Text", null, "classatushaal"));
                    rpt21.ner.DataBindings.Add(new XRBinding("Text", null, "classner"));
                    rpt21.proff.DataBindings.Add(new XRBinding("Text", null, "classproff"));
                    rpt21.niitAjilsan.DataBindings.Add(new XRBinding("Text", null, "classniitAjilsan"));
                    rpt21.ajillsan.DataBindings.Add(new XRBinding("Text", null, "classajillsan"));
                    rpt21.ShowPreview(); 
                }
                else
                {
                    MessageBox.Show("Ямар ч өгөгдөл сонгогдоогүй байна.");
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            finally { }
        }

       private void groupControl5_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                string status = "";
                for (int i = 0; i < checkedListBoxControl5.CheckedIndices.Count; i++)
                {
                    int index = checkedListBoxControl5.CheckedIndices[i];
                    string itemText = checkedListBoxControl5.GetItemText(index);
                    itemText = itemText.Split(':')[0].Trim();
                    status += itemText + "q";
                }
                if (status.EndsWith("q"))
                {
                    status = status.Substring(0, status.Length - 1);
                }
                if (status != "")
                {
                   // MessageBox.Show(status);
                    gridControl5.DataSource = ds.gridFill("getdevices", "condition=" + status);
                    reportM3 rpt21 = new reportM3();
                    List<ReportData> reportDataList = new List<ReportData>();
                    for (int i = 0; i < gridView5.RowCount; i++)
                    {
                        reportDataList.Add(new ReportData
                        {
                            classner = gridView5.GetRowCellValue(i, "ner").ToString() + ":" + gridView5.GetRowCellValue(i, "mark").ToString(),
                            classpower = gridView5.GetRowCellValue(i, "power").ToString(),
                            classtoo = gridView5.GetRowCellValue(i, "too").ToString(),
                            classULSdugaar= gridView5.GetRowCellValue(i, "ULSdugaar").ToString(),
                            classooriin = gridView5.GetRowCellValue(i, "ooriin").ToString()
                        });
                    }
                    rpt21.DataSource = reportDataList;
                    rpt21.mayahtnumber.Text = "Маягт №3";
                    rpt21.titletext.Text = "Үндсэн тоног төхөөрөмж, техник хэрэгслийн мэдээлэл ";
                    rpt21.ner.DataBindings.Add(new XRBinding("Text", null, "classner"));
                    rpt21.power.DataBindings.Add(new XRBinding("Text", null, "classpower"));
                    rpt21.too.DataBindings.Add(new XRBinding("Text", null, "classtoo"));
                    rpt21.ooriin.DataBindings.Add(new XRBinding("Text", null, "classooriin"));
                    rpt21.ULSdugaar.DataBindings.Add(new XRBinding("Text", null, "classULSdugaar"));
                    rpt21.ShowPreview(); 
                }
                else
                {
                    MessageBox.Show("Ямар ч өгөгдөл сонгогдоогүй байна.");
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            finally { }
        }

        private void groupControl7_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                string status = "";
                for (int i = 0; i < checkedListBoxControl7.CheckedIndices.Count; i++)
                {
                    int index = checkedListBoxControl7.CheckedIndices[i];
                    string itemText = checkedListBoxControl7.GetItemText(index);
                    itemText = itemText.Split(':')[0].Trim();
                    status += itemText + "q";
                }
                if (status.EndsWith("q"))
                {
                    status = status.Substring(0, status.Length - 1);
                }
                if (status != "")
                {
                   // MessageBox.Show(status);
                    gridControl7.DataSource = ds.gridFill("getprojectT", "status=4&comID=" + UserSession.LoggedComID + "&condition=" + Uri.EscapeDataString(status));
                    reportM4 rpt21 = new reportM4();
                    List<ReportData> reportDataList = new List<ReportData>();
                    for (int i = 0; i < gridView7.RowCount; i++)
                    {
                        long budget = long.Parse(gridView7.GetRowCellValue(i, "budget").ToString());
                       
                        reportDataList.Add(new ReportData
                        {
                            classner = gridView7.GetRowCellValue(i, "projectName").ToString().Trim() ,
                            classZahialagch = gridView7.GetRowCellValue(i, "zahialagch").ToString().Trim() + "  Утас:" + gridView7.GetRowCellValue(i, "zahialagchphone").ToString().Trim(),
                            classBudget = budget.ToString("#,0")+"₮",
                            classognoo1 = gridView7.GetRowCellValue(i, "ognoo1").ToString(),
                            classognoo2 = gridView7.GetRowCellValue(i, "ognoo2").ToString(),
                            classhaashaa = gridView7.GetRowCellValue(i, "location").ToString(),
                            classULSdugaar = gridView7.GetRowCellValue(i, "gereeNo").ToString()
                        });
                    }
                    rpt21.DataSource = reportDataList;
                    rpt21.mayagtnumber.Text = "Маягт №4";
                    rpt21.titletext.Text = "Ижил төстэй ажил гүйцэтгэсэн гэрээний мэдээлэл";
                    rpt21.projectName.DataBindings.Add(new XRBinding("Text", null, "classner"));
                    rpt21.zahialagch.DataBindings.Add(new XRBinding("Text", null, "classZahialagch"));
                    rpt21.budget.DataBindings.Add(new XRBinding("Text", null, "classBudget"));
                    rpt21.ognoo1.DataBindings.Add(new XRBinding("Text", null, "classognoo1"));
                    rpt21.ognoo2.DataBindings.Add(new XRBinding("Text", null, "classognoo2"));
                    

                    reportM6 rpt6 = new reportM6();

                    rpt6.DataSource = reportDataList;
                    rpt6.mayagtnumber.Text = "Маягт №6";
                    rpt6.titletext.Text = "Ижил төстэй гэрээний дэлгэрэнгүй мэдээлэл";
                    rpt6.projectName.DataBindings.Add(new XRBinding("Text", null, "classner","Гэрээний нэр: {0}"));
                    rpt6.zahialagch.DataBindings.Add(new XRBinding("Text", null, "classZahialagch", "Захиалагчийн нэр: {0}" ));
                    rpt6.budget.DataBindings.Add(new XRBinding("Text", null, "classBudget", "Төсөвт өртөг: {0}"));
                    rpt6.ognoo1.DataBindings.Add(new XRBinding("Text", null, "classognoo1", "Гэрээ байгуулсан огноо: {0}"));
                    rpt6.ognoo2.DataBindings.Add(new XRBinding("Text", null, "classognoo2", "Гэрээ дуусгавар болсон огноо: {0}"));
                    rpt6.locationP.DataBindings.Add(new XRBinding("Text", null, "classhaashaa", "Гэрээ гүйцэтгэсэн хаяг байршил: {0}"));
                    rpt6.gereeNo.DataBindings.Add(new XRBinding("Text", null, "classULSdugaar", "Гэрээний дугаар: {0}"));
                    rpt6.undsenesex.Text = "Үндсэн гүйцэтгэгч байгууллагаар ажилласан.";

                    // 1. XtraReport бүрийн Document үүсгэх
                    rpt21.CreateDocument();
                    rpt6.CreateDocument();

                    // 2. Нэгэн шинэ PrintingSystem үүсгээд хоёуланг нэгтгэх
                    PrintingSystem ps = new PrintingSystem();
                    ps.Pages.AddRange(rpt21.PrintingSystem.Pages);
                    ps.Pages.AddRange(rpt6.PrintingSystem.Pages);

                    // 3. Preview
                    PrintTool printTool = new PrintTool(ps);
                    printTool.ShowPreviewDialog();
                   
                }
                else
                {
                    MessageBox.Show("Ямар ч өгөгдөл сонгогдоогүй байна.");
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            finally { }
        }

        private void groupControl6_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                string status = "";
                for (int i = 0; i < checkedListBoxControl6.CheckedIndices.Count; i++)
                {
                    int index = checkedListBoxControl6.CheckedIndices[i];
                    string itemText = checkedListBoxControl6.GetItemText(index);
                    itemText = itemText.Split(':')[0].Trim();
                    status += itemText + "q";
                }
                if (status.EndsWith("q"))
                {
                    status = status.Substring(0, status.Length - 1);
                }
                if (status != "")
                {
                    //MessageBox.Show(status+""+UserSession.LoggedComID+"");
                    gridControl6.DataSource = ds.gridFill("getprojectT", "status=9&comID=" + UserSession.LoggedComID + "&condition=" + Uri.EscapeDataString(status));

                    reportM5 rpt5 = new reportM5();
                    List<ReportData> reportDataList = new List<ReportData>();
                    for (int i = 0; i < gridView6.RowCount; i++)
                    {
                        long budget = long.Parse(gridView6.GetRowCellValue(i, "budget").ToString());

                        reportDataList.Add(new ReportData
                        {
                            classner = gridView6.GetRowCellValue(i, "projectName").ToString().Trim(),
                            classZahialagch = gridView6.GetRowCellValue(i, "zahialagch").ToString().Trim() + "  Утас:" + gridView6.GetRowCellValue(i, "zahialagchphone").ToString().Trim(),
                            classBudget = budget.ToString("#,0") + "₮",
                            classognoo1 = gridView6.GetRowCellValue(i, "ognoo1").ToString(),
                            classognoo2 = gridView6.GetRowCellValue(i, "ognoo2").ToString(),
                            classhaashaa = gridView6.GetRowCellValue(i, "location").ToString(),
                            classULSdugaar = gridView6.GetRowCellValue(i, "gereeNo").ToString()
                            
                        });
                    }
                    rpt5.DataSource = reportDataList;
                    rpt5.mayagtnumber.Text = "Маягт №5";
                    rpt5.titletext.Text = "Хэрэгжүүлж байгаа, хэрэгжүүлэхээр эрх авсан гэрээний мэдээлэл";
                    rpt5.projectName.DataBindings.Add(new XRBinding("Text", null, "classner"));
                    rpt5.zahialagch.DataBindings.Add(new XRBinding("Text", null, "classZahialagch"));
                    rpt5.budget.DataBindings.Add(new XRBinding("Text", null, "classBudget"));
                    rpt5.ognoo1.DataBindings.Add(new XRBinding("Text", null, "classognoo1"));
                    rpt5.ognoo2.DataBindings.Add(new XRBinding("Text", null, "classognoo2"));
                    rpt5.huleegdejbui.Text = "99.9%";
                    rpt5.ShowPreview();

                }
                else
                {
                    MessageBox.Show("Ямар ч өгөгдөл сонгогдоогүй байна.");
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            finally { }

        }

        private void checkEdit6_CheckedChanged_1(object sender, EventArgs e)
        {
            checkEdit6_CheckedChanged(sender, e);
        }

        private void checkEdit2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkEdit2.Checked)
                {
                    checkedListBoxControl2.CheckAll();
                }
                else
                {
                    checkedListBoxControl2.UnCheckAll();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            finally { }
        }
    }
}
