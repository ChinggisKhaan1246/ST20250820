using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;
using System.Net;
using System.Net.Http;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.LookAndFeel;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrintingLinks;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.Utils;
using DevExpress.XtraReports.UI;
using Word = Microsoft.Office.Interop.Word;
using System.Collections.Specialized;
using System.Diagnostics;


namespace ST
{
    public partial class tender : Form
    {

        Form1 f;  //eneii hereg bn u ter door hergelj bgaa yum bna ок
        public tender(Form1 ff)
        {
            InitializeComponent();
            f = ff;
            gridView1.CustomUnboundColumnData += (sender, e) =>
            {
                GridView view = sender as GridView;
                if (e.Column.FieldName == "dd" && e.IsGetData)
                    e.Value = view.GetRowHandle(e.ListSourceRowIndex) + 1;
            };
        }

        public void tender_Load(object sender, EventArgs e)
        {
            try
            {
                fillGridTender();
                dateEdit1.DateTime = DateTime.Now;
                dateEdit2.DateTime = DateTime.Now;
                dateEdit3.DateTime = DateTime.Now;
                string year = dateEdit1.DateTime.Year.ToString();
                textEdit1.Text = year;
                textEdit1.Properties.DropDownRows = textEdit1.Properties.Items.Count;
                

            }
            catch (Exception)
            {
                MessageBox.Show("Алдаа гарлаа");
            }
            finally
            {
 
            }


            
        }

        public void fillGridTender()
        {
            try
            {
                dataSetFill ds = new dataSetFill();
                gridControl1.DataSource = ds.gridFill("gettender", "status=0");
                GridView gridView = gridControl1.MainView as GridView;
                if (gridView != null)
                {
                    gridView.OptionsView.RowAutoHeight = true;
                    gridView.Appearance.Row.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
                    var nerColumn = gridView.Columns["ner"];
                    if (nerColumn != null)
                    {
                        nerColumn.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
                        nerColumn.Width = 200; // "ner" баганын өргөнийг тохируулах
                    }
                    gridView.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                    gridView.Appearance.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
                    gridView.LayoutChanged();
                }
            }
            catch (Exception ee)
            {
                 MessageBox.Show("Алдаа гарлаа: " + ee.Message + "\n" + ee.StackTrace);
            }
            finally { }
 
        }
        private void panelControl6_Paint(object sender, PaintEventArgs e)
        {
            // Add your painting logic here
        }

        private void ApplyTenderFilter()
        {
            string selectedYear = textEdit1.Text.Trim();         // Он
            string selectedStatus = comboBoxEdit1.Text.Trim();   // Төлөв (харагдах утга)

            string filter = "";

            // Статус текстийг код руу хөрвүүлнэ
            string statusValue = "";

            if (selectedStatus == "шалгарсан") statusValue = "9";
            else if (selectedStatus == "оролцох") statusValue = "5";
            else if (selectedStatus == "хасагдсан") statusValue = "4";
            else if (selectedStatus == "сонирхсон") statusValue = "0";

            // Статус filter (Бүгд биш үед)
            if (!string.IsNullOrEmpty(selectedStatus) && selectedStatus != "Бүгд")
            {
                filter += "status = " + statusValue;
            }

            // Он filter (Бүгд биш үед)
            if (!string.IsNullOrEmpty(selectedYear) && selectedYear != "Бүгд")
            {
                if (filter != "") filter += " AND ";
                filter += "ognooOpen LIKE '%" + selectedYear + "%'";
            }

            // GridView-д оноох
            gridView1.ActiveFilterString = filter;
        }



