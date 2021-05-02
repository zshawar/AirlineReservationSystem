using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirlineReservation
{
    public partial class Login : Form
    {
        /*List<User> loginUsers = new List<User>();
        public void SetAllPeople(List<User> registered)
        {
            foreach (User s in registered)
            {
                loginUsers.Add(s);
            }
        }*/
        
        public Login()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            
            //reset labels used for incorrect input to empty
            incorrectUser.Text = "";
            incorrectPass.Text = "";

            //create boolean that will store what the method returns
            bool[] auth = new bool [2];

            //call method that checks if user is registered
            auth = checkUser();
            

            //if one is incorrect then they need to enter correct credentials
            //checks boolean values to see if username or password is valid
            if (auth[0] != true || auth[1] != true)
            {
                //if username is incorrect
                if (auth[0] != true)
                {
                    incorrectUser.Text = "Incorrect Username";
                }
                //if password is incorrect
                if (auth[1] != true)
                {
                    incorrectPass.Text = "Incorrect Password";
                }
            }
            //if both are correct send user to corresponding dashboard
            if (auth[0] == true && auth[1] == true)
            {
                //check if user is admin or regular user
                if (Program.currentUser.Admin == true)
                {
                    //show admin dashboard form
                    var AdminDash = new adminDash();
                    AdminDash.Show();
                }
                else
                {
                    //show user dashboard form
                    var UserDash = new UserDash();
                    UserDash.Show();
                }

                //close login page
                this.Close();
                
            }

            
                
        }

        public bool[] checkUser()
        {
            
            //Check that username and password match username and password from registration
            for (int i = 0; i <= Program.users.Count - 1; i++)
            {
                if (Program.users[i].Name.Equals(userName.Text) && Program.users[i].Password.Equals(password.Text))
                {
                    //set the current user to this valid logged in user
                    Program.currentUser = (Program.users[i]);
                    //return true for valid username and true for valid password
                    return new bool[] { true, true }; 

                }
                //checks if username was valid and password was not
                else if (Program.users[i].Name.Equals(userName.Text) && !(Program.users[i].Password.Equals(password.Text)))
                {
                    //return true for valid username and false for valid password
                    return new bool[] { true, false };
                }
                //checks if password was valid and username was not
                else if (!(Program.users[i].Name.Equals(userName.Text)) && Program.users[i].Password.Equals(password.Text))
                {
                    //returns false for username and true for valid password
                    return new bool[] { false, true };
                }
                

            }
            //otherwise it was nothing was correct and return false for both
            return new bool[] { false, false };

        }
    }

    
}
