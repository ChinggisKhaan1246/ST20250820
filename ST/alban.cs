using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Controls;
using System.Reflection;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrintingLinks;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.LookAndFeel;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.Utils;
using MySql.Data.MySqlClient;
using Word = Microsoft.Office.Interop.Word;
using Spire.Doc;
using Spire.Doc.Documents;
using Spire.Doc.Fields;
using Spire.Doc.Collections;
using Newtonsoft.Json;
using System.Collections.Specialized;
using System.Diagnostics;





namespace ST
{
    public partial class alban : Form
    {
        public alban()
        {
            InitializeComponent();
            gridView1.CustomUnboundColumnData += (sender, e) =>
            {
                DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
                if (e.Column.FieldName == "dd" && e.IsGetData)
                    e.Value = view.GetRowHandle(e.ListSourceRowIndex) + 1;
            };
            gridView2.CustomUnboundColumnData += (sender, e) =>
            {
                DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
                if (e.Column.FieldName == "dd2" && e.IsGetData)
                    e.Value = view.GetRowHandle(e.ListSourceRowIndex) + 1;
            };

        }
      //  MySqlConnection con = new MySqlConnection(Properties.Settings.Default.selbeg2ConnectionString);
        dataSetFill ds = new dataSetFill();
        public void FillGridIrsen()
        {
            try
            {
                gridControl2.DataSource = ds.gridFill("getalban", "albantype=irsen");
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
        }
        public void FillGridYavsan()
        {
            try
            {
                gridControl1.DataSource = ds.gridFill("getalban", "albantype=yavsan");
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
        }
        public void huh_Load(object sender, EventArgs e)
        {
            try
            {
                FillGridIrsen();
                FillGridYavsan();
                dateEdit1.DateTime = DateTime.Now;
                dateEdit2.DateTime = DateTime.Now;
            }
            catch (Exception ee)
            { MessageBox.Show(ee.ToString()); }
            finally {}

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            gridView1.ActiveFilterString = "";
        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {
            hai();
        }

        private void hai()
        {
            gridView1.ActiveFilterString = "bcode like '" + textEdit1.Text + "%' and ner like '" + textEdit2.Text + "%' and contname like '" + textEdit3.Text + "%'";
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            gridView1.ActiveFilterString = "ognoo >= '" + dateEdit1.DateTime.ToString("yyyy-MM-dd") + "%' and ognoo <= '" + dateEdit2.DateTime.ToString("yyyy-MM-dd") + "%' ";
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            printableComponentLink1.CreateDocument();
            PrintTool pt = new PrintTool(printableComponentLink1.PrintingSystemBase);
            
           
           // f.saveLogg(f.salerID.Text, "Татан авалтын түүх хэвлэсэн");
            pt.ShowPreviewDialog();
        }

        private void устгахToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                dataSetFill dc = new dataSetFill();
                string id = gridView1.GetFocusedRowCellValue("id").ToString();
                DialogResult ds = MessageBox.Show("Тухайн албан бичгийн мэдээллийг устгахдаа итгэлтэй байна уу.", "Анхаар", MessageBoxButtons.YesNo);
                if (ds == System.Windows.Forms.DialogResult.Yes)
                {
                    var data = new NameValueCollection();
                    data["ali_table"] = "alban";
                    data["deleteid"] = id;
                    MessageBox.Show(dc.exec_command("deleteAll", data));
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString()); 
            }
            finally 
            { 
                FillGridYavsan(); 
            }
        }

        private void gridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            
        }

        private void textEdit2_EditValueChanged(object sender, EventArgs e)
        {
            hai();
        }

        private void textEdit3_EditValueChanged(object sender, EventArgs e)
        {
            hai();
        }