        private void simpleButton4_Click(object sender, EventArgs e)
        {
            try
            {
                addtender td = new addtender(this);
                td.ShowDialog();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            finally
            { }
        }

        private void label1_TextChanged(object sender, EventArgs e)
        {
            fillGridTender();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            //PrintGridview.Print(gridView1, 25, 20, 20, 15, "Миний Header Агуулга", "Page {0} of {1}", false);
        }

        private void textEdit5_EditValueChanged(object sender, EventArgs e)
        {
            haichih();
        }

        private void haichih()
        {
            try
            {
                gridView1.ActiveFilterString = "Tdugaar Like '%" + keytext.Text + "%' or Udugaar Like '%" + keytext.Text + "%' or ner Like '%" + keytext.Text + "%'";
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            finally { }
        }

        private void haichihYear()
        {
            try
            {
                gridView1.ActiveFilterString = "ognooOpen Like '%" + textEdit1.Text.Trim() + "%'";
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            finally { }
        }

        private void албанМэдэгдэлүүдToolStripMenuItem_Click(object sender, EventArgs e)
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
                oTable.Cell(1, 1).Range.Text = gridView1.GetFocusedRowCellValue("Nognoo").ToString();
                oTable.Cell(1, 2).Range.Text = "№" + gridView1.GetFocusedRowCellValue("Dognoo").ToString();
                oTable.Cell(1, 3).Range.Text = gridView1.GetFocusedRowCellValue("zahialagch").ToString();
                oTable.Cell(1, 1).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                oTable.Cell(1, 2).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                oTable.Cell(1, 3).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight;

                Word.Paragraph oPara11;
                oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;

                oPara11 = oDoc.Content.Paragraphs.Add(ref oRng);
                oPara11.Range.Text = gridView1.GetFocusedRowCellValue("zahialagch").ToString().ToUpper();
                oPara11.Range.Font.Bold = 1;
                oPara11.Range.Font.Size = 12;
                oPara11.Range.Font.Name = "Arial";
                oPara11.Format.SpaceAfter = 24;
                oPara11.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                oPara11.Range.InsertParagraphAfter();

                Word.Paragraph oPara3;
                oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;

                oPara3 = oDoc.Content.Paragraphs.Add(ref oRng);
                oPara3.Range.Text = "[" + gridView1.GetFocusedRowCellValue("zahialagch").ToString() + "]";
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
                oPara4.Range.Text = "\t" + gridView1.GetFocusedRowCellValue("zahialagch").ToString();
                oPara4.Format.SpaceAfter = 48;
                oPara4.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphJustify;
                oPara4.Range.InsertParagraphAfter();

                wrdRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
                wrdRng.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                wrdRng.Font.Size = 12;
                wrdRng.Font.Bold = 1;
                wrdRng.InsertParagraphAfter();
                wrdRng.Font.Name = "Arial";
                wrdRng.InsertAfter("" + gridView1.GetFocusedRowCellValue("zahialagch").ToString().ToUpper() + "\t" + "\t" + "\t" + gridView1.GetFocusedRowCellValue("zahialagch").ToString().ToUpper() + "");


            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            finally { }
        }
        dataSetFill dc = new dataSetFill();
        
        private void гэрээБүртгэхToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                addproject addp = new addproject(f);
                addp.locationP.Text = gridView1.GetFocusedRowCellValue("zahialagch").ToString();
                addp.projectName.Text = gridView1.GetFocusedRowCellValue("ner").ToString();
                addp.zahialagch.Text = gridView1.GetFocusedRowCellValue("zahialagch").ToString();
                var data = new NameValueCollection();
                data["id"] = gridView1.GetFocusedRowCellValue("id").ToString();
                data["status"] = "9";
                MessageBox.Show(dc.exec_command("edittender", data));
                addp.ShowDialog();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            finally { }
        }
        private void тендерийнБаталгааныХүсэлтToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                reportalban rpa = new reportalban();
                rpa.ognoo.Text = DateTime.Now.ToString("yyyy-MM-dd");
                rpa.tuhai.Text = "Тендерийн баталгаа гаргуулах тухай";
                rpa.dugaar.Text = "T34";
                rpa.utga.Text = "           Бид " + this.Text + " нь " + gridView1.GetFocusedRowCellValue("zahialagch").ToString() + "-c зарласан " + gridView1.GetFocusedRowCellValue("Udugaar").ToString() + " дугаартай \"" + gridView1.GetFocusedRowCellValue("ner").ToString() + "\" тендерийн сонгон шалгаруулалтад оролцох болсон тул \"" + (Convert.ToInt32(((Convert.ToDouble(gridView1.GetFocusedRowCellValue("niittusuv").ToString())) * 0.005))).ToString() + "₮\" төгрөгийн үнийн дүн бүхий тендерийн баталгааг  гаргаж өгнө үү. Манай компанийн данс: 5540385329";
                rpa.haashaa.Text = "ХААНБАНК-Д";
                rpa.ShowPreview();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            finally { }
        }

