using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Net;
using System.IO;
using System.Collections.Specialized;
using Newtonsoft.Json;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.LookAndFeel;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrintingLinks;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.Utils;
namespace ST
{
    public partial class fildaldact : Form
    {
       
        public fildaldact()
        {
          
            InitializeComponent();
            gridView1.CustomUnboundColumnData += (sender, e) =>
            {
                GridView view = sender as GridView;
                if (e.Column.FieldName == "dd" && e.IsGetData)
                    e.Value = view.GetRowHandle(e.ListSourceRowIndex) + 1;
            };
        }

        dataSetFill dc = new dataSetFill();

        private void aguulax_Load(object sender, EventArgs e)
        {
           gridControl1.DataSource = dc.gridFill("getBook1"); //
          

        }
       
        private void simpleButton1_Click(object sender, EventArgs e)
        {
           

        }

        private void labelControl1_Click(object sender, EventArgs e)
        {
            /*string id = gridView1.GetFocusedRowCellValue("cid").ToString();
            DialogResult dr = MessageBox.Show("Агуулах утсгах уу", "Анхаар", MessageBoxButtons.YesNo);
            if (dr == System.Windows.Forms.DialogResult.Yes) {
                var data = new NameValueCollection();
                data["deleteid"] = id; 
                MessageBox.Show(dc.exec_command("deleteAguulah", data));
                // f.saveLogg(f.salerID.Text, f.salerName.Text, "Агуулахын бүртгэлээс устгасан");
                aguulax_Load(e, null);
            }*/
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
          
        }
       
        dataSetFill dsaz = new dataSetFill();
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            textEdit3.Text = gridView1.GetFocusedRowCellValue("id").ToString();
          