        private void simpleButton3_Click_1(object sender, EventArgs e)
        {
            try
            {
                addbichig bb = new addbichig(this);
                bb.Bnumber.Text = gridView1.GetRowCellValue(0,"Bnumber").ToString();
                string v = bb.Bnumber.Text;
                string d = DateTime.Now.ToString("yyyy/MM/dd");
                bb.Bnumber.Text = d.Substring(2,2) + "/" + (Convert.ToInt16(v.Substring(v.IndexOf("/") + 1, v.Length - v.IndexOf("/") - 1))+1).ToString();
                bb.ShowDialog();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            finally { }
        }
       
        private void simpleButton2_Click_1(object sender, EventArgs e)
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

                string logo = "" + Application.StartupPath + "\\images\\header.jpg";
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
                oTable.Cell(1, 1).Range.Text = textEdit3.Text;
                oTable.Cell(1, 2).Range.Text = "№" + gridView1.GetFocusedRowCellValue("Bnumber").ToString();
                oTable.Cell(1, 3).Range.Text = gridView1.GetFocusedRowCellValue("ognooDoc").ToString();
                oTable.Cell(1, 1).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                oTable.Cell(1, 2).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                oTable.Cell(1, 3).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight;

                Word.Paragraph oPara11;
                oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
                oPara11 = oDoc.Content.Paragraphs.Add(ref oRng);
                oPara11.Range.Text = gridView1.GetFocusedRowCellValue("haanaas").ToString().ToUpper();
                oPara11.Range.Font.Bold = 1;
                oPara11.Range.Font.Size = 12;
                oPara11.Range.Font.Name = "Arial";
                oPara11.Format.SpaceAfter = 24;
                oPara11.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                oPara11.Range.InsertParagraphAfter();

                Word.Paragraph oPara3;
                oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;

                oPara3 = oDoc.Content.Paragraphs.Add(ref oRng);
                oPara3.Range.Text = "[" + gridView1.GetFocusedRowCellValue("tuhai").ToString() + "]";
                oPara3.Range.Font.Name = "Arial";
                oPara3.Range.Font.Bold = 0;
                oPara3.Range.Font.Size = 12;
                oPara3.Format.SpaceAfter = 16;
                oPara3.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight;
                oPara3.Range.InsertParagraphAfter();

                //insert Utga.
                Word.Paragraph oPara4;
                oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
                oPara4 = oDoc.Content.Paragraphs.Add(ref oRng);
                oPara4.Range.Font.Size = 12;
                //oPara4.Range.InsertParagraphBefore();
                oPara4.Range.Font.Name = "Arial";
                oPara4.Range.Text = "\t" + gridView1.GetFocusedRowCellValue("Utga").ToString();
                oPara4.Format.SpaceAfter = 48;
                oPara4.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphJustify;
                oPara4.Range.InsertParagraphAfter();

                wrdRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
                wrdRng.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                wrdRng.Font.Size = 12;
                wrdRng.Font.Bold = 1;
                wrdRng.InsertParagraphAfter();
                wrdRng.Font.Name = "Arial";
                wrdRng.InsertAfter("" + gridView1.GetFocusedRowCellValue("signTushaal").ToString().ToUpper() + "\t" + "\t" + "\t" + gridView1.GetFocusedRowCellValue("signName").ToString().ToUpper() + "");


            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            finally { }
        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            try
            {
                gridView1.ActiveFilterString = "ognoo >= '" + dateEdit1.DateTime.ToString("yyyy-MM-dd") + "'  and ognoo <= '" + dateEdit2.DateTime.ToString("yyyy-MM-dd") + "'";
            }
            catch (Exception ee)
            {
                MessageBox.Show("Алдаа:"+ee.ToString());
            }
        }

        private void тамгатайToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                reportalban rpA = new reportalban();
                rpA.ognoo.Text = gridView1.GetFocusedRowCellValue("ognooDoc").ToString();
                rpA.dugaar.Text = gridView1.GetFocusedRowCellValue("Bnumber").ToString();
                rpA.haashaa.Text = gridView1.GetFocusedRowCellValue("haanaas").ToString().ToUpper();
                rpA.tuhai.Text = gridView1.GetFocusedRowCellValue("tuhai").ToString();
                rpA.utga.Text = "              " + gridView1.GetFocusedRowCellValue("Utga").ToString() + "";
                //  rpA.utga.FormattingRules.;
                rpA.zaki.Text = gridView1.GetFocusedRowCellValue("signTushaal").ToString().ToUpper();
                rpA.zakiname.Text = gridView1.GetFocusedRowCellValue("signName").ToString().ToUpper();
                
