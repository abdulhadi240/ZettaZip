using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System. IO;
using System.Security.Cryptography;


namespace ZETTOZIP_FINAL
{
    public partial class Decrypt : Form
    {
        
        public Decrypt()
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



                string password = @"ZETTAZIP"; // Your Key Here



                OpenFileDialog ofd = new OpenFileDialog();

                ofd.ShowDialog();

                textBox2.Text = ofd.FileName;

                UnicodeEncoding UE = new UnicodeEncoding();

                byte[] key = UE.GetBytes(password);



                FileStream fsCrypt = new FileStream(ofd.FileName, FileMode.Open);



                RijndaelManaged RMCrypto = new RijndaelManaged();



                CryptoStream cs = new CryptoStream(fsCrypt,

                    RMCrypto.CreateDecryptor(key, key),

                    CryptoStreamMode.Read);


                


                string outputfile = @"C:\Users\ADMIN\OneDrive\Desktop\Decrypted.png";
                



                FileStream fsOut = new FileStream(outputfile, FileMode.Create);



                int data;

                while ((data = cs.ReadByte()) != -1)

                    fsOut.WriteByte((byte)data);



                fsOut.Close();

                cs.Close();

                fsCrypt.Close();





                MessageBox.Show("File Decrypted Successfully");

            }

            catch (Exception ex)

            {

                MessageBox.Show(ex.ToString());

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

        private void Decrypt_Load(object sender, EventArgs e)
        {
            txt = label1.Text;
            len = txt.Length;
            label1.Text = "";
            timer1.Start();
        }
    }


        
}
