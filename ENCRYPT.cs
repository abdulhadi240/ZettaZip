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
using System.IO;

namespace ZETTOZIP_FINAL
{
    public partial class ENCRYPT : Form
    {
        
        public ENCRYPT()
        {
            InitializeComponent();
            
        }
        int counter = 0;
        int len = 0;
        string txt;


        private void button3_Click(object sender, EventArgs e)
        {
            try

            {

                OpenFileDialog ofd = new OpenFileDialog();

                ofd.ShowDialog();

                textBox1.Text=ofd.FileName;



                string password = @"ZETTAZIP"; // Your Key Here

                UnicodeEncoding UE = new UnicodeEncoding();

                byte[] key = UE.GetBytes(password);



                string cryptFile = @"C:\Users\ADMIN\OneDrive\Desktop\encrypted.zetta";

                FileStream fsCrypt = new FileStream(cryptFile, FileMode.Create);



                RijndaelManaged RMCrypto = new RijndaelManaged();



                CryptoStream cs = new CryptoStream(fsCrypt,

                    RMCrypto.CreateEncryptor(key, key),

                    CryptoStreamMode.Write);



                FileStream fsIn = new FileStream(ofd.FileName, FileMode.Open);



                int data;

                while ((data = fsIn.ReadByte()) != -1)

                    cs.WriteByte((byte)data);

                fsIn.Close();

                cs.Close();

                fsCrypt.Close();



                MessageBox.Show("Encrypted successfull");

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error");
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            counter++;

            if (counter > len)
            {
                counter = 0;
                label1.Text = "";
            }

            else
            {

                label1.Text = txt.Substring(0, counter);

                if (label1.ForeColor == Color.White)
                    label1.ForeColor = Color.Orange;
                else
                    label1.ForeColor = Color.White;
            }
        }

        private void ENCRYPT_Load(object sender, EventArgs e)
        {
            txt = label1.Text;
            len = txt.Length;
            label1.Text = "";
            timer1.Start();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
