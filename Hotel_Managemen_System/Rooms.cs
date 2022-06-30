using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Hotel_Managemen_System
{
    public partial class Rooms : Form
    {
        public Rooms()
        {
            InitializeComponent();
            Populate();
            GetCategories();
        }

        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-CRFOF2E;Initial Catalog=HotelManagementSystem;User ID=sa;Password=Zandev"); int key = 0;

        private static string GetConnectionString()
        {
            return "Data Source=DESKTOP-CRFOF2E;Initial Catalog=HotelManagementSystem;User ID=sa;Password=Zandev";
        }

        private void Populate()
        {
            conn.Open();

            string Query = "Select * from RoomTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, conn);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            DataSet ds = new DataSet();
            sda.Fill(ds);

            RoomsDGV.DataSource = ds.Tables[0];

            conn.Close();
        }


        private void InsertRooms()
        {
            if (RNameTb.Text == "" || RTypeCb.SelectedIndex == -1 || RStatusCb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing information!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    conn.Open();

                    SqlCommand sqlCommand = new SqlCommand("insert into RoomTbl(RName,RType,RStatus) values(@RN,@RT,@RS)", conn);

                    sqlCommand.Parameters.AddWithValue("@RN", RNameTb.Text);
                    sqlCommand.Parameters.AddWithValue("@RT", RTypeCb.SelectedValue.ToString());
                    sqlCommand.Parameters.AddWithValue("@RS", "Available");
                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Room Added!", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn.Close();
                    Populate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void GetCategories()
        {
            conn.Open();

            SqlCommand cmd = new SqlCommand("select * from TYpeTbl", conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("TypeId", typeof(int));
            dt.Load(rdr);
            RTypeCb.ValueMember = "TypeId";
            RTypeCb.DataSource = dt;

            conn.Close();
        }

        private void EditRooms()
        {
            if (RNameTb.Text == "" || RTypeCb.SelectedIndex == -1 || RStatusCb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing information!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    conn.Open();

                    SqlCommand sqlCommand = new SqlCommand("update RoomTbl set RName=@RN,RType=@RT,RStatus=@RS where RId = @RKey", conn);

                    sqlCommand.Parameters.AddWithValue("@RN", RNameTb.Text);
                    sqlCommand.Parameters.AddWithValue("@RT", RTypeCb.SelectedValue.ToString());
                    sqlCommand.Parameters.AddWithValue("@RS", RStatusCb.SelectedItem.ToString());
                    sqlCommand.Parameters.AddWithValue("@RKey", key);
                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Room edited!", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn.Close();
                    Populate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void DeleteRooms()
        {
            if (key == 0)
            {
                MessageBox.Show("select a room!", "error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                try
                {
                    conn.Open();

                    SqlCommand sqlCommand = new SqlCommand("delete from RoomTbl where RId=@RKey", conn);
                    sqlCommand.Parameters.AddWithValue("@RKey", key);

                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Room Deleted!", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    conn.Close();

                    Populate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Types fm = new Types();
            fm.Show();
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
            InsertRooms();
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            EditRooms();
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            DeleteRooms();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();

            string Query = "Select * from RoomTbl where RName = '" + ClientSearchRoom.Text + "'";
            SqlDataAdapter sda = new SqlDataAdapter(Query, conn);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            DataSet ds = new DataSet();
            sda.Fill(ds);

            RoomsDGV.DataSource = ds.Tables[0];

            conn.Close();
        }

        private void RoomsDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            RNameTb.Text = RoomsDGV.SelectedRows[0].Cells[1].Value.ToString();
            RTypeCb.Text = RoomsDGV.SelectedRows[0].Cells[2].Value.ToString();
            RStatusCb.Text = RoomsDGV.SelectedRows[0].Cells[3].Value.ToString();

            if (RNameTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(RoomsDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }


        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            reportroom form = new reportroom();
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

