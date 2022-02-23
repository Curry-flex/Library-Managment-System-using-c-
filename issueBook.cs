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
    public partial class issueBook : DevComponents.DotNetBar.Metro.MetroForm
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-GJACM0V\CURRYSQL;Initial Catalog=Library_management;Integrated Security=True  ");
        public issueBook()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i = 0;
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select *from student_info where student_number ='" + textBox2.Text + "'";
            cmd.ExecuteNonQuery();
            con.Close();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            i = Convert.ToInt32(dt.Rows.Count.ToString());

            if (i == 0)
            {
                MessageBox.Show("Record not found");
            }
            else
            {


                foreach (DataRow dr in dt.Rows)
                {
                    textBox3.Text = dr["student_name"].ToString();
                    textBox5.Text = dr["student_depertment"].ToString();
                    textBox6.Text = dr["student_semi"].ToString();
                    textBox7.Text = dr["student_contact"].ToString();
                    textBox8.Text = dr["student_email"].ToString();
                }
            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            int count = 0;

            if(e.KeyCode != Keys.Enter)
            {
                listBo.Items.Clear();
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select *from Book_info where bookname like('%" + textBox1.Text + "%')";
                cmd.ExecuteNonQuery();
                con.Close();
               
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                count = Convert.ToInt32(dt.Rows.Count.ToString());

                if (count > 0)
                {
                    listBo.Visible = true;

                    foreach(DataRow dr in dt.Rows)
                    {
                        listBo.Items.Add(dr["bookname"].ToString());
                    }
                }
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                listBo.Focus();
                listBo.SelectedIndex = 0;
            }
        }

        private void listBo_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                textBox1.Text = listBo.SelectedItem.ToString();
                listBo.Visible = false;
            }
        }

        private void listBo_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = listBo.SelectedItems.ToString();
            listBo.Visible = false;
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            try
            {
                int qty = 0;
                con.Open();
                SqlCommand cmd1 = con.CreateCommand();
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "select *from Book_info where bookname='" + textBox1.Text + "'";
                cmd1.ExecuteNonQuery();
                con.Close();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd1);
                da.Fill(dt);

                foreach(DataRow dr in dt.Rows)
                {
                    qty = Convert.ToInt32(dr["available_quantity"].ToString());
                }
                if (qty > 0)
                {




                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "insert into issue_book values('" + textBox2.Text + "','" + textBox3.Text + "' ,'" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox1.Text + "','" + dateTimePicker1.Text + "')";
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Record Inserted Successfully");

                    con.Open();
                    SqlCommand cm = con.CreateCommand();
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = "update Book_info set available_quantity=available_quantity-1 where bookname='" + textBox1.Text + "'";
                    cm.ExecuteNonQuery();
                    con.Close();
                }

                else
                {
                    MessageBox.Show("Books Not Available");
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            this.Hide();
            user ss = new user();
            ss.Show();
        }
    }
}