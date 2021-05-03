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
    public partial class FindFlights : Form
    {
        public FindFlights()
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
            btn.HeaderText = "Add Flight";
            btn.Name = "button";
            btn.Text = "Add";
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

        //fill data method
        private void FillData()
        {
            foreach (Flights created in Program.flight)
            {
                string[] row = { created.FlightNumber, created.From, created.Destination, created.Price, created.Time, created.Capacity.ToString() };
                dataGridView1.Rows.Add(row);
            }
        }

        //refreshs table
        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            FillData();
        }

        //if add button is clicked
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

                //check capacity - if no seats are available
                if (Program.flight[index].Capacity == 0)
                {
                    //Tell user the ticket cannot be added check for seats later
                    label1.ForeColor = Color.Red;
                    label1.Text = "Ticket for " + Program.flight[index].FlightNumber + " cannot be added. Check for seats later.";
                }
                //there are still seats available
                else
                {
                    //adjust capacity
                    Program.flight[index].Capacity -= 1;

                    //add flight to current user in user array list
                    int userIndex = Program.users.IndexOf(Program.currentUser);
                    Program.users[userIndex].myFlight.Add(Program.flight[index]);
                    //Program.currentUser.myFlight.Add(Program.flight[index]);

                    //add current user to flight
                    Program.flight[index].myPassengers.Add(Program.currentUser);

                    //Tell user the ticket was added
                    label1.ForeColor = Color.Green;
                    label1.Text = "Ticket for " + Program.flight[index].FlightNumber + " was added!";

                    //Update the table so capacity changes
                    dataGridView1.Rows.Clear();
                    FillData();
                }
                
            }
            
        }

        
    }
}
