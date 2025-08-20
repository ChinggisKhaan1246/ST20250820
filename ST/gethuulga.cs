using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Collections.Specialized;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors;

namespace ST
{
    public partial class gethuulga : Form
    {

        Form1 f;
        public gethuulga(Form1 ff)
        {
            InitializeComponent();
            f = ff;
          
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            progressBarControl1.Position = 0;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                LoadExcelData(openFileDialog1.FileName, gridControl1);
            }
        }
        private void LoadExcelData(string filePath, DevExpress.XtraGrid.GridControl gridControl)
        {
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook workbook = null;
            Excel.Worksheet worksheet = null;
            try
            {
                workbook = excelApp.Workbooks.Open(filePath);
                worksheet = workbook.Sheets[1];
                Excel.Range range = worksheet.UsedRange;
                if (range == null || range.Rows.Count == 0 || range.Columns.Count == 0)
                {
                    MessageBox.Show("Excel файл нь хоосон байна.");
                    return;
                }

                // DataTable үүсгэх
                DataTable dt = new DataTable();
                dt.Columns.Add(new DataColumn("№", typeof(int)));
                dt.Columns.Add("Огноо");
                dt.Columns.Add("Салбар");
                dt.Columns.Add("Эхний үлд");
                dt.Columns.Add("Зарлага");
                dt.Columns.Add("Орлого");
                dt.Columns.Add("Эцсийн үлд");
                dt.Columns.Add("Гүйлгээний утга");
                dt.Columns.Add("Харилцах данс");
                dt.Columns.Add("Төслийн нэр");
                dt.Columns.Add("Бүртгэх");

                // Excel өгөгдлийг унших
                progressBarControl1.Properties.Maximum = range.Rows.Count;
                for (int row = 2; row <= range.Rows.Count; row++)
                {
                    DataRow dataRow = dt.NewRow();
                    dataRow["Огноо"] = (range.Cells[row, 1] as Excel.Range).Value2 != null ? (range.Cells[row, 1] as Excel.Range).Value2.ToString() : string.Empty;
                    dataRow["Салбар"] = (range.Cells[row, 2] as Excel.Range).Value2 != null ? (range.Cells[row, 2] as Excel.Range).Value2.ToString() : string.Empty;
                    dataRow["Эхний үлд"] = (range.Cells[row, 3] as Excel.Range).Value2 != null ? (range.Cells[row, 3] as Excel.Range).Value2.ToString() : string.Empty;

                    string zarLagaValue = (range.Cells[row, 4] as Excel.Range).Value2 != null ? (range.Cells[row, 4] as Excel.Range).Value2.ToString() : string.Empty;
                    if (zarLagaValue != "0.00")
                    {
                        dataRow["Зарлага"] = zarLagaValue;
                        dataRow["Орлого"] = (range.Cells[row, 5] as Excel.Range).Value2 != null ? (range.Cells[row, 5] as Excel.Range).Value2.ToString() : string.Empty;
                        dataRow["Эцсийн үлд"] = (range.Cells[row, 6] as Excel.Range).Value2 != null ? (range.Cells[row, 6] as Excel.Range).Value2.ToString() : string.Empty;
                        dataRow["Гүйлгээний утга"] = (range.Cells[row, 7] as Excel.Range).Value2 != null ? (range.Cells[row, 7] as Excel.Range).Value2.ToString() : string.Empty;
                        dataRow["Харилцах данс"] = (range.Cells[row, 8] as Excel.Range).Value2 != null ? (range.Cells[row, 8] as Excel.Range).Value2.ToString() : string.Empty;
                        dt.Rows.Add(dataRow);
                    }
                    progressBarControl1.PerformStep();
                }
                
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["№"] = i + 1;
                }

                gridControl.DataSource = dt;

                DevExpress.XtraGrid.Views.Grid.GridView gridView = gridControl.MainView as DevExpress.XtraGrid.Views.Grid.GridView;
                if (gridView != null)
                {
                    gridView.Columns["№"].Width = 30;
                    dataSetFill ds = new dataSetFill();
                    DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookupEdit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
                    DataTable projectData = ds.gridFill("getProject", "status=9") as DataTable;
                    if (projectData != null && projectData.Rows.Count > 0)
                    {
                        lookupEdit.DataSource = projectData;
                        lookupEdit.DisplayMember = "projectName"; // ComboBox-д харагдах утга
                        lookupEdit.ValueMember = "projectID";     // Дотоод утга
                        lookupEdit.NullText = "Төсөл сонгох"; // Анхны харагдах текст
                        lookupEdit.PopulateColumns();
                        foreach (DevExpress.XtraEditors.Controls.LookUpColumnInfo column in lookupEdit.Columns)
                        {
                            if (column.FieldName != "projectName")
                            {
                                column.Visible = false;  // projectName-ээс бусад багануудыг нуух
                            }
                        }
                       
                        if (gridView1 != null && gridView.Columns["Төслийн нэр"] != null)
                        {
                            gridView1.Columns["Төслийн нэр"].ColumnEdit = lookupEdit;
                        }
                    }

                    DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit buttonEdit = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
                    buttonEdit.Buttons[0].Caption = "Бүртгэх";
                    buttonEdit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
                    buttonEdit.ButtonClick += (s, e) =>
                    {
                        
                        int rowHandle = gridView.FocusedRowHandle;
                        string projectName = gridView.GetRowCellValue(rowHandle, "Төслийн нэр").ToString();
                        if (projectName != "")
                        {
                            addcost();
                        }
                        else
                        {
                            MessageBox.Show("Төсөл тодорхойгүй байна.");
                        }
                    };
                    gridView.Columns["Бүртгэх"].ColumnEdit = buttonEdit;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Excel файл уншихад алдаа гарлаа: {0}", ex.Message));
            }
            finally
            {
                workbook.Close(false);
                excelApp.Quit();

                System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
                simpleButton1.Enabled = true;
                worksheet = null;
                workbook = null;
                excelApp = null;
                GC.Collect();
            }
        }



