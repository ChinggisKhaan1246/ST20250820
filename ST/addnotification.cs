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
    public partial class addnotification : Form
    {
        public addnotification()
        {
            InitializeComponent();
        }

        private void addnotification_Load(object sender, EventArgs e)
        {
            try
            {
                dataSetFill ds = new dataSetFill();
                DataTable result;
                ognoo.DateTime = DateTime.Now;
                result = ds.gridFill("getuser");

                username.Properties.DataSource = result;
                username.Properties.ValueMember = "id";  // Сонгогдох утга (id)
                username.Properties.DisplayMember = "ner";  // Харагдах утга (Нэр)

                // Харагдах багануудыг тохируулах
                username.Properties.Columns.Clear(); // Бүх багануудыг цэвэрлэнэ
                username.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ner", "Нэр"));
                username.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("phone", "Утас")); // Phone баганыг нэмнэ

                username.Properties.DropDownRows = result.Rows.Count;

                // EditValueChanged эвент нэмэх
                //username.EditValueChanged += Username_EditValueChanged;

            }
            catch (Exception ee)
            {
                MessageBox.Show("Алдаа" + ee.ToString());
            }
            finally { }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (username.EditValue != null)
                {
                    var data = new NameValueCollection();
                    dataSetFill dcd = new dataSetFill();
                    if (checkBox1.Checked)
                    {
                        //MessageBox.Show(username.GetColumnValue("phone").ToString().Trim());
                        data["comID"] = UserSession.LoggedComID.ToString();
                        data["sendTo"] = username.GetColumnValue("phone").ToString().Trim();
                        data["notification"] = Nofi.Text.Trim();
                        data["status"] = "0";
                        data["hend"] = "0";
                        data["Nread"] = "0";
                        data["ognoo"] = ognoo.DateTime.ToString("yyyy-MM-dd hh:mm:ss");
                        MessageBox.Show(dcd.exec_command("sendsms", data));
                    }
                    else if (checkBox2.Checked)
                    {
                        data["comID"] = UserSession.LoggedComID.ToString().Trim();
                        data["sendTo"] = username.EditValue.ToString().Trim();
                        data["notification"] = Nofi.Text.Trim();
                        data["status"] = "0";
                        data["hend"] = "0";
                        data["Nread"] = "0";
                        data["ognoo"] = ognoo.DateTime.ToString("yyyy-MM-dd hh:mm:ss");
                        MessageBox.Show(dcd.exec_command("addnoti", data));
                    }
                    else
                    {
                        MessageBox.Show("Илгээх хувилбарыг сонгоно уу.");
                    }
                }
                else
                {
                    MessageBox.Show("Хэнд илгээх нь тодорхойгүй байна.");
                }
            }
            catch
            {
                MessageBox.Show("Алдаа");
            }
            finally { }
        }

        private void username_EditValueChanged(object sender, EventArgs e)
        {
            
        }
    }
}
