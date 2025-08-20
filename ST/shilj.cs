using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections.Specialized;
namespace ST
{
    public partial class shilj : Form
    {
        Form1 f;
        public shilj(Form1 ff)
        {
            InitializeComponent();
            f = ff;
        }

        dataSetFill dsB = new dataSetFill();
        private void shilj_Load(object sender, EventArgs e)
        {
            dateEdit1.EditValue = DateTime.Now;
            
            try
            {

                shcid.Properties.DataSource = dsB.gridFill("getCont");
                shcid.Properties.DisplayMember = "name";
                shcid.Properties.ValueMember = "cid";

              
            }
            catch (Exception)
            { }
            finally { };
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if (shcid.Text == "")
                {
                    MessageBox.Show("Очих агуулахыг сонгоогүй байна.");
                }
                else if ((Convert.ToInt32(shtoo.Text)) > (Convert.ToInt32(too.Text)))
                {
                    MessageBox.Show("Байгаа хэмжээнээс хэтэрсэн тоо хэмжээг шилжүүлэх боломжгүй.");
                }
                else if (aguulax.Text == shcid.Text)
                {
                    MessageBox.Show("Одоо байгаа болон шижлүүлэх агуулахуудын нэрс ижил байна.");
                }

                else
                {
                    var data = new NameValueCollection();
                    data["bara_id"] = baraID.Text;
                    data["id"] = baraID.Text;
                    data["btoo"] = too.Text;
                    data["shtoo"] = shtoo.Text;
                    data["shcid"] = shcid.EditValue.ToString();
                    data["bcid"] = bcid.Text;
                    data["ognoo"] = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                    data["saler_id"] = f.comName.Text;
                    int check = Convert.ToInt32(too.Text) - Convert.ToInt32(shtoo.Text);
                    if (check == 0)
                    {
                        data["types"] = "all";
                    }
                    else
                    {
                        data["types"] = "part";
                    }
                    MessageBox.Show(dsB.exec_command("shiljuul", data));
                    // f.saveLogg(f.salerID.Text, f.salerName.Text, "Агуулах хооронд шилжүүлсэн");
                    
                    
                    f.label6.Text += "1";
                    this.Hide();
                }



                

            }
            catch (Exception)
            {
                MessageBox.Show("өгөгдлийн санд хадгалах үед нэг хөөрхөн алдаа гарлаа. Тэр нь угаасаа олдохгүй байх доо. ");
                
            }
            finally
            {
                
            }
        }

        private void shtoo_EditValueChanged(object sender, EventArgs e)
        {
           
        }

        private void shaguulax_EditValueChanged(object sender, EventArgs e)
        {
            
        }

        private void label8_Click(object sender, EventArgs e)
        {
            shtoo.Text = too.Text;
        }

        private void shtoo_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
           
        }
    }
}
