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
    public partial class Form3 : Form
    {
        string constring = @"Data Source=DESKTOP-MBT85H7\AHMEDBADR;Initial Catalog=testtable;Integrated Security=True";
        public Form3()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            DateTime currentdate = DateTime.Today;
            SqlConnection sqlcon = new SqlConnection(constring);
            sqlcon.Open();
            SqlCommand cmd = sqlcon.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into customer_reservation values('" + fname_tb.Text + "','" + lname_tb.Text + "','" + nationalid_tb.Text + "','" + phonenb_tb.Text + "','" + int.Parse(roomnb_tb.Text) + "','"+currentdate+"','"+null+"')";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "update rooms set room_availablity = 'no' where room_number='" + int.Parse(roomnb_tb.Text) + "'";
            cmd.ExecuteNonQuery();
            sqlcon.Close();
            MessageBox.Show("done!");
            
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection(constring);
            sqlcon.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter("SELECT * FROM ROOMS WHERE room_type = 'single' and room_availablity = 'yes'", sqlcon);
            DataTable dtbl = new DataTable();
            sqlda.Fill(dtbl);
            dataGridView1.DataSource = dtbl;
            sqlcon.Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection(constring);
            sqlcon.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter("SELECT * FROM ROOMS WHERE room_type = 'double' and room_availablity = 'yes'", sqlcon);
            DataTable dtbl = new DataTable();
            sqlda.Fill(dtbl);
            dataGridView1.DataSource = dtbl;
            sqlcon.Close();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection(constring);
            sqlcon.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter("SELECT * FROM ROOMS WHERE room_type = 'triple' and room_availablity = 'yes'", sqlcon);
            DataTable dtbl = new DataTable();
            sqlda.Fill(dtbl);
            dataGridView1.DataSource = dtbl;
            sqlcon.Close();
        }
    }
}
