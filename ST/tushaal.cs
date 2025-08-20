using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.LookAndFeel;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrintingLinks;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.Utils;
using System.Collections.Specialized;
using Word = Microsoft.Office.Interop.Word;
using Spire.Doc;
using Spire.Doc.Documents;
using Spire.Doc.Fields;
using Spire.Doc.Collections;
using DxPrinting = DevExpress.XtraPrinting;
using System.Web; 


namespace ST
{
    public partial class ZeelList : Form
    {
        public ZeelList()
        {
            InitializeComponent();
           

            gridView2.CustomUnboundColumnData += (sender, e) =>
            {
                GridView view = sender as GridView;
                if (e.Column.FieldName == "dd" && e.IsGetData)
                    e.Value = view.GetRowHandle(e.ListSourceRowIndex) + 1;
            };
        }
        dataSetFill ds = new dataSetFill();
        baseinfo userInfo = new baseinfo(UserSession.LoggedUserID);
        public void ZeelList_Load(object sender, EventArgs e)
        {
            try
            {
                dateEdit1.EditValue = DateTime.Now;
                dateEdit2.EditValue = DateTime.Now;
                gridControl2.DataSource = ds.gridFill("gettushaal");
            }
            catch (Exception ee)
            { MessageBox.Show(ee.ToString()); }
            finally { }
        }

        private void textEdit2_EditValueChanged(object sender, EventArgs e)
        {
            
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                gridView2.ActiveFilterString = "ognooDoc >= '" + dateEdit1.DateTime.ToString("yyyy-MM-dd") + "%' and ognooDoc <= '" + dateEdit2.DateTime.ToString("yyyy-MM-dd") + "%' ";
            }
            catch (Exception ee)
            {
                MessageBox.Show("Алдаа: "+ee.ToString());
            }
            finally { }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            try
            {
                addtushaal adT = new addtushaal(this);
                adT.Tnumber.Text = gridView2.GetRowCellValue(0, "Tnumber").ToString();
                string v = adT.Tnumber.Text;
                string d = DateTime.Now.ToString("yyyy/MM/dd");
                adT.Tnumber.Text = "T"+d.Substring(2, 2) + "/" + (Convert.ToInt16(v.Substring(v.IndexOf("/") + 1, v.Length - v.IndexOf("/") - 1)) + 1).ToString();
                adT.ShowDialog();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            finally { }
        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                gridView2.ActiveFilterString = "Utga like '%" + textEdit1.Text + "%'";
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            finally { }
        }

        private void засахToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                editTushaal edT = new editTushaal(this);
                edT.ID.Text = gridView2.GetFocusedRowCellValue("id").ToString();
                edT.Tnumber.Text = gridView2.GetFocusedRowCellValue("Tnumber").ToString();
                edT.tuhai.Text = gridView2.GetFocusedRowCellValue("tuhai").ToString();
                string justifiedRtf = @"{\rtf1\ansi\ansi\deff0\pard\qj " + gridView2.GetFocusedRowCellValue("Utga").ToString() + @"\par}";
               // edT.Utga.RtfText = @gridView2.GetFocusedRowCellValue("Utga").ToString();
                
                edT.Utga.Text = gridView2.GetFocusedRowCellValue("UtgaNormal").ToString();
                edT.signTushaal.Text = gridView2.GetFocusedRowCellValue("signTushaal").ToString();
                edT.signName.Text = gridView2.GetFocusedRowCellValue("signName").ToString();
                edT.ognooDoc.DateTime = Convert.ToDateTime(gridView2.GetFocusedRowCellValue("ognooDoc").ToString());
                edT.ShowDialog();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            finally { }
        }

