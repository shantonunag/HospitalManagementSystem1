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
    public partial class PatientLOGIN : Form
    {
        string userName;
        public PatientLOGIN(string uName)
        {
            InitializeComponent();
            this.userName = uName;
        }
        SqlConnection con = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=HMSDB;Integrated Security=True");

        private void label2_Click(object sender, EventArgs e)
        {
           

        }

        private void PatientLOGIN_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = null;

                SqlCommand cmd = new SqlCommand(@"Select l.userName,l.Role,p.* from PatientTB p inner join LogInTB l on p.UserID = l.UserID where l.UserName=@userName", con);
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

        private void button5_Click(object sender, EventArgs e)
        {
            SearchDoctor sd = new SearchDoctor();
            sd.Show();
            this.Hide();
        
    }

        private void button2_Click(object sender, EventArgs e)
        {
            BookAppoinment ba = new BookAppoinment();
            ba.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            SqlCommand cmd = new SqlCommand(@"Select a.* from AppoinmentTB a inner join PatientTb p on a.PatientID = p.patientID inner join LoginTB l on p.UserID=l.UserID where l.UserName = @userName", con);
            cmd.Parameters.AddWithValue("@userName",this.userName);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();


          try
            {
                con.Open();
                sd.Fill(dt);

                dataGridView1.DataSource = dt;
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

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            SqlCommand cmd = new SqlCommand(@"Select p.* from PrescriptionTB p inner join PatientTB t on p.PatientID=t.PatientID inner join LogINTB l on t.UserID=l.UserID where l.UserName=@userName", con);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@userName", userName);
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

        private void button6_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            l.Show();
            this.Hide();
        }
    }
}
