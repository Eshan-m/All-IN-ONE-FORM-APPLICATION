﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class PharmacyCheckoutP : Form
    {
         
        public PharmacyCheckoutP()
        {
            InitializeComponent();
        }

        string Payment;
        private void button1_Click(object sender, EventArgs e)
        {
            
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\EDUCATION\1 Year SEM 3\Object Oriented Programming with C#\Assigments\SEM END Project\All-IN-CARE-FORM-APPLICATION\AllInCare.mdf;Integrated Security=True;Connect Timeout=30");
            string query = "insert into Pharmacy(City,Pharmacy,Date,Payment) values('" + cityCmb.Text + "','" + pharmacyLst.Text + "','" + dateCal.Value.ToString() + "','" + Payment + "')";
            SqlCommand cmd = new SqlCommand(query, con);
            this.Hide();
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Records were added successfully");
                this.Hide();
                Patient patient = new Patient();
                patient.Show();

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
                MessageBox.Show("Error your values didn't added");
            }
            finally
            {
                con.Close();
            }
        }                

        private void cashBtn_CheckedChanged(object sender, EventArgs e)
        {
            Payment = "Cash On Delivery";
        }

        private void payBtn_CheckedChanged(object sender, EventArgs e)
        {
            Payment = "Pay Now";
        }      

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            POrder log = new POrder();
            log.Show();
        }
    }
}
