using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using System.Data.SqlClient;

namespace Library_Managment_System
{
    public partial class Addbooks : DevComponents.DotNetBar.Metro.MetroForm

       
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-GJACM0V\CURRYSQL;Initial Catalog=Library_management;Integrated Security=True");
        public Addbooks()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText="insert into Book_info values('"+textBox1.Text+"','"+textBox2.Text+"','"+textBox3.Text+"','"+dateTimePicker1.Text+"','"+textBox5.Text+"','"+textBox6.Text+ "','" + textBox6.Text + "')";
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Inserted Successfully");

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox5.Clear();
            textBox6.Clear();
            

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            this.Hide();
            user ss = new user();
            ss.Show();
        }
    }
}