            switch (textEdit3.Text)
            {
                case "1":
                    {
                        MessageBox.Show("Буурь хөрсний акт Геодизийн байгууллагаас гарна.");
                        break;
                    }
                case "2":
                    {
                        act2 ac = new act2();
                        
                        ac.Text = "Улаан шугамыг татаж, тэг тэнхлэг тавьсан акт";
                        ac.aimag.Properties.DataSource = dsaz.gridFill("getlocation", "status=1&projectID=" + textEdit2.Text + "");
                        ac.aimag.Properties.DisplayMember = "aimag";
                        ac.aimag.Properties.ValueMember = "aimag";
                        ac.aimag.Properties.ForceInitialize();
                        ac.aimag.ItemIndex = 0;
                        
                        ac.sumname.Properties.DataSource = dsaz.gridFill("getlocation", "status=2&projectID=" + textEdit2.Text + "");
                        ac.sumname.Properties.DisplayMember = "sumname";
                        ac.sumname.Properties.ValueMember = "sumname";
                        ac.sumname.Properties.ForceInitialize();
                        ac.sumname.ItemIndex = 0;
                        
                        ac.barilga.Properties.DataSource = dsaz.gridFill("getlocation", "status=3&projectID=" + textEdit2.Text + "");
                        ac.barilga.Properties.DisplayMember = "projectName";
                        ac.barilga.Properties.ValueMember = "projectName";
                        ac.barilga.Properties.ForceInitialize();
                        ac.barilga.ItemIndex = 0;
                        
                        ac.projectID.Text = textEdit2.Text;
                        ac.actID.Text = textEdit3.Text;
                        ac.ShowDialog();
                        break;
                    }
                case "3":
                    {
                        Zoinj act3 = new Zoinj();
                        act3.Text = "Суурийн нүх ухсан акт";
                        act3.actognoo.EditValue = DateTime.Now.ToString("yyyy-MM-dd");
                        act3.aimag.Properties.DataSource = dsaz.gridFill("getlocation", "status=1&projectID=" + textEdit2.Text + "");
                        act3.aimag.Properties.DisplayMember = "aimag";
                        act3.aimag.Properties.ValueMember = "aimag";
                        act3.aimag.Properties.ForceInitialize();
                        act3.aimag.ItemIndex = 0;

                        act3.sumname.Properties.DataSource = dsaz.gridFill("getlocation", "status=2&projectID=" + textEdit2.Text + "");
                        act3.sumname.Properties.DisplayMember = "sumname";
                        act3.sumname.Properties.ValueMember = "sumname";
                        act3.sumname.Properties.ForceInitialize();
                        act3.sumname.ItemIndex = 0;

                        act3.barilga.Properties.DataSource = dsaz.gridFill("getlocation", "status=3&projectID=" + textEdit2.Text + "");
                        act3.barilga.Properties.DisplayMember = "projectName";
                        act3.barilga.Properties.ValueMember = "projectName";
                        act3.barilga.Properties.ForceInitialize();
                        act3.barilga.ItemIndex = 0;
                        
                        act3.projectID.Text = textEdit2.Text;
                        act3.actID.Text = textEdit3.Text;
                        act3.ShowDialog();
                        break;
                    }
                case "4":
                    {
                        act4 act4 = new act4();
                        act4.Text = "Цутгамал төмөр бетон бүтээцийг арматурчилсан АКТ";
                        act4.actognoo.EditValue = DateTime.Now.ToString("yyyy-MM-dd");
                        act4.aimag.Properties.DataSource        = dsaz.gridFill("getlocation", "status=1&projectID=" + textEdit2.Text + "");
                        act4.aimag.Properties.DisplayMember = "aimag";
                        act4.aimag.Properties.ValueMember = "aimag";
                        act4.aimag.Properties.ForceInitialize();
                        act4.aimag.ItemIndex = 0;

                        act4.sumname.Properties.DataSource      = dsaz.gridFill("getlocation", "status=2&projectID=" + textEdit2.Text + "");
                        act4.sumname.Properties.DisplayMember = "sumname";
                        act4.sumname.Properties.ValueMember = "sumname";
                        act4.sumname.Properties.ForceInitialize();
                        act4.sumname.ItemIndex = 0;

                        act4.barilga.Properties.DataSource      = dsaz.gridFill("getlocation", "status=3&projectID=" + textEdit2.Text + "");
                        act4.barilga.Properties.DisplayMember = "projectName";
                        act4.barilga.Properties.ValueMember = "projectName";
                        act4.barilga.Properties.ForceInitialize();
                        act4.barilga.ItemIndex = 0;
                        
                        act4.aimag.ItemIndex    = 0;
                        act4.projectID.Text     = textEdit2.Text;
                        act4.actID.Text         = textEdit3.Text;
                        act4.ShowDialog();
                        break;
                    }

                case "5":
                    {
                        act5 act5 = new act5();
                        act5.Text = "Суурь хийсэн АКТ";
                        act5.actognoo.EditValue = DateTime.Now.ToString("yyyy-MM-dd");
                        act5.aimag.Properties.DataSource = dsaz.gridFill("getlocation", "status=1&projectID=" + textEdit2.Text + "");
                        act5.aimag.Properties.DisplayMember = "aimag";
                        act5.aimag.Properties.ValueMember = "aimag";
                        act5.barilga.Properties.ForceInitialize();
                        act5.aimag.ItemIndex = 0;

                        act5.sumname.Properties.DataSource = dsaz.gridFill("getlocation", "status=2&projectID=" + textEdit2.Text + "");
                        act5.sumname.Properties.DisplayMember = "sumname";
                        act5.sumname.Properties.ValueMember = "sumname";
                        act5.sumname.Properties.ForceInitialize();
                        act5.sumname.ItemIndex = 0;

                        act5.barilga.Properties.DataSource = dsaz.gridFill("getlocation", "status=3&projectID=" + textEdit2.Text + "");
                        act5.barilga.Properties.DisplayMember = "projectName";
                        act5.barilga.Properties.ValueMember = "projectName";
                        act5.barilga.Properties.ForceInitialize();
                        act5.barilga.ItemIndex = 0;
                        
                        act5.aimag.ItemIndex = 0;
                        act5.projectID.Text = textEdit2.Text;
                        act5.actID.Text = textEdit3.Text;
                        act5.ShowDialog();
                        break;
                    }
                

            }
        }
        dataSetFill ds = new dataSetFill();
        public void gridControl1_Click(object sender, EventArgs e)
        {
            try
            {
                textEdit3.Text = gridView1.GetFocusedRowCellValue("id").ToString();

                switch (textEdit3.Text)
                {
                    case "1":
                        {
                            gridView2.Columns.Clear();

                            gridControl2.DataSource = ds.gridFill("getact", "actID=" + textEdit3.Text + "&projectID=" + textEdit2.Text + "");
                            if (gridView2.RowCount != 0)
                            {
                                gridView2.Columns[0].Visible = false;
                                gridView2.Columns[1].Visible = false;
                                gridView2.Columns[2].Visible = false;
                                gridView2.Columns[3].Visible = false;
                                gridView2.Columns[4].Caption = "Огноо";
                                gridView2.Columns[5].Caption = "AKT№";
                                gridView2.Columns[6].Visible = false;
                                gridView2.Columns[7].Visible = false;
                                gridView2.Columns[8].Caption = "Гүйцэтгэгч.Инж";
                                gridView2.Columns[8].FieldName = "Guinj";
                                gridView2.Columns[9].Visible = false;
                                gridView2.Columns[10].Visible = false;
                                gridView2.Columns[11].Visible = false;
                                gridView2.Columns[12].Visible = false;
                                gridView2.Columns[13].Visible = false;
                                gridView2.Columns[14].Visible = false;
                                gridView2.Columns[15].Visible = false;
                                gridView2.Columns[16].Visible = false;
                                gridView2.Columns[17].Visible = false;
                                gridView2.Columns[18].Visible = false;
                                gridView2.Columns[19].Visible = false;
                                gridView2.Columns[20].Visible = false;
                                gridView2.Columns[21].Visible = false;
                                gridView2.Columns[22].Visible = false;
                                gridView2.Columns[23].Visible = false;
                            }
                            else
                            { 
                            }

                            break;
                        }
                    case "2":
                        {
                            gridView2.Columns.Clear();
                            
                            gridControl2.DataSource = ds.gridFill("getact", "actID=" + textEdit3.Text + "&projectID=" + textEdit2.Text + "");
                             if (gridView2.RowCount != 0)
                            {
                            gridView2.Columns[0].Visible = false;
                            gridView2.Columns[1].Visible = false;
                            gridView2.Columns[2].Visible = false;
                            gridView2.Columns[3].Visible = false;
                            gridView2.Columns[4].Caption = "Огноо";
                            gridView2.Columns[5].Caption = "AKT№";
                            gridView2.Columns[6].Visible = false;
                            gridView2.Columns[7].Visible = false;
                            gridView2.Columns[8].Caption = "Гүйцэтгэгч.Инж";
                            gridView2.Columns[8].FieldName = "Guinj";
                            gridView2.Columns[9].Visible = false;
                            gridView2.Columns[10].Visible = false;
                            gridView2.Columns[11].Visible = false;
                            gridView2.Columns[12].Visible = false;
                            gridView2.Columns[13].Visible = false;
                            gridView2.Columns[14].Visible = false;
                            gridView2.Columns[15].Visible = false;
                            gridView2.Columns[16].Visible = false;
                            gridView2.Columns[17].Visible = false;
                            gridView2.Columns[18].Visible = false;
                            gridView2.Columns[19].Visible = false;
                            gridView2.Columns[20].Visible = false;
                            gridView2.Columns[21].Visible = false;
                            gridView2.Columns[22].Visible = false;
                            gridView2.Columns[23].Visible = false;
                            }
                             else
                             {
                             }
                            break;
                        }
                    case "3":
                        {
                            gridView2.Columns.Clear();
                            
                            gridControl2.DataSource = ds.gridFill("getact", "actID=" + textEdit3.Text + "&projectID=" + textEdit2.Text + "");
                               if (gridView2.RowCount != 0)
                            {
                                gridView2.Columns[0].Visible = false;
                                gridView2.Columns[1].Visible = false;
                                gridView2.Columns[2].Visible = false;
                                gridView2.Columns[3].Visible = false;
                                gridView2.Columns[4].Caption = "Огноо";
                                gridView2.Columns[5].Caption = "AKT№";
                                gridView2.Columns[6].Visible = false;
                                gridView2.Columns[7].Visible = false;
                                gridView2.Columns[8].Visible = false;
                                gridView2.Columns[9].Visible = false;
                                gridView2.Columns[10].Visible = false;
                                gridView2.Columns[11].Caption = "Гүйцэтгэгч.Инж";
                                gridView2.Columns[11].FieldName = "Guinj";
                                gridView2.Columns[12].Visible = false;
                                gridView2.Columns[13].Visible = false;
                                gridView2.Columns[14].Visible = false;
                                gridView2.Columns[15].Visible = false;
                                gridView2.Columns[16].Visible = false;
                                gridView2.Columns[17].Visible = false;
                                gridView2.Columns[18].Visible = false;
                                gridView2.Columns[19].Visible = false;
                                gridView2.Columns[20].Visible = false;
                           
                            }
                               else
                               {
                               }
                            break;
                        }
                    case "4":
                        {
                            gridView2.Columns.Clear();

                            gridControl2.DataSource = ds.gridFill("getact", "actID=" + textEdit3.Text + "&projectID=" + textEdit2.Text + "");
                            if (gridView2.RowCount != 0)
                            {
                                gridView2.Columns[0].Visible = false;
                                gridView2.Columns[1].Visible = false;
                                gridView2.Columns[2].Visible = false;
                                gridView2.Columns[3].Visible = false;
                                gridView2.Columns[4].Caption = "Огноо";
                                gridView2.Columns[5].Caption = "Акт №";
                                gridView2.Columns[6].Visible = false;
                                gridView2.Columns[7].Visible = false;
                                gridView2.Columns[8].Visible = false;
                                gridView2.Columns[9].Visible = false;
                                gridView2.Columns[10].Visible = false;
                                gridView2.Columns[11].Caption = "Гүйцэтгэгч.Инж";
                                gridView2.Columns[11].FieldName = "Guinj";
                                gridView2.Columns[12].Visible = false;
                                gridView2.Columns[13].Visible = false;
                                gridView2.Columns[14].Visible = false;
                                gridView2.Columns[15].Visible = false;
                                gridView2.Columns[16].Visible = false;
                                gridView2.Columns[17].Visible = false;
                                gridView2.Columns[18].Visible = false;
                                gridView2.Columns[19].Visible = false;
                                gridView2.Columns[20].Visible = false;
                                gridView2.Columns[21].Visible = true;
                                gridView2.Columns[21].Caption = "Ямар хэсэг";
                            }
                            else
                            {
                            }
                            break;
                        }
                    case "5":
                        {
                            gridView2.Columns.Clear();

                            gridControl2.DataSource = ds.gridFill("getact", "actID=" + textEdit3.Text + "&projectID=" + textEdit2.Text + "");
                            if (gridView2.RowCount != 0)
                            {
                                gridView2.Columns[0].Visible = false;
                                gridView2.Columns[1].Visible = false;
                                gridView2.Columns[2].Visible = false;
                                gridView2.Columns[3].Visible = false;
                                gridView2.Columns[4].Caption = "Огноо";
                                gridView2.Columns[5].Caption = "AKT№";
                                gridView2.Columns[6].Visible = false;
                                gridView2.Columns[7].Visible = false;
                                gridView2.Columns[8].Visible = false;
                                gridView2.Columns[9].Visible = false;
                                gridView2.Columns[10].Visible = false;
                                gridView2.Columns[11].Caption = "Гүйцэтгэгч.Инж";
                                gridView2.Columns[11].FieldName = "Guinj";
                                gridView2.Columns[12].Visible = false;
                                gridView2.Columns[13].Visible = false;
                                gridView2.Columns[14].Visible = false;
                                gridView2.Columns[15].Visible = false;
                                gridView2.Columns[16].Visible = false;
                                gridView2.Columns[17].Visible = false;
                                gridView2.Columns[18].Visible = false;
                                gridView2.Columns[19].Visible = false;
                                gridView2.Columns[20].Visible = false;
                               
                            }
                            else
                            {
                            }
                            break;
                        }
                    case "6":
                        {
                            gridView2.Columns.Clear();

                            gridControl2.DataSource = ds.gridFill("getact", "actID=" + textEdit3.Text + "&projectID=" + textEdit2.Text + "");
                            if (gridView2.RowCount != 0)
                            {
                                gridView2.Columns[0].Visible = false;
                                gridView2.Columns[1].Visible = false;
                                gridView2.Columns[2].Visible = false;
                                gridView2.Columns[3].Visible = false;
                                gridView2.Columns[4].Caption = "Огноо";
                                gridView2.Columns[5].Caption = "AKT№";
                                gridView2.Columns[6].Visible = false;
                                gridView2.Columns[7].Visible = false;
                                gridView2.Columns[8].Visible = false;
                                gridView2.Columns[9].Visible = false;
                                gridView2.Columns[10].Visible = false;
                                gridView2.Columns[11].Caption = "Гүйцэтгэгч.Инж";
                                gridView2.Columns[11].FieldName = "Guinj";
                                gridView2.Columns[12].Visible = false;
                                gridView2.Columns[13].Visible = false;
                                gridView2.Columns[14].Visible = false;
                                gridView2.Columns[15].Visible = false;
                                gridView2.Columns[16].Visible = false;
                                gridView2.Columns[17].Visible = false;
                                gridView2.Columns[18].Visible = false;
                                gridView2.Columns[19].Visible = false;
                            }
                            else
                            {
                            }
                            break;
                        }
                    case "7":
                        {
                            gridView2.Columns.Clear();

                            gridControl2.DataSource = ds.gridFill("getact", "actID=" + textEdit3.Text + "&projectID=" + textEdit2.Text + "");
                            if (gridView2.RowCount != 0)
                            {
                                gridView2.Columns[0].Visible = false;
                                gridView2.Columns[1].Visible = false;
                                gridView2.Columns[2].Visible = false;
                                gridView2.Columns[3].Visible = false;
                                gridView2.Columns[4].Caption = "Огноо";
                                gridView2.Columns[5].Caption = "AKT№";
                                gridView2.Columns[6].Visible = false;
                                gridView2.Columns[7].Visible = false;
                                gridView2.Columns[8].Visible = false;
                                gridView2.Columns[9].Visible = false;
                                gridView2.Columns[10].Visible = false;
                                gridView2.Columns[11].Caption = "Гүйцэтгэгч.Инж";
                                gridView2.Columns[11].FieldName = "Guinj";
                                gridView2.Columns[12].Visible = false;
                                gridView2.Columns[13].Visible = false;
                                gridView2.Columns[14].Visible = false;
                                gridView2.Columns[15].Visible = false;
                                gridView2.Columns[16].Visible = false;
                                gridView2.Columns[17].Visible = false;
                                gridView2.Columns[18].Visible = false;
                                gridView2.Columns[19].Visible = false;
                            }
                            else
                            {
                            }
                            break;
                        }
                    case "8":
                        {
                            gridView2.Columns.Clear();

                            gridControl2.DataSource = ds.gridFill("getact", "actID=" + textEdit3.Text + "&projectID=" + textEdit2.Text + "");
                            if (gridView2.RowCount != 0)
                            {
                                gridView2.Columns[0].Visible = false;
                                gridView2.Columns[1].Visible = false;
                                gridView2.Columns[2].Visible = false;
                                gridView2.Columns[3].Visible = false;
                                gridView2.Columns[4].Caption = "Огноо";
                                gridView2.Columns[5].Caption = "AKT№";
                                gridView2.Columns[6].Visible = false;
                                gridView2.Columns[7].Visible = false;
                                gridView2.Columns[8].Visible = false;
                                gridView2.Columns[9].Visible = false;
                                gridView2.Columns[10].Visible = false;
                                gridView2.Columns[11].Caption = "Гүйцэтгэгч.Инж";
                                gridView2.Columns[11].FieldName = "Guinj";
                                gridView2.Columns[12].Visible = false;
                                gridView2.Columns[13].Visible = false;
                                gridView2.Columns[14].Visible = false;
                                gridView2.Columns[15].Visible = false;
                                gridView2.Columns[16].Visible = false;
                                gridView2.Columns[17].Visible = false;
                                gridView2.Columns[18].Visible = false;
                                gridView2.Columns[19].Visible = false;
                            }
                            else
                            {
                            }
                            break;
                        }
                    case "9":
                        {
                            gridView2.Columns.Clear();

                            gridControl2.DataSource = ds.gridFill("getact", "actID=" + textEdit3.Text + "&projectID=" + textEdit2.Text + "");
                            if (gridView2.RowCount != 0)
                            {
                                gridView2.Columns[0].Visible = false;
                                gridView2.Columns[1].Visible = false;
                                gridView2.Columns[2].Visible = false;
                                gridView2.Columns[3].Visible = false;
                                gridView2.Columns[4].Caption = "Огноо";
                                gridView2.Columns[5].Caption = "AKT№";
                                gridView2.Columns[6].Visible = false;
                                gridView2.Columns[7].Visible = false;
                                gridView2.Columns[8].Visible = false;
                                gridView2.Columns[9].Visible = false;
                                gridView2.Columns[10].Visible = false;
                                gridView2.Columns[11].Caption = "Гүйцэтгэгч.Инж";
                                gridView2.Columns[11].FieldName = "Guinj";
                                gridView2.Columns[12].Visible = false;
                                gridView2.Columns[13].Visible = false;
                                gridView2.Columns[14].Visible = false;
                                gridView2.Columns[15].Visible = false;
                                gridView2.Columns[16].Visible = false;
                                gridView2.Columns[17].Visible = false;
                                gridView2.Columns[18].Visible = false;
                                gridView2.Columns[19].Visible = false;
                            }
                            else
                            {
                            }
                            break;
                        }
                    case "10":
                        {
                            gridView2.Columns.Clear();

                            gridControl2.DataSource = ds.gridFill("getact", "actID=" + textEdit3.Text + "&projectID=" + textEdit2.Text + "");
                            if (gridView2.RowCount != 0)
                            {
                                gridView2.Columns[0].Visible = false;
                                gridView2.Columns[1].Visible = false;
                                gridView2.Columns[2].Visible = false;
                                gridView2.Columns[3].Visible = false;
                                gridView2.Columns[4].Caption = "Огноо";
                                gridView2.Columns[5].Caption = "AKT№";
                                gridView2.Columns[6].Visible = false;
                                gridView2.Columns[7].Visible = false;
                                gridView2.Columns[8].Visible = false;
                                gridView2.Columns[9].Visible = false;
                                gridView2.Columns[10].Visible = false;
                                gridView2.Columns[11].Caption = "Гүйцэтгэгч.Инж";
                                gridView2.Columns[11].FieldName = "Guinj";
                                gridView2.Columns[12].Visible = false;
                                gridView2.Columns[13].Visible = false;
                                gridView2.Columns[14].Visible = false;
                                gridView2.Columns[15].Visible = false;
                                gridView2.Columns[16].Visible = false;
                                gridView2.Columns[17].Visible = false;
                                gridView2.Columns[18].Visible = false;
                                gridView2.Columns[19].Visible = false;
                            }
                            else
                            {
                            }
                            break;
                        }
                    case "11":
                        {
                            gridView2.Columns.Clear();

                            gridControl2.DataSource = ds.gridFill("getact", "actID=" + textEdit3.Text + "&projectID=" + textEdit2.Text + "");
                            if (gridView2.RowCount != 0)
                            {
                                gridView2.Columns[0].Visible = false;
                                gridView2.Columns[1].Visible = false;
                                gridView2.Columns[2].Visible = false;
                                gridView2.Columns[3].Visible = false;
                                gridView2.Columns[4].Caption = "Огноо";
                                gridView2.Columns[5].Caption = "AKT№";
                                gridView2.Columns[6].Visible = false;
                                gridView2.Columns[7].Visible = false;
                                gridView2.Columns[8].Visible = false;
                                gridView2.Columns[9].Visible = false;
                                gridView2.Columns[10].Visible = false;
                                gridView2.Columns[11].Caption = "Гүйцэтгэгч.Инж";
                                gridView2.Columns[11].FieldName = "Guinj";
                                gridView2.Columns[12].Visible = false;
                                gridView2.Columns[13].Visible = false;
                                gridView2.Columns[14].Visible = false;
                                gridView2.Columns[15].Visible = false;
                                gridView2.Columns[16].Visible = false;
                                gridView2.Columns[17].Visible = false;
                                gridView2.Columns[18].Visible = false;
                                gridView2.Columns[19].Visible = false;
                            }
                            else
                            {
                            }
                            break;
                        }
                    case "12":
                        {
                            gridView2.Columns.Clear();

                            gridControl2.DataSource = ds.gridFill("getact", "actID=" + textEdit3.Text + "&projectID=" + textEdit2.Text + "");
                            if (gridView2.RowCount != 0)
                            {
                                gridView2.Columns[0].Visible = false;
                                gridView2.Columns[1].Visible = false;
                                gridView2.Columns[2].Visible = false;
                                gridView2.Columns[3].Visible = false;
                                gridView2.Columns[4].Caption = "Огноо";
                                gridView2.Columns[5].Caption = "AKT№";
                                gridView2.Columns[6].Visible = false;
                                gridView2.Columns[7].Visible = false;
                                gridView2.Columns[8].Visible = false;
                                gridView2.Columns[9].Visible = false;
                                gridView2.Columns[10].Visible = false;
                                gridView2.Columns[11].Caption = "Гүйцэтгэгч.Инж";
                                gridView2.Columns[11].FieldName = "Guinj";
                                gridView2.Columns[12].Visible = false;
                                gridView2.Columns[13].Visible = false;
                                gridView2.Columns[14].Visible = false;
                                gridView2.Columns[15].Visible = false;
                                gridView2.Columns[16].Visible = false;
                                gridView2.Columns[17].Visible = false;
                                gridView2.Columns[18].Visible = false;
                                gridView2.Columns[19].Visible = false;
                            }
                            else
                            {
                            }
                            break;
                        }
                    case "13":
                        {
                            gridView2.Columns.Clear();

                            gridControl2.DataSource = ds.gridFill("getact", "actID=" + textEdit3.Text + "&projectID=" + textEdit2.Text + "");
                            if (gridView2.RowCount != 0)
                            {
                                gridView2.Columns[0].Visible = false;
                                gridView2.Columns[1].Visible = false;
                                gridView2.Columns[2].Visible = false;
                                gridView2.Columns[3].Visible = false;
                                gridView2.Columns[4].Caption = "Огноо";
                                gridView2.Columns[5].Caption = "AKT№";
                                gridView2.Columns[6].Visible = false;
                                gridView2.Columns[7].Visible = false;
                                gridView2.Columns[8].Visible = false;
                                gridView2.Columns[9].Visible = false;
                                gridView2.Columns[10].Visible = false;
                                gridView2.Columns[11].Caption = "Гүйцэтгэгч.Инж";
                                gridView2.Columns[11].FieldName = "Guinj";
                                gridView2.Columns[12].Visible = false;
                                gridView2.Columns[13].Visible = false;
                                gridView2.Columns[14].Visible = false;
                                gridView2.Columns[15].Visible = false;
                                gridView2.Columns[16].Visible = false;
                                gridView2.Columns[17].Visible = false;
                                gridView2.Columns[18].Visible = false;
                                gridView2.Columns[19].Visible = false;
                            }
                            else
                            {
                            }
                            break;
                        }
                    case "14":
                        {
                            gridView2.Columns.Clear();

                            gridControl2.DataSource = ds.gridFill("getact", "actID=" + textEdit3.Text + "&projectID=" + textEdit2.Text + "");
                            if (gridView2.RowCount != 0)
                            {
                                gridView2.Columns[0].Visible = false;
                                gridView2.Columns[1].Visible = false;
                                gridView2.Columns[2].Visible = false;
                                gridView2.Columns[3].Visible = false;
                                gridView2.Columns[4].Caption = "Огноо";
                                gridView2.Columns[5].Caption = "AKT№";
                                gridView2.Columns[6].Visible = false;
                                gridView2.Columns[7].Visible = false;
                                gridView2.Columns[8].Visible = false;
                                gridView2.Columns[9].Visible = false;
                                gridView2.Columns[10].Visible = false;
                                gridView2.Columns[11].Caption = "Гүйцэтгэгч.Инж";
                                gridView2.Columns[11].FieldName = "Guinj";
                                gridView2.Columns[12].Visible = false;
                                gridView2.Columns[13].Visible = false;
                                gridView2.Columns[14].Visible = false;
                                gridView2.Columns[15].Visible = false;
                                gridView2.Columns[16].Visible = false;
                                gridView2.Columns[17].Visible = false;
                                gridView2.Columns[18].Visible = false;
                                gridView2.Columns[19].Visible = false;
                            }
                            else
                            {
                            }
                            break;
                        }
                    case "15":
                        {
                            gridView2.Columns.Clear();

                            gridControl2.DataSource = ds.gridFill("getact", "actID=" + textEdit3.Text + "&projectID=" + textEdit2.Text + "");
                            if (gridView2.RowCount != 0)
                            {
                                gridView2.Columns[0].Visible = false;
                                gridView2.Columns[1].Visible = false;
                                gridView2.Columns[2].Visible = false;
                                gridView2.Columns[3].Visible = false;
                                gridView2.Columns[4].Caption = "Огноо";
                                gridView2.Columns[5].Caption = "AKT№";
                                gridView2.Columns[6].Visible = false;
                                gridView2.Columns[7].Visible = false;
                                gridView2.Columns[8].Visible = false;
                                gridView2.Columns[9].Visible = false;
                                gridView2.Columns[10].Visible = false;
                                gridView2.Columns[11].Caption = "Гүйцэтгэгч.Инж";
                                gridView2.Columns[11].FieldName = "Guinj";
                                gridView2.Columns[12].Visible = false;
                                gridView2.Columns[13].Visible = false;
                                gridView2.Columns[14].Visible = false;
                                gridView2.Columns[15].Visible = false;
                                gridView2.Columns[16].Visible = false;
                                gridView2.Columns[17].Visible = false;
                                gridView2.Columns[18].Visible = false;
                                gridView2.Columns[19].Visible = false;
                            }
                            else
                            {
                            }
                            break;
                        }
                    case "16":
                        {
                            gridView2.Columns.Clear();

                            gridControl2.DataSource = ds.gridFill("getact", "actID=" + textEdit3.Text + "&projectID=" + textEdit2.Text + "");
                            if (gridView2.RowCount != 0)
                            {
                                gridView2.Columns[0].Visible = false;
                                gridView2.Columns[1].Visible = false;
                                gridView2.Columns[2].Visible = false;
                                gridView2.Columns[3].Visible = false;
                                gridView2.Columns[4].Caption = "Огноо";
                                gridView2.Columns[5].Caption = "AKT№";
                                gridView2.Columns[6].Visible = false;
                                gridView2.Columns[7].Visible = false;
                                gridView2.Columns[8].Visible = false;
                                gridView2.Columns[9].Visible = false;
                                gridView2.Columns[10].Visible = false;
                                gridView2.Columns[11].Caption = "Гүйцэтгэгч.Инж";
                                gridView2.Columns[11].FieldName = "Guinj";
                                gridView2.Columns[12].Visible = false;
                                gridView2.Columns[13].Visible = false;
                                gridView2.Columns[14].Visible = false;
                                gridView2.Columns[15].Visible = false;
                                gridView2.Columns[16].Visible = false;
                                gridView2.Columns[17].Visible = false;
                                gridView2.Columns[18].Visible = false;
                                gridView2.Columns[19].Visible = false;
                            }
                            else
                            {
                            }
                            break;
                        }
                    case "17":
                        {
                            gridView2.Columns.Clear();

                            gridControl2.DataSource = ds.gridFill("getact", "actID=" + textEdit3.Text + "&projectID=" + textEdit2.Text + "");
                            if (gridView2.RowCount != 0)
                            {
                                gridView2.Columns[0].Visible = false;
                                gridView2.Columns[1].Visible = false;
                                gridView2.Columns[2].Visible = false;
                                gridView2.Columns[3].Visible = false;
                                gridView2.Columns[4].Caption = "Огноо";
                                gridView2.Columns[5].Caption = "AKT№";
                                gridView2.Columns[6].Visible = false;
                                gridView2.Columns[7].Visible = false;
                                gridView2.Columns[8].Visible = false;
                                gridView2.Columns[9].Visible = false;
                                gridView2.Columns[10].Visible = false;
                                gridView2.Columns[11].Caption = "Гүйцэтгэгч.Инж";
                                gridView2.Columns[11].FieldName = "Guinj";
                                gridView2.Columns[12].Visible = false;
                                gridView2.Columns[13].Visible = false;
                                gridView2.Columns[14].Visible = false;
                                gridView2.Columns[15].Visible = false;
                                gridView2.Columns[16].Visible = false;
                                gridView2.Columns[17].Visible = false;
                                gridView2.Columns[18].Visible = false;
                                gridView2.Columns[19].Visible = false;
                            }
                            else
                            {
                            }
                            break;
                        }
                    case "18":
                        {
                            gridView2.Columns.Clear();

                            gridControl2.DataSource = ds.gridFill("getact", "actID=" + textEdit3.Text + "&projectID=" + textEdit2.Text + "");
                            if (gridView2.RowCount != 0)
                            {
                                gridView2.Columns[0].Visible = false;
                                gridView2.Columns[1].Visible = false;
                                gridView2.Columns[2].Visible = false;
                                gridView2.Columns[3].Visible = false;
                                gridView2.Columns[4].Caption = "Огноо";
                                gridView2.Columns[5].Caption = "AKT№";
                                gridView2.Columns[6].Visible = false;
                                gridView2.Columns[7].Visible = false;
                                gridView2.Columns[8].Visible = false;
                                gridView2.Columns[9].Visible = false;
                                gridView2.Columns[10].Visible = false;
                                gridView2.Columns[11].Caption = "Гүйцэтгэгч.Инж";
                                gridView2.Columns[11].FieldName = "Guinj";
                                gridView2.Columns[12].Visible = false;
                                gridView2.Columns[13].Visible = false;
                                gridView2.Columns[14].Visible = false;
                                gridView2.Columns[15].Visible = false;
                                gridView2.Columns[16].Visible = false;
                                gridView2.Columns[17].Visible = false;
                                gridView2.Columns[18].Visible = false;
                                gridView2.Columns[19].Visible = false;
                            }
                            else
                            {
                            }
                            break;
                        }
                    case "19":
                        {
                            gridView2.Columns.Clear();

                            gridControl2.DataSource = ds.gridFill("getact", "actID=" + textEdit3.Text + "&projectID=" + textEdit2.Text + "");
                            if (gridView2.RowCount != 0)
                            {
                                gridView2.Columns[0].Visible = false;
                                gridView2.Columns[1].Visible = false;
                                gridView2.Columns[2].Visible = false;
                                gridView2.Columns[3].Visible = false;
                                gridView2.Columns[4].Caption = "Огноо";
                                gridView2.Columns[5].Caption = "AKT№";
                                gridView2.Columns[6].Visible = false;
                                gridView2.Columns[7].Visible = false;
                                gridView2.Columns[8].Visible = false;
                                gridView2.Columns[9].Visible = false;
                                gridView2.Columns[10].Visible = false;
                                gridView2.Columns[11].Caption = "Гүйцэтгэгч.Инж";
                                gridView2.Columns[11].FieldName = "Guinj";
                                gridView2.Columns[12].Visible = false;
                                gridView2.Columns[13].Visible = false;
                                gridView2.Columns[14].Visible = false;
                                gridView2.Columns[15].Visible = false;
                                gridView2.Columns[16].Visible = false;
                                gridView2.Columns[17].Visible = false;
                                gridView2.Columns[18].Visible = false;
                                gridView2.Columns[19].Visible = false;
                            }
                            else
                            {
                            }
                            break;
                        }
                    case "20":
                        {
                            gridView2.Columns.Clear();

                            gridControl2.DataSource = ds.gridFill("getact", "actID=" + textEdit3.Text + "&projectID=" + textEdit2.Text + "");
                            if (gridView2.RowCount != 0)
                            {
                                gridView2.Columns[0].Visible = false;
                                gridView2.Columns[1].Visible = false;
                                gridView2.Columns[2].Visible = false;
                                gridView2.Columns[3].Visible = false;
                                gridView2.Columns[4].Caption = "Огноо";
                                gridView2.Columns[5].Caption = "AKT№";
                                gridView2.Columns[6].Visible = false;
                                gridView2.Columns[7].Visible = false;
                                gridView2.Columns[8].Visible = false;
                                gridView2.Columns[9].Visible = false;
                                gridView2.Columns[10].Visible = false;
                                gridView2.Columns[11].Caption = "Гүйцэтгэгч.Инж";
                                gridView2.Columns[11].FieldName = "Guinj";
                                gridView2.Columns[12].Visible = false;
                                gridView2.Columns[13].Visible = false;
                                gridView2.Columns[14].Visible = false;
                                gridView2.Columns[15].Visible = false;
                                gridView2.Columns[16].Visible = false;
                                gridView2.Columns[17].Visible = false;
                                gridView2.Columns[18].Visible = false;
                                gridView2.Columns[19].Visible = false;
                            }
                            else
                            {
                            }
                            break;
                        }
                    case "21":
                        {
                            gridView2.Columns.Clear();

                            gridControl2.DataSource = ds.gridFill("getact", "actID=" + textEdit3.Text + "&projectID=" + textEdit2.Text + "");
                            if (gridView2.RowCount != 0)
                            {
                                gridView2.Columns[0].Visible = false;
                                gridView2.Columns[1].Visible = false;
                                gridView2.Columns[2].Visible = false;
                                gridView2.Columns[3].Visible = false;
                                gridView2.Columns[4].Caption = "Огноо";
                                gridView2.Columns[5].Caption = "AKT№";
                                gridView2.Columns[6].Visible = false;
                                gridView2.Columns[7].Visible = false;
                                gridView2.Columns[8].Visible = false;
                                gridView2.Columns[9].Visible = false;
                                gridView2.Columns[10].Visible = false;
                                gridView2.Columns[11].Caption = "Гүйцэтгэгч.Инж";
                                gridView2.Columns[11].FieldName = "Guinj";
                                gridView2.Columns[12].Visible = false;
                                gridView2.Columns[13].Visible = false;
                                gridView2.Columns[14].Visible = false;
                                gridView2.Columns[15].Visible = false;
                                gridView2.Columns[16].Visible = false;
                                gridView2.Columns[17].Visible = false;
                                gridView2.Columns[18].Visible = false;
                                gridView2.Columns[19].Visible = false;
                            }
                            else
                            {
                            }
                            break;
                        }
                    case "22":
                        {
                            gridView2.Columns.Clear();

                            gridControl2.DataSource = ds.gridFill("getact", "actID=" + textEdit3.Text + "&projectID=" + textEdit2.Text + "");
                            if (gridView2.RowCount != 0)
                            {
                                gridView2.Columns[0].Visible = false;
                                gridView2.Columns[1].Visible = false;
                                gridView2.Columns[2].Visible = false;
                                gridView2.Columns[3].Visible = false;
                                gridView2.Columns[4].Caption = "Огноо";
                                gridView2.Columns[5].Caption = "AKT№";
                                gridView2.Columns[6].Visible = false;
                                gridView2.Columns[7].Visible = false;
                                gridView2.Columns[8].Visible = false;
                                gridView2.Columns[9].Visible = false;
                                gridView2.Columns[10].Visible = false;
                                gridView2.Columns[11].Caption = "Гүйцэтгэгч.Инж";
                                gridView2.Columns[11].FieldName = "Guinj";
                                gridView2.Columns[12].Visible = false;
                                gridView2.Columns[13].Visible = false;
                                gridView2.Columns[14].Visible = false;
                                gridView2.Columns[15].Visible = false;
                                gridView2.Columns[16].Visible = false;
                                gridView2.Columns[17].Visible = false;
                                gridView2.Columns[18].Visible = false;
                                gridView2.Columns[19].Visible = false;
                            }
                            else
                            {
                            }
                            break;
                        }
                    case "23":
                        {
                            gridView2.Columns.Clear();

                            gridControl2.DataSource = ds.gridFill("getact", "actID=" + textEdit3.Text + "&projectID=" + textEdit2.Text + "");
                            if (gridView2.RowCount != 0)
                            {
                                gridView2.Columns[0].Visible = false;
                                gridView2.Columns[1].Visible = false;
                                gridView2.Columns[2].Visible = false;
                                gridView2.Columns[3].Visible = false;
                                gridView2.Columns[4].Caption = "Огноо";
                                gridView2.Columns[5].Caption = "AKT№";
                                gridView2.Columns[6].Visible = false;
                                gridView2.Columns[7].Visible = false;
                                gridView2.Columns[8].Visible = false;
                                gridView2.Columns[9].Visible = false;
                                gridView2.Columns[10].Visible = false;
                                gridView2.Columns[11].Caption = "Гүйцэтгэгч.Инж";
                                gridView2.Columns[11].FieldName = "Guinj";
                                gridView2.Columns[12].Visible = false;
                                gridView2.Columns[13].Visible = false;
                                gridView2.Columns[14].Visible = false;
                                gridView2.Columns[15].Visible = false;
                                gridView2.Columns[16].Visible = false;
                                gridView2.Columns[17].Visible = false;
                                gridView2.Columns[18].Visible = false;
                                gridView2.Columns[19].Visible = false;
                            }
                            else
                            {
                            }
                            break;
                        }
                    case "24":
                        {
                            gridView2.Columns.Clear();

                            gridControl2.DataSource = ds.gridFill("getact", "actID=" + textEdit3.Text + "&projectID=" + textEdit2.Text + "");
                            if (gridView2.RowCount != 0)
                            {
                                gridView2.Columns[0].Visible = false;
                                gridView2.Columns[1].Visible = false;
                                gridView2.Columns[2].Visible = false;
                                gridView2.Columns[3].Visible = false;
                                gridView2.Columns[4].Caption = "Огноо";
                                gridView2.Columns[5].Caption = "AKT№";
                                gridView2.Columns[6].Visible = false;
                                gridView2.Columns[7].Visible = false;
                                gridView2.Columns[8].Visible = false;
                                gridView2.Columns[9].Visible = false;
                                gridView2.Columns[10].Visible = false;
                                gridView2.Columns[11].Caption = "Гүйцэтгэгч.Инж";
                                gridView2.Columns[11].FieldName = "Guinj";
                                gridView2.Columns[12].Visible = false;
                                gridView2.Columns[13].Visible = false;
                                gridView2.Columns[14].Visible = false;
                                gridView2.Columns[15].Visible = false;
                                gridView2.Columns[16].Visible = false;
                                gridView2.Columns[17].Visible = false;
                                gridView2.Columns[18].Visible = false;
                                gridView2.Columns[19].Visible = false;
                            }
                            else
                            {
                            }
                            break;
                        }
                    case "25":
                        {
                            gridView2.Columns.Clear();

                            gridControl2.DataSource = ds.gridFill("getact", "actID=" + textEdit3.Text + "&projectID=" + textEdit2.Text + "");
                            if (gridView2.RowCount != 0)
                            {
                                gridView2.Columns[0].Visible = false;
                                gridView2.Columns[1].Visible = false;
                                gridView2.Columns[2].Visible = false;
                                gridView2.Columns[3].Visible = false;
                                gridView2.Columns[4].Caption = "Огноо";
                                gridView2.Columns[5].Caption = "AKT№";
                                gridView2.Columns[6].Visible = false;
                                gridView2.Columns[7].Visible = false;
                                gridView2.Columns[8].Visible = false;
                                gridView2.Columns[9].Visible = false;
                                gridView2.Columns[10].Visible = false;
                                gridView2.Columns[11].Caption = "Гүйцэтгэгч.Инж";
                                gridView2.Columns[11].FieldName = "Guinj";
                                gridView2.Columns[12].Visible = false;
                                gridView2.Columns[13].Visible = false;
                                gridView2.Columns[14].Visible = false;
                                gridView2.Columns[15].Visible = false;
                                gridView2.Columns[16].Visible = false;
                                gridView2.Columns[17].Visible = false;
                                gridView2.Columns[18].Visible = false;
                                gridView2.Columns[19].Visible = false;
                            }
                            else
                            {
                            }
                            break;
                        }
                    case "26":
                        {
                            gridView2.Columns.Clear();

                            gridControl2.DataSource = ds.gridFill("getact", "actID=" + textEdit3.Text + "&projectID=" + textEdit2.Text + "");
                            if (gridView2.RowCount != 0)
                            {
                                gridView2.Columns[0].Visible = false;
                                gridView2.Columns[1].Visible = false;
                                gridView2.Columns[2].Visible = false;
                                gridView2.Columns[3].Visible = false;
                                gridView2.Columns[4].Caption = "Огноо";
                                gridView2.Columns[5].Caption = "AKT№";
                                gridView2.Columns[6].Visible = false;
                                gridView2.Columns[7].Visible = false;
                                gridView2.Columns[8].Visible = false;
                                gridView2.Columns[9].Visible = false;
                                gridView2.Columns[10].Visible = false;
                                gridView2.Columns[11].Caption = "Гүйцэтгэгч.Инж";
                                gridView2.Columns[11].FieldName = "Guinj";
                                gridView2.Columns[12].Visible = false;
                                gridView2.Columns[13].Visible = false;
                                gridView2.Columns[14].Visible = false;
                                gridView2.Columns[15].Visible = false;
                                gridView2.Columns[16].Visible = false;
                                gridView2.Columns[17].Visible = false;
                                gridView2.Columns[18].Visible = false;
                                gridView2.Columns[19].Visible = false;
                            }
                            else
                            {
                            }
                            break;
                        }
                    case "27":
                        {
                            gridView2.Columns.Clear();

                            gridControl2.DataSource = ds.gridFill("getact", "actID=" + textEdit3.Text + "&projectID=" + textEdit2.Text + "");
                            if (gridView2.RowCount != 0)
                            {
                                gridView2.Columns[0].Visible = false;
                                gridView2.Columns[1].Visible = false;
                                gridView2.Columns[2].Visible = false;
                                gridView2.Columns[3].Visible = false;
                                gridView2.Columns[4].Caption = "Огноо";
                                gridView2.Columns[5].Caption = "AKT№";
                                gridView2.Columns[6].Visible = false;
                                gridView2.Columns[7].Visible = false;
                                gridView2.Columns[8].Visible = false;
                                gridView2.Columns[9].Visible = false;
                                gridView2.Columns[10].Visible = false;
                                gridView2.Columns[11].Caption = "Гүйцэтгэгч.Инж";
                                gridView2.Columns[11].FieldName = "Guinj";
                                gridView2.Columns[12].Visible = false;
                                gridView2.Columns[13].Visible = false;
                                gridView2.Columns[14].Visible = false;
                                gridView2.Columns[15].Visible = false;
                                gridView2.Columns[16].Visible = false;
                                gridView2.Columns[17].Visible = false;
                                gridView2.Columns[18].Visible = false;
                                gridView2.Columns[19].Visible = false;
                            }
                            else
                            {
                            }
                            break;
                        }

                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            finally { }
        }

        

        private void gridControl2_Click(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip2_Opening(object sender, CancelEventArgs e)
        {

        }

        private void gridControl2_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int actID = Convert.ToInt32(textEdit3.Text.Trim());
                switch (actID)
                {
                    case 2:
                        {
                            textEdit3.Text = gridView1.GetFocusedRowCellValue("id").ToString();
                            reportA2 za = new reportA2();
                            za.aimag.Text = gridView2.GetFocusedRowCellValue("aimag").ToString();
                            za.sumname.Text = gridView2.GetFocusedRowCellValue("sumname").ToString();
                            za.barilga.Text = gridView2.GetFocusedRowCellValue("barilga").ToString();
                            za.wherename.Text = gridView2.GetFocusedRowCellValue("sumname").ToString();
                            za.Ginj.Text = gridView2.GetFocusedRowCellValue("Guinj").ToString();
                            za.Zinj.Text = gridView2.GetFocusedRowCellValue("Zainj").ToString();
                            za.Zoinj.Text = gridView2.GetFocusedRowCellValue("Zoinj").ToString();
                            za.Talinj.Text = gridView2.GetFocusedRowCellValue("Guinj").ToString();
                            za.Daamal.Text = gridView2.GetFocusedRowCellValue("Daamal").ToString();
                            za.row11.Text = gridView2.GetFocusedRowCellValue("row11").ToString();
                            za.row12.Text = gridView2.GetFocusedRowCellValue("row12").ToString();
                            za.row13.Text = gridView2.GetFocusedRowCellValue("row13").ToString();
                            za.tuvshin.Text = gridView2.GetFocusedRowCellValue("tuvshin").ToString();
                            za.Tognoo.Text = gridView2.GetFocusedRowCellValue("tognoo").ToString();
                            za.row32.Text = gridView2.GetFocusedRowCellValue("row32").ToString();
                            za.avsanner.Text = gridView2.GetFocusedRowCellValue("avsanner").ToString();
                            za.row41.Text = gridView2.GetFocusedRowCellValue("row41").ToString();
                            za.row51.Text = gridView2.GetFocusedRowCellValue("row51").ToString();
                            za.row52.Text = gridView2.GetFocusedRowCellValue("row52").ToString();
                            za.row53.Text = gridView2.GetFocusedRowCellValue("row53").ToString();
                            za.GinjSign.Text = gridView2.GetFocusedRowCellValue("Guinj").ToString();
                            za.ZainjSign.Text = gridView2.GetFocusedRowCellValue("Zainj").ToString();
                            za.ZoinjSign.Text = gridView2.GetFocusedRowCellValue("Zoinj").ToString();
                            za.DaamalSign.Text = gridView2.GetFocusedRowCellValue("Daamal").ToString();
                            za.actognoo.Text = gridView2.GetFocusedRowCellValue("actognoo").ToString();
                            za.actNo.Text = "№" + gridView2.GetFocusedRowCellValue("actNo").ToString();
                            za.ShowPreview();
                            break;
                        }

                    case 3:
                        {
                            textEdit3.Text = gridView1.GetFocusedRowCellValue("id").ToString();
                            reportA3 za3 = new reportA3();
                            za3.actognoo.Text = gridView2.GetFocusedRowCellValue("actognoo").ToString();
                            za3.actNo.Text = "№"+gridView2.GetFocusedRowCellValue("actNo").ToString();
                            za3.sumname1.Text = gridView2.GetFocusedRowCellValue("sumname").ToString();
                            za3.blockname.Text = gridView2.GetFocusedRowCellValue("blockname").ToString();
                            za3.aimag.Text = gridView2.GetFocusedRowCellValue("aimag").ToString();
                            za3.sumname.Text = gridView2.GetFocusedRowCellValue("sumname").ToString();
                            za3.barilga.Text = gridView2.GetFocusedRowCellValue("barilga").ToString();
                            za3.Guinj.Text = gridView2.GetFocusedRowCellValue("Guinj").ToString();
                            za3.Zoinj.Text = gridView2.GetFocusedRowCellValue("Zoinj").ToString();
                            za3.Zainj.Text = gridView2.GetFocusedRowCellValue("Zainj").ToString();
                            za3.Daamal.Text = gridView2.GetFocusedRowCellValue("Daamal").ToString();
                            za3.row1.Text = gridView2.GetFocusedRowCellValue("row1").ToString();
                            za3.row2.Text = gridView2.GetFocusedRowCellValue("row2").ToString();
                            za3.row3.Text = gridView2.GetFocusedRowCellValue("row3").ToString();
                            za3.row4.Text = gridView2.GetFocusedRowCellValue("row4").ToString();
                            za3.row5.Text = gridView2.GetFocusedRowCellValue("row5").ToString();
                            za3.row6.Text = gridView2.GetFocusedRowCellValue("row6").ToString();
                            za3.row7.Text = gridView2.GetFocusedRowCellValue("row7").ToString();

                            za3.GuinjS.Text = gridView2.GetFocusedRowCellValue("Guinj").ToString();
                            za3.ZoinjS.Text = gridView2.GetFocusedRowCellValue("Zoinj").ToString();
                            za3.ZainjS.Text = gridView2.GetFocusedRowCellValue("Zainj").ToString();
                            za3.DaamalS.Text = gridView2.GetFocusedRowCellValue("Daamal").ToString();
                       
                            za3.ShowPreview();
                            break;
                        }
                    case 4:
                        {
                            textEdit3.Text = gridView1.GetFocusedRowCellValue("id").ToString();
                            reportA4 za4 = new reportA4();
                            za4.actognoo.Text = gridView2.GetFocusedRowCellValue("actognoo").ToString();
                            za4.actNo.Text = "№" + gridView2.GetFocusedRowCellValue("actNo").ToString();
                            za4.sumname1.Text = gridView2.GetFocusedRowCellValue("sumname").ToString();
                            za4.blockname.Text = gridView2.GetFocusedRowCellValue("blockname").ToString();
                            za4.aimag.Text = gridView2.GetFocusedRowCellValue("aimag").ToString();
                            za4.sumname.Text = gridView2.GetFocusedRowCellValue("sumname").ToString();
                            za4.barilga.Text = gridView2.GetFocusedRowCellValue("barilga").ToString();
                            za4.Guinj.Text = gridView2.GetFocusedRowCellValue("Guinj").ToString();
                            za4.Zoinj.Text = gridView2.GetFocusedRowCellValue("Zoinj").ToString();
                            za4.Zainj.Text = gridView2.GetFocusedRowCellValue("Zainj").ToString();
                            za4.Daamal.Text = gridView2.GetFocusedRowCellValue("Daamal").ToString();
                            za4.row11.Text = gridView2.GetFocusedRowCellValue("row11").ToString();
                            za4.row12.Text = gridView2.GetFocusedRowCellValue("row12").ToString();
                            za4.row13.Text = gridView2.GetFocusedRowCellValue("row13").ToString();
                            za4.row21.Text = gridView2.GetFocusedRowCellValue("row21").ToString();
                            za4.row22.Text = gridView2.GetFocusedRowCellValue("row22").ToString();
                            za4.row3.Text = gridView2.GetFocusedRowCellValue("row3").ToString();
                            za4.row4.Text = gridView2.GetFocusedRowCellValue("row4").ToString();
                            za4.haana.Text = gridView2.GetFocusedRowCellValue("haana").ToString();

                            za4.GuinjS.Text = gridView2.GetFocusedRowCellValue("Guinj").ToString();
                            za4.ZoinjS.Text = gridView2.GetFocusedRowCellValue("Zoinj").ToString();
                            za4.ZainjS.Text = gridView2.GetFocusedRowCellValue("Zainj").ToString();
                            za4.DaamalS.Text = gridView2.GetFocusedRowCellValue("Daamal").ToString();

                            za4.ShowPreview();
                            break;
                        }

                    case 5:
                        {
                            textEdit3.Text = gridView1.GetFocusedRowCellValue("id").ToString();
                            reportA5 za5 = new reportA5();
                            za5.actognoo.Text = gridView2.GetFocusedRowCellValue("actognoo").ToString();
                            za5.actNo.Text = "№" + gridView2.GetFocusedRowCellValue("actNo").ToString();
                            za5.sumname1.Text = gridView2.GetFocusedRowCellValue("sumname").ToString();
                            za5.blockname.Text = gridView2.GetFocusedRowCellValue("blockname").ToString();
                            za5.aimag.Text = gridView2.GetFocusedRowCellValue("aimag").ToString();
                            za5.sumname.Text = gridView2.GetFocusedRowCellValue("sumname").ToString();
                            za5.barilga.Text = gridView2.GetFocusedRowCellValue("barilga").ToString();
                            za5.Guinj.Text = gridView2.GetFocusedRowCellValue("Guinj").ToString();
                            za5.Zoinj.Text = gridView2.GetFocusedRowCellValue("Zoinj").ToString();
                            za5.Zainj.Text = gridView2.GetFocusedRowCellValue("Zainj").ToString();
                            //za5.Daamal.Text = gridView2.GetFocusedRowCellValue("Daamal").ToString();
                            za5.row1.Text = gridView2.GetFocusedRowCellValue("row1").ToString();
                           
                            za5.row2.Text = gridView2.GetFocusedRowCellValue("row2").ToString();
                            za5.row3.Text = gridView2.GetFocusedRowCellValue("row3").ToString();
                            za5.row4.Text = gridView2.GetFocusedRowCellValue("row4").ToString();
                            za5.row5.Text = gridView2.GetFocusedRowCellValue("row5").ToString();
                            za5.row6.Text = gridView2.GetFocusedRowCellValue("row6").ToString();
                            za5.row7.Text = gridView2.GetFocusedRowCellValue("row7").ToString();
                           // za5.haana.Text = gridView2.GetFocusedRowCellValue("haana").ToString();

                            za5.GuinjS.Text = gridView2.GetFocusedRowCellValue("Guinj").ToString();
                            za5.ZoinjS.Text = gridView2.GetFocusedRowCellValue("Zoinj").ToString();
                            za5.ZainjS.Text = gridView2.GetFocusedRowCellValue("Zainj").ToString();
                            za5.DaamalS.Text = gridView2.GetFocusedRowCellValue("Daamal").ToString();

                            za5.ShowPreview();
                            break;
                        }  
                        
                       
                        
                }
               
               
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            finally
            { }
        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {
            gridView1.ActiveFilterString = "actname LIKE '%" + textEdit1.Text + "%'";
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void усгтгахToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                dataSetFill dc = new dataSetFill();
                string id = gridView2.GetFocusedRowCellValue("id").ToString();
                DialogResult ds = MessageBox.Show("Тухайн tender-ийн мэдээллийг устгахдаа итгэлтэй байна уу.", "Анхаар", MessageBoxButtons.YesNo);
                if (ds == System.Windows.Forms.DialogResult.Yes)
                {
                    var data = new NameValueCollection();
                    data["deleteid"] = id;
                    data["ali_table"] = "a3";
                    MessageBox.Show(dc.exec_command("deleteAll", data));
                    gridControl1_Click(sender, e);
                }
            }
            catch (Exception ee)
            { MessageBox.Show(ee.ToString()); }
            finally { }
        }
    }
}
