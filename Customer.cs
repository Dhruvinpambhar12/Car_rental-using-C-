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
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\LENOVO\source\repos\CarRental\CarRental\CarRentaldb.mdf;Integrated Security=True;Asynchronous Processing=true;");


        private void populate()
        {
            Con.Open();
            String query = "select * from CustomerTbl";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            CustomerDGV.DataSource = ds.Tables[0];

            Con.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm main = new MainForm();
            main.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (IdTb.Text == "" || NameTb.Text == "" || AddressTb.Text == "" || PhoneTb.Text == "")
            {
                MessageBox.Show("missing information");
            }
            else
            {
                try
                {
                    Con.Open();
                    String query = "insert into CustomerTbl values(" + IdTb.Text + " ,'" + NameTb.Text + "'','" + AddressTb.Text + "','" + PhoneTb.Text + "')";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.BeginExecuteNonQuery();
                    MessageBox.Show("cars suessfully added");

                    Con.Close();
                    populate();
                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
        }

        private void Customer_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (IdTb.Text == "")
            {
                MessageBox.Show("missing information");
            }
            else
            {
                try
                {
                    Con.Open();
                    String query = "delete from CustomerTbl where CustId=" + IdTb.Text+ ";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Customer delete suessfull");
                    Con.Close();
                    populate();

                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
        }

        private void CustomerDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            IdTb.Text = CustomerDGV.SelectedRows[0].Cells[0].Value.ToString();
            NameTb.Text = CustomerDGV.SelectedRows[0].Cells[1].Value.ToString();
            AddressTb.Text = CustomerDGV.SelectedRows[0].Cells[2].Value.ToString();
            PhoneTb.Text = CustomerDGV.SelectedRows[0].Cells[3].Value.ToString();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (IdTb.Text == "" || NameTb.Text == "" || AddressTb.Text == "" || PhoneTb.Text == "")
            {
                MessageBox.Show("missing information");
            }
            else
            {
                try
                {
                    Con.Open();
                    String query = "update CustomerTbl set CustName=" + NameTb.Text + ",CustAdd=" + AddressTb.Text + ",Phone=" + PhoneTb.Text + ", where CustId= " + IdTb.Text + "; ";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.BeginExecuteNonQuery();
                    MessageBox.Show("Customer suessfully edited");

                    Con.Close();
                    populate();
                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
        }
    }
}
