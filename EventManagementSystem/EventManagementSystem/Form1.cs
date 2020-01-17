using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace EventManagementSystem
{
    public partial class Form1 : Form
    {
        private OleDbConnection connection = new OleDbConnection();
        public Form1()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Rishabh\Documents\EventManagementSystem.mdb";
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if(textBox2.Text.Equals("admin") && textBox3.Text.Equals("admin123"))
            {
                (new Form2()).Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid ADMIN credentials");
                textBox2.Text = textBox3.Text = "";
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            (new Form3()).Show();
            this.Hide();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            connection.Open();
            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            command.CommandText = "select * from Users where user_id = '"+textBox4.Text+"' and user_pass = '"+textBox5.Text+"'";
            OleDbDataReader reader =  command.ExecuteReader();
            int count = 0;
            while (reader.Read())
            {
                count++;
            }
            if (count == 1)
            {
                (new Form4()).Show();
                this.Hide();
                connection.Close();
                textBox4.Text = textBox5.Text = "";
            }
            else
            {
                MessageBox.Show("Invalid Credentials");
                textBox4.Text = textBox5.Text = "";
                connection.Close();
            }
        }
    }
}
