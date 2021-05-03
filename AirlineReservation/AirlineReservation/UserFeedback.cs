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
    public partial class UserFeedback : Form
    {
        public UserFeedback()
        {
            InitializeComponent();
            //setup datagrid columns
            dataGridView1.ColumnCount = 2;
            dataGridView1.Columns[0].Name = "User";
            dataGridView1.Columns[1].Name = "Feedback";

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        //Method that fills data to datagrid
        private void FillData()
        {
            
                //loop through each passenger for each flight
                foreach (User passenger in Program.users)
                {
                    foreach (string s in passenger.Feedback)
                    {

                        //stores feedback at this index
                       /* string temp = passenger.Feedback[i].ToString();*/
                        //add flight information
                        string[] row = { passenger.Name, s};
                        dataGridView1.Rows.Add(row);
                    }
                    
                        
                  

                }
            
        }

        //this is user feedback button
        private void button1_Click(object sender, EventArgs e)
        {
            //refresh feedback info
            dataGridView1.Rows.Clear();
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
    }
}
