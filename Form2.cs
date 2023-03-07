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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           /* if (e.RowIndex >= 0)
            {

                txtID.Text = DGV1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtSalary.Text = DGV1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtName.Text = DGV1.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtRole.Text = DGV1.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtContact.Text = DGV1.Rows[e.RowIndex].Cells[4].Value.ToString();


            }*/
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            load();

        }

        void load()
        {

            try //Exception Handler
            {
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-502PTQA\SQLEXPRESS;Initial Catalog=Quite Attic;Integrated Security=True");
                con.Open();
                string sql = "select * from Production;"; //Select Query
                SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                DGV2.DataSource = dt;//Assing Data to Datagridview
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
    
}