        private void түргэнХөрвөхХөрөнгийнТодорхойлолтБанкToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                reportalban rpa = new reportalban();
                rpa.ognoo.Text = DateTime.Now.ToString("yyyy-MM-dd");
                rpa.tuhai.Text = "Тодорхойлолт хүсэх тухай";
                rpa.dugaar.Text = "C34";
                rpa.utga.Text = "           Бид " + this.Text + " нь " + gridView1.GetFocusedRowCellValue("zahialagch").ToString() + "-c зарласан " + gridView1.GetFocusedRowCellValue("Udugaar").ToString() + " дугаартай '" + gridView1.GetFocusedRowCellValue("ner").ToString() + "' тендер сонгон шалгаруулалтад оролцох тул авч болох зээлийн хэмжээний талаар тодорхойлолтыг инженер П.Мөнхбаатарт (ЙЮ83051811) гаргаж өгнө үү. Манай компанийн данс: 5540385329";
                rpa.haashaa.Text = "" + gridView1.GetFocusedRowCellValue("zahialagch").ToString() + "-НД";
                rpa.haashaa.Text = "ХААНБАНК-нд";
                rpa.ShowPreview();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            finally { }
        }

        private void тендерийнБаталгууЦуцлуулахХүсэлтToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                reportalban rpa = new reportalban();
                rpa.ognoo.Text = DateTime.Now.ToString("yyyy-MM-dd");
                rpa.tuhai.Text = "Тендерийн баталгаа цуцлуулах тухай";
                rpa.dugaar.Text = "C34";
                rpa.utga.Text = "           Бид " + this.Text + " нь " + gridView1.GetFocusedRowCellValue("Udugaar").ToString() + " дугаартай " + gridView1.GetFocusedRowCellValue("ner").ToString() + " тендер сонгон шалгаруулалтад оролцсон ба тендер шалгаруулалтын үр дүр гарсан байх тул бидний илгээсэн тендерийн баталгааг цуцлаж өгнө үү.";
                rpa.haashaa.Text = "" + gridView1.GetFocusedRowCellValue("zahialagch").ToString() + "-НД";
                rpa.ShowPreview();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            finally { }
        }

        private void хААНБАНКToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                reportalban rpa = new reportalban();
                rpa.ognoo.Text = DateTime.Now.ToString("yyyy-MM-dd");
                rpa.tuhai.Text = "Тодорхойлолт хүсэх тухай";
               // rpa.haashaa.Text = хААНБАНКToolStripMenuItem.Text + "-нд";
                rpa.dugaar.Text = "C34";
                rpa.utga.Text = "           Бид " + this.Text + " нь " + gridView1.GetFocusedRowCellValue("zahialagch").ToString() + "-c зарласан " + gridView1.GetFocusedRowCellValue("Udugaar").ToString() + " дугаартай '" + gridView1.GetFocusedRowCellValue("ner").ToString() + "' тендер сонгон шалгаруулалтад оролцох тул хугацаа хэтэрсэн өр,  хүүгийн өргүй болох талаар тодорхойлолтыг инженер П.Мөнхбаатарт (ЙЮ83051811) гаргаж өгнө үү. Манай компанийн данс: 5540385329";
                rpa.ShowPreview();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            finally { }
        }

        private void тӨРИЙНБАНКToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                reportalban rpa = new reportalban();
                rpa.ognoo.Text = DateTime.Now.ToString("yyyy-MM-dd");
                rpa.tuhai.Text = "Тодорхойлолт хүсэх тухай";
               // rpa.haashaa.Text = тӨРИЙНБАНКToolStripMenuItem.Text + "-нд";
                rpa.dugaar.Text = "C34";
                rpa.utga.Text = "           Бид " + this.Text + " нь " + gridView1.GetFocusedRowCellValue("zahialagch").ToString() + "-c зарласан " + gridView1.GetFocusedRowCellValue("Udugaar").ToString() + " дугаартай '" + gridView1.GetFocusedRowCellValue("ner").ToString() + "' тендер сонгон шалгаруулалтад оролцох тул хугацаа хэтэрсэн өр,  хүүгийн өргүй болох талаар тодорхойлолтыг инженер П.Мөнхбаатарт (ЙЮ83051811) гаргаж өгнө үү. Манай компанийн данс: 5540385329";
                rpa.ShowPreview();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            finally { }
        }

        private void хАСБАНКToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                reportalban rpa = new reportalban();
                rpa.ognoo.Text = DateTime.Now.ToString("yyyy-MM-dd");
                rpa.tuhai.Text = "Тодорхойлолт хүсэх тухай";
               // rpa.haashaa.Text = хАСБАНКToolStripMenuItem.Text + "-нд";
                rpa.dugaar.Text = "C34";
                rpa.utga.Text = "           Бид " + this.Text + " нь " + gridView1.GetFocusedRowCellValue("zahialagch").ToString() + "-c зарласан " + gridView1.GetFocusedRowCellValue("Udugaar").ToString() + " дугаартай '" + gridView1.GetFocusedRowCellValue("ner").ToString() + "' тендер сонгон шалгаруулалтад оролцох тул хугацаа хэтэрсэн өр,  хүүгийн өргүй болох талаар тодорхойлолт гаргаж өгнө үү. Манай компанийн данс: 5540385329";
                rpa.ShowPreview();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            finally { }
        }

        private void хУДАЛДААХӨГЖИЙНБАНКToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                reportalban rpa = new reportalban();
                rpa.ognoo.Text = DateTime.Now.ToString("yyyy-MM-dd");
                rpa.tuhai.Text = "Тодорхойлолт хүсэх тухай";
               // rpa.haashaa.Text = хУДАЛДААХӨГЖИЙНБАНКToolStripMenuItem.Text + "нд";
                rpa.dugaar.Text = "C34";
                rpa.utga.Text = "           Бид " + this.Text + " нь " + gridView1.GetFocusedRowCellValue("zahialagch").ToString() + "-c зарласан " + gridView1.GetFocusedRowCellValue("Udugaar").ToString() + " дугаартай '" + gridView1.GetFocusedRowCellValue("ner").ToString() + "' тендер сонгон шалгаруулалтад оролцох тул хугацаа хэтэрсэн өр,  хүүгийн өргүй болох талаар тодорхойлолт гаргаж өгнө үү. Манай компанийн данс: 5540385329";
                rpa.ShowPreview();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            finally { }
        }

        private void гОЛОМТБАНКToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                reportalban rpa = new reportalban();
                rpa.ognoo.Text = DateTime.Now.ToString("yyyy-MM-dd");
                rpa.tuhai.Text = "Тодорхойлолт хүсэх тухай";
                //rpa.haashaa.Text = гОЛОМТБАНКToolStripMenuItem.Text + "-нд";
                rpa.dugaar.Text = "C34";
                rpa.utga.Text = "           Бид " + this.Text + " нь " + gridView1.GetFocusedRowCellValue("zahialagch").ToString() + "-c зарласан " + gridView1.GetFocusedRowCellValue("Udugaar").ToString() + " дугаартай '" + gridView1.GetFocusedRowCellValue("ner").ToString() + "' тендер сонгон шалгаруулалтад оролцох тул хугацаа хэтэрсэн өр,  хүүгийн өргүй болох талаар тодорхойлолт гаргаж өгнө үү. Манай компанийн данс: 5540385329";
                rpa.ShowPreview();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            finally { }
        }

        private void хасагдсанТэмдэToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
                
        }

        private void gridView1_RowStyle(object sender, RowStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                string status = View.GetRowCellDisplayText(e.RowHandle, View.Columns["status"]);
                if (status == "9")
                {
                    e.Appearance.BackColor = Color.FromArgb(150, Color.Yellow);
                    // e.Appearance.BackColor2 = Color.FromArgb(150, Color.LightBlue);

                }
                if ((status == "4"))
                {
                    e.Appearance.BackColor = Color.FromArgb(150, Color.Salmon);
                    // ** e.Appearance.BackColor2 = Color.FromArgb(150, Color.Salmon);
                }

                if ((status == "5"))
                {
                    e.Appearance.BackColor = Color.FromArgb(150, Color.LightSkyBlue);
                    // e.Appearance.BackColor2 = Color.FromArgb(150, Color.Salmon);
                }

                if ((status == "0"))
                {
                    e.Appearance.BackColor = Color.FromArgb(150, Color.White);
                    // e.Appearance.BackColor2 = Color.FromArgb(150, Color.Salmon);
                }
            }
        }

        private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
           if (e.Column.FieldName == "status")
            {
                if (e.Value.ToString() == "0")
                {
                    e.DisplayText = "сонирхсон";
                }
                else if (e.Value.ToString() == "4")
                {
                    e.DisplayText = "хасагдсан";
                }
                else if (e.Value.ToString() == "9")
                {
                    e.DisplayText = "шалгарсан";
                }
                else if (e.Value.ToString() == "5")
                {
                    e.DisplayText = "оролцох";
                }
            } 
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                Process.Start("chrome.exe", gridView1.GetFocusedRowCellValue("URL").ToString().Trim());
            }
            catch (Exception)
            {
                MessageBox.Show("Chrome суулгачих");
            }
        }

        private void урилгаХэвлэхToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                invite rpi = new invite();
                rpi.utga.LoadDocument(gridView1.GetFocusedRowCellValue("bigtext").ToString());
                rpi.ShowDialog();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            finally
            {
 
            }
        }

        private void устгахToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            try
            {
                dataSetFill dc = new dataSetFill();
                string id = gridView1.GetFocusedRowCellValue("id").ToString();
                DialogResult ds = MessageBox.Show("Тухайн tender-ийн мэдээллийг устгахдаа итгэлтэй байна уу.", "Анхаар", MessageBoxButtons.YesNo);
                if (ds == System.Windows.Forms.DialogResult.Yes)
                {
                    var data = new NameValueCollection();
                    data["deleteid"] = id;
                    data["ali_table"] = "tender";
                    MessageBox.Show(dc.exec_command("deleteAll", data));
                }
            }
            catch (Exception ee)
            { 
                MessageBox.Show(ee.ToString()); 
            }
            finally
            {
                tender_Load(sender, e);
            }
        }

        private void тоотуудToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                tendermat tendm = new tendermat();
                tendm.tenderID.Text = gridView1.GetFocusedRowCellValue("id").ToString();
                tendm.tendName.Text = gridView1.GetFocusedRowCellValue("ner").ToString();
                tendm.tendCode.Text = gridView1.GetFocusedRowCellValue("Udugaar").ToString();
                tendm.tendZahi.Text = gridView1.GetFocusedRowCellValue("zahialagch").ToString();
                tendm.ognoo.DateTime = Convert.ToDateTime(gridView1.GetFocusedRowCellValue("ognooOpen").ToString());
                tendm.ShowDialog();
                this.Hide();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            finally { this.Hide(); }
           
        }

        private void tender_Activated(object sender, EventArgs e)
        {
            //f.odooGridFill();//ИНгэчих үү энэ form active хий
        }

        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyTenderFilter();
        }
        private void changeTenderStatus(string status)
        {
            try
            {
                var data = new NameValueCollection();
                data["id"] = gridView1.GetFocusedRowCellValue("id").ToString();
                data["status"] = status;
                MessageBox.Show(dc.exec_command("edittender", data));
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            finally { fillGridTender(); }
        }
        private void хасагдсанToolStripMenuItem_Click(object sender, EventArgs e)
        {
            changeTenderStatus("4"); 
        }

        private void шалгарсанToolStripMenuItem_Click(object sender, EventArgs e)
        {
            changeTenderStatus("9"); 
        }

        private void сонирхсонToolStripMenuItem_Click(object sender, EventArgs e)
        {
            changeTenderStatus("0"); 
        }

        private void оролцохToolStripMenuItem_Click(object sender, EventArgs e)
        {
            changeTenderStatus("5"); 
        }

        private void dateEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void textEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (textEdit1.Text == "Бүгд")
            {
                gridView1.ActiveFilterString = "";
            }
            else
            {
                ApplyTenderFilter();
            }
            
        }

        private void textEdit1_TextChanged(object sender, EventArgs e)
        {
            haichihYear();
        }

    }
}
