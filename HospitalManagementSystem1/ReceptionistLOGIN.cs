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
    public partial class ReceptionistLOGIN : Form
    {
        string userName;
        public ReceptionistLOGIN(string uname)
        {
            InitializeComponent();
            this.userName = uname;
        }
        SqlConnection con = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=HMSDB;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = null;

                SqlCommand cmd = new SqlCommand(@"Select l.userName,l.Role,r.* from ReceptionistTB r inner join LogInTB l on r.UserID = l.UserID where l.UserName=@userName", con);
                SqlDataAdapter sd = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@UserName", this.userName);
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

        private void button2_Click(object sender, EventArgs e)
        {
            SearchPatient sp = new SearchPatient();
            sp.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            BookAppoinment ba = new BookAppoinment();
            ba.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SearchDoctor sd = new SearchDoctor();
            sd.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            SqlCommand cmd = new SqlCommand(@"Select* from AppoinmentTB",con);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();


            con.Open();
            sd.Fill(dt);

            dataGridView1.DataSource = dt;

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            l.Show();
            this.Hide();
        }
    }
}
