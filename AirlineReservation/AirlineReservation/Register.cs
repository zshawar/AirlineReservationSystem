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
            //create variables to store usernames, passwords
            string username;
            string pass;
            string email;

            //Get user input
            username = userName.Text;
            pass = password.Text;
            email = emailBox.Text;
            if (username == "" || pass=="" || email=="")
            {
                regError.Text = "Please fill out all fields";
            }
            else
            {
                //Create user object to add to list
                /*User one = new User(username, pass, email);*/

                //create array lists
                Program.users.Add(new User(username, pass, email));
                /*label1.Text = Program.users[0].Name;*/
                //show login form
                /*Login login = new Login();
                login.SetAllPeople(Program.users);
                login.Show();*/
                var Login = new Login();
                Login.Show();
            }

           




        }

        
    }

    

    
}

