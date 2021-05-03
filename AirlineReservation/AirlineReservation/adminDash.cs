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
    public partial class adminDash : Form
    {
        public adminDash()
        {
            InitializeComponent();
            label1.Text += " " + Program.currentUser.Name + "!";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //show create flight form
            var create = new CreateFlight();
            create.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //show view flights form
            var view = new ViewFlights();
            view.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //show login form 
            var login = new Login();
            login.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //show user accounts form 
            var accounts = new UserAccounts();
            accounts.Show();
            this.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //show passenger list form 
            var passenger = new FlightPassengers();
            passenger.Show();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //show user feedback form 
            var userFeedback = new UserFeedback();
            userFeedback.Show();
            this.Close();
        }
    }
}
