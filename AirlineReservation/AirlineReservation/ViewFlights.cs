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
    public partial class ViewFlights : Form
    {
        public ViewFlights()
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

            //Add button column to delete flights to users
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.HeaderText = "Delete Flight";
            btn.Name = "button";
            btn.Text = "Delete";
            btn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(btn);

            //Add button column to update flights to users
            DataGridViewButtonColumn btn2 = new DataGridViewButtonColumn();
            btn2.HeaderText = "Update Flight";
            btn2.Name = "buttons";
            btn2.Text = "Update";
            btn2.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(btn2);

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            FillData();

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

        //opens admin dashboard
        private void button2_Click(object sender, EventArgs e)
        {
            //show admin dashboard form
            var AdminDash = new adminDash();
            AdminDash.Show();

            //close current form
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Check what was clicked
            //check to make sure the correct column was selected
            int col = dataGridView1.CurrentCell.ColumnIndex;
            int index = dataGridView1.CurrentCell.RowIndex;

            //if its column 6 for delete flight
            if (col == 6)
            {
                
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
                            //loop through user lists and remove all flight occurrences
                            foreach (User added in Program.users)
                            {
                               
                                //loop throught the users flights and remove occurrences of the flight being deleted
                                for(int i = 0; i<added.myFlight.Count; i++)
                                {
                                    if (added.myFlight[i] == created)
                                    {
                                        added.myFlight.Remove(created);
                                        --i;
                                    }
                                }
                            }

                            //then remove the flight from flight list
                            Program.flight.Remove(created);

                            //Tell user the ticket was deleted
                            label1.ForeColor = Color.Red;
                            label1.Text = "Ticket for " + created.FlightNumber + " was deleted!";

                            //Update the table so capacity changes
                            dataGridView1.Rows.Clear();
                            FillData();

                            //change boolean to false
                            isTicket = false;
                            
                            //ticket no longer exists so cannot be used to compare, a break statement is needed to exit
                            //another way could be to temporarily store the flight being deleted so it can still be referenced after it is removed
                            break;

                        }
                    }
                }
            }

            //check if column 7 for update flight
            if (col == 7)
            {
               
                //make sure empty row was not clicked
                if (dataGridView1.Rows[index].Cells["Flight Number"].Value == null)
                {
                    //nothing should happend - this will make sure that if user clicks this the error does not stop the program
                }
                //correct cell was clicked
                else
                {
                    //loop through flights to find which flight was clicked in the row that needs to be updated from the user and flight list
                    foreach (Flights created in Program.flight)
                    {
                        if (created.FlightNumber == dataGridView1.Rows[index].Cells["Flight Number"].Value.ToString())
                        {
                            //store flight in variable to get sent ot updateflight form
                            Program.updateFlight = created;

                            //then open update flight form
                            var update = new UpdateFlight();
                            update.Show();
                            this.Close();

                        }
                    }
                }
            }


        }

    }
}
