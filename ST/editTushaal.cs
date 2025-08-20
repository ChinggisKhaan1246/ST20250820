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
    public partial class editTushaal : Form
    {
        ZeelList z;
        public editTushaal(ZeelList zz)
        {
            InitializeComponent();
            z = zz;
        }
        dataSetFill ds = new dataSetFill();
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                var data = new NameValueCollection();
                data["id"] = ID.Text.Trim();
                data["Tnumber"] = Tnumber.Text;
                data["ognooDoc"] = ognooDoc.DateTime.ToString("yyyy-MM-dd");
                data["tuhai"] = tuhai.Text;
                data["Utga"] = Utga.Document.RtfText;
                data["UtgaNormal"] = Utga.Text;   
                data["signTushaal"] = signTushaal.Text;
                data["signName"] = signName.Text;
                MessageBox.Show(ds.exec_command("edittushaal", data));
                z.labelloader.Text += "1";
            }
            catch (Exception ee)
            { MessageBox.Show(ee.ToString()); }
            finally { this.Hide(); }
        }

        private void signTushaal_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (signTushaal.SelectedIndex == 0)
                {
                    combobox22.Properties.DataSource = ds.gridFill("getsign", "atushaal=Захирал");
                }
                if (signTushaal.SelectedIndex == 1)
                {
                    combobox22.Properties.DataSource = ds.gridFill("getsign", "atushaal=Холбооны инженер");
                }
                combobox22.Properties.DisplayMember = "ner";
                combobox22.Properties.ValueMember = "ner";
                combobox22.ItemIndex = 0;
                signName.Text = combobox22.Text;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            finally
            {

            }
        }
    }
}
