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
    public partial class Form5 : Form
    {
        string constring = @"Data Source=DESKTOP-MBT85H7\AHMEDBADR;Initial Catalog=testtable;Integrated Security=True";
        public Form5()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form5_Load(object sender, EventArgs e)
        {
            textBox1.Text = Form4.instance.checkin.ToString();
            textBox2.Text = DateTime.Today.ToString();
            int room_number = Form4.instance.roomnum;
            double room_price;
            SqlConnection sqlcon = new SqlConnection(constring);
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand("select room_price_perday from rooms where room_number ='" + room_number + "' ", sqlcon);
            SqlDataReader data = cmd.ExecuteReader();
            while (data.Read())
            {
                room_price = double.Parse(data.GetValue(0).ToString());
                
            }
            sqlcon.Close();
            sqlcon.Open();
            SqlCommand cmd1 = new SqlCommand("update customer_reservation set check_out = '" + DateTime.Today + "' where national_id ='" + Form4.instance.nationalid + "'",sqlcon);
            cmd1.ExecuteNonQuery();
            SqlCommand cmd2 = new SqlCommand("select check_out from customer_reservation where national_id ='" + Form4.instance.nationalid + "' ", sqlcon);
            sqlcon.Close();
            
            
        }
    }
}
