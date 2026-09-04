using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalManagementSystem1
{
    public partial class SearchDoctor : Form
    {
        public SearchDoctor()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=HMSDB;Integrated Security=True");


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = null;

                SqlCommand cmd = new SqlCommand(@"Select l.UserName,l.Role,d.* from DoctorTB d inner join LogInTB l on d.UserID = l.UserID where l.UserName=@userName", con);
                //SqlDataAdapter sd = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@userName", textBox1.Text);
                SqlDataAdapter sd = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();


                con.Open();
                sd.Fill(dt);

                dataGridView1.DataSource = dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
