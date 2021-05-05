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
    public partial class MyFlights : Form
    {
        public MyFlights()
        {
            InitializeComponent();

            //setup datagrid columns
            dataGridView1.ColumnCount = 6;
            dataGridView1.Columns[0].Name = "Flight Number";
            dataGridView1.Columns[1].Name = "From";
            dataGridView1.Columns[2].Name = "To";
            dataGridView1.Columns[3].Name = "Price";
            dataGridView1.Columns[4].Name = "Time";
            dataGridView1.Columns[5].Name = "Capacity";

            //Add button column to add flights to users
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.HeaderText = "Delete Flight";
            btn.Name = "button";
            btn.Text = "Delete";
            btn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(btn);

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //call fill data
            FillData();
        }

        //takes you to user dashboard
        private void button2_Click(object sender, EventArgs e)
        {
            //show user dashboard
            var userDash = new UserDash();
            userDash.Show();
            this.Close();
        }

        //Method that fills data to datagrid
        private void FillData()
        {
            foreach (Flights created in Program.flight)
            {
                //loop through each passenger for each flight
                foreach (User passenger in created.myPassengers)
                {
                    //make sure they are the current user
                    if (Program.currentUser == passenger)
                    {
                        //add flight information
                        string[] row = { created.FlightNumber, created.From, created.Destination, created.Price, created.Time, created.Capacity.ToString() };
                        dataGridView1.Rows.Add(row);
                    }
                    
                }
            }
        }


        //this will allow the user to delete a flight
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Check what was clicked
            //check to make sure the correct column was selected
            int col = dataGridView1.CurrentCell.ColumnIndex;
           

            //if its the correct column then check the capacity
            if (col == 6)
            {
                //find what row index
                int index = dataGridView1.CurrentCell.RowIndex;

                //create boolean to check that only one item is being deleted
                bool isTicket = true;

                //make sure empty row was not clicked
                if (dataGridView1.Rows[index].Cells["Flight Number"].Value == null)
                {
                    //nothing should happend - this will make sure that if user clicks this the error does not stop the program
                }
                //correct cell was clicked
                else
                {
                    //loop through flights to find which flight was clicked in the row that needs to be removed from the user and flight list
                    foreach (Flights created in Program.flight)
                    {
                        if (created.FlightNumber == dataGridView1.Rows[index].Cells["Flight Number"].Value.ToString() && isTicket)
                        {
                            //add one to capacity
                            created.Capacity += 1;
                            //remove user from flight
                            created.myPassengers.Remove(Program.currentUser);

                            //remove flight from user
                            int userIndex = Program.users.IndexOf(Program.currentUser);
                            Program.users[userIndex].myFlight.Remove(created);

                            //Tell user the ticket was deleted
                            label1.ForeColor = Color.Red;
                            label1.Text = "Ticket for " + created.FlightNumber + " was deleted!";

                            //Update the table so capacity changes
                            dataGridView1.Rows.Clear();
                            FillData();

                            //change bool to false
                            isTicket = false;

                            break;
                        }
                    }
                }
                
                
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //Update the table so capacity changes
            dataGridView1.Rows.Clear();
            FillData();
        }
    }
}

