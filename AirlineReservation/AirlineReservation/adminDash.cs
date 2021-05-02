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
            var create = new CreateFlight();
            create.Show();
            this.Close();
        }
    }
}
