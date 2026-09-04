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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            Register r = new Register();
            r.Show();
            this.Hide();
        }
        SqlConnection con = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=HMSDB;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            string userName = textBox1.Text.Trim();
            string PassWord = textBox2.Text.Trim();
            

            if(string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(PassWord))
            {
                MessageBox.Show("Please Enter Both User Name & Password", "ERROR");
            }

            try
            {
               
                SqlCommand cmd = new SqlCommand(@"Select role From LoginTB where userName=@UserName and PassWord = @PassWord and Status=@Status", con);

                cmd.Parameters.AddWithValue("@UserName", textBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@PassWord", textBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@Status", "Active");

                con.Open();
                SqlDataReader dt = cmd.ExecuteReader();

                if (dt.Read())
                {
                    String role = dt["role"].ToString();


                    MessageBox.Show("Login Succesfull!!!!", "Success");
                    if (role == "Patient")
                    {
                        PatientLOGIN PL = new PatientLOGIN(userName);
                        PL.Show();
                        this.Hide();
                    }
                    else if (role == "Doctor")
                    {
                        DoctorLOGIN DL = new DoctorLOGIN(userName);
                        DL.Show();
                        this.Hide();
                    }
                    else if (role == "Receptionist")
                    {
                        ReceptionistLOGIN RL = new ReceptionistLOGIN(userName);
                        RL.Show();
                        this.Hide();
                    }
                    else if (role == "Admin")
                    {
                        Admin a = new Admin();
                        a.Show();
                        this.Hide();
                    }

                    else
                    {
                        MessageBox.Show("Invalid Account.....Login Failed");
                    }
                }
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(textBox2.UseSystemPasswordChar)
            {
                textBox2.UseSystemPasswordChar = false;
                button3.Text = "HIDE";
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
                button3.Text = "Show";
            }
        }
    }
}
