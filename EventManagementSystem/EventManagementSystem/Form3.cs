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
    public partial class Form3 : Form
    {
        private OleDbConnection connection = new OleDbConnection();
        public Form3()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Rishabh\Documents\EventManagementSystem.mdb";
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "insert into Users (user_id,user_pass,user_contact,user_email) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')";
                command.ExecuteNonQuery();
                MessageBox.Show("You are registered");
                connection.Close();
                textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("error: " + ex);
                textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = "";
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            (new Form1()).Show();
            this.Hide();
        }
    }
}
