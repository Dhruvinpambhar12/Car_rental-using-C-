using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CarRental
{
    public partial class Users : Form
    {
        public Users()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\LENOVO\source\repos\CarRental\CarRental\CarRentaldb.mdf;Integrated Security=True;Asynchronous Processing=true;");

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void populate()
        {
            Con.Open();
            String query = "select * from UserTbl";
            SqlDataAdapter da = new SqlDataAdapter(query,  Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            UserDGV.DataSource = ds.Tables[0];

           Con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(UId.Text == "" || Uname.Text == "" || Upass.Text == "")
            {
                MessageBox.Show("missing information");
            }
            else
            {
                try
                {
                    Con.Open();
                    String query = "insert into UserTbl values("+UId.Text+" ,'"+Uname.Text+"'','"+Upass.Text+"')";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.BeginExecuteNonQuery();
                    MessageBox.Show("user suessfully added");

                    Con.Close();
                    populate();
                }
                catch(Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
        }

        private void Users_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(UId.Text=="")
            {
                MessageBox.Show("missing information");
            }
            else
            {
                try
                {
                    Con.Open();
                    String query = "delete from UserTbl where Id=" + UId.Text + ";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("user delete suessfull");
                    Con.Close();
                    populate();

                }
                catch(Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
        }

        private void UserDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            UId.Text = UserDGV.SelectedRows[0].Cells[0].Value.ToString();
            Uname.Text = UserDGV.SelectedRows[0].Cells[1].Value.ToString();
            Upass.Text = UserDGV.SelectedRows[0].Cells[2].Value.ToString();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (UId.Text == "" || Uname.Text == "" || Upass.Text == "")
            {
                MessageBox.Show("missing information");
            }
            else
            {
                try
                {
                    Con.Open();
                    String query = "update UserTbl set Uname="+Uname.Text+" where Id = "+UId.Text+"; ";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.BeginExecuteNonQuery();
                    MessageBox.Show("user suessfully edited");

                    Con.Close();
                    populate();
                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm main = new MainForm();
            main.Show();
        }
    }
}
