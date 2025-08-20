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
using DevExpress.XtraReports.UI;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Net.NetworkInformation;
using System.Management;
using System.Diagnostics;
using System.Web;

namespace ST
{
    public partial class fplans : Form
    {
        public fplans()
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
        dataSetFillnew dsn = new dataSetFillnew();
        private void fplans_Load(object sender, EventArgs e)
        {
            try
            {
                FillPlans();
                repositoryItemComboBox1.Items.Clear();
                repositoryItemComboBox1.Items.AddRange(new string[] {
                "шинэ", "дууссан", "баталсан"
            });

                // API-с төсөл татах
                var parameters = new Dictionary<string, string> { { "status", "filter" }, { "comID", UserSession.LoggedComID.ToString() } };
                var projectData = dsn.getData("getproject", parameters);

                if (projectData == null || projectData.Rows.Count == 0)
                {
                    MessageBox.Show("Идэвхтэй төсөл олдсонгүй.", "Анхааруулга", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    projectnameFilter.Properties.DataSource = projectData;
                    projectnameFilter.Properties.ValueMember = "projectID";
                    projectnameFilter.Properties.DisplayMember = "projectName";
                    projectnameFilter.Properties.Columns.Clear(); // Бүх багануудаа цэвэрлэнэ
                    projectnameFilter.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("projectName", "Төслийн нэр"));
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            finally { }
        }
        public void FillPlans()
        {
            try
            {
                var parameters = new Dictionary<string, string>
                {
                    { "status", "9" },
                    { "comID", UserSession.LoggedComID.ToString() }
                };

                var planData = dsn.getData("getplan", parameters);

                if (planData == null || planData.Rows.Count == 0)
                {
                    gridControl2.DataSource = new DataTable();
                }
                else
                {
                    gridControl2.DataSource = planData;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Алдаа гарлаа: " + ex.Message, "Алдаа", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void projectnameFilter_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                projectName.Text = projectnameFilter.Text;
                projectID.Text = projectnameFilter.EditValue.ToString();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            finally
            {

            }
        }

        private void projectName_EditValueChanged(object sender, EventArgs e)
        {
            gridView2.ActiveFilterString = "projectName LIKE '%" + projectName.Text + "%'";
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if (projectName.Text != "")
                {
                    addplan addpln = new addplan(this);
                    addpln.projectID.Text = projectID.Text;
                    addpln.projectName.Text = projectName.Text;
                    addpln.ognoo.DateTime = DateTime.Now;
                    addpln.ognoo2.DateTime = DateTime.Now;
                    addpln.aimag.Text = aimag.Text.Trim();
                    addpln.sum.Text = sum.Text.Trim();
                    addpln.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Ялгах хэсгээс төсөлөө сонгоно уу.");
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

        private void simpleButton1_Click(object sender, EventArgs e)
        {
                   PrintGridview.Print(
                   gridView2,
                   20, 15, 15, 10,  // Margin-ууд
                   xtraTabPage1.Text + ": " + projectnameFilter.Text,
                   "",
                   userInfo.comName,     // Header хэсэг
                   "Хэвлэсэн:" + userInfo.userName,
                   DateTime.Now.ToString("yyyy-MM-dd"), // Footer хэсэг
                   true); // Landscape чиглэл);
        }
        baseinfo userInfo = new baseinfo(UserSession.LoggedUserID);
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            try
            {
                dataSetFill dc = new dataSetFill();
                string id = gridView2.GetFocusedRowCellValue("id").ToString();
                DialogResult dr = MessageBox.Show("Төлөвлөгөөний мэдээллийг утсгах уу?", "Анхаар", MessageBoxButtons.YesNo);
                if (dr == System.Windows.Forms.DialogResult.Yes)
                {
                    var data = new NameValueCollection();
                    data["deleteid"] = id;
                    data["ali_table"] = "plans";
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
                FillPlans();
            }
        }

        private void фотоЗурагОруулахToolStripMenuItem_Click(object sender, EventArgs e)
        {
            simpleButton2_Click(sender, e);
        }

        private void gridControl2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                EditPlanData();
                e.Handled = true;
            }
        }
        private void EditPlanData()
        {
            try
            {
                MessageBox.Show("Хадгалсан");
                gridView2.PostEditor();
                gridView2.UpdateCurrentRow();

                object idObj = gridView2.GetFocusedRowCellValue("id");
                object ognooObj = gridView2.GetFocusedRowCellValue("ognoo");
                object ognooDObj = gridView2.GetFocusedRowCellValue("ognooD");
                object hiihObj = gridView2.GetFocusedRowCellValue("hiih");
                object mechanismObj = gridView2.GetFocusedRowCellValue("mechanism");
                object ajilchidObj = gridView2.GetFocusedRowCellValue("ajilchid");
                object statusObj = gridView2.GetFocusedRowCellValue("status");

                if (idObj == null || ognooObj == null || hiihObj == null)
                {
                    MessageBox.Show("Мэдээлэл дутуу байна!", "Алдаа", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string id = idObj.ToString().Trim();
                string ognoo = Convert.ToDateTime(ognooObj).ToString("yyyy-MM-dd");
                string ognooD = Convert.ToDateTime(ognooDObj).ToString("yyyy-MM-dd");
                string hiih = hiihObj != null ? hiihObj.ToString().Trim() : "";
                string mechanism = mechanismObj != null ? mechanismObj.ToString().Trim() : "";
                string ajilchid = ajilchidObj != null ? ajilchidObj.ToString().Trim() : "";
                string status = statusObj != null ? statusObj.ToString().Trim() : "";

                var data = new System.Collections.Specialized.NameValueCollection
                        {
                            { "id", id },
                            { "ognoo", ognoo },
                            { "ognooD", ognooD },
                            { "hiih", hiih },
                            { "mechanism", mechanism },
                            { "ajilchid", ajilchid },
                            { "status", status },
                        };

                dataSetFill ds = new dataSetFill();
                string response = ds.exec_command("editplan", data);

                if (!string.IsNullOrEmpty(response) && response.Contains("success"))
                {
                    gridView2.SetFocusedRowCellValue("ognoo", ognoo);
                    gridView2.SetFocusedRowCellValue("ognooD", ognooD);
                    gridView2.SetFocusedRowCellValue("hiih", hiih);
                    gridView2.SetFocusedRowCellValue("mechanism", mechanism);
                    gridView2.SetFocusedRowCellValue("ajilchid", ajilchid);
                }
                else
                {
                    MessageBox.Show("Хадгалах явцад алдаа гарлаа: " + response, "Алдаа", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Алдаа гарлаа: " + ex.Message, "Алдаа", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }
    }
}
