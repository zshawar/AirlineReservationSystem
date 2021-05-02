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
    public partial class CreateFlight : Form
    {
        public CreateFlight()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //get textbox data to store in variables 
            string flightNum = textBox1.Text;
            string from = textBox2.Text;
            string destination = textBox3.Text;
            string price = textBox4.Text;
            string time = textBox5.Text;
            int capacity = (int)numericUpDown1.Value;

            //first check that every box is filled
            if (flightNum == "" || from == "" || destination == "" || price == "" || time == "" || capacity<=0)
            {
                createError.ForeColor = Color.Red;
                createError.Text = "Please make sure all fields are valid!";
            }
            //otherwise everything is right so show success message
            else
            {
                //Create flight item to add
                Flights created = new Flights(flightNum, from, destination, price, time, capacity);
                //add values to flight array
                Program.flight.Add(created);
                createError.ForeColor = Color.Green;
                createError.Text = "Success!";
                //reset textboxes and capacity to blank
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                numericUpDown1.Value = 0;
            }
        }
    }
}
