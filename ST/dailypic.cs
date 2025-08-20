using System;
using System.IO;
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
using DevExpress.XtraEditors.Repository;
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
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace ST
{
    public partial class dailypic : Form
    {
        public dailypic()
        {
            InitializeComponent();
            gridView1.CustomUnboundColumnData += (sender, e) =>
            {
                GridView view = sender as GridView;
                if (e.Column.FieldName == "dd" && e.IsGetData)
                {
                    e.Value = view.GetRowHandle(e.ListSourceRowIndex) + 1;
                }
            };
        }
        private void dailypic_Load(object sender, EventArgs e)
        {
            fillgriddailyPic();
        }

        public void fillgriddailyPic()
        {
            try
            {
                // Өгөгдлийг унших
                dataSetFill ds = new dataSetFill();
                gridControl1.DataSource = ds.gridFill("getdailypic", "status=" + daily.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void LoadImageFromUrl(string imageUrl)
        {
            try
            {
                using (WebClient webClient = new WebClient())
                {
                    byte[] imageData = webClient.DownloadData(imageUrl);
                    using (MemoryStream stream = new MemoryStream(imageData))
                    {
                        Image image = Image.FromStream(stream);
                        int width = image.Width;
                        int height = image.Height;
                        pictureEdit1.Image = image;
                    }
                }
            }
            catch (Exception ex)
            {
                pictureEdit1.Image = null;
                MessageBox.Show(string.Format("Зургийг ачаалахад алдаа гарлаа: {0}", ex.Message));
            }
        }
        BaseUrl Url = new BaseUrl();
        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                var encode = gridView1.GetFocusedRowCellValue("pic").ToString().Replace(" ", "%20");
                FileViewer flcc = new FileViewer(Url.GetUrl()+"dist/uploads/daily/" + projectID.Text.Trim() + "/" + encode + "");
                // MessageBox.Show(encode);
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
                    addphotos addp = new addphotos(this);
                    addp.dailyID.Text = daily.Text;
                    addp.projectID.Text = projectID.Text;
                    addp.ShowDialog();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            finally
            {
                
            }
        }
        
        private void simpleButton6_Click(object sender, EventArgs e)
        {
            try
              {
                 gridView1.ActiveFilterString = "[checkboxfield] = 1";
                 BaseUrl Url = new BaseUrl();
                 List<ReportData> reportDataList = new List<ReportData>();
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    // Эхлээд мөрийн утгыг шалгаж авахаас өмнө хоосон эсэхийг шалгах
                    string Ztailbar = gridView1.GetRowCellValue(i, "Ztailbar") != null ? gridView1.GetRowCellValue(i, "Ztailbar").ToString() : string.Empty;
                    string ognoo = gridView1.GetRowCellValue(i, "ognoo") != null ? gridView1.GetRowCellValue(i, "ognoo").ToString() : string.Empty;
                    
                    string imageUrlPicEdit = string.Format(Url.GetUrl()+"dist/uploads/daily/{0}/{1}", projectID.Text, gridView1.GetRowCellValue(i, "pic"));

                    reportDataList.Add(new ReportData
                    {
                        classatushaal = imageUrlPicEdit,
                        classner = Ztailbar,
                        classognoo = ognoo,
                        
                    });
                }

                reportdailypic rpdpic = new reportdailypic
                {
                    DataSource = reportDataList
                };
                rpdpic.xrPictureBox1.DataBindings.Add(new XRBinding("ImageUrl", null, "classatushaal")); // Зураг URL
                rpdpic.ognoo.DataBindings.Add(new XRBinding("Text", null, "classognoo")); // Огноо
                rpdpic.hiisen.DataBindings.Add(new XRBinding("Text", null, "classner"));  // Хийсэн зүйл
                rpdpic.weather.Text = weather.Text;
                rpdpic.titletext.Text = label2.Text + "-" + label3.Text; 
                rpdpic.engname.Text = engname.Text;
                rpdpic.xabname.Text = xabname.Text;
                rpdpic.daamalname.Text = daamal.Text;
                rpdpic.Rognoo.Text = label10.Text.Trim();
                rpdpic.comName.Text = Form1.companyName;
                rpdpic.ShowPreview();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            finally
            {
                gridView1.ActiveFilterString = "";
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            урилгаХэвлэхToolStripMenuItem_Click(sender, e);
        }

        private void gridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
           try
           {
            if (e.Column.FieldName == "checkboxfield")
            {
                dataSetFill ds = new dataSetFill();
                var data = new NameValueCollection();
                int id = Convert.ToInt32(gridView1.GetRowCellValue(e.RowHandle, "id"));
                int value = Convert.ToInt32(e.Value); // checkbox утга
                //MessageBox.Show("ID="+id.ToString()+"  value ="+value.ToString());
                data["id"] = id.ToString();
                data["value"] = value.ToString();
                data["edittype"] = "checkbox";

                ds.exec_command("editdailypic", data);
            }
           }
            catch (Exception ex)
            {
                    // Алдаа гарвал мэдэгдэл гаргах
                    MessageBox.Show("Error: " + ex.Message);
            }
            }
        private void DisplayImagesFromUrls()
        {
            // GridView-ийн өгөгдлийг авч, "pic" баганыг хөрвүүлэх
            var dataSource = gridControl1.DataSource as DataTable;

            if (dataSource == null || !dataSource.Columns.Contains("pic"))
                return;
            BaseUrl Url = new BaseUrl();
            foreach (DataRow row in dataSource.Rows)
            {
                string imageUrl = Url.GetUrl()+"dist/uploads/daily/"+projectID.Text+"/"+row["pic"] as string; //"pic" багана дахь URL
                MessageBox.Show(imageUrl);
                if (!string.IsNullOrEmpty(imageUrl))
                {
                    row["pic"] = DownloadImageFromUrl(imageUrl); // URL-ийг зураг болгон солих
                    
                }
            }

            // GridView-д шинэчлэлт хийх
            gridControl1.RefreshDataSource();
        }
        private Image DownloadImageFromUrl(string url)
        {
            try
            {
                using (WebClient webClient = new WebClient())
                {
                    byte[] imageData = webClient.DownloadData(url);
                    using (MemoryStream stream = new MemoryStream(imageData))
                    {
                        return Image.FromStream(stream); // Stream-аас Image үүсгэх
                    }
                }
            }
            catch
            {
                return null; // Алдаа гарвал хоосон зураг буцаах
            }
        }

       private void gridView1_Click(object sender, EventArgs e)
        {
            try
            {
                BaseUrl Url = new BaseUrl();
                string imageUrlPicEdit = Url.GetUrl()+"dist/uploads/daily/" + projectID.Text + "/" + gridView1.GetFocusedRowCellValue("pic").ToString() + "";
                //MessageBox.Show(imageUrlPicEdit);
                LoadImageFromUrl(imageUrlPicEdit);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }

        }

       private void gridView1_KeyDown(object sender, KeyEventArgs e)
       {
           if (e.KeyCode == Keys.Enter)
               {
                   EditZtailbar();
                   e.Handled = true; 
               }
       }

       private void EditZtailbar()
       {
           try
           {
               gridView1.PostEditor();
               gridView1.UpdateCurrentRow();

               object idObj = gridView1.GetFocusedRowCellValue("id");
               object valueObj = gridView1.GetFocusedRowCellValue("Ztailbar");
               object ognooObj = gridView1.GetFocusedRowCellValue("ognoo");

               if (idObj == null || valueObj == null || ognooObj == null)
               {
                   MessageBox.Show("Мэдээлэл дутуу байна!", "Алдаа", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                   return;
               }

               string id = idObj.ToString().Trim();
               string value = valueObj.ToString().Trim();

               // Огнооны зөв форматыг шалгах
               DateTime parsedDate;
               if (!DateTime.TryParse(ognooObj.ToString(), out parsedDate))
               {
                   MessageBox.Show("Огнооны формат буруу байна!", "Алдаа", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                   return;
               }

               string ognoo = parsedDate.ToString("yyyy-MM-dd HH:mm:ss");

               dataSetFill ds = new dataSetFill();
               var data = new NameValueCollection
                        {
                            { "id", id },
                            { "value", value },
                            { "ognoo", ognoo },
                            { "edittype", "Ztailbar" }
                        };

               string result = ds.exec_command("editdailypic", data);

               if (!string.IsNullOrEmpty(result) && result.Trim() == "success")
               {
                   gridView1.SetFocusedRowCellValue("Ztailbar", value);
                   gridView1.SetFocusedRowCellValue("ognoo", ognoo);
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
        private void gridView1_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            try
            {
                // Indicator-ийн дугаарыг өөрчлөх
                if (e.RowHandle < 0)
                    return;

                // Indicator-ийн текстийг тохируулна
                e.Info.DisplayText = "зураг харах"; // Дугаарын оронд "Зураг" гэж гаргана

                // Текстийн өнгө, фонтыг тохируулах
                e.Appearance.ForeColor = Color.Blue; // Текстийн өнгийг цэнхэр болгоно
                e.Appearance.BackColor = Color.LightGray; // Indicator-ийн арын өнгийг саарал болгоно

                // Текстийн байрлалыг өөрчлөх (заавал биш)
                e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                e.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
        }

        private void устгахToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                dataSetFill dc = new dataSetFill();
                string id = gridView1.GetFocusedRowCellValue("id").ToString().Trim();
                DialogResult dr = MessageBox.Show("Зардалын баримт мэдээллийг утсгах уу?", "Анхаар", MessageBoxButtons.YesNo);
                if (dr == System.Windows.Forms.DialogResult.Yes)
                {
                    var data = new NameValueCollection();
                    data["deleteid"] = id;
                    data["ali_table"] = "dailypic";
                    MessageBox.Show(dc.exec_command("deleteAll", data));
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            finally
            {
                fillgriddailyPic();
            }
        }

        private void keytext_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                gridView1.ActiveFilterString = "Ztailbar LIKE '%" + keytext.Text + "%'  or ognoo LIKE '%" + keytext.Text + "%'";
            }
            catch (Exception)
            {
                MessageBox.Show("Өгөгдөл байхгүй.");
            }
        }
            
        }

      
    
}
