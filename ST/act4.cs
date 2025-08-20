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
    public partial class act4 : Form
    {
        public act4()
        {
            InitializeComponent();
        }

        private void labelControl25_Click(object sender, EventArgs e)
        {

        }

        private void row6_EditValueChanged(object sender, EventArgs e)
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
                    data["blockname"] = blockname.Text;
                    data["daamal"] = daamal.Text;
                    data["locationB"] = sumname.Text;
                    data["row11"] = row11.Text;
                    data["row12"] = row12.Text;
                    data["row13"] = row13.Text;
                    data["row21"] = row21.Text;
                    data["row22"] = row22.Text;
                    data["row3"] = row3.Text;
                    data["row4"] = row4.Text;
                    data["haana"] = haana.Text;
                    


                    MessageBox.Show(dcd.exec_command("addact", data));
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

        private void Avtor_EditValueChanged(object sender, EventArgs e)
        {
            avtorSign.Text = Avtor.Text;
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

        private void act4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) // Enter товч дарагдсан эсэхийг шалгана
            {
                simpleButton1.PerformClick(); // simpleButton1_Click функцыг дуудаж байна
            }
        }
    }
}
