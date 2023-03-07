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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            load();
        }

            void load()
            {

                try //Exception Handler
                {
                    SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-502PTQA\SQLEXPRESS;Initial Catalog=Quite Attic;Integrated Security=True");
                    con.Open();
                    string sql = "select * from Properties;"; //Select Query
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    DGV3.DataSource = dt;//Assing Data to Datagridview
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
    }
}
