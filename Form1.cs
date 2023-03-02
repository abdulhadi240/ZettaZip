using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace ZETTOZIP_FINAL
{
    public partial class Form1 : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=LoginForm;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

           
            string query = "select * from table_1 where username=@User and pass=@pass";
            SqlCommand cmd=new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@user", Username.Text);
            cmd.Parameters.AddWithValue("@pass", textBox2.Text);

            conn.Open();
            SqlDataReader dr=cmd.ExecuteReader();
            if (dr.HasRows==true)
            {
               Login_Successsful a=new Login_Successsful();
                a.ShowDialog();
                this.Hide();
                page1cs obj = new page1cs();
                obj.ShowDialog();
            }
            else
            {
                login_failed a=new login_failed();
                a.ShowDialog();
            }

            conn.Close();

            
           


        }

        private void Login_Click(object sender, EventArgs e)
        {
            this.Hide();
            Register obj=new Register();
            obj.ShowDialog();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            bool check = checkBox2.Checked;

            switch(check)
            {
                case  true:
                    {
                        textBox2.UseSystemPasswordChar = false;
                        break;
                    }
                default:
                    {
                        textBox2.UseSystemPasswordChar=true;
                        break;
                    }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
