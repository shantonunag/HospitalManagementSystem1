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
    public partial class DoctorLOGIN : Form
    {
        string userName;
        public DoctorLOGIN(string uName)
        {
            InitializeComponent();
            this.userName = uName;
        }
        SqlConnection con = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=HMSDB;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            try 
            {
                dataGridView1.DataSource = null;

                SqlCommand cmd = new SqlCommand(@"Select l.userName,l.Role,d.* from DoctorTB d inner join LogInTB l on d.UserID = l.UserID where l.UserName=@userName", con);
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

        private void button7_Click(object sender, EventArgs e)
        {
            SearchPatient sp = new SearchPatient();
            sp.Show();
            this.Hide();
        }
        

        private void button4_Click(object sender, EventArgs e)
        {
            Prescription p = new Prescription();
            p.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            SqlCommand cmd = new SqlCommand(@"Select a.* from AppoinmentTB a inner join DoctorTB d on a.DoctorID=d.DoctorID inner join LogINTB l on d.UserID=l.UserID where l.UserName=@userName",con);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@userName", userName);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            dataGridView1.DataSource = dt;
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            SqlCommand cmd = new SqlCommand(@"Select a.* from AppoinmentTB a inner join DoctorTB d on a.DoctorID=d.DoctorID inner join LogINTB l on d.UserID=l.UserID where l.UserName=@userName and cast(a.AppoinmentDate as DATE)=cast(GETDATE() AS DATE)", con);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@userName", userName);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            dataGridView1.DataSource = dt;
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();

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
            Login l = new Login();
            l.Show();
            this.Hide();
        }
    }
}