        private void gethuulga_Load(object sender, EventArgs e)
        {

        }



        private void button1_Click(object sender, EventArgs e)
        {
        
        }
        private void addcost()
        {
            try
            {
                dataSetFill dcd = new dataSetFill();
                var data = new NameValueCollection();
                string formattedValue = gridView1.GetFocusedRowCellValue("Зарлага").ToString().Trim().Replace(".00", "");
                formattedValue = formattedValue.Replace(",", "").Replace("-", "");
                data["projectID"] = gridView1.GetFocusedRowCellValue("Төслийн нэр").ToString().Trim();
                data["costname"] = gridView1.GetFocusedRowCellValue("Гүйлгээний утга").ToString().Trim();
                data["cost"] = formattedValue;
                data["ognoo"] = Convert.ToDateTime(gridView1.GetFocusedRowCellValue("Огноо").ToString().Trim()).ToString("yyyy-MM-dd");

                DialogResult dr = MessageBox.Show("ID: " + data["projectID"] + " \nТөслийн нэр: " + gridView1.GetFocusedRowCellDisplayText("Төслийн нэр").Trim() + "\n Зардлын нэр: " + data["costname"] + "\n Зардлын дүн: " + data["cost"] + "\n Огноо: " + data["ognoo"], "Анхаар зардлын мэдээллийг нэмэх үү", MessageBoxButtons.YesNo);
                if (dr == System.Windows.Forms.DialogResult.Yes)
                {
                    MessageBox.Show(dcd.exec_command("addcost", data));
                }

            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            finally
            {

                f.FillGridCost(Convert.ToInt16(projectID.Text));
            }
        }

        private void SuggestProjectBasedOnTransaction(DevExpress.XtraGrid.Views.Grid.GridView gridView, DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookupEdit)
        {
            try
            {
                // LookUpEdit-ийн DisplayMember-үүдийг авах
                List<string> projectNames = new List<string>();
                DataTable projectData = lookupEdit.DataSource as DataTable;

                if (projectData != null)
                {
                    foreach (DataRow row in projectData.Rows)
                    {
                        projectNames.Add(row[lookupEdit.ValueMember].ToString()); // ValueMember-ийг хадгалах
                    }
                }

                // GridView-ийн мөр бүрийг шалгах
                for (int i = 0; i < gridView.RowCount; i++)
                {
                    string transactionValue = gridView.GetRowCellValue(i, "Гүйлгээний утга") != null
                        ? gridView.GetRowCellValue(i, "Гүйлгээний утга").ToString()
                        : string.Empty;
 
                    // TransactionValue нь ProjectValues-д байгаа эсэхийг шалгах
                    foreach (string projectValue in projectNames)
                    {
                        if (!string.IsNullOrEmpty(transactionValue) && transactionValue.Contains(projectValue))
                        {
                            // DisplayMember-ийг ашиглан төслийн нэрийг харуулах
                            string projectName = projectData.AsEnumerable()
                                .Where(row => row[lookupEdit.ValueMember].ToString() == projectValue)
                                .Select(row => row[lookupEdit.DisplayMember].ToString())
                                .FirstOrDefault();

                            // MessageDialog ашиглан үйлдэл хийх
                            var result = DevExpress.XtraEditors.XtraMessageBox.Show(
                                string.Format("Мөр №{0}: \"{1}\" гүйлгээ нь \"{2}\" төсөлд хамаарах боломжтой байна.\nҮүнийг баталгаажуулах уу?",
                                              i + 1, transactionValue, projectName),
                                "Санал болгох",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question
                            );

                            if (result == DialogResult.Yes)
                            {
                                // GridView-ээс мөрийн тусгай баганын LookUpEdit утгыг шинэчлэх
                                gridView.SetRowCellValue(i, "Төслийн нэр", projectValue); // projectValue нь ValueMember-ийг ашиглан төслийг олж авсан утга.

                                // Өөрийн кодыг ашиглан төслийн нэрийг бүртгэх
                                //addcost(i, transactionValue, projectName); // addcost функц хэрэглээрэй
                            }
                            break; // Давхардсан шалгалтыг зогсоох
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Алдаа гарлаа: " + ex.Message);
            }
        }



        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                // lookupEdit контролнд тохирох хувьсагчийг ашиглах
                DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookupEdit = gridView1.Columns["Төслийн нэр"].ColumnEdit as DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit;

                if (lookupEdit != null)
                {
                    SuggestProjectBasedOnTransaction(gridView1, lookupEdit);
                }
                else
                {
                    MessageBox.Show("Төслийн нэрийн LookUpEdit алдаатай байна.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Алдаа гарсан: " + ex.Message, "Алдаа", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                simpleButton1.Enabled = true;
            }

        }

    
    
    }
}
