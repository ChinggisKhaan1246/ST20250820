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
    public partial class devices : Form
    {
        public devices()
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
        public void too_Load(object sender, EventArgs e)
        {
            try
            {
               fillgridDevices();   
            }
            catch (Exception)
            { }
            finally { }
        }
        public void fillgridDevices()
        {
            try
            {
                gridControl2.DataSource = ds.gridFill("getdevices");
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }

        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            gridView2.ActiveFilterString = "";
        }
        baseinfo userInfo = new baseinfo(UserSession.LoggedUserID);
        private void simpleButton2_Click(object sender, EventArgs e)
        {
                   PrintGridview.Print(
                   gridView2,
                   20, 15, 15, 10,  // Margin-ууд
                   gridView2.GroupPanelText,
                   "",
                   userInfo.comName,     // Header хэсэг
                   "Хэвлэсэн:" + userInfo.userName,
                   DateTime.Now.ToString("yyyy-MM-dd"), // Footer хэсэг
                   true); // Landscape чиглэл);
        }

        private void hai()
        {
           
        }
        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {
        }

        private void textEdit2_EditValueChanged(object sender, EventArgs e)
        {
           
        }

        private void textEdit3_EditValueChanged(object sender, EventArgs e)
        {
            hai();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {

            try
            {
                adddevice adddev = new adddevice(this);
                adddev.ognoo.DateTime = DateTime.Now;
                adddev.ShowDialog();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            finally
            {
 
            }
        }

        private void устгахToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            try
            {
                DialogResult ds = MessageBox.Show("Сонгогдсон борлуулалтын буцаалт хийхдээ итгэлтэй байна уу.", "Анхаар", MessageBoxButtons.YesNo);
                if (ds == System.Windows.Forms.DialogResult.Yes)
                {
                   // Устгах команд энд бичнэ
                    hai();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "");
            }
            finally { //con.Close(); 
            }
        }

        private void gridControl2_Click(object sender, EventArgs e)
        {
            try
            {
               
                
            }
            catch (Exception)
            { }
            finally
            {
                
            }
        }

       private void textEdit1_EditValueChanged_1(object sender, EventArgs e)
        {
            gridView2.ActiveFilterString = "ner LIKE '%" + textEdit1.Text + "%'  or mark LIKE '%" + textEdit1.Text + "%'  or ULSdugaar LIKE '%" + textEdit1.Text + "%'";
        }

        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string searchtext = "";
            if (comboBoxEdit1.SelectedIndex == 0)
            {
                searchtext = "";
            }
            if (comboBoxEdit1.SelectedIndex == 1)
            {
                searchtext = "машин механизм";
            }

            if (comboBoxEdit1.SelectedIndex == 2)
            {
                searchtext = "багаж, тоног төхөөрөмж";
            }
            if (comboBoxEdit1.SelectedIndex == 3)
            {
                searchtext = "ХАБЭА хэрэгсэл";
            }
           // MessageBox.Show(searchtext + ":" + comboBoxEdit1.SelectedIndex.ToString());
             gridView2.ActiveFilterString = "devicetype LIKE '%" + searchtext + "%'";
        }

        private void comboBoxEdit1_TextChanged(object sender, EventArgs e)
        {
            gridView2.ActiveFilterString = "ner LIKE '%" + textEdit1.Text + "%'  or mark LIKE '%" + textEdit1.Text + "%'  or ULSdugaar LIKE '%" + textEdit1.Text + "%'";
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                dataSetFill dc = new dataSetFill();
                string id = gridView2.GetFocusedRowCellValue("id").ToString().Trim();
                DialogResult dr = MessageBox.Show("Тоног төхөөрөмжийн мэдээллийг утсгах уу?", "Анхаар", MessageBoxButtons.YesNo);
                if (dr == System.Windows.Forms.DialogResult.Yes)
                {
                    var data = new NameValueCollection();
                    data["deleteid"] = id;
                    data["ali_table"] = "devices";
                    MessageBox.Show(dc.exec_command("deleteAll", data));
                    //f.saveLogg(f.salerID.Text, f.salerName.Text, "Агуулахын бүртгэлээс устгасан");

                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            finally
            {
                fillgridDevices();
            }
        }

        private void засахToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                editdevice edd = new editdevice(this);
                edd.deviceID.Text = gridView2.GetFocusedRowCellValue("id").ToString().Trim();
                edd.ner.Text = gridView2.GetFocusedRowCellValue("ner").ToString().Trim();
                edd.mark.Text = gridView2.GetFocusedRowCellValue("mark").ToString().Trim();
                edd.ooriin.Text = gridView2.GetFocusedRowCellValue("ooriin").ToString().Trim();
                edd.too.Text = gridView2.GetFocusedRowCellValue("too").ToString().Trim();
                edd.ready.Text = gridView2.GetFocusedRowCellValue("ready").ToString().Trim();
                edd.made.Text = gridView2.GetFocusedRowCellValue("made").ToString().Trim();
                edd.devicetype.Text = gridView2.GetFocusedRowCellValue("devicetype").ToString().Trim();
                edd.power.Text = gridView2.GetFocusedRowCellValue("power").ToString().Trim();
                edd.producted.Text = gridView2.GetFocusedRowCellValue("producted").ToString().Trim();
                edd.ulsdugaar.Text = gridView2.GetFocusedRowCellValue("ULSdugaar").ToString().Trim();
                if (edd.ognoo.DateTime.ToString() != "")
                {
                    edd.ognoo.DateTime = Convert.ToDateTime(gridView2.GetFocusedRowCellValue("ognoo").ToString().Trim());
                }
                
                edd.ShowDialog();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            finally
            {
 
            }
        }
        BaseUrl Url = new BaseUrl();
        private void gridControl2_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                var encode = gridView2.GetFocusedRowCellValue("docURL").ToString().Replace(" ", "%20").Trim();
                if (encode != "")
                {
                    FileViewer vvr = new FileViewer(Url.GetUrl() + "dist/uploads/devices/" + encode);
                }
                else
                {
                    MessageBox.Show("Харгалзах файл байхгүй байна.");
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            finally { }
        }

        private void нэмэхToolStripMenuItem_Click(object sender, EventArgs e)
        {
            simpleButton3_Click(sender, e);
        }
    }
}
