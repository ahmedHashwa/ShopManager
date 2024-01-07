#region using directives

using System;
using System.Collections.Generic;
using System.Management;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

#endregion

namespace WindowsFormsApplication1
{
    //Namespace Reference

    /// <summary>
    ///   method to retrieve the selected HDD's serial number
    public partial class SerialNumberGenerator : Form
    {
        public SerialNumberGenerator()
        {
            InitializeComponent();

            GetPassword();
        }

        private static string GetPass(IEnumerable<byte> bytes)
        {
            string passhashed = "";
            foreach (byte cbyte in bytes)
            {
                passhashed += string.Format("{0:X}", cbyte);
            }
            return passhashed;
        }

        public byte[] Xor(byte[] arr1, byte[] arr2)
        {
            if (arr1.Length != arr2.Length) return null;
            var xor = new byte[arr1.Length];
            for (int i = 0; i < xor.Length; i++)
            {
                xor[i] = (byte) (arr1[i] ^ arr2[i]);
            }

            return xor;
        }

        private static byte[] GetHash(string key, string property)
        {
            var searcher = new ManagementObjectSearcher(string.Format("select {0} from  {1}", property, key));

            foreach (ManagementObject share in searcher.Get())
                return
                    new MD5CryptoServiceProvider().ComputeHash(
                        Encoding.Unicode.GetBytes(share.Properties[property].Value.ToString()));
            return null;
        }

        private void GetPassword()
        {
            byte[] x = GetHash("win32_Bios", "SerialNumber");
            byte[] y = GetHash("win32_processor", "processorid");
            byte[] s = GetHash("win32_diskdrive", "signature");
            byte[] t = Xor(s, Xor(y, x));
            serialTextBox.Text = GetPass(t);
        }

        private void GenerateSerialButton_Click(object sender, EventArgs e)
        {
            GetPassword();
        }


        private void CopyToClipBoardButton_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(serialTextBox.Text);
        }

        private void GenerateForIDInfoButton_Click(object sender, EventArgs e)
        {
            string[] info = IDInfoTextBox.Text.Split('&');
            if (info.Length != 3)
            {
                MessageBox.Show("Invalid Info ID");
                return;
            }
            var ini = new byte[16];
            foreach (string s in info)
            {
                ini = Xor(ini, new MD5CryptoServiceProvider().ComputeHash(
                    Encoding.Unicode.GetBytes(s)));
            }

            serialTextBox.Text = GetPass(ini);
        }
    }
}