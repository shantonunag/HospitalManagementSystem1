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
    public partial class Prescription : Form
    {
        public Prescription()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=HMSDB;Integrated Security=True");


        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand(@"Insert into PrescriptionTB (AppoinmentID,PatientID,DoctorID,PrescriptionDate,Medicines,Advice,Tests)values(@AppoinmentID,@PatientID,@DoctorID,@PrescriptionDate,@Medicines,@Advice,@Tests)", con);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@AppoinmentID", textBox1.Text);
            cmd.Parameters.AddWithValue("@PatientID", textBox5.Text);
            cmd.Parameters.AddWithValue("@DoctorID", textBox2.Text);
            cmd.Parameters.AddWithValue("@PrescriptionDate", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@Medicines", textBox3.Text);
            cmd.Parameters.AddWithValue("@Advice", textBox4.Text);


            List<string> selectedTests = new List<string>();
            foreach (var item in checkedListBox1.CheckedItems)
            {
                selectedTests.Add(item.ToString());
            }
            string testsString = string.Join(", ", selectedTests);
            cmd.Parameters.AddWithValue("@Tests", testsString);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Prescription Given");
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
