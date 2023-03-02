using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZETTOZIP_FINAL
{
    public partial class page1cs : Form
    {
        public page1cs()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //this.Hide();
            page2 obj=new page2();  
            obj.ShowDialog();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if(webBrowser1.CanGoBack)
            {
                webBrowser1.GoBack(); 
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            DELETE obj=new DELETE();
            obj.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            extract obj=new extract();  
            obj.ShowDialog();
        }

      

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            page2 obj=new page2();
            obj.ShowDialog();    
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            ENCRYPT obj=new ENCRYPT();
            obj.ShowDialog();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Decrypt obj = new Decrypt();
            obj.ShowDialog();
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog() { Description = "SELECT YOUR PATH" })
            {
                if(fbd.ShowDialog()==DialogResult.OK)
                {
                    webBrowser1.Url = new Uri(fbd.SelectedPath);
                    textBox1.Text = fbd.SelectedPath;
                }
            }
            {

            }
        }

        private void pictureBox5_MouseEnter(object sender, EventArgs e)
        {
            this.pictureBox5.BackColor = ColorTranslator.FromHtml("#19324B");
        }

        private void pictureBox5_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox5.BackColor = System.Drawing.Color.Transparent;
           
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            
            this.pictureBox1.BackColor = ColorTranslator.FromHtml("#19324B");
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
           
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            
            this.pictureBox2.BackColor = ColorTranslator.FromHtml("#19324B");
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            
        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            
            this.pictureBox3.BackColor = ColorTranslator.FromHtml("#19324B");
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            
        }

        private void pictureBox6_MouseEnter(object sender, EventArgs e)
        {
            
            this.pictureBox6.BackColor = ColorTranslator.FromHtml("#19324B");
        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox6.BackColor = System.Drawing.Color.Transparent;
            
        }

        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {
            
            this.pictureBox4.BackColor = ColorTranslator.FromHtml("#19324B");
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            
        }
    }
}
