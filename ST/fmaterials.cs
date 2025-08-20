using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Net.NetworkInformation;
using System.Management;
using System.Diagnostics;
using System.Web;
using System.IO;
using System.Drawing.Printing;
using DevExpress.LookAndFeel;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrinting.Control;
using DevExpress.XtraPrintingLinks;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.Utils;
using DevExpress.XtraReports.UI;
using DevExpress.XtraGrid.Views.Grid;
using Newtonsoft.Json;

namespace ST
{
    public partial class fmaterials : Form
    {
        public fmaterials()
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
        }

        private void fmaterials_Load(object sender, EventArgs e)
        {
            fillGridMat();
            fillGridZar();

        }
        public void fillGridMat()
        {
            try
            {
                // Өгөгдлийг унших
                dataSetFillnew dsn = new dataSetFillnew();
             //   var DT = ds.gridFill("getmaterial", "comID="+UserSession.LoggedComID.ToString().Trim());
              //  gridControl1.DataSource = DT;

                gridControl1.DataSource = dsn.getData("getmaterial", new Dictionary<string, string>
                    {
                         { "comID", "1" },
                       
                    });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: MATERIAL " + ex.Message);
            }
        }
        public void fillGridZar()
        {
            try
            {
                // Өгөгдлийг унших
                dataSetFillnew dsn = new dataSetFillnew();
                gridControl2.DataSource = dsn.getData("getmaterial", new Dictionary<string, string>
                    {
                         { "comID", "1" },
                       
                    });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: MATERIALZAR " + ex.Message);
            }
        }
        private void keytext_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                gridView1.ActiveFilterString = "matname LIKE '%" + keytext.Text + "%'";
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            finally { }
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
                   PrintGridview.Print(
                   gridView1,
                   20, 15, 15, 10,  // Margin-ууд
                   gridView1.GroupPanelText,
                   "",
                   userInfo.comName,     // Header хэсэг
                   "Хэвлэсэн:" + userInfo.userName,
                   DateTime.Now.ToString("yyyy-MM-dd"), // Footer хэсэг
                   true); // Landscape чиглэл);
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            try
            {
                addmat am = new addmat(this);
                am.ShowDialog();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            finally { }
        }

        BaseUrl Url = new BaseUrl();
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                var encode = gridView1.GetFocusedRowCellValue("serti").ToString().Replace(" ", "%20");
                FileViewer flcc = new FileViewer(Url.GetUrl() + "dist/uploads/serti/" + encode + "");
                // MessageBox.Show(encode);
            }
            catch (Exception)
            {
                MessageBox.Show("Chrome суулгачих");
            }
        }
        dataSetFill ds = new dataSetFill();
        private void урилгаХэвлэхToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                fzartsuulah fz = new fzartsuulah(this);
                fz.une.Text = gridView1.GetFocusedRowCellValue("une").ToString().Trim();
                fz.matname.Text = gridView1.GetFocusedRowCellValue("matname").ToString().Trim();
                fz.uldegdel.Text = gridView1.GetFocusedRowCellValue("too").ToString().Trim();
                fz.ognoo.DateTime = DateTime.Now;
                fz.matID.Text = gridView1.GetFocusedRowCellValue("id").ToString().Trim();
                var DT = ds.gridFill("getproject", "status=filter&comID="+UserSession.LoggedComID.ToString().Trim());
                fz.projectName.Properties.DataSource = DT;
                fz.projectName.Properties.ValueMember = "projectID";
                fz.projectName.Properties.DisplayMember = "projectName";
                fz.projectName.Properties.Columns.Clear(); // Бүх багануудаа цэвэрлэнэ
                fz.projectName.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("projectName", "Төслийн нэр"));
                fz.projectName.Properties.DropDownRows = ds.gridFill("getproject", "status=filter&comID=" + UserSession.LoggedComID.ToString().Trim()).Rows.Count;

                fz.human.Properties.DataSource = ds.gridFill("getita", "itatype=ITA");
                fz.human.Properties.ValueMember = "id";
                fz.human.Properties.DisplayMember = "ner";
                fz.human.Properties.Columns.Clear();
                fz.human.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ner", "Нэр"));
                fz.human.Properties.DropDownRows = ds.gridFill("getita", "itatype=ITA").Rows.Count;
                fz.ShowDialog();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            finally
            {
               
            }
        }

        private void projectnameFilter_EditValueChanged(object sender, EventArgs e)
        {
            gridView2.ActiveFilterString = "projectName LIKE '%" + projectnameFilter.Text + "%'";
        }

        private void устгахToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                dataSetFill dc = new dataSetFill();
                string id = gridView1.GetFocusedRowCellValue("id").ToString();
                DialogResult dr = MessageBox.Show("Материалын мэдээллийг утсгах уу?", "Анхаар", MessageBoxButtons.YesNo);
                if (dr == System.Windows.Forms.DialogResult.Yes)
                {
                    var data = new NameValueCollection();
                    data["deleteid"] = id;
                    data["ali_table"] = "materials";
                //    MessageBox.Show(dc.exec_command("deleteAll", data));
                    
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            finally
            {
                fillGridMat(); 
            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            try
            {
                dataSetFill dc = new dataSetFill();
                string id = gridView2.GetFocusedRowCellValue("id").ToString().Trim();
                DialogResult dr = MessageBox.Show("Зарлагдсан материалын мэдээллийг утсгах уу?", "Анхаар", MessageBoxButtons.YesNo);
                if (dr == System.Windows.Forms.DialogResult.Yes)
                {
                    var data = new NameValueCollection();
                    data["deleteid"] = id;
                    data["ali_table"] = "matzar";
                    MessageBox.Show(dc.exec_command("deleteAll", data));
                    fillGridZar();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            finally
            {
                
            }
        }

        private void гэрчилгээОруулахToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                editmat edm = new editmat(this);
                edm.matID.Text = gridView1.GetFocusedRowCellValue("id").ToString().Trim();
                edm.matname.Text = gridView1.GetFocusedRowCellValue("matname").ToString().Trim();
                edm.une.Text = gridView1.GetFocusedRowCellValue("une").ToString().Trim();
                edm.too.Text = gridView1.GetFocusedRowCellValue("too").ToString().Trim();
                edm.niit.Text = gridView1.GetFocusedRowCellValue("niit").ToString().Trim();
                edm.negj.Text = gridView1.GetFocusedRowCellValue("negj").ToString().Trim();
                edm.status.Text = gridView1.GetFocusedRowCellValue("status").ToString().Trim();
                edm.location.Text = gridView1.GetFocusedRowCellValue("location").ToString().Trim();
                edm.ognoo.DateTime = Convert.ToDateTime(gridView1.GetFocusedRowCellValue("ognoo").ToString().Trim());
                edm.ShowDialog();

            }
            catch (Exception ee)
            {
                MessageBox.Show("Засварлах үед алдаа гарлаа:" + ee.ToString());
            }
            finally
            {
 
            }
        }
       
        baseinfo userInfo = new baseinfo(UserSession.LoggedUserID);
        private void simpleButton1_Click(object sender, EventArgs e)
        {
                   PrintGridview.Print(
                   gridView2,
                   20, 15, 15, 12,  // Margin-ууд
                   projectnameFilter.Text + ": "+ gridView2.GroupPanelText,
                   "",
                   userInfo.comName,     // Header хэсэг
                   "Хэвлэсэн:" + userInfo.userName,
                   DateTime.Now.ToString("yyyy-MM-dd"), // Footer хэсэг
                   true); // Landscape чиглэл);
        }
    }
}
