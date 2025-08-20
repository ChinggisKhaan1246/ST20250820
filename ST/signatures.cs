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
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;

namespace ST
{
    public partial class signatures : Form
    {
        public signatures()
        {
            InitializeComponent();
            gridView1.CustomUnboundColumnData += (sender, e) =>
            {
                GridView view = sender as GridView;
                if (e.Column.FieldName == "dd" && e.IsGetData)
                    e.Value = view.GetRowHandle(e.ListSourceRowIndex) + 1;
            };
        }
        dataSetFill ds = new dataSetFill();
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (ner.Text != null || ovog.Text != null || albantushaal.Text != null || engtype.Text != "Сонгоно уу!")
            {
                var data = new NameValueCollection();
                data["uureg"] = engtype.Text.Trim();
                data["ogov"] = ovog.Text.Trim();
                data["ner"] = ner.Text.Trim();
                data["albantushaal"] = albantushaal.Text.Trim();
                if (engtype.SelectedIndex == 1) { data["engtype"] = "ZAH"; }
                if (engtype.SelectedIndex == 2) { data["engtype"] = "ZOH"; }
                if (engtype.SelectedIndex == 3) { data["engtype"] = "ERCHIM"; }
                if (engtype.SelectedIndex == 4) { data["engtype"] = "USSUVAG"; }
                if (engtype.SelectedIndex == 5) { data["engtype"] = "DULAAN"; }
                if (engtype.SelectedIndex == 6) { data["engtype"] = "ONTSGOI"; }
                if (engtype.SelectedIndex == 7) { data["engtype"] = "HOLBOO"; }
                if (engtype.SelectedIndex == 8) { data["engtype"] = "ASHIGLAGCH"; }
                data["projectID"] = projectID.Text.Trim();
                MessageBox.Show(ds.exec_command("addsignature", data));
                FillGridSing();
                
            }
            else
            {
                MessageBox.Show("Өгөгдөл дутуу байна, төрөл сонгож бүх талбарыг бөглөөрэй.");
            }
        }

        private void FillGridSing()
        {
            try
            {
                var DT = ds.gridFill("getacteng", "projectID=" + projectID.Text.Trim());
                gridControl1.DataSource = DT;
            }
            catch (Exception)
            {
                MessageBox.Show("Та төсөлөө сонгоогүй байна.");
            }
 
        }

        private void signatures_Load(object sender, EventArgs e)
        {
            FillGridSing();
            gridView1.Columns["id"].Width = 35;
            gridView1.Columns["ovog"].Width = 170;
            gridView1.Columns["ner"].Width = 170;
            gridView1.Columns["uureg"].Width = 220;
            engtype.Properties.DropDownRows = engtype.Properties.Items.Count;

        }

        private void устгахToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                dataSetFill dc = new dataSetFill();
                string id = gridView1.GetFocusedRowCellValue("id").ToString();
                DialogResult ds = MessageBox.Show("Тухайн энэ мэдээллийг устгахдаа итгэлтэй байна уу." + id, "Анхаар", MessageBoxButtons.YesNo);
                if (ds == System.Windows.Forms.DialogResult.Yes)
                {
                    var data = new NameValueCollection();
                    data["deleteid"] = id.Trim();
                    MessageBox.Show(dc.exec_command("deleteacteng", data));
                    FillGridSing();
                }
            }
            catch (Exception ee)
            { MessageBox.Show(ee.ToString()); }
            finally { }
        }

        private void engtype_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (gridView1.RowCount == 0)
            {
                e.Cancel = true; 
            }
        }
            
    }
}
