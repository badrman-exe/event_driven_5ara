﻿using System;
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
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void username_TextChanged(object sender, EventArgs e)
        {

        }

        private void sign_in_btn_Click(object sender, EventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection(constring);
            sqlcon.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM employee WHERE employee_id='" + username.Text + "' AND employee_pw='" + password.Text + "'", sqlcon);
            /* in above line the program is selecting the whole data from table and the matching it with the user name and password provided by user. */
            DataTable dt = new DataTable(); //this is creating a virtual table  
            sda.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                MessageBox.Show("correct");
            }
            else
                MessageBox.Show("Invalid username or password");
            
        }
    }
}
