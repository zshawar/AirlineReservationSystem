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

        //refreshs table
        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            FillData();
        }

        //this will allow the user to delete a flight
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Check what was clicked
            //check to make sure the correct column was selected
            int col = dataGridView1.CurrentCell.ColumnIndex;
            bool isTicket;

            //if its the correct column then check the capacity
            if (col == 6)
            {
                //find what row index
                int index = dataGridView1.CurrentCell.RowIndex;

                

                //create boolean to make sure you only remove one ticket
                isTicket = false;

                //remove the user from the flight object first
                //loop through the flights to find the one being removed
                foreach (Flights created in Program.flight)
                {
                    //if the flight being removed matches the one in the flight list and boolean is false
                    if(created == Program.flight[index] && isTicket == false)
                    {

                        //remove user from flight
                        created.myPassengers.Remove(Program.currentUser);
                        //Next remove flight from user
                        //FIX THIS LATER
                        int userIndex = Program.users.IndexOf(Program.currentUser);
                        Program.users[userIndex].myFlight.Remove(created);

                        /*Program.currentUser.myFlight.Remove(created);*/
                        //set boolean to true so no other ticket is removed
                        //add one back to capacity
                        Program.flight[index].Capacity += 1;
                        isTicket = true;


                    }

                }

                //Tell user the ticket was deleted
                label1.ForeColor = Color.Red;
                label1.Text = "Ticket for " + Program.flight[index].FlightNumber + " was deleted!";

                //Update the table so capacity changes
                dataGridView1.Rows.Clear();
                FillData();
            }

        }
    }
}

