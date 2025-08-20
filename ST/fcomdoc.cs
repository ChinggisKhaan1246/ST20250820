using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.LookAndFeel;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrintingLinks;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.Utils;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Net.NetworkInformation;
using System.Management;
using System.Diagnostics;
using System.Web;

namespace ST
{
    public partial class fcomdoc : Form
    {
        public fcomdoc()
        {
            InitializeComponent();
            gridView1.CustomUnboundColumnData += (sender, e) =>
            {
                GridView view = sender as GridView;
                if (e.Column.FieldName == "dd" && e.IsGetData)
                    e.Value = view.GetRowHandle(e.ListSourceRowIndex) + 1;
            };

            gridView2.CustomUnboundColumnData += (sender, e) =>
            {
                GridView view = sender as GridView;
                if (e.Column.FieldName == "dd2" && e.IsGetData)
                    e.Value = view.GetRowHandle(e.ListSourceRowIndex) + 1;
            };
            gridView3.CustomUnboundColumnData += (sender, e) =>
            {
                GridView view = sender as GridView;
                if (e.Column.FieldName == "dd3" && e.IsGetData)
                    e.Value = view.GetRowHandle(e.ListSourceRowIndex) + 1;
            };
            gridView4.CustomUnboundColumnData += (sender, e) =>
            {
                GridView view = sender as GridView;
                if (e.Column.FieldName == "dd4" && e.IsGetData)
                    e.Value = view.GetRowHandle(e.ListSourceRowIndex) + 1;
            };


           
        }
        dataSetFill ds = new dataSetFill();
        public void hish_Load(object sender, EventArgs e)
        {
            try
            {
                gridControl1.DataSource = ds.gridFill("getcomdoc", "doctype=companyM");
                gridControl2.DataSource = ds.gridFill("getcomdoc", "doctype=companyS");
                gridControl3.DataSource = ds.gridFill("getcomdoc", "doctype=companyA");
                gridControl4.DataSource = ds.gridFill("getcomdoc", "doctype=companyN");
                dateEdit1.EditValue = DateTime.Now;
            }
            catch (Exception ee)
            { MessageBox.Show(ee.ToString()); }
            finally { }

        }

        private void hai()
        {

            if (xtraTabControl1.SelectedTabPageIndex == 0)
            {
                gridView1.ActiveFilterString = "docname like '%" + textEdit1.Text + "%' and URL like '%" + textEdit2.Text + "%' and tailbar like '" + textEdit3.Text + "%' and doctype = 'companyM' and projectID = '0'";
            }
            if (xtraTabControl1.SelectedTabPageIndex == 1)
            {
                gridView2.ActiveFilterString = "docname like '%" + textEdit1.Text + "%' and URL like '%" + textEdit2.Text + "%' and tailbar like '" + textEdit3.Text + "%' and doctype = 'companyS' and projectID = '0'";
            }

            if (xtraTabControl1.SelectedTabPageIndex == 2)
            {
                gridView3.ActiveFilterString = "docname like '%" + textEdit1.Text + "%' and URL like '%" + textEdit2.Text + "%' and tailbar like '" + textEdit3.Text + "%' and doctype = 'companyA' and projectID = '0'";
            }
            if (xtraTabControl1.SelectedTabPageIndex == 3)
            {
                gridView4.ActiveFilterString = "docname like '%" + textEdit1.Text + "%' and URL like '%" + textEdit2.Text + "%' and tailbar like '" + textEdit3.Text + "%' and doctype = 'companyN' and projectID = '0'";
            }
       
           
        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {
            hai();
        }

        private void textEdit2_EditValueChanged(object sender, EventArgs e)
        {
            hai();
        }

        private void textEdit3_EditValueChanged(object sender, EventArgs e)
        {
            hai();
        }
        
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            hai();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            addcomdoc d = new addcomdoc(this);
            if (xtraTabControl1.SelectedTabPageIndex == 0)
            {
               
                d.projectID.Text = "0";
                d.doctype.Text = "companyM";
                d.Text = "Үндсэн бичиг баримт нэмэх";
            }
            if (xtraTabControl1.SelectedTabPageIndex == 1)
            {
               
                d.projectID.Text = "0";
                d.doctype.Text = "companyS";
                d.Text = "Санхүүгийн тайлан нэмэх";
            }

            if (xtraTabControl1.SelectedTabPageIndex == 2)
            {
               
                d.projectID.Text = "0";
                d.doctype.Text = "companyA";
                d.Text = "Аудитын тайлан нэмэх";
            }
            if (xtraTabControl1.SelectedTabPageIndex == 3)
            {
               
                d.projectID.Text = "0";
                d.doctype.Text = "companyN";
                d.Text = "Нийгмийн даатгалын тайлан нэмэх";
            }
           
           
            d.ShowDialog();
            //gridView1.ActiveFilterString = "doctype LIKE 'companyM'";
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            printableComponentLink1.CreateDocument();
            PrintTool pt = new PrintTool(printableComponentLink1.PrintingSystemBase);
            
            pt.ShowPreviewDialog();

           // f.saveLogg(f.salerID.Text, f.salerName.Text, "Шилжүүлэгчийн түүх хэвлэсэн");
           
        }

