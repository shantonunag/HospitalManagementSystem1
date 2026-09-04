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
    public partial class DoctorInfo : Form
    {
        public DoctorInfo()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=HMSDB;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            Login LD = new Login();
            LD.Show();
            this.Hide();

            SqlCommand cmd = new SqlCommand(@"Insert into DoctorTB(UserID,Gender,DOB,BloodGroup,PhoneNumber,Address,EmergencyContact,Specialization,Qualification,Department)Values(@UserID,@Gender,@DOB,@BloodGroup,@PhoneNumber,@Address,@EmergencyContact,@Specialization,@Qualification,@Department)", con);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);

            cmd.Parameters.AddWithValue("@UserID", textBox1.Text);
            cmd.Parameters.AddWithValue("@Gender", comboBox1.Text);
            cmd.Parameters.AddWithValue("@DOB", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@BloodGroup", comboBox2.Text);
            cmd.Parameters.AddWithValue("@PhoneNumber", textBox2.Text);
            cmd.Parameters.AddWithValue("@Address", textBox3.Text);
            cmd.Parameters.AddWithValue("@EmergencyContact", textBox4.Text);
            cmd.Parameters.AddWithValue("@Specialization", textBox5.Text);
            cmd.Parameters.AddWithValue("@Qualification", textBox6.Text);
            cmd.Parameters.AddWithValue("@Department", comboBox3.Text);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("You HAVE successfully created a DOCTOR ACCOUNT");
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
    }
}
