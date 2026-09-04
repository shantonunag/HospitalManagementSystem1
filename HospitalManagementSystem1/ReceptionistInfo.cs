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
    public partial class ReceptionistInfo : Form
    {
        public ReceptionistInfo()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=HMSDB;Integrated Security=True");

        private void button4_Click(object sender, EventArgs e)
        {
            Login LR = new Login();
            LR.Show();
            this.Hide();

            SqlCommand cmd = new SqlCommand(@"Insert Into ReceptionistTB(UserID,Gender,DOB,BloodGroup,PhoneNo,Address,EmergencyContact,EmploymentType,Experience,Qualification,PreferredShift)Values(@UserID,@Gender,@DOB,@BloodGroup,@PhoneNo,@Address,@EmergencyContact,@EmploymentType,@Experience,@Qualification,@PreferredShift)", con);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);

            cmd.Parameters.AddWithValue("@UserID", textBox1.Text);
            cmd.Parameters.AddWithValue("@Gender", comboBox1.Text);
            cmd.Parameters.AddWithValue("@DOB", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@BloodGroup", comboBox2.Text);
            cmd.Parameters.AddWithValue("@PhoneNo", textBox2.Text);
            cmd.Parameters.AddWithValue("@Address", textBox3.Text);
            cmd.Parameters.AddWithValue("@EmergencyContact", textBox4.Text);
            cmd.Parameters.AddWithValue("@EmploymentType", comboBox3.Text);
            cmd.Parameters.AddWithValue("@Experience", comboBox5.Text);
            cmd.Parameters.AddWithValue("@Qualification", textBox7.Text);
            cmd.Parameters.AddWithValue("@PreferredShift", comboBox4.Text);

            try
            {
                con.Open();

                cmd.ExecuteNonQuery();

                MessageBox.Show("You Have successfully created an Receptionist Account");
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

        private void label12_Click(object sender, EventArgs e)
        {

        }
    }
}
