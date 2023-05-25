using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Event_Project
{
    public partial class Form4 : Form 
    {
        string constring = @"Data Source=DESKTOP-MBT85H7\AHMEDBADR;Initial Catalog=testtable;Integrated Security=True";
        public static Form4 instance;
        public TextBox checkin;
        public int roomnum;
        public string nationalid;
        public DateTime login, logout;
        public Form4()
        {
            InitializeComponent();
            instance = this;
            checkin = textBox1;
            
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection(constring);
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand("select customer_fname, customer_lname, phone_number, room_number, check_in from customer_reservation where national_id = '" + textBox7.Text + "'",sqlcon);
            SqlDataReader da = cmd.ExecuteReader();
            while(da.Read())
            {
                textBox6.Text = da.GetValue(0).ToString();
                textBox5.Text = da.GetValue(1).ToString();
                textBox4.Text = da.GetValue(3).ToString();
                textBox3.Text = da.GetValue(2).ToString();
                textBox1.Text = da.GetValue(4).ToString();
            }
            roomnum = int.Parse(textBox4.Text);
            nationalid = textBox7.Text;
            sqlcon.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form5 f = new Form5();
            f.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection(constring);
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand("select login_time from login_session where employee_id = '" + Form1.instance.user + "'", sqlcon);
            SqlDataReader data = cmd.ExecuteReader();
            TimeSpan duration;
             while (data.Read())
             {

                login = DateTime.Parse(data.GetValue(0).ToString());
                    

             }
            logout = DateTime.Now;
            duration = logout - login;
            
            sqlcon.Close();
            sqlcon.Open();
            SqlCommand insert = new SqlCommand("update login_session set logout_time='" + logout + "' where logout_time = '" +null+ "'", sqlcon);
            SqlCommand insert1 = new SqlCommand("update login_session set login_duration='" + duration + "' where login_duration = '" + null + "'", sqlcon);

            insert.ExecuteNonQuery();
            insert1.ExecuteNonQuery();
            sqlcon.Close();
        } 
    }
}
