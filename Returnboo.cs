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
    public partial class Returnboo : DevComponents.DotNetBar.Metro.MetroForm
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-GJACM0V\CURRYSQL;Initial Catalog=Library_management;Integrated Security=True");
        public Returnboo()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            fill(textBox1.Text);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select *from issue_book where id='" + i + "'";
            cmd.ExecuteNonQuery();
            con.Close();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                textBox2.Text = dr["bookname"].ToString();
                textBox3.Text = Convert.ToString(dr["date"].ToString());

            }


        }

        private void Returnboo_Load(object sender, EventArgs e)
        {
       
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        public void fill(string enrol)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select *from issue_book where student_number='" + textBox1.Text + "'";
            cmd.ExecuteNonQuery();
            con.Close();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int i;
            i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Update issue_book set date='"+dateTimePicker1.Text+"' where id='"+i+"'";
            cmd.ExecuteNonQuery();
            con.Close();

            con.Open();
            SqlCommand cmd1 = con.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "Update book_info set available_quantity=available_quantity +1 where bookname='"+textBox2.Text+"'";
            cmd1.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Book Return Successfully");
            fill(textBox1.Text);
           
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            this.Hide();
            user ss = new user();
            ss.Show();
        }
    }
}