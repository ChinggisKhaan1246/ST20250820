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
    public partial class fzartsuulah : Form
    {
        fmaterials f;
        public fzartsuulah(fmaterials ff)
        {
            InitializeComponent();
            f = ff;
        }

        private void pictureEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void keytext_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
               projectID.Text = projectName.EditValue.ToString();
               panelControl1.Visible = true;
            }
           
            finally
            {
                f.fillGridZar();
            }


        }

        private void too_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (too.Text == "") 
                {
                    too.Text = "0";
                }

                niit.Text = (Convert.ToInt64(une.Text) * Convert.ToInt64(too.Text)).ToString();
            }
            catch(Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }

        }

        private void fzartsuulah_Load(object sender, EventArgs e)
        {

        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var data = new NameValueCollection();
            dataSetFill dcd = new dataSetFill();
            if (projectName.Text != "" && projectID.Text != "" && human.Text != "" && matID.Text !="")
            {
                try
                {
                    if (Convert.ToInt64(too.Text.Trim()) <= Convert.ToInt64(uldegdel.Text.Trim()))
                    {
                        if (Convert.ToInt64(too.Text.Trim()) != 0)
                        {
                            data["projectID"] = projectName.EditValue.ToString();
                            data["matID"] = matID.Text.Trim();
                            data["humanID"] = human.EditValue.ToString();
                            data["too"] = too.Text.Trim();
                            data["uldegdel"] = uldegdel.Text.Trim();
                            data["ognoo"] = ognoo.DateTime.ToString("yyyy-MM-dd hh:mm:ss");
                            MessageBox.Show(dcd.exec_command("addmatzar", data));
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("0 утгаар зарцуулалт хийх боломжгүй.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Үлдэгдэл  хүрэлцэхгүй байна.");
                    }
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.ToString());
                }
                finally
                {
                    f.fillGridZar();
                    f.fillGridMat();
                    
                }
            }
            else
            {
                MessageBox.Show("Өгөгдөл дутуу байна.");
            }
        }
    }
}
