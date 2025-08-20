using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Specialized;

namespace ST
{
    public partial class addplan : Form
    {
        fplans f;
        public addplan(fplans ff)
        {
            InitializeComponent();
            f = ff;
        }

        private void addplan_Load(object sender, EventArgs e)
        {
            try
            {
                dataSetFill ds = new dataSetFill();
                DataTable result;
                result = ds.gridFill("getita", "itatype=daily");
                engname.Properties.DataSource = result;
                engname.Properties.ValueMember = "id";
                engname.Properties.DisplayMember = "ner";
                engname.Properties.Columns.Clear(); // Бүх багануудаа цэвэрлэнэ
                engname.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ner", "Нэр"));
                engname.Properties.DropDownRows = result.Rows.Count;
                xabname.Properties.DataSource = result;
                xabname.Properties.ValueMember = "id";
                xabname.Properties.DisplayMember = "ner";
                xabname.Properties.Columns.Clear(); // Бүх багануудаа цэвэрлэнэ
                xabname.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ner", "Нэр"));
                xabname.Properties.DropDownRows = result.Rows.Count;
                daamalname.Properties.DataSource = result;
                daamalname.Properties.ValueMember = "id";
                daamalname.Properties.DisplayMember = "ner";
                daamalname.Properties.Columns.Clear(); // Бүх багануудаа цэвэрлэнэ
                daamalname.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ner", "Нэр"));
                daamalname.Properties.DropDownRows = result.Rows.Count;
                ognoo.DateTime = DateTime.Now;
                ognoo2.DateTime = DateTime.Now;
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
            var data = new NameValueCollection();
            dataSetFill dcd = new dataSetFill();
            if (projectName.Text != "" && projectID.Text != "" && engname.Text != "")
            {
                try
                {
                    data["projectID"] = projectID.Text.Trim();
                    data["engID"] = engname.EditValue.ToString();
                    data["xabID"] = xabname.EditValue.ToString();
                    data["daamalID"] = daamalname.EditValue.ToString();
                    data["ajilchid"] = ajilchid.Text;
                    data["hiih"] = hiih.Text;
                    data["mechanism"] = mechanism.Text;
                    data["ognoo"] = ognoo.DateTime.ToString("yyyy-MM-dd hh:mm:ss");
                    data["ognooD"] = ognoo2.DateTime.ToString("yyyy-MM-dd hh:mm:ss");
                    data["userID"] = UserSession.LoggedUserID.ToString();
                    data["status"] = "шинэ";
                    MessageBox.Show(dcd.exec_command("addplan", data));
                }
                catch (Exception ee)
                {
                    MessageBox.Show("Алдаа: "+ee.ToString());
                }
                finally
                {
                    f.FillPlans();
                }
            }
            else
            {
                MessageBox.Show("Өгөгдөл дутуу байна.");
            }
        }

        private void addplan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) // Enter товч дарагдсан эсэхийг шалгана
            {
                simpleButton1.PerformClick(); // simpleButton1_Click функцыг дуудаж байна
            }
        }
    }
}
