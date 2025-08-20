using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Collections.Specialized;
namespace ST
{
    public partial class Zform : Form
    {
        Form1 f;
        public Zform(Form1 ff)
        {
            InitializeComponent();
            f = ff;
        }
        dataSetFill ds = new dataSetFill();
        private void simpleButton10_Click(object sender, EventArgs e)
        {
          /*  var data = new NameValueCollection();

            if (f.gridView2.RowCount > 0)
            {

               

                data["zeelner"] = Zeelner.Text;
                data["zeelphone"] = Zeelutas.Text;
                data["zeelcar"] = Zeelcar.Text;
                data["zeeladdress"] = Zeeladdress.Text;
                data["tulsun"] = zeeltulsun.Text;

                data["saler_id"] = f.salerID.Text;
                data["ognoo"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                data["turul"] = "зээлээр";
                data["unetotal"] = f.gridView3.Columns["dun"].SummaryText;
              //  data["items"] = f.DataTableToJSON(f.cardTableCont);
                Zeeladdress.Text = "";
                Zeelner.Text = "";
                Zeelutas.Text = "";
                Zeelcar.Text = "";
                
                MessageBox.Show(ds.exec_command("addZarsan", data));
                f.saveLogg(f.salerID.Text, "Зээлээр борлуулалт хийсэн");
                f.cardTable.Clear();
                f.cardTableCont.Clear();
                f.label6.Text = f.label6.Text + "1";
                this.Hide();
            }
            else { MessageBox.Show("Сагс хоосон байна"); }  */
        }
        //Shuud ingeed oruulchuul yadiin болж байвал яахав дээ. одоо логг хадгалахаар хоосон мсжbox гарч ирээд байхын php хуудаснаас хоосон утга ирээд байгаат
        //Log hadgalj bgaa ni haana bgaa bil ee за
        //za odoo bolson bh
        private void Zform_Load(object sender, EventArgs e)
        {

        }
    }
}
