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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=HMSDB;Integrated Security=True");

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
             

            string role = "";
            if(radioButton1.Checked)
            {
                role = "Patient";
                PatientInfo PI = new PatientInfo();
                PI.Show();
                this.Hide();
            }
            if (radioButton2.Checked)
            {
                role = "Doctor";
                DoctorInfo DI = new DoctorInfo();
                DI.Show();
                this.Hide();
            }
            if (radioButton3.Checked)
            {
                role = "Receptionist";
                ReceptionistInfo RI = new ReceptionistInfo();
                RI.Show();
                this.Hide();
            }

            SqlCommand cmd = new SqlCommand(@"INSeRT INTO LogINTB(UserName,PassWord,Email,Role)VALUES(@Name,@Pass,@Email,@Role);select SCOPE_IDENTITY();", con);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);


            cmd.Parameters.AddWithValue("@Name", textBox1.Text);
            cmd.Parameters.AddWithValue("@Pass", textBox2.Text);
            cmd.Parameters.AddWithValue("@Email", textBox4.Text);
            cmd.Parameters.AddWithValue("@Role", role);

            try
            {
                con.Open();
                //cmd.ExecuteScalar();

                object userID = cmd.ExecuteScalar();

                MessageBox.Show("Data Saved Successfully!!!! Your UserID is: "+userID.ToString());
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
