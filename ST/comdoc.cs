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
using System.IO;

namespace ST
{
    public partial class comdoc : Form
    {
        public comdoc()
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
        public string mainurl;
        public string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.txt").Trim();
        public void hish_Load(object sender, EventArgs e)
        {
            try
            {
                fillgridComM();
                fillgridComS();
                fillgridComA();
                fillgridComN();
                dateEdit1.EditValue = DateTime.Now;
            }
            catch (Exception ee)
            { MessageBox.Show(ee.ToString()); }
            finally { }

        }
        public void fillgridComM()
        {
            try
            {
                gridControl1.DataSource = ds.gridFill("getcomdoc", "doctype=companyM");
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
        }
        public void fillgridComS()
        {
            try
            {
                gridControl2.DataSource = ds.gridFill("getcomdoc", "doctype=companyS");
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
        }
        public void fillgridComA()
        {
             try
            {
                gridControl3.DataSource = ds.gridFill("getcomdoc", "doctype=companyA");
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }

        }
        public void fillgridComN()
        {
            try
            {
                gridControl4.DataSource = ds.gridFill("getcomdoc", "doctype=companyN");
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
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
            if (xtraTabControl1.SelectedTabPageIndex == 0)
            {
                PrintGridview.Print(
                    gridView1,
                    20, 15, 15, 12,  // Margin-ууд
                    "Үндсэн бичиг баримтуудын жагсаалт",    
                    "",
                    userInfo.comName,     // Header хэсэг
                    "Хэвлэсэн:"+userInfo.userName,
                    DateTime.Now.ToString("yyyy-MM-dd"), // Footer хэсэг
                    false // Landscape чиглэл
                );
            }
            if (xtraTabControl1.SelectedTabPageIndex == 1)
            {
                PrintGridview.Print(gridView2,
                    20, 15, 15, 12,  // Margin-ууд
                    "Санхүүгийн тайлангуудын жагсаалт",
                    "",
                    userInfo.comName,     // Header хэсэг
                    "Хэвлэсэн:" + userInfo.userName,
                    DateTime.Now.ToString("yyyy-MM-dd"), // Footer хэсэг
                    false // Landscape чиглэл
                );
            }

            if (xtraTabControl1.SelectedTabPageIndex == 2)
            {
                PrintGridview.Print(gridView3,
                    20, 15, 15, 12,  // Margin-ууд
                    "Аудитын дүгнэлтүүдийн жагсаалт",
                   "",
                    userInfo.comName,     // Header хэсэг
                    "Хэвлэсэн:" + userInfo.userName,
                    DateTime.Now.ToString("yyyy-MM-dd"), // Footer хэсэг
                    false // Landscape чиглэл
                );
            }
            if (xtraTabControl1.SelectedTabPageIndex == 3)
            {
                PrintGridview.Print(gridView4,
                    20, 15, 15, 12,  // Margin-ууд
                    "Нийгмийн даатгалын тайлангуудын жагсаалт",
                    "",
                    userInfo.comName,     // Header хэсэг
                    "Хэвлэсэн:" + userInfo.userName,
                    DateTime.Now.ToString("yyyy-MM-dd"), // Footer хэсэг
                    false // Landscape чиглэл
                );
            }
           
        }
        baseinfo userInfo = new baseinfo(UserSession.LoggedUserID);
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
                        data["URL11"] = gridView1.GetFocusedRowCellValue("URL").ToString();
                    }
                    if (xtraTabControl1.SelectedTabPageIndex == 1)
                    {
                        data["deleteid"] = gridView2.GetFocusedRowCellValue("id").ToString();
                        data["URL11"] = gridView2.GetFocusedRowCellValue("URL").ToString();
                    }

                    if (xtraTabControl1.SelectedTabPageIndex == 2)
                    {
                        data["deleteid"] = gridView3.GetFocusedRowCellValue("id").ToString();
                        data["URL11"] = gridView3.GetFocusedRowCellValue("URL").ToString();
                    }
                    if (xtraTabControl1.SelectedTabPageIndex == 3)
                    {
                        data["deleteid"] = gridView4.GetFocusedRowCellValue("id").ToString();
                        data["URL11"] = gridView4.GetFocusedRowCellValue("URL").ToString();
                    }
                    data["ali_table"] = "comdoc";
                    MessageBox.Show(dcd.exec_command("deleteAll", data));
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

        private void gridControl4_DoubleClick_1(object sender, EventArgs e)
        {
            try
            {
                var encode = gridView4.GetFocusedRowCellValue("URL").ToString().Replace(" ", "%20");
                if (encode != "")
                {
                    FileViewer vvr = new FileViewer(url.GetUrl() + "dist/uploads/company/" + encode);
                }
                else
                {
                    MessageBox.Show("Одоогоор харгалзах файл байхгүй.");
                }
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
                if (encode != "")
                {
                    FileViewer vwr = new FileViewer(url.GetUrl() + "dist/uploads/company/" + encode);
                }
                else
                {
                    MessageBox.Show("Одоогоор харгалзах файл байхгүй.");
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            finally { }
        }

        BaseUrl url = new BaseUrl();
        private void gridControl2_DoubleClick_1(object sender, EventArgs e)
        {
            try
            {
                var encode = gridView2.GetFocusedRowCellValue("URL").ToString().Replace(" ", "%20");
                if (encode != "")
                {
                    FileViewer vvr = new FileViewer(url.GetUrl() + "dist/uploads/company/" + encode);
                }
                else
                {
                    MessageBox.Show("Одоогоор харгалзах файл байхгүй.");
                }
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
                if (encode != "")
                {
                    FileViewer vvr = new FileViewer(url.GetUrl() + "dist/uploads/company/" + encode);
                }
                else
                {
                    MessageBox.Show("Одоогоор харгалзах файл байхгүй.");
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            finally { }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }
    }
}
