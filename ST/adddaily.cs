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
    public partial class adddaily : Form
    {
        redbook f;
        public adddaily(redbook ff)
        {
            InitializeComponent();
            f = ff;
        }
        
        private void adddaily_Load(object sender, EventArgs e)
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
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            finally 
            {
 
            }

               
        }

        private void engname_EditValueChanged(object sender, EventArgs e)
        {
            var selectedId = engname.EditValue;

            // MessageBox-р id-ийг харуулах
          //  MessageBox.Show("Сонгосон item-ийн ID: " + selectedId.ToString());
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var data = new NameValueCollection();
            dataSetFill dcd = new dataSetFill();
            if (projectName.Text != "" && projectID.Text != "" && engname.Text != "")
            {
                try
                {
                    data["projectID"] = projectID.Text;
                    data["engID"] = engname.EditValue.ToString();
                    data["xabID"] = xabname.EditValue.ToString();
                    data["daamalID"] = daamalname.EditValue.ToString();
                    data["weather"] = weather.Text;
                    data["ajilchid"] = ajilchid.Text;
                    data["hiisen"] = hiisen.Text;
                    data["zorchil"] = zorchil.Text;
                    data["margaash"] = margaash.Text;
                    data["ognoo"] = ognoo.DateTime.ToString();
                    data["ognooD"] = ognoo.DateTime.ToString();
                    data["zurag2"] = "";
                    data["zurag3"] = "";
                    data["zurag4"] = "";
                    data["userID"] = UserSession.LoggedUserID.ToString();
                    MessageBox.Show(dcd.exec_command("adddaily", data));
                    //  this.Hide();
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.ToString());
                }
                finally 
                { 
                    f.redbook_Load(sender, e); this.Hide(); 
                }
            }
            else
            {
                MessageBox.Show("Өгөгдөл дутуу байна.");
            }

        }

        private void simpleButton1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) // Enter товч дарагдсан эсэхийг шалгана
            {
                simpleButton1.PerformClick(); // simpleButton1_Click функцыг дуудаж байна
            }
        }

        
        private  void ognoo_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                var data = new NameValueCollection();
                dataSetFill ds = new dataSetFill();
                data["aimag"] = aimag.Text.Trim();
                data["city"] = sum.Text.Trim();
                data["date"] = ognoo.DateTime.ToString("yyyy-MM-dd");
                weather.Text = ds.exec_command("getweather", data);
                
            }
            catch (Exception ee)
            {
                // Алдаа гарвал харуулах
                MessageBox.Show("Алдаа гарлаа: " + ee.Message);
            }
        }


    }
}
