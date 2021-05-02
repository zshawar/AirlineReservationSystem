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
    public partial class UserAccounts : Form
    {
        public UserAccounts()
        {
            InitializeComponent();
            //setup datagrid columns
            dataGridView1.ColumnCount = 3;
            dataGridView1.Columns[0].Name = "Username";
            dataGridView1.Columns[1].Name = "Password";
            dataGridView1.Columns[2].Name = "Email";

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            FillData();
        }

        private void FillData()
        {
            foreach (User created in Program.users)
            {
                string[] row = { created.Name, created.Password, created.Email};
                dataGridView1.Rows.Add(row);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //show admin dashboard form
            var AdminDash = new adminDash();
            AdminDash.Show();

            //close current form
            this.Close();
        }
    }
}
