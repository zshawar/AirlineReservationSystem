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
    public partial class UpdateFlight : Form
    {
        public UpdateFlight()
        {
            InitializeComponent();

            //fill values with already used flight information
            textBox1.Text = Program.updateFlight.FlightNumber;
            textBox2.Text = Program.updateFlight.From;
            textBox3.Text = Program.updateFlight.Destination;
            textBox4.Text = Program.updateFlight.Price;
            textBox5.Text = Program.updateFlight.Time;
            numericUpDown1.Value = Program.updateFlight.Capacity;
        }

        //when update button is clicked the flight needs to be updated in the flight list and for each user who bought this flight ticket
        private void button1_Click(object sender, EventArgs e)
        {
            //store updated values in form in another flight object and keep same users
            Flights newFlight = new Flights(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, (int)numericUpDown1.Value);
            newFlight.myPassengers = Program.updateFlight.myPassengers;

            //first check that every box is filled
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
            {
                createError.ForeColor = Color.Red;
                createError.Text = "Please make sure all fields are valid!";
            }
            else
            {
                //loop through flights to find the one being updated
                foreach (Flights created in Program.flight)
                {
                    if (created == Program.updateFlight)
                    {
                        //update all users with this fligt first
                        foreach (User withTicket in Program.users)
                        {
                            //loop throught the users flights and update occurrences of the flight being updated
                            for (int i = 0; i < withTicket.myFlight.Count; i++)
                            {
                                if (withTicket.myFlight[i] == created)
                                {
                                    withTicket.myFlight[i] = newFlight;
                                }
                            }
                        }

                        //Once user flights are updated change value of flight
                        int flightIndex = Program.flight.IndexOf(created);
                        Program.flight[flightIndex] = newFlight;

                        //flight has been updated so stop looping
                        break;

                    }
                }

                //open view flights form again
                var viewFlights = new ViewFlights();
                viewFlights.Show();
                this.Close();
            }
            
        }

        //go back to admin dashboard
        private void button2_Click(object sender, EventArgs e)
        {
            //show admin dashboard form
            var AdminDash = new adminDash();
            AdminDash.Show();

            //close current form
            this.Close();
        }
    }
}
