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
    public partial class Form1 : Form
    {
        string constring = @"Data Source=DESKTOP-MBT85H7\AHMEDBADR;Initial Catalog=testtable;Integrated Security=True";
        public static Form1 instance;
        public string user;
        string id;
        public string usernam;
        public Form1()
        {
            InitializeComponent();
            instance = this;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void username_TextChanged(object sender, EventArgs e)
        {
            usernam = username.Text;
        }

        private void sign_in_btn_Click(object sender, EventArgs e)
        {
           
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection(constring);
            sqlcon.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM employee WHERE employee_id='" + username.Text + "' AND employee_pw='" + password.Text + "'", sqlcon);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count == 1)
            {

                DateTime d1 = new DateTime(1900,1,1,00,00,00);
                SqlDataAdapter err = new SqlDataAdapter("SELECT * FROM login_session WHERE logout_time = '"+null+"'", sqlcon);
                DataTable tb = new DataTable();
                err.Fill(tb);
                if (tb.Rows.Count == 0)
                {
                    DateTime currenttime = DateTime.Now;
                   
                    SqlCommand cmd = new SqlCommand("insert into login_session values('" + username.Text + "', '" + currenttime + "', '" + null + "', '" + null + "')", sqlcon);
                    cmd.ExecuteNonQuery();
                    Home f = new Home();
                    f.Show();
                    this.Hide();
                    
                    
                }
                else
                {
                    SqlCommand adp = new SqlCommand("SELECT employee_id FROM login_session WHERE logout_time = '" + null + "'", sqlcon);
                    SqlDataReader data = adp.ExecuteReader();
                    while (data.Read())
                    {
                        id = data.GetValue(0).ToString();
                    }

                    if (id.Trim().Equals(username.Text.Trim()))
                    {
                        Home f = new Home();
                        f.Show();
                        this.Hide();

                    }
                    else
                        MessageBox.Show(id+usernam);


                }
            }
            else
                MessageBox.Show("Invalid username or password");
            sqlcon.Close();
            user = username.Text;
        }
        
    }
}
