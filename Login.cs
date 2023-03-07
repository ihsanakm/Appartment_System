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

namespace Database_System__HND
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            String Mail = txtEmail.Text;
            String Password = txtPassword.Text;
            String UserType = cmbRole.Text;//Combo Box

            //Database Connection
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-502PTQA\SQLEXPRESS;Initial Catalog=Quite Attic;Integrated Security=True"); // making connection
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM [User] WHERE mail = '" + Mail + "' AND password = '" + Password + "';", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (Mail == "")
            {
                lblEmail.Text = "Enter your Email !";
            }

            else if (Password == "")
            {
                lblPassword.Text = "Enter your Password !";
            }

            else if (UserType == "")
            {
                lblRole.Text = "Select the User Type !";
            }

            else if (dt.Rows.Count == 1)
            {
                if (UserType == "Admin")
                {
                    MessageBox.Show("Login Successful!");
                }

                else if (UserType == "Staff")
                {
                    MessageBox.Show("Login Successful!");
                }
            }

            else
            {

                MessageBox.Show("Invalid Email or Password");
            }
        }
    }
}
