using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Console;

namespace AirlineReservation
{
    
    public partial class Register : Form
    {
        /*public List<User> accounts = new List<User>();*/
        public Register()
        {
            /*Program.users = new List<User>();*/
            InitializeComponent();
            
            

        }
       

        public void registerButton_Click(object sender, EventArgs e)
        {
            //create variables to store usernames, passwords, emails, and admin
            string username;
            string pass;
            string email;
            bool isAdmin;

            //Get user input
            username = userName.Text;
            pass = password.Text;
            email = emailBox.Text;
            isAdmin = checkBox1.Checked;
            if (username == "" || pass=="" || email=="")
            {
                regError.ForeColor = Color.Red;
                regError.Text = "Please fill out all fields";
            }
            else
            {
                

                //add registered user to list
                Program.users.Add(new User(username, pass, email, isAdmin));

                //Show success message and clear results
                regError.ForeColor = Color.Green;
                regError.Text = "Success!";
                userName.Text = "";
                password.Text = "";
                emailBox.Text = "";
                checkBox1.Checked = false;

            }

          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var Login = new Login();
            Login.Show();
        }
    }

    

    
}

