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
    public partial class fappusers : Form
    {
        public fappusers()
        {
            InitializeComponent();
            gridView1.CustomUnboundColumnData += (sender, e) =>
            {
                GridView view = sender as GridView;
                if (e.Column.FieldName == "dd1" && e.IsGetData)
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
        private void fappusers_Load(object sender, EventArgs e)
        {
            dateEdit1.EditValue = DateTime.Now;
            dateEdit2.EditValue = DateTime.Now;
            dateEdit3.EditValue = DateTime.Now;
            dateEdit4.EditValue = DateTime.Now;
            fillgridUsers();
            fillgridRequest();
            fillgridNoti();
            fillgridlogg();
            repositoryItemComboBox1.Items.Clear();
            repositoryItemComboBox1.Items.AddRange(new string[] {
                "шинэ", "registered", "ажилтан", "инженер", "оффис", "бригад"
            });

            repositoryItemComboBox2.Items.Clear();
            repositoryItemComboBox2.Items.AddRange(new string[] {
                "шинэ", "танилцсан", "буцаасан", "зөвшөөрсөн"
            });
        }
        public void fillgridUsers()
        {
            try
            {
                gridControl1.DataSource = ds.gridFill("getuser");
            }
            catch (Exception ee)
            {
                MessageBox.Show("Алдаа: Хэрэглэгчийн мэдээлэл татах үед алдаа гарлаа:   " + ee.ToString());
            }
            finally { }
        }
        public void fillgridRequest()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = ds.gridFill("getrequest", "userID=1");
                gridControl2.DataSource = dt;
            }
            catch (Exception ee)
            {
                MessageBox.Show("Алдаа: хүсэлтийн мэдээлэл татах үед алдаа гарлаа:   " + ee.ToString());
            }
            finally { }
        }
        public void fillgridNoti()
        {
            try
            {
                gridControl3.DataSource = ds.gridFill("getnotification", "userID=All");
            }
            catch (Exception ee)
            {
                MessageBox.Show("Алдаа: Мэдэгдэлүүдийг татах үед алдаа гарлаа:   " + ee.ToString());
            }
            finally { }
        }
        public void fillgridlogg()
        {
            try
            {
                gridControl4.DataSource = ds.gridFill("getlog", "status=All");
            }
            catch (Exception ee)
            {
                MessageBox.Show("Алдаа: Үйлдлүүдийн түүх татах үед алдаа гарлаа:   " + ee.ToString());
            }
            finally { }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
           
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            try
            {
                addnotification an = new addnotification();
                an.ShowDialog();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            finally { }
        }

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                EditUser();
                e.Handled = true;
            }
        }
        private void EditUser()
        {
            try
            {
                gridView1.PostEditor();
                gridView1.UpdateCurrentRow();

                object idObj = gridView1.GetFocusedRowCellValue("id");
                object ovogObj = gridView1.GetFocusedRowCellValue("ovog");
                object nerObj = gridView1.GetFocusedRowCellValue("ner");
                object albantushaalObj = gridView1.GetFocusedRowCellValue("albantushaal");
                object addressObj = gridView1.GetFocusedRowCellValue("address");
                object statusObj = gridView1.GetFocusedRowCellValue("status");
                if (idObj == null || nerObj == null || statusObj == null )
                        {
                            MessageBox.Show("Мэдээлэл дутуу байна!", "Алдаа", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                
                
                string id = idObj.ToString().Trim();
                string ovog = ovogObj.ToString().Trim();
                string ner = nerObj.ToString().Trim();
                string albantushaal = albantushaalObj.ToString().Trim(); 
                string address = addressObj.ToString().Trim();
                string status = statusObj.ToString().Trim();

                string comID = UserSession.LoggedComID.ToString().Trim();
                if (status == "шинэ" || status == "ажилтан" || status == "инженер" || status == "оффис" || status == "бригад")
                {
                    comID = UserSession.LoggedComID.ToString();
                }

                dataSetFill ds = new dataSetFill();
                var data = new NameValueCollection
                        {
                            { "id", id },
                            { "ovog", ovog },
                            { "ner", ner },
                            { "albantushaal", albantushaal },
                            { "address", address },
                            { "status", status },
                            { "comID", comID },
                        };
                string result = ds.exec_command("edituser", data);
                MessageBox.Show(result);
                if (!string.IsNullOrEmpty(result) && result.Trim() == "success")
                {
                    gridView1.SetFocusedRowCellValue("ovog", ovog);
                    gridView1.SetFocusedRowCellValue("ner", ner);
                    gridView1.SetFocusedRowCellValue("albantushaal", albantushaal);
                    gridView1.SetFocusedRowCellValue("address", address);
                    gridView1.SetFocusedRowCellValue("status", status);
                    gridView1.SetFocusedRowCellValue("comID", comID);
                }
                else
                {
                    MessageBox.Show("Серверээс хариу ирсэнгүй!", "Алдаа", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Алдаа: " + ex.Message, "Алдаа", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textEdit10_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                gridView1.ActiveFilterString = "ner LIKE '%" + textEdit10.Text + "%'";
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            finally { }
        }

        private void textEdit12_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                gridView1.ActiveFilterString = "phone LIKE '%" + textEdit12.Text + "%'";
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            finally { }
        }

        private void textEdit11_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                gridView1.ActiveFilterString = "albantushaal LIKE '%" + textEdit11.Text + "%'";
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            finally { }
        }

        private void dateEdit1_EditValueChanged(object sender, EventArgs e)
        {
            /*try
            {
                string dateValue = Convert.ToDateTime(dateEdit1.EditValue).ToString("yyyy-MM-dd");
                gridView1.ActiveFilterString = "ognoo LIKE '%" + dateValue + "%'";
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            finally { } */
        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                gridView2.ActiveFilterString = "username LIKE '%" + textEdit1.Text + "%'";
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            finally { }
        }

        private void textEdit2_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                gridView2.ActiveFilterString = "albantushaal LIKE '%" + textEdit2.Text + "%'";
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            finally { }
        }

        private void textEdit3_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                gridView2.ActiveFilterString = "phone LIKE '%" + textEdit3.Text + "%'";
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            finally { }
        }

        private void textEdit4_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                gridView3.ActiveFilterString = "ner LIKE '%" + textEdit4.Text + "%'";
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            finally { }
        }

        private void textEdit5_EditValueChanged(object sender, EventArgs e)
        {
           
        }

        private void textEdit6_EditValueChanged(object sender, EventArgs e)
        {
           
        }

        private void textEdit7_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                gridView4.ActiveFilterString = "ner LIKE '%" + textEdit7.Text + "%'";
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            finally { }
        }

        private void textEdit8_EditValueChanged(object sender, EventArgs e)
        {
          
        }

        private void textEdit9_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                gridView4.ActiveFilterString = "phone LIKE '%" + textEdit7.Text + "%'";
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            finally { }
        }

        private void dateEdit2_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                string dateValue = Convert.ToDateTime(dateEdit2.EditValue).ToString("yyyy-MM-dd");
                gridView2.ActiveFilterString = "ognoo LIKE '%" + dateValue + "%'";
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            finally { }
        }

        private void dateEdit3_EditValueChanged(object sender, EventArgs e)
        {
            /*try
            {
                string dateValue = Convert.ToDateTime(dateEdit3.EditValue).ToString("yyyy-MM-dd");
                gridView3.ActiveFilterString = "ognoo LIKE '%" + dateValue + "%'";
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            finally { }  */
        }

        private void dateEdit4_EditValueChanged(object sender, EventArgs e)
        {
            /*try
            {
                string dateValue = Convert.ToDateTime(dateEdit4.EditValue).ToString("yyyy-MM-dd");
                gridView4.ActiveFilterString = "ognoo LIKE '%" + dateValue + "%'";
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            finally { }  */
        }
    }
}
