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
    public partial class Admin : Form
    {
      
        public Admin()
        {
            InitializeComponent();
            
        }
        SqlConnection con = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=HMSDB;Integrated Security=True");


        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            SqlCommand cmd = new SqlCommand(@"Select l.*,d.* from LogINTB l inner join DoctorTB d on l.UserID = d.UserID where l.Role = 'Doctor'", con);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            
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
            dataGridView1.DataSource = null;
            SqlCommand cmd = new SqlCommand(@"Select l.*,p.* from LogINTB l inner join PatientTB p on l.UserID = p.UserID where l.Role = 'Patient'", con);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);

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

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            SqlCommand cmd = new SqlCommand(@"Select l.*,r.* from LogINTB l inner join ReceptionistTB r on l.UserID = r.UserID where l.Role = 'Receptionist'", con);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            
            try
            {
                sd.Fill(dt);
                dataGridView1.DataSource = dt;
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

        private void button4_Click(object sender, EventArgs e)
        {
            DeleteDoctor dd = new DeleteDoctor();
            dd.Show();
            this.Hide();
            
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DeletePatient dp = new DeletePatient();
            dp.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DeleteReceptionist dr = new DeleteReceptionist();
            dr.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ActiveStatusUpdator asu = new ActiveStatusUpdator();
            asu.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            l.Show();
            this.Hide();
        }
    }
}
