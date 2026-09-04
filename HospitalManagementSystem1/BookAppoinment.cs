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
    public partial class BookAppoinment : Form
    {
        public BookAppoinment()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=HMSDB;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand(@"Insert into AppoinmentTB(PatientID,DoctorID,AppoinmentDate,Reason,AppoinmentStatus)Values(@PatientID,@DoctorID,@AppoinmentDate,@Reason,@AppoinmentStatus)",con);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);

            cmd.Parameters.AddWithValue("@PatientID", textBox1.Text);
            cmd.Parameters.AddWithValue("@DoctorID", textBox4.Text);
            cmd.Parameters.AddWithValue("@AppoinmentDate", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@Reason", textBox3.Text);
            cmd.Parameters.AddWithValue("@AppoinmentStatus", "Confirmed");

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Appoinment Done");
                
                

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
