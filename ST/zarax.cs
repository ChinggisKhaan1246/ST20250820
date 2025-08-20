using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Collections.Specialized;
using Newtonsoft.Json;
namespace ST
{
    public partial class zarax : Form
    {
        Form1 f;
        public zarax(Form1 ff)
        {
            InitializeComponent();
            f = ff;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
       
        private void zarax_Load(object sender, EventArgs e)
        {
            dateEdit1.EditValue = DateTime.Now;
            too_EditValueChanged(e, null);

        
        }

        private void too_EditValueChanged(object sender, EventArgs e)
        {
            too_TextChanged(e, null);        
        }

        private void une_EditValueChanged(object sender, EventArgs e)
        {
            too_EditValueChanged(e, null);
        }
        
        dataSetFill dc = new dataSetFill();
        
        
       
        private void simpleButton1_Click(object sender, EventArgs e)
        {

            /*  try
            {
                if (Convert.ToInt32(atoo.Text) <= 0)
                {
                    MessageBox.Show("Барааны үлдэгдэл хүрэлцэхгүй байна.");
                }

                else if (Convert.ToInt32(atoo.Text) >= Convert.ToInt32(too.Text) )
                {
                    int niit;

                    f.gridView2.ActiveFilterString = "bcode LIKE "+code.Text+"";
                    if (f.gridView2.RowCount == 0)
                            {
                               // DataRow Dr = f.cardTable.NewRow();

                                niit = Convert.ToInt32(too.Text) * Convert.ToInt32(une.Text);

                             //   Dr[0] = f.cardTable.Rows.Count + 1;
                             //   Dr[1] = Convert.ToInt32(code.Text);
                            //    Dr[2] = ner.Text;
                           //     Dr[3] = Convert.ToInt32(too.Text);
                            //    Dr[4] = Convert.ToInt32(une.Text);
                           //     Dr[5] = niit;
                           //     f.cardTable.Rows.Add(Dr);

                                f.gridView1.SetRowCellValue(Convert.ToInt32(f.gridView1.GetFocusedRowCellValue("dd").ToString()) - 1, f.gridView1.Columns["too"], Convert.ToInt32(atoo.Text) - Convert.ToInt32(too.Text));
                                f.gridView2.ActiveFilterString = "";
                            }
                    else
                            {
                                f.gridView2.SetRowCellValue( 0, f.gridView2.Columns["too"], Convert.ToInt32(f.gridView2.GetFocusedRowCellValue("too").ToString()) + Convert.ToInt32(too.Text));
                                f.gridView2.SetRowCellValue(0, f.gridView2.Columns["unet"], Convert.ToInt32(f.gridView2.GetFocusedRowCellValue("une").ToString()) * Convert.ToInt32(f.gridView2.GetFocusedRowCellValue("too").ToString()));
                                f.gridView1.SetRowCellValue(Convert.ToInt32(f.gridView1.GetFocusedRowCellValue("dd").ToString()) - 1, f.gridView1.Columns["too"], Convert.ToInt32(atoo.Text) - Convert.ToInt32(too.Text)); //тоо ширхэг ээ бодож байгаа аанхн
                                f.gridView2.ActiveFilterString = "";
                            }

                    f.gridView3.ActiveFilterString = "bara_id LIKE  " + IDbara.Text + "  and  cid like  " +cid.Text+"";
                   
                    if (f.gridView3.RowCount == 0)
                    {
                        DataRow Dr = f.cardTable.NewRow();

                        niit = Convert.ToInt32(too.Text) * Convert.ToInt32(une.Text);

                        DataRow DrC = f.cardTableCont.NewRow();
                        DrC[0] = Convert.ToInt32(cid.Text);
                        DrC[1] = Convert.ToInt32(IDbara.Text);
                        DrC[2] = Convert.ToInt32(too.Text);
                        DrC[3] = Convert.ToInt32(une.Text);
                        DrC[4] = niit;
                        DrC[5] = Convert.ToInt32(code.Text);
                        f.cardTableCont.Rows.Add(DrC);
                        f.gridView3.ActiveFilterString = "";
                    }
                    else
                    {
                        f.gridView3.SetRowCellValue(0, f.gridView3.Columns["ctoo"], Convert.ToInt32(f.gridView3.GetFocusedRowCellValue("ctoo").ToString()) + Convert.ToInt32(too.Text));
                        f.gridView3.SetRowCellValue(0, f.gridView3.Columns["dun"], Convert.ToInt32(f.gridView3.GetFocusedRowCellValue("une").ToString()) * Convert.ToInt32(f.gridView3.GetFocusedRowCellValue("ctoo").ToString()));
                        f.gridView3.ActiveFilterString = "";
                    }

                       f.saveLogg(f.salerID.Text, "Бараа сагсалсан");
                }
                else
                {
                    MessageBox.Show("Барааны үлдэгдэл хүрэлцэхгүй байна.");
                }
                
            }
            catch (Exception ee)
            {
                MessageBox.Show("Алдаа" + ee.ToString(), "");
            }
            finally { }




               
                this.Hide();   */
           
            
           
       
        }

        private void too_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(atoo.Text) >= Convert.ToInt32(too.Text))
                {
                    try
                    {
                        niitune.Text = Convert.ToString(Convert.ToInt32(Lune.Text) * Convert.ToInt32(too.Text));
                    }
                    catch (Exception)
                    { }
                }
                else
                {
                    too.Text = atoo.Text;
                    niitune.Focus();
                    //MessageBox.Show("Агуулахад байгаа тоо таны оруулсан тоо ширхэгээс бага байна", "Анхаар");
                }
            }
            catch (Exception)
            { }
        }

        private void groupZeel_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void too_SelectedIndexChanged(object sender, EventArgs e)
        {
            niitune.Text = Convert.ToString(Convert.ToInt32(Lune.Text) * Convert.ToInt32(too.Text));
        }

        private void une_EditValueChanged_1(object sender, EventArgs e)
        {

        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {
           try
           {
            if (salee.Text.Length == 0)  
                {
                    Lune.Text = une.Text;
                }
            else 
            {
              if (radioButton1.Checked)
              {
                Lune.Text = Convert.ToString(Convert.ToInt32(une.Text) - Convert.ToInt32(salee.Text));
                niitune.Text = Convert.ToString(Convert.ToInt32(Lune.Text) * Convert.ToInt32(too.Text));
              }
             if (radioButton2.Checked)
              {
                  Lune.Text = Convert.ToString(Convert.ToInt32(une.Text) - Convert.ToInt32(salee.Text));
                  niitune.Text = Convert.ToString(Convert.ToInt32(Lune.Text) * Convert.ToDouble(meterBox.Text));
              }  

            }
        
           
           }
           catch (Exception ee)
           {
                MessageBox.Show("Алдаа" + ee.ToString(), "");
           }
           finally { }
        }

        private void Lune_EditValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Lune.Text) < 0)
            { 
                    salee.Text = "";
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            too.Visible = true;
            label6.Visible = true;
            meterBox.Visible = false;
            label11.Visible = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            too.Visible = false;
            label6.Visible = false;
            meterBox.Visible = true;
            label11.Visible = true;
        }

        private void meterBox_EditValueChanged(object sender, EventArgs e)
        {
           
        }
    }
}
