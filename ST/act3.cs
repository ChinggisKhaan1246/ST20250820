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
    public partial class Zoinj : Form
    {
        public Zoinj()
        {
            InitializeComponent();
        }

        private void locationEdit_EditValueChanged(object sender, EventArgs e)
        {
            avtorSign.Text = Avtor.Text;
        }

        private void row7_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void row6_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void row5_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void row4_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void row3_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void aimag_EditValueChanged(object sender, EventArgs e)
        {
           
        }

        private void Zinj_EditValueChanged(object sender, EventArgs e)
        {
            Zahsign.Text = Zinj.Text;
        }

        private void Bainj_EditValueChanged(object sender, EventArgs e)
        {
            Bainjsign.Text = Bainj.Text;
        }

        private void daamal_EditValueChanged(object sender, EventArgs e)
        {
            Daamalsign.Text = daamal.Text;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var data = new NameValueCollection();
            dataSetFill dcd = new dataSetFill();
            if (aimag.Text != "" && sumname.Text != "" && barilga.Text != "" && Bainj.Text != "" && actNo.Text != "")
            {
                try
                {
                    data["projectID"] = projectID.Text;
                    data["actID"] = actID.Text;
                    data["actognoo"] = actognoo.DateTime.ToString("yyyy-MM-dd");
                    data["actNo"] = actNo.Text;
                    data["pageN"] = pageN.Text;
                    data["Guinj"] = Bainj.Text;
                    data["Zainj"] = Zinj.Text;
                    data["Zoinj"] = Avtor.Text;
                    data["Daamal"] = daamal.Text;
                    data["blockname"] = blockname.Text;
                    data["locationB"] = locationB.Text;
                    data["row1"] = row1.Text;
                    data["row2"] = row2.Text;
                    data["row3"] = row3.Text;
                    data["row4"] = row4.Text;
                    data["row5"] = row5.Text;
                    data["row6"] = row6.Text;
                    data["row7"] = row7.Text;
                    MessageBox.Show(dcd.exec_command("addact", data));
                    //ildaldact ii = new ildaldact();
                    //ii.gridControl1_Click(sender, e);
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.ToString());
                }
                finally { }
            }
            else
            {
                MessageBox.Show("Өгөгдөл дутуу байна.");
            }
        }

        private void Zoinj_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) // Enter товч дарагдсан эсэхийг шалгана
            {
                simpleButton1.PerformClick(); // simpleButton1_Click функцыг дуудаж байна
            }
        }
    }
}
