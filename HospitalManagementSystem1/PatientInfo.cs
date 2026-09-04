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
    public partial class PatientInfo : Form
    {
        public PatientInfo()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=HMSDB;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            Login LP = new Login();
            LP.Show();
            this.Hide();

            SqlCommand cmd = new SqlCommand(@"insert into PatientTB(UserID,Gender,DOB,BloodGroup,PhoneNO,Adress,EmergencyContact,MedicalRecord,Allergies,PrevMedicalHistory,CurrentCondition)Values(@UserID,@Gender,@DOB,@BloodGroup,@PhoneNO,@Adress,@EmergencyContact,@MedicalRecord,@Allergies,@PrevMedicalHistory,@CurrentCondition)", con);

            SqlDataAdapter sd = new SqlDataAdapter(cmd);

            cmd.Parameters.AddWithValue("@UserID", textBox1.Text);
            cmd.Parameters.AddWithValue("@Gender", comboBox1.Text);
            cmd.Parameters.AddWithValue("@DOB", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@BloodGroup", comboBox2.Text);
            cmd.Parameters.AddWithValue("@PhoneNO", textBox2.Text);
            cmd.Parameters.AddWithValue("@Adress", textBox3.Text);
            cmd.Parameters.AddWithValue("@EmergencyContact", textBox4.Text);
            cmd.Parameters.AddWithValue("@MedicalRecord", textBox5.Text);
            cmd.Parameters.AddWithValue("@Allergies", textBox6.Text);
            cmd.Parameters.AddWithValue("@PrevMedicalHistory", textBox7.Text);
            cmd.Parameters.AddWithValue("@CurrentCondition", textBox8.Text);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();

                MessageBox.Show("You Have successfully Created an Patient Account");

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

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
