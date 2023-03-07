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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-502PTQA\SQLEXPRESS;Initial Catalog=Quite Attic;Integrated Security=True");
                con.Open();
                string q1 = "insert into Staff Values ('" + txtID.Text + "','" + txtSalary.Text + "','" + txtName.Text+"','"+txtRole.Text+"','"+txtContact.Text+"')";
                SqlCommand comd1 = new SqlCommand(q1, con);
                int i = comd1.ExecuteNonQuery();
                con.Close();

                if (i > 0)
                {
                    load();
                    MessageBox.Show("Insert successfully", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);

             
                }
                else
                {
                    MessageBox.Show("Error", "alert", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                
            }


        }

        private void Form4_Load(object sender, EventArgs e)
        {

            load();

        }

        void load()
        {

            try //Exception Handler
            {
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-502PTQA\SQLEXPRESS;Initial Catalog=Quite Attic;Integrated Security=True");
                con.Open();
                string sql = "select * from Staff;"; //Select Query
                SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                DGV1.DataSource = dt;//Assing Data to Datagridview
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-502PTQA\SQLEXPRESS;Initial Catalog=Quite Attic;Integrated Security=True");
                con.Open();
                string q1 = "delete Staff  where StaffID = '" + txtID.Text + "'";
                SqlCommand comd1 = new SqlCommand(q1, con);
                int i = comd1.ExecuteNonQuery();
                con.Close();

                if (i > 0)
                {
                    MessageBox.Show("Deleted Successfully", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    load();
                   
                }
                else
                {
                    MessageBox.Show("Error", "alert", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void DGV1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                txtID.Text = DGV1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtSalary.Text = DGV1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtName.Text = DGV1.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtRole.Text = DGV1.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtContact.Text = DGV1.Rows[e.RowIndex].Cells[4].Value.ToString();

              
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
             
                try
                {
                    SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-502PTQA\SQLEXPRESS;Initial Catalog=Quite Attic;Integrated Security=True");
                    con.Open();
                    string q2 = " update Staff set Salary='" + txtSalary.Text + "',Name='" + txtName.Text + "',Role='" + txtRole.Text + "',Contact='" + txtContact.Text + "'where StaffID='" + txtID.Text +"';";
                    SqlCommand comd2 = new SqlCommand(q2, con);
                    int i = comd2.ExecuteNonQuery();
                    con.Close();

                    if (i > 0)
                    {

                        MessageBox.Show("update successfully", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        load();
                        
                    }
                    else
                    {
                        MessageBox.Show("Error", "alert", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    
                }
           
        }
    }
    
}