        private void устгахToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                dataSetFill dc = new dataSetFill();
                string id = gridView2.GetFocusedRowCellValue("id").ToString();
                DialogResult ds = MessageBox.Show("Тухайн тушаалыг устгахдаа итгэлтэй байна уу.", "Анхаар", MessageBoxButtons.YesNo);
                if (ds == System.Windows.Forms.DialogResult.Yes)
                {
                    var data = new NameValueCollection();
                    data["deleteid"] = id;
                    data["ali_table"] = "tushaal";
                    ZeelList_Load(sender, e);
                    MessageBox.Show(dc.exec_command("deleteAll", data));
                    
                }
            }
            catch (Exception ee)
            { MessageBox.Show(ee.ToString()); }
            finally { }
        }

        private void labelloader_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ZeelList_Load(sender, e);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            finally { }
        }

        private void wordРууToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                object oMissing = System.Reflection.Missing.Value;
                object oEndOfDoc = "\\endofdoc"; /* \endofdoc is a predefined bookmark */
                object missing = System.Reflection.Missing.Value;

                Word.Application oWord = new Word.Application();
                oWord = new Word.Application();
                oWord.Visible = true;
                Word.Document oDoc = oWord.Documents.Add(ref missing, ref missing, ref missing, ref missing);

                string logo = "" + Application.StartupPath + "\\images\\headerT.jpg";
                string logo2 = "" + Application.StartupPath + "\\images\\footer.jpg";
               

                foreach (Word.Section section in oDoc.Sections)
                {
                    Word.HeaderFooter headerRange = section.Headers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary];
                    Word.Shape oshape = headerRange.Shapes.AddPicture(logo, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing);
                    oshape.WrapFormat.Type = Word.WdWrapType.wdWrapFront;
                }

                foreach (Word.Section wordSection in oDoc.Sections)
                {
                    Word.HeaderFooter footerRange = wordSection.Footers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary];
                    Word.Shape oshape = footerRange.Shapes.AddPicture(logo2, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing);
                }
                object oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;

                Word.Paragraph oParaEmpty;
                oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
                oParaEmpty = oDoc.Content.Paragraphs.Add(ref oRng);
                oParaEmpty.Format.SpaceBefore = 60;
                oParaEmpty.Range.Font.Size = 4;
                //oParaEmpty.Range.InsertParagraphAfter();

                Word.Table oTable;
                Word.Range wrdRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;

                oTable = oDoc.Tables.Add(wrdRng, 2, 3, ref oMissing, ref oMissing);
                // oTable.Range.ParagraphFormat.SpaceBefore = 60;
                oTable.Range.ParagraphFormat.SpaceAfter = 24;
                oTable.Range.Font.Name = "Arial";
                oTable.Cell(2, 1).Range.Text = gridView2.GetFocusedRowCellValue("ognooDoc").ToString();
                oTable.Cell(2, 2).Range.Text = "№" + gridView2.GetFocusedRowCellValue("Tnumber").ToString();
                oTable.Cell(2, 3).Range.Text = textEdit3.Text;
                
                oTable.Cell(2, 1).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                oTable.Cell(2, 2).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                oTable.Cell(2, 3).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight;

                 Word.Paragraph oPara11;
                oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;

                oPara11 = oDoc.Content.Paragraphs.Add(ref oRng);
                oPara11.Range.Text = "";
                oPara11.Range.Font.Bold = 1;
                oPara11.Range.Font.Size = 12;
                oPara11.Range.Font.Name = "Arial";
                oPara11.Format.SpaceAfter = 24;
                oPara11.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                oPara11.Range.InsertParagraphAfter();
                
               
                
                Word.Paragraph oPara3;
                oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
                oPara3 = oDoc.Content.Paragraphs.Add(ref oRng);
                oPara3.Range.Text = "" + gridView2.GetFocusedRowCellValue("tuhai").ToString() + "";
                oPara3.Range.Font.Name = "Arial";
                oPara3.Range.Font.Bold = 0;
                oPara3.Range.Font.Size = 12;
                oPara3.Format.SpaceAfter = 16;
                oPara3.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                oPara3.Range.InsertParagraphAfter();
                
                //insert Utga.
                Word.Paragraph oPara4;
                oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
                oPara4 = oDoc.Content.Paragraphs.Add(ref oRng);
                oPara4.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphJustify;
                oPara4.Range.Font.Size = 11;
                oPara4.Range.InsertParagraphBefore();
                oPara4.Range.Font.Name = "Arial";
                oPara4.Range.Text = "\t" + gridView2.GetFocusedRowCellValue("UtgaNormal").ToString();
                oPara4.Format.SpaceAfter = 16;
                
                oPara4.Range.InsertParagraphAfter();

                wrdRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
                wrdRng.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                wrdRng.Font.Size = 12;
                wrdRng.Font.Bold = 1;
                wrdRng.InsertParagraphAfter();
                wrdRng.Font.Name = "Arial";
                wrdRng.InsertAfter("" + gridView2.GetFocusedRowCellValue("signTushaal").ToString().ToUpper() + "\t" + "\t" + "\t" + gridView2.GetFocusedRowCellValue("signName").ToString().ToUpper() + "");


            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            finally { }
        }

        private void тамгатайToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                reporttushaal rpT = new reporttushaal();
                rpT.ognooDoc.Text = gridView2.GetFocusedRowCellValue("ognooDoc").ToString();
                rpT.Tnumber.Text = gridView2.GetFocusedRowCellValue("Tnumber").ToString();
                rpT.tuhai.Text = gridView2.GetFocusedRowCellValue("tuhai").ToString();
                string justifiedRtf = @"{\rtf1\ansi\ansi\deff0\pard\qj " + gridView2.GetFocusedRowCellValue("Utga").ToString() + @"\par}";
                rpT.Utga.Rtf = @gridView2.GetFocusedRowCellValue("Utga").ToString();
                rpT.City.Text = textEdit3.Text;
                rpT.signTushaal.Text = gridView2.GetFocusedRowCellValue("signTushaal").ToString().ToUpper();
                rpT.signName.Text = gridView2.GetFocusedRowCellValue("signName").ToString().ToUpper();
                rpT.ShowPreview();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            finally { }
        }

        private void тамгайгүйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                reporttushaal rpT = new reporttushaal();
                rpT.ognooDoc.Text = gridView2.GetFocusedRowCellValue("ognooDoc").ToString();
                rpT.Tnumber.Text = gridView2.GetFocusedRowCellValue("Tnumber").ToString();
                rpT.tuhai.Text = gridView2.GetFocusedRowCellValue("tuhai").ToString();
                string justifiedRtf = @"{\rtf1\ansi\ansi\deff0\pard\qj " + gridView2.GetFocusedRowCellValue("Utga").ToString() + @"\par}";
                rpT.Utga.Rtf = @gridView2.GetFocusedRowCellValue("Utga").ToString();
                rpT.City.Text = textEdit3.Text;
                rpT.signTushaal.Text = gridView2.GetFocusedRowCellValue("signTushaal").ToString().ToUpper();
                rpT.signName.Text = gridView2.GetFocusedRowCellValue("signName").ToString().ToUpper();
                rpT.stamp.Visible = false;
                rpT.signature.Visible = false;
                rpT.ShowPreview();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            finally { }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }

        private void gridControl2_DoubleClick(object sender, EventArgs e)
        {
            //MessageBox.Show(HttpUtility.HtmlDecode(gridView2.GetFocusedRowCellValue("Utga").ToString()));            
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
           PrintGridview.Print(
           gridView2,
           20, 15, 15, 12,  // Margin-ууд
           gridView2.GroupPanelText,
           "",
           userInfo.comName,     // Header хэсэг
           "Хэвлэсэн:" + userInfo.userName,
           DateTime.Now.ToString("yyyy-MM-dd"), // Footer хэсэг
           false // Landscape чиглэл
           );
        }
    }
}
