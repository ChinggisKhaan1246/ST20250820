using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Management;
using System.Collections.Specialized;
using System.Net.NetworkInformation;
using Microsoft.Win32; // Windows Registry ашиглах

namespace ST
{
    public partial class FUTUREINNOVATION : Form
    {
        private static string _cachedMacAddress = null; // **CACHE**
        private string liskey;
        private dataSetFill ds = new dataSetFill(); // **ds объектийг зарлаж байна**
       
        public FUTUREINNOVATION()
        {
            InitializeComponent();
            _cachedMacAddress = Properties.Settings.Default.MacAddress;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public static byte[] GetHash(string inputString)
        {
            using (HashAlgorithm algorithm = SHA256.Create())
                return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }

        public static string GetHashString(string inputString)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in GetHash(inputString))
                sb.Append(b.ToString("X2"));

            return sb.ToString();
        }
        public static string GetMacAddress()
        {
            if (!string.IsNullOrEmpty(_cachedMacAddress)) // ✅ RAM дотор хадгалагдсан бол буцаана
            {
               // MessageBox.Show("Cache read: " + _cachedMacAddress);
                return _cachedMacAddress;
            }

            _cachedMacAddress = Properties.Settings.Default.MacAddress;
            if (!string.IsNullOrEmpty(_cachedMacAddress))
            {
                //MessageBox.Show("Settings-c read: " + _cachedMacAddress);
                return _cachedMacAddress;
               
            }

            try
            {
                foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
                {
                    if (nic.NetworkInterfaceType != NetworkInterfaceType.Loopback && nic.OperationalStatus == OperationalStatus.Up)
                    {
                        _cachedMacAddress = nic.GetPhysicalAddress().ToString();
                        Properties.Settings.Default.MacAddress = _cachedMacAddress; // ✅ **Програмын тохиргоонд хадгалах**
                        Properties.Settings.Default.Save(); // ✅ **Тохиргоог хадгалах**
                        return _cachedMacAddress;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("MAC Address уншихад алдаа гарлаа: " + ex.Message);
                _cachedMacAddress = "UNKNOWN"; // **Алдаа гарвал UNKNOWN**
            }

            return _cachedMacAddress;
        }


        private void FUTUREINNOVATION_Load(object sender, EventArgs e)
        {
            string macAddress = GetMacAddress();
            string regkey1 = GetHashString(macAddress + "FutureInnovation");
            regText.Text = regkey1;
            liskey = GetHashString(regkey1 + "FutureInnovation");
        }

        private void FUTUREINNOVATION_Activated(object sender, EventArgs e)
        {
            try
            {
                string basekey;
                var data = new NameValueCollection();
                data.Add("lis", liskey);

                basekey = ds.exec_command("getlis", data);
                

                if (!string.IsNullOrEmpty(basekey) && liskey == basekey)
                {
                    login lgg = new login();
                    lgg.Show();
                    this.Hide();
                }
                else
                {
                   
                    this.Opacity = 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Интернет сүлжээгээ шалгана уу: " + ex.Message);
            }
        }

        private void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            // **Энэ функцийг устгахгүй, байгаа чигээр нь үлдээв**
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (liskey == keyText.Text)
                {
                    var data = new NameValueCollection();
                    data.Add("reg", regText.Text);
                    data.Add("lis", liskey);
                    data.Add("id", "1");
                    data.Add("Fdate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    data.Add("Ldate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                    MessageBox.Show(ds.exec_command("addlis", data));
                    login lgg = new login();
                    lgg.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Та лиценз худалдаж авна уу. 99991246, 88992842");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Алдаа: " + ex.Message);
            }
        }
    }
}
