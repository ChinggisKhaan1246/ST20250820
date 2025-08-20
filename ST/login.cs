﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Collections.Specialized;
using Newtonsoft.Json;
using Microsoft.Win32;

namespace ST
{
    public partial class login : Form
    {
        
        public login()
        {
            InitializeComponent();
        }

        dataSetFill ds = new dataSetFill();
        private void label1_Click(object sender, EventArgs e)
        {
            // Add your logic for the label click event
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                Form1 f = new Form1();
                var data = new NameValueCollection();
                data["phone"] = textEdit1.Text.Trim();
                data["password"] = textEdit2.Text.Trim();
                var answer = ds.exec_command("login", data);
                string[] parts = answer.Split(';'); // "1;1  буюу userID;comID гэж ирж байгаа" 
                try
                {
                    int userID = int.Parse(parts[0]);
                    int comID = int.Parse(parts[1]);
                    UserSession.LoggedUserID = Convert.ToInt16(userID);
                    UserSession.LoggedComID = comID;
                   
                    baseinfo userInfo = new baseinfo(UserSession.LoggedUserID);
                    //MessageBox.Show(UserSession.LoggedUserID.ToString());
                    f.salerLogin.Text = userInfo.userPhone;
                    f.comName.Text = userInfo.comName;
                    f.labelControl1.Text = userInfo.userAlbantushaal;
                    f.salerName.Text = userInfo.userName;
                    f.saveLogg(f.comName.Text, "Нэвтэрсэн");
                    if (checkEdit1.Checked) // Хэрэв Remember Me идэвхтэй бол
                    {
                        SaveLoginInfo(textEdit3.Text, textEdit1.Text, textEdit2.Text);
                    }
                    else // Хэрэв идэвхгүй бол өмнөх мэдээллийг устгах
                    {
                        ClearLoginInfo();
                    }
                    f.Show();
                    this.Hide();
                }
                catch 
                {
                    MessageBox.Show(answer);
                    this.textEdit2.Text = "";
                    this.Show();

                }
            }
            catch (Exception ee)
            { 
                MessageBox.Show("Алдаа: getuser:"+ee.ToString()); 
            }
        }
        private void ClearLoginInfo()
        {
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey("SOFTWARE\\MyApp"))
            {
                key.DeleteValue("ID", false);
                key.DeleteValue("Username", false);
                key.DeleteValue("Password", false);
            }
        }

        // **Нэвтрэх мэдээллийг автоматаар бөглөх (LoginForm_Load үед дуудагдана)**
        private void LoadLoginInfo()
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\MyApp"))
            {
                if (key != null)
                {
                    textEdit3.Text = key.GetValue("ID", "").ToString();
                    textEdit1.Text = key.GetValue("Username", "").ToString();
                    textEdit2.Text = key.GetValue("Password", "").ToString();
                    checkEdit1.Checked = !string.IsNullOrEmpty(textEdit1.Text); // Remember Me автоматаар идэвхжүүлэх
                }
            }
        }
        private void SaveLoginInfo(string id, string username, string password)
        {
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey("SOFTWARE\\MyApp"))
            {
                key.SetValue("ID", id);
                key.SetValue("Username", username);
                key.SetValue("Password", password);
            }
        }
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                Form1 f = new Form1();
                f.simpleButton14_Click_1(sender, e);
                Application.Exit();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            finally { }

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) // Enter товч дарагдсан эсэхийг шалгана
            {
                simpleButton1.PerformClick(); // simpleButton1_Click функцыг дуудаж байна
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textEdit3_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void textEdit2_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void login_Load(object sender, EventArgs e)
        {
            LoadLoginInfo();
        }
    }
}
