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
    public partial class Form4 : Form
    {
        private OleDbConnection connection = new OleDbConnection();
        public Form4()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Rishabh\Documents\EventManagementSystem.mdb";
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "select * from Venues where booked = 0";
                OleDbDataAdapter da = new OleDbDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                connection.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("error: " + ex);
            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "select * from Services where booked = 0";
                OleDbDataAdapter da = new OleDbDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error: " + ex);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            (new Form1()).Show();
            this.Hide();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            connection.Open();
            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            command.CommandText = "update Venues set booked=-1 where venue_id=" + textBox1.Text;
            command.ExecuteNonQuery();
            MessageBox.Show("Venue booked!!!");
            textBox1.Text = "";
            connection.Close();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            connection.Open();
            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            command.CommandText = "update Services set booked=-1 where ser_id=" + textBox2.Text;
            command.ExecuteNonQuery();
            MessageBox.Show("Service booked!!!");
            textBox1.Text = "";
            connection.Close();
        }
    }
}
