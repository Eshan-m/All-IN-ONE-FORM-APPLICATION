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
    public partial class SignupRider : Form
    {
        public SignupRider()
        {
            InitializeComponent();
        }       

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\EDUCATION\1 Year SEM 3\Object Oriented Programming with C#\Assigments\SEM END Project\All-IN-CARE-FORM-APPLICATION\AllInCare.mdf;Integrated Security=True;Connect Timeout=30");
            string query = "insert into RiderSettings(Username,FirstName,LastName,BirthDate,AdressLine1,AdressLine2,ZipCode,Province,Email,MobileNo1,LicensePlate,Password,ConfirmPassword) values ('" + unameTxt.Text + "','" + fnameTxt.Text + "','" + lnameTxt.Text + "','" + bdayCal.Value + "','" + ad1Txt.Text + "','" + ad2Txt.Text + "','" + zipTxt.Text + "','" + provCmb.Text + "','" + emailTxt.Text + "','" + mobileTxt.Text + "','" + licpTxt.Text + "','" + pwTxt.Text + "','" + conpwTxt + "')";
            SqlCommand cmd = new SqlCommand(query, con);
            try
            {
                if (pwTxt.Text == conpwTxt.Text)
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thank you for choosing ALL-IN-CARE");
                    this.Hide();
                    PRLogin log = new PRLogin();
                    log.Show();
                }
                else
                {
                    MessageBox.Show("The password you entered is not matching with the previous one try again");
                    Signup log = new Signup();
                    log.Show();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Form Submission Failed");
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }


        }

        
  
    }
}
