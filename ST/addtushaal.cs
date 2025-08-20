using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.LookAndFeel;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrintingLinks;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.Utils;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Net.NetworkInformation;
using System.Management;
using System.Diagnostics;
using System.Web;

namespace ST
{
    public partial class addtushaal : Form
    {
        ZeelList f;  
        public addtushaal( ZeelList ff)
        {
            InitializeComponent();
            f = ff;
        }
        dataSetFill ds = new dataSetFill();
        private void addtushaal_Load(object sender, EventArgs e)
        {
            try
            {
                ognooDoc.DateTime = DateTime.Now;
                combobox12.SelectedIndex = 0;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            finally { }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var data = new NameValueCollection();

            dataSetFill dcd = new dataSetFill();
            if (Tnumber.Text != "" && Utga.Text != "" && Utga.Text != "")
            {
                try
                {
                    data["Tnumber"] = Tnumber.Text;
                    data["tuhai"] = tuhai.Text;
                    data["Utga"] = Utga.Document.RtfText;
                    data["UtgaNormal"] = Utga.Text;   
                    data["signTushaal"] = combobox12.Text.ToUpper();
                    data["signName"] = combobox22.Text.ToUpper();
                    data["ognooDoc"] = ognooDoc.DateTime.ToString("yyyy-MM-dd");
                    data["ognoo"] = DateTime.Now.ToString("yyyy-MM-dd");

                    MessageBox.Show(dcd.exec_command("addtushaal", data));
                    //  this.Hide();
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.ToString());
                }
                finally { f.ZeelList_Load(sender, e); this.Hide(); }
            }
            else
            {
                MessageBox.Show("Өгөгдөл дутуу байна.");
            }
        }

 
        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Utga.Text = "";
                tuhai.Text = zagvarcombo.Text+" тухай";
                switch (zagvarcombo.SelectedText.Trim())
                {
                    case "Ажилд томилох":
                        {
                            Utga.LoadDocument(AppDomain.CurrentDomain.BaseDirectory + @"\tushaal\zagvar\tomiloh.docx");
                            break;
                         }
                    case "Ажлаас чөлөөлөх":
                        {
                            Utga.LoadDocument(AppDomain.CurrentDomain.BaseDirectory + @"\tushaal\zagvar\cholooloh.docx");
                            break;
                        }
                    case "Хөрөнгө зарцуулах":
                        {
                           
                            break;
                        }
                    case "Хөрөнгө оруулах":
                        {
                           
                            break;
                        }
                    case "Ажлын хэсэг байгуулах":
                        {
                           
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



        private void lookUpEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (combobox12.SelectedIndex == 0)
                {
                    combobox22.Properties.DataSource = ds.gridFill("getita", "itatype=SIGN1");
                }
                if (combobox12.SelectedIndex == 1)
                {
                    combobox22.Properties.DataSource = ds.gridFill("getita", "itatype=SIGN2");
                }
                combobox22.Properties.DisplayMember = "ner";
                combobox22.Properties.ValueMember = "ner";
                combobox22.ItemIndex = 0;
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
