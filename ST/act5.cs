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
    public partial class act5 : Form
    {
        public act5()
        {
            InitializeComponent();
        }

        private void act5_Load(object sender, EventArgs e)
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
                    data["row1"] = row1.Text;
                    data["row2"] = row2.Text;
                    data["row3"] = row6.Text;
                    data["row4"] = row7.Text;
                    data["row5"] = row5.Text;
                    data["row6"] = row6.Text;
                    data["row7"] = row7.Text;
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

        private void act5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) // Enter товч дарагдсан эсэхийг шалгана
            {
                simpleButton1.PerformClick(); // simpleButton1_Click функцыг дуудаж байна
            }
        }
    }
}
