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
    public partial class DisplayBooks : DevComponents.DotNetBar.Metro.MetroForm
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-GJACM0V\CURRYSQL;Initial Catalog=Library_management;Integrated Security=True");

        public DisplayBooks()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select *from Book_info";
            cmd.ExecuteNonQuery();
            con.Close();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
           
            }
        public void Display()
        {

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select *from Book_info";
            cmd.ExecuteNonQuery();
            con.Close();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            int i = 0;
           try
            {

                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select *from Book_info where bookname like('%"+textBox1.Text+"%')";
                cmd.ExecuteNonQuery();
                con.Close();

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;

                if (i == 0)
                {
                    MessageBox.Show("No books found");
                }

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int i = 0;
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select *from book_info where authorname like('%" + textBox2.Text + "%')";
                cmd.ExecuteNonQuery();
                con.Close();

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                if (i == 0)
                {
                    MessageBox.Show("No books found");
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select *from Book_info where  id='"+i+"'";
                cmd.ExecuteNonQuery();
                con.Close();


                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach(DataRow dr in dt.Rows)
                {
                    textBox3.Text = dr["bookname"].ToString();
                    textBox4.Text = dr["authorname"].ToString();
                    textBox5.Text = dr["publicationname"].ToString();
                    dateTimePicker1.Value = Convert.ToDateTime(dr["PurchaseDate"].ToString());
                    textBox8.Text = dr["price"].ToString();
                    textBox6.Text = dr["quantity"].ToString();
                    textBox7.Text = dr["available_quantity"].ToString();
                }
                con.Close();




            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            int i;
            i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update Book_info set bookname='" + textBox3.Text + "',authorname='" + textBox4.Text + "',publicationname='" + textBox5.Text + "',PurchaseDate='" + dateTimePicker1.Text + "',price='" + textBox8.Text + "',quntity='" + textBox6.Text + "',available_quantity='"+textBox7.Text+"' where id='" + i + "'";
                cmd.ExecuteNonQuery();
                con.Close();
                Display();
                MessageBox.Show("Record updated successfully");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DisplayBooks_Load(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            user ss = new user();
            ss.Show();
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            this.Hide();
            user ss = new user();
            ss.Show();
        }
    }
    }
