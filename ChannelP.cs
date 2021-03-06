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

namespace WindowsFormsApp1
{
    public partial class ChannelP : Form
    {
        public ChannelP()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string special = cmbSpecialize.SelectedItem.ToString();
            string descript = txtProbDescript.Text;
            string doc = cmbDoctor.SelectedItem.ToString();
            string hos = cmbHospital.SelectedItem.ToString();
            string appointdate = dtpAppointment.Value.ToString();

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\EDUCATION\1 Year SEM 3\Object Oriented Programming with C#\Assigments\SEM END Project\All-IN-CARE-FORM-APPLICATION\AllInCare.mdf;Integrated Security=True;Connect Timeout=30");
            string query = "insert into ChannelOne(Specialize,ProblemDescription,Doctor,Hospital,DateandTime) values('" + special + "', '" + descript + "', '" + doc + "', '" + hos + "', '" + appointdate + "')";
            SqlCommand cmd = new SqlCommand(query, con);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Your Appointment Is Confirmed");
                this.Hide();
                Patient cn = new Patient();
                cn.Show();
            }

            catch(SqlException ex1)
            {
                MessageBox.Show("Your Appointment Is Not Confirmed");
                MessageBox.Show(ex1.ToString());
            }

            finally
            {
                con.Close();
            }



        }       

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Patient patient = new Patient();
            patient.Show();
        }
    }
}
