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
    public partial class UserDash : Form
    {
        public UserDash()
        {
            InitializeComponent();
            label1.Text += " " + Program.currentUser.Name + "!";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //show find flights form
            var findFlights = new FindFlights();
            findFlights.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //show login form 
            var login = new Login();
            login.Show();
            this.Close();
        }
    }
}
