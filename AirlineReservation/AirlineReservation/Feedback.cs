using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirlineReservation
{
    public partial class Feedback : Form
    {
        public Feedback()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Check that from is not blank when submitted
            //first check that every box is filled
            string feedback = textBox1.Text;
            if (feedback == "")
            {
                createdError.ForeColor = Color.Red;
                createdError.Text = "Please make sure all fields are valid!";
            }
            //otherwise data is valid
            else
            {
                //adds feedback to specific user
                int userIndex = Program.users.IndexOf(Program.currentUser);
                Program.users[userIndex].Feedback.Add(feedback);

                //clear textbox and send success message
                createdError.ForeColor = Color.Green;
                createdError.Text = "Success!";
                textBox1.Text = "";
            }
            

        }

        //user dashboard
        private void button2_Click(object sender, EventArgs e)
        {
            //show user dashboard
            var userDash = new UserDash();
            userDash.Show();
            this.Close();
        }
    }
}
