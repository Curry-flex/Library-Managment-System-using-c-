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
    public partial class LOGIN : DevComponents.DotNetBar.Metro.MetroForm
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-GJACM0V\CURRYSQL;Initial Catalog=Library_management;Integrated Security=True");
        public LOGIN()
        {
            InitializeComponent();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select *from library_person where username='" + textBox1.Text + "' and password='" + textBox2.Text + "'";
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            da.Fill(dt);

            if (dt.Rows[0][0].ToString() == "1")
            {
                this.Hide();
                user ss = new user();
                ss.Show();
            }
            else
            {
                MessageBox.Show("incorrect password or username");
            }
        }

        private void LOGIN_Load(object sender, EventArgs e)
        {

        }
    }
}