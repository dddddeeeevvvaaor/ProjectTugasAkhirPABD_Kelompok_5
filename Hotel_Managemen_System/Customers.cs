using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Hotel_Managemen_System
{
    public partial class Customers : Form
    {
        public Customers()
        {
            InitializeComponent();
            Populate();
        }

        private static string GetConnectionString()
        {
            return "Data Source=DESKTOP-CRFOF2E;Initial Catalog=HotelManagementSystem;User ID=sa;Password=Zandev";
        }

        private void Populate()
        {
            conn.Open();

            string Query = "Select * from CustomerTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, conn);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            DataSet ds = new DataSet();
            sda.Fill(ds);

            CustomerDGV.DataSource = ds.Tables[0];

            conn.Close();
        }

        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-CRFOF2E;Initial Catalog=HotelManagementSystem;Persist Security Info=True;User ID=sa;Password=Zandev");
        

        private void InsertCustomer()
        {
            if (CNametb.Text == "" || CGenderCb.SelectedIndex == -1 || CPhoneTb.Text == "")
            {
                MessageBox.Show("Missing information!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    conn.Open();

                    SqlCommand sqlCommand = new SqlCommand("insert into CustomerTbl(CustName,CustGender,CustPhone) values(@CN,@CG,@CP)", conn);

                    sqlCommand.Parameters.AddWithValue("@CN", CNametb.Text);
                    sqlCommand.Parameters.AddWithValue("@CG", CGenderCb.SelectedItem.ToString());
                    sqlCommand.Parameters.AddWithValue("@CP", CPhoneTb.Text);
                    sqlCommand.ExecuteNonQuery();

                    MessageBox.Show("Customer inserted");

                    conn.Close();
                    Populate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }


        private void EditCustomer()
        {
            if (CNametb.Text == "" || CGenderCb.SelectedIndex == -1 || CPhoneTb.Text == "")
            {
                MessageBox.Show("Missing information!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    conn.Open();

                    SqlCommand sqlCommand = new SqlCommand("update CustomerTbl set CustName=@CN,CustPhone=@CP,CustGender=@CG where CustId=@CKey", conn);

                    sqlCommand.Parameters.AddWithValue("@CN", CNametb.Text);
                    sqlCommand.Parameters.AddWithValue("@CG", CGenderCb.SelectedItem.ToString());
                    sqlCommand.Parameters.AddWithValue("@CP", CPhoneTb.Text);
                    sqlCommand.Parameters.AddWithValue("@CKey", key);
                    sqlCommand.ExecuteNonQuery();

                    MessageBox.Show("Customer updated");

                    conn.Close();
                    Populate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }


        private void DeleteCustomer()
        {
            if (key == 0)
            {
                MessageBox.Show("Select a category!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    conn.Open();

                    SqlCommand sqlCommand = new SqlCommand("delete from CustomerTbl where CustId=@CKey", conn);
                    sqlCommand.Parameters.AddWithValue("@CKey", key);
                    sqlCommand.ExecuteNonQuery();

                    MessageBox.Show("Customer Deleted!");

                    conn.Close();
                    Populate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Rooms form = new Rooms();
            form.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Types form = new Types();
            form.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Bookings form = new Bookings();
            form.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Dashboard form = new Dashboard();
            form.Show();
            this.Hide();
        }

        private void CSaveBtn_Click(object sender, EventArgs e)
        {
            InsertCustomer();
        }

        private void CEditBtn_Click(object sender, EventArgs e)
        {
            EditCustomer();
        }

        private void CDeleteBtn_Click(object sender, EventArgs e)
        {
            DeleteCustomer();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Query = "Select * from CustomerTbl where CustName = '" + ClientSearchCustomers.Text + "'";
            SqlDataAdapter sda = new SqlDataAdapter(Query, conn);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            DataSet ds = new DataSet();
            sda.Fill(ds);

            CustomerDGV.DataSource = ds.Tables[0];

            conn.Close();
        }
        int key = 0;
        private void CustomerDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CNametb.Text = CustomerDGV.SelectedRows[0].Cells[1].Value.ToString();
            CPhoneTb.Text = CustomerDGV.SelectedRows[0].Cells[2].Value.ToString();
            CGenderCb.Text = CustomerDGV.SelectedRows[0].Cells[3].Value.ToString();

            if (CNametb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(CustomerDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            reportcustomers form = new reportcustomers();
            form.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }
    }
}