        private void устгахToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                dataSetFill dcd = new dataSetFill();
                var data = new NameValueCollection();

                DialogResult ds = MessageBox.Show("Мэдээллийг устгахдаа итгэлтэй байна уу.", "Анхаар", MessageBoxButtons.YesNo);
                if (ds == System.Windows.Forms.DialogResult.Yes)
                {
                    if (xtraTabControl1.SelectedTabPageIndex == 0)
                    {
                        data["deleteid"] = gridView1.GetFocusedRowCellValue("id").ToString();
                        data["deletetype"] = "companyM";
                        data["URL11"] = gridView1.GetFocusedRowCellValue("URL").ToString();
                    }
                    if (xtraTabControl1.SelectedTabPageIndex == 1)
                    {
                        data["deleteid"] = gridView2.GetFocusedRowCellValue("id").ToString();
                        data["deletetype"] = "companyS";
                        data["URL11"] = gridView2.GetFocusedRowCellValue("URL").ToString();
                    }

                    if (xtraTabControl1.SelectedTabPageIndex == 2)
                    {
                        data["deleteid"] = gridView3.GetFocusedRowCellValue("id").ToString();
                        data["deletetype"] = "companyA";
                        data["URL11"] = gridView3.GetFocusedRowCellValue("URL").ToString();
                    }
                    if (xtraTabControl1.SelectedTabPageIndex == 3)
                    {
                        data["deleteid"] = gridView4.GetFocusedRowCellValue("id").ToString();
                        data["deletetype"] = "companyN";
                        data["URL11"] = gridView4.GetFocusedRowCellValue("URL").ToString();
                    }
                    MessageBox.Show(dcd.exec_command("deletecomdoc", data));
                }
            }
            catch (Exception ee)
            { MessageBox.Show(ee.ToString()); }
            finally { this.hish_Load(sender, e); }
        }

        private void gridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.IsGetData && e.Column.FieldName == "dd")
            {
                //e.Value = e.RowHandle + 1;
            }
        }

        private void gridControl1_DoubleClick_1(object sender, EventArgs e)
        {
           
        }

        private void gridControl2_DoubleClick(object sender, EventArgs e)
        {
           
        }

        private void gridControl3_DoubleClick(object sender, EventArgs e)
        {
           
        }

        private void gridControl4_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void xtraTabControl1_DoubleClick(object sender, EventArgs e)
        {
           
        }

        private void gridControl5_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void gridControl5_DoubleClick_1(object sender, EventArgs e)
        {
           
        }

        private void gridControl4_DoubleClick_1(object sender, EventArgs e)
        {
            try
            {
                var encode = gridView4.GetFocusedRowCellValue("URL").ToString().Replace(" ", "%20");



                Process.Start("chrome.exe", "https://selbeg.shop/devsoft/dist/uploads/company/" + encode + "");
                // MessageBox.Show(encode);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            finally { }
        }

        private void gridControl3_DoubleClick_1(object sender, EventArgs e)
        {
            try
            {
                var encode = gridView3.GetFocusedRowCellValue("URL").ToString().Replace(" ", "%20");



                Process.Start("chrome.exe", "https://selbeg.shop/devsoft/dist/uploads/company/" + encode + "");
                // MessageBox.Show(encode);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            finally { }
        }

        private void gridControl2_DoubleClick_1(object sender, EventArgs e)
        {
            try
            {
                var encode = gridView2.GetFocusedRowCellValue("URL").ToString().Replace(" ", "%20");



                Process.Start("chrome.exe", "https://selbeg.shop/devsoft/dist/uploads/company/" + encode + "");
                // MessageBox.Show(encode);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            finally { }
        }

        private void gridControl1_DoubleClick_2(object sender, EventArgs e)
        {
            try
            {
                var encode = gridView1.GetFocusedRowCellValue("URL").ToString().Replace(" ", "%20");



                Process.Start("chrome.exe", "https://selbeg.shop/devsoft/dist/uploads/company/" + encode + "");
                // MessageBox.Show(encode);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            finally { }
        }
    }
}
