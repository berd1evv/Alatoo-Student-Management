using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Alatoo_student_management
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        SqlConnection conn;
        SqlCommand cmd;
        private void Form1_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(@"Data Source=DataSourceName;Initial Catalog=university; Integrated Security=True");
            cmd = new SqlCommand();
            cmd.Connection = conn;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = $"insert into student values('{txtid.Text.ToString()}','{txtname.Text}','{txtSurname.Text}','{txtgrade.Text.ToString()}')";
            cmd.CommandText = query;
            conn.Open();
            cmd.ExecuteNonQuery();
            cleardata();
            conn.Close();
            displaydata();
        }

        private void cleardata()
        {
            txtid.Clear();
            txtname.Clear();
            txtSurname.Clear();
            txtgrade.Clear();
        }

        private void displaydata()
        { 
            conn.Open(); 
            SqlCommand cmd = conn.CreateCommand();
        cmd.CommandType = CommandType.Text; 
            cmd.CommandText = "select * from teacher"; 
            cmd.ExecuteNonQuery(); 
            DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt); 
            dataGridView1.DataSource = dt; 
            conn.Close(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update student set name='" + txtname.Text + "',Surname='" + txtSurname.Text + "',grade='" + txtgrade.Text.ToString() + "' where id='" + txtid.Text.ToString() + "' ";
            cmd.ExecuteNonQuery();
            conn.Close();
            displaydata();
            cleardata();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            displaydata();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string query = $"delete student where id='{txtid.Text.ToString()}'";
            cmd.CommandText = query;
            conn.Open();
            cmd.ExecuteNonQuery();
            dataGridView1.DataSource = query;
            cleardata();
            conn.Close();
            displaydata();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from student where id='" + txtsearch.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            txtname.Text = dt.ToString();
            txtSurname.Text = dt.ToString();
            txtgrade.Text = dt.ToString();
            dataGridView1.DataSource = dt;
            conn.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
