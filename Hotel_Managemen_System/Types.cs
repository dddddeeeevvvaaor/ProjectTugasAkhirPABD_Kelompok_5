using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel_Managemen_System
{
    public partial class Types : Form
    {
        public Types()
        {
            InitializeComponent();
            Populate();
        }

        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-CRFOF2E;Initial Catalog=HotelManagementSystem;User ID=sa;Password=Zandev");
        int key = 0;

        private static string GetConnectionString()
        {
            return "Data Source=DESKTOP-CRFOF2E;Initial Catalog=HotelManagementSystem;User ID=sa;Password=Zandev";
        }

        private void Populate()
        {
            conn.Open();

            string Query = "Select * from TypeTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, conn);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);

            TypesDGV.DataSource = ds.Tables[0];

            conn.Close();
        }


        private void InsertCategories()
        {
            if (TypeNameTb.Text == "" || CostTb.Text == "")
            {
                MessageBox.Show("Missing information!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    conn.Open();

                    SqlCommand sqlCommand = new SqlCommand("insert into TypeTbl(TypeName,TypeCost) values(@TN,@TC)", conn);

                    sqlCommand.Parameters.AddWithValue("@TN", TypeNameTb.Text);
                    sqlCommand.Parameters.AddWithValue("@TC", CostTb.Text);
                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("category inserted");
                    conn.Close();
                    Populate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }


        private void EditCategorie()
        {
            if (TypeNameTb.Text == "" || CostTb.Text == "")
            {
                MessageBox.Show("Missing information!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    conn.Open();

                    SqlCommand sqlCommand = new SqlCommand("update TypeTbl set TypeName=@TN,TypeCost=@TC where TypeId=@TKey", conn);

                    sqlCommand.Parameters.AddWithValue("@TN", TypeNameTb.Text);
                    sqlCommand.Parameters.AddWithValue("@TC", CostTb.Text);
                    sqlCommand.Parameters.AddWithValue("@TKey", key);
                    sqlCommand.ExecuteNonQuery();

                    MessageBox.Show("Category updated");

                    conn.Close();
                    Populate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }


        private void DeleteCategorie()
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

                    SqlCommand sqlCommand = new SqlCommand("delete from TypeTbl where TypeId=@TKey", conn);
                    sqlCommand.Parameters.AddWithValue("@TKey", key);
                    sqlCommand.ExecuteNonQuery();

                    MessageBox.Show("Category Deleted!");

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

        private void label5_Click(object sender, EventArgs e)
        {
            Bookings form = new Bookings();
            form.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Customers form = new Customers();
            form.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Dashboard form = new Dashboard();
            form.Show();
            this.Hide();
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            InsertCategories();
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            EditCategorie();
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            DeleteCategorie();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();

            string Query = "Select * from TypeTbl where TypeName = '" + ClientSearchTypes.Text + "'";
            SqlDataAdapter sda = new SqlDataAdapter(Query, conn);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);

            TypesDGV.DataSource = ds.Tables[0];

            conn.Close();
        }

        private void TypesDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            TypeNameTb.Text = TypesDGV.SelectedRows[0].Cells[1].Value.ToString();
            CostTb.Text = TypesDGV.SelectedRows[0].Cells[2].Value.ToString();

            if (TypeNameTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(TypesDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            reportTypes form = new reportTypes();
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

