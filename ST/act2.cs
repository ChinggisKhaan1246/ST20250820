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
    public partial class act2 : Form
    {
    
        public act2()
        {
         
            InitializeComponent();
        }
        
        private void act2_Load(object sender, EventArgs e)
        {
            tognoo.EditValue = DateTime.Now;
           
            
            
           
        }

        private void textEdit18_EditValueChanged(object sender, EventArgs e)
        {
           
        }

        private void textEdit17_EditValueChanged(object sender, EventArgs e)
        {
           
        }

        private void textEdit19_EditValueChanged(object sender, EventArgs e)
        {
            Bainjsign.Text = Bainj.Text;
        }

        private void textEdit20_EditValueChanged(object sender, EventArgs e)
        {
            Daamalsign.Text = Daamal.Text;
        }

        private void textEdit16_EditValueChanged(object sender, EventArgs e)
        {
            Bainjsign.Text = Erinj.Text;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var data = new NameValueCollection();
            dataSetFill dcd = new dataSetFill();
            if (aimag.Text != "" && sumname.Text != "" && barilga.Text != "" && Erinj.Text !="" && actNo.Text != "")
            {
                try
                {
                    data["projectID"] = projectID.Text;
                    data["actID"] = actID.Text;
                    data["actognoo"] = Actognoo.DateTime.ToString("yyyy-MM-dd");
                    data["actNo"] = actNo.Text;
                    data["Guinj"] = Erinj.Text;
                    data["Zainj"] = Zainj.Text;
                    data["Zoinj"] = Avtor.Text;
                    data["Daamal"] = Daamal.Text;
                    data["row11"] = row11.Text;
                    data["row12"] = row12.Text;
                    data["row13"] = row13.Text;
                    data["tuvshin"] = tuvshin.Text;
                    data["tognoo"] = tognoo.DateTime.ToString("yyyy-MM-dd");
                    data["row32"] = row32.Text;
                    data["avsanner"] = avsanner.Text;
                    data["row41"] = row41.Text;
                    data["row51"] = row51.Text;
                    data["row52"] = row52.Text;
                    data["row53"] = row53.Text;
                    MessageBox.Show(dcd.exec_command("addact", data));
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.ToString());
                }
                finally { simpleButton2_Click(sender, e); }
            }
            else
            {
                MessageBox.Show("Өгөгдөл дутуу байна.");
            }
        }

        private void labelControl13_Click(object sender, EventArgs e)
        {

        }

        private void Zainj_EditValueChanged(object sender, EventArgs e)
        {
            Zahsign.Text = Zainj.Text;
        }

        private void Avtor_EditValueChanged(object sender, EventArgs e)
        {
            avtorSign.Text = Avtor.Text;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            actNo.Text = "";
            locationB.Text = "";
            Bainj.Text = "";
            Zainj.Text = "";
            Avtor.Text =  "";
            Erinj.Text = "";
            Daamal.Text = "";
            row11.Text = "";
            row12.Text = "";
            row13.Text = "";
            row32.Text = "";
            row41.Text = "";
            row51.Text = "";
            row52.Text = "";
            row53.Text = "";
            avsanner.Text = "";
            tuvshin.Text = "";



            
        }

        private void act2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) // Enter товч дарагдсан эсэхийг шалгана
            {
                simpleButton1.PerformClick(); // simpleButton1_Click функцыг дуудаж байна
            }
        }
    }
}
