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
            
            //reset labels to empty
            incorrectUser.Text = "";
            incorrectPass.Text = "";
            //call method
            bool[] auth = new bool [2];
            auth = checkUser();
            /*Boolean user;
            Boolean userPass;
            
            //Get user input
            user = false;
            userPass = false;*/

            //Check that username and password match username and password from registration
            /*for(int i = 0; i <= Program.users.Count-1; i++)
            {
                if (Program.users[i].Name.Equals(userName.Text) && Program.users[i].Password.Equals(password.Text))
                {
                    user = true;
                    userPass = true;
                    break;
                }
                //these statements caused login problem comment out please
                else if (Program.users[i].Name.Equals(userName.Text) && !(Program.users[i].Password.Equals(password.Text)))
                {
                    user = true;
                    userPass = false;
                }
                else if (!(Program.users[i].Name.Equals(userName.Text)) && Program.users[i].Password.Equals(password.Text))
                {
                    user = false;
                    userPass = true;
                }
                else
                {
                    user = false;
                    userPass = false;
                }

            }*/

            label1.Text = Program.users[0].Name;

            //if one is incorrect then they need to enter correct credentials
            if (auth[0] != true || auth[1] != true)
            {
                if (auth[0] != true)
                {
                    incorrectUser.Text = "Incorrect Username";
                }
                if (auth[1] != true)
                {
                    incorrectPass.Text = "Incorrect Password";
                }
            }
            if (auth[0] == true && auth[1] == true)
            {
                //show user dashboard form
                var UserDash = new UserDash();
                UserDash.Show();
            }

            
                
        }

        public bool[] checkUser()
        {
            
            //Check that username and password match username and password from registration
            for (int i = 0; i <= Program.users.Count - 1; i++)
            {
                if (Program.users[i].Name.Equals(userName.Text) && Program.users[i].Password.Equals(password.Text))
                {
                    return new bool[] { true, true };

                }
                //these statements caused login problem comment out please
                else if (Program.users[i].Name.Equals(userName.Text) && !(Program.users[i].Password.Equals(password.Text)))
                {
                    return new bool[] { true, false };
                }
                else if (!(Program.users[i].Name.Equals(userName.Text)) && Program.users[i].Password.Equals(password.Text))
                {
                    return new bool[] { false, true };
                }
                

            }
            return new bool[] { false, false };

        }
    }

    
}
