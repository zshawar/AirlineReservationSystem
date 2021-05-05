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
    public partial class FlightPassengers : Form
    {
        public FlightPassengers()
        {
            InitializeComponent();

            //setup datagrid columns
            dataGridView1.ColumnCount = 3;
            dataGridView1.Columns[0].Name = "Flight Number";
            dataGridView1.Columns[1].Name = "Passenger";
            dataGridView1.Columns[2].Name = "Email";
            

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //call fill data
            FillData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //show admin dashboard form
            var AdminDash = new adminDash();
            AdminDash.Show();

            //close current form
            this.Close();
        }

     
        //fill data method
        private void FillData()
        {
            //loop through each flight in the list
            foreach (Flights created in Program.flight)
            {
                //loop through each passenger for each flight
                foreach (User passenger in created.myPassengers)
                {
                    //add flight number, passenger username, and passenger email to data
                    string[] row = { created.FlightNumber, passenger.Name, passenger.Email };
                    dataGridView1.Rows.Add(row);
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