                rpA.ShowPreview();
            }
            catch(Exception ee)
            { 
                MessageBox.Show(ee.ToString()); 
            }
            finally{}
        }

        private void тамгайгүйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                reportalban rpA = new reportalban();
                rpA.ognoo.Text = gridView1.GetFocusedRowCellValue("ognooDoc").ToString();
                rpA.dugaar.Text = gridView1.GetFocusedRowCellValue("Bnumber").ToString();
                rpA.haashaa.Text = gridView1.GetFocusedRowCellValue("haanaas").ToString().ToUpper();
                rpA.tuhai.Text = gridView1.GetFocusedRowCellValue("tuhai").ToString();
                rpA.utga.Text = "              "+gridView1.GetFocusedRowCellValue("Utga").ToString()+"";
                rpA.stamp.Visible = false;
                rpA.signature.Visible = false;
                //rpA.zaki.Text = "                         " + gridView1.GetFocusedRowCellValue("signTushaal").ToString().ToUpper() + "\t" + "\t" + "\t" + gridView1.GetFocusedRowCellValue("signName").ToString().ToUpper() + "";
                rpA.zaki.Text = gridView1.GetFocusedRowCellValue("signTushaal").ToString().ToUpper();
                rpA.zakiname.Text = gridView1.GetFocusedRowCellValue("signName").ToString().ToUpper();
                rpA.ShowPreview();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            finally { }
        }

        private void wordРууToolStripMenuItem_Click(object sender, EventArgs e)
        {
            simpleButton2_Click_1(sender, e);
        }

        private void засахToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                editAlban edL = new editAlban(this);
                edL.ID.Text = gridView1.GetFocusedRowCellValue("id").ToString();
                edL.Bnumber.Text = gridView1.GetFocusedRowCellValue("Bnumber").ToString();
                edL.tuhai.Text = gridView1.GetFocusedRowCellValue("tuhai").ToString();
                edL.haanaas.Text = gridView1.GetFocusedRowCellValue("haanaas").ToString();
                edL.Utga.Text = gridView1.GetFocusedRowCellValue("Utga").ToString();
                edL.signTushaal.Text = gridView1.GetFocusedRowCellValue("signTushaal").ToString();
                edL.signName.Text = gridView1.GetFocusedRowCellValue("signName").ToString();
                edL.ognooDoc.DateTime = Convert.ToDateTime(gridView1.GetFocusedRowCellValue("ognooDoc").ToString());
                edL.ShowDialog();
            }
            catch (Exception EE)
            {
                MessageBox.Show(EE.ToString());
            }
            finally { }
        }

       

        private void labelload_TextChanged_1(object sender, EventArgs e)
        {
            huh_Load(sender, e);
        }

        private void textEdit2_EditValueChanged_1(object sender, EventArgs e)
        {
            haihAlban();
        }

        private void haihAlban()
        {
            gridView1.ActiveFilterString = "Utga LIKE '%" + textEdit2.Text + "%'  or haanaas LIKE '%" + textEdit2.Text + "%'  or Bnumber LIKE '%" + textEdit2.Text + "%'";
        }

         private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                editirsenbichig edi = new editirsenbichig(this);
                edi.id.Text = gridView2.GetFocusedRowCellValue("id").ToString().Trim();
                edi.haanaas.Text = gridView2.GetFocusedRowCellValue("haanaas").ToString().Trim();
                edi.Bnumber.Text = gridView2.GetFocusedRowCellValue("Bnumber").ToString().Trim();
                edi.utga.Text = gridView2.GetFocusedRowCellValue("Utga").ToString().Trim();
                edi.ognoo.DateTime = Convert.ToDateTime(gridView2.GetFocusedRowCellValue("ognoo").ToString().Trim());
                edi.ognooDoc.DateTime = Convert.ToDateTime(gridView2.GetFocusedRowCellValue("ognooDoc").ToString().Trim());
                edi.ShowDialog();

            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            finally
            {
 
            }

        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            try
            {
                dataSetFill dc = new dataSetFill();
                string id = gridView2.GetFocusedRowCellValue("id").ToString();
                DialogResult ds = MessageBox.Show("Тухайн ирсэн албан бичгийн мэдээллийг устгахдаа итгэлтэй байна уу.", "Анхаар", MessageBoxButtons.YesNo);
                if (ds == System.Windows.Forms.DialogResult.Yes)
                {
                    var data = new NameValueCollection();
                    data["ali_table"] = "alban";
                    data["deleteid"] = id;
                    MessageBox.Show(dc.exec_command("deleteAll", data));
                }
            }
            catch (Exception ee)
            { 
                MessageBox.Show(ee.ToString()); 
            }
            finally 
            {
                FillGridIrsen();
            }
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

        private void textEdit5_EditValueChanged(object sender, EventArgs e)
        {
            gridView2.ActiveFilterString = "Utga LIKE '%" + textEdit5.Text + "%'  or haanaas LIKE '%" + textEdit5.Text + "%'  or Bnumber LIKE '%" + textEdit5.Text + "%'";
        }

        private void simpleButton4_Click_1(object sender, EventArgs e)
        {
            try
            {
                addirsenbichig adi = new addirsenbichig(this);
                adi.ShowDialog();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            finally { }
        }
        baseinfo userInfo = new baseinfo(UserSession.LoggedUserID);
        BaseUrl Url = new BaseUrl();
        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                var encode = gridView2.GetFocusedRowCellValue("filename").ToString().Replace(" ", "%20");

                if (encode != "")
                {
                    FileViewer vvr = new FileViewer(Url.GetUrl() + "dist/uploads/alban/irsen/" + encode);
                }
                else
                {
                    MessageBox.Show("Одоогоор хавсралт файл байхгүй.");
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            finally { }
        }
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                var encode = gridView1.GetFocusedRowCellValue("filename").ToString().Replace(" ", "%20");

                if (encode != "")
                {
                    FileViewer vvr = new FileViewer(Url.GetUrl() + "dist/uploads/alban/yavsan/" + encode);
                }
                else
                {
                    MessageBox.Show("Одоогоор хавсралт файл байхгүй.");
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            finally { }
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
                    PrintGridview.Print(
                    gridView1,
                    20, 15, 15, 12,  // Margin-ууд
                    gridView1.GroupPanelText,
                    "",
                    userInfo.comName,     // Header хэсэг
                    "Хэвлэсэн:" + userInfo.userName,
                    DateTime.Now.ToString("yyyy-MM-dd"), // Footer хэсэг
                    true // Landscape чиглэл
                    );
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            try
            {
                gridView1.ActiveFilterString = "ognoo >= '" + dateEdit3.DateTime.ToString("yyyy-MM-dd") + "'  and ognoo <= '" + dateEdit4.DateTime.ToString("yyyy-MM-dd") + "'";
            }
            catch (Exception ee)
            {
                MessageBox.Show("Алдаа:" + ee.ToString());
            }
        }
       
    }
}
