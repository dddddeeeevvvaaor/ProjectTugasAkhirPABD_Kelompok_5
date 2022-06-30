using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Hotel_Managemen_System
{
    public partial class Bookings : Form
    {
        public Bookings()
        {
            InitializeComponent();
            Populate();
            GetRooms();
            GetCustomers();
        }

        private static string GetConnectionString()
        {
            return "Data Source=DESKTOP-CRFOF2E;Initial Catalog=HotelManagementSystem;User ID=sa;Password=Zandev";
        }

        private void Populate()
        {
            conn.Open();

            string Query = "Select * from BookingTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, conn);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            BookingsDGV.DataSource = ds.Tables[0];
            conn.Close();
        }

        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-CRFOF2E;Initial Catalog=HotelManagementSystem;User ID=sa;Password=Zandev");

        int key = 0;

        private void GetRooms()
        {
            conn.Open();

            SqlCommand cmd = new SqlCommand("select * from RoomTbl where RStatus='Available'", conn);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("RId", typeof(int));
            dt.Load(rdr);
            RoomCb.ValueMember = "RId";
            RoomCb.DataSource = dt;
            conn.Close();
        }

        private void GetCustomers()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("Select * from CustomerTbl", conn);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("CustId", typeof(int));
            dt.Load(dr);
            CustomerCb.ValueMember = "CustId";
            CustomerCb.DataSource = dt;
            conn.Close();

        }

        int Price =1;
        private void fetchCost()
        {
            conn.Open();
            string Query = "select TypeCost from RoomTbl join TypeTbl on RType=TypeId where RId='" + RoomCb.SelectedValue.ToString() + "'";
            SqlCommand cmd = new SqlCommand(Query, conn);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                Price = Convert.ToInt32(dr["TypeCost"].ToString());
            }

            conn.Close();
        }

        private void BookBtn_Click(object sender, EventArgs e)
        {
            if (CustomerCb.SelectedIndex == -1 || RoomCb.SelectedIndex == -1 || AmountTb.Text == "" || DurationTb.Text == "")
            {
                MessageBox.Show("missing information!");
            }
            else
            {
                try
                {
                    conn.Open();
                    SqlCommand sqlCommand = new SqlCommand("insert into BookingTbl(Room,Customer,BookDate,Duration,Cost) values(@BR,@BC,@BBD,@BD,@BCost)");
                    sqlCommand.Connection = conn;

                    sqlCommand.Parameters.AddWithValue("@BR", RoomCb.SelectedValue.ToString());
                    sqlCommand.Parameters.AddWithValue("@BC", CustomerCb.SelectedValue.ToString());
                    sqlCommand.Parameters.AddWithValue("@BBD", BDate.Value.Date);
                    sqlCommand.Parameters.AddWithValue("@BD", DurationTb.Text);
                    sqlCommand.Parameters.AddWithValue("@BCost", AmountTb.Text);

                    sqlCommand.ExecuteNonQuery();

                    MessageBox.Show("Booking Added!!!");
                    conn.Close();
                    Populate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            CancelBooking();
            setAvailable();
        }

        private void CancelBooking()
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

                    SqlCommand sqlCommand = new SqlCommand("delete from BookingTbl where BookId=@BKey", conn);
                    sqlCommand.Parameters.AddWithValue("@BKey", key);
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

        private void setBooked()
        {
            try
            {
                conn.Open();

                SqlCommand sqlCommand = new SqlCommand("update RoomTbl set RStatus=@RS where RId=@RKey", conn);

                sqlCommand.Parameters.AddWithValue("@RS", "Booked");
                sqlCommand.Parameters.AddWithValue("@RKey", RoomCb.SelectedValue.ToString());

                sqlCommand.ExecuteNonQuery();
                MessageBox.Show("Room Updated!", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);

                conn.Close();

                Populate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void setAvailable()
        {
            try
            {
                conn.Open();

                SqlCommand sqlCommand = new SqlCommand("update RoomTbl set RStatus=@RS where RId=@RKey", conn);

                sqlCommand.Parameters.AddWithValue("@RS", "Available");
                sqlCommand.Parameters.AddWithValue("@RKey", RoomCb.Text);

                sqlCommand.ExecuteNonQuery();
                MessageBox.Show("Room Updated!", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);

                conn.Close();

                Populate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Query = "Select * from BookingTbl where BookId = '" + ClientSearchBookings.Text + "'";
            SqlDataAdapter sda = new SqlDataAdapter(Query, conn);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            DataSet ds = new DataSet();
            sda.Fill(ds);

            BookingsDGV.DataSource = ds.Tables[0];

            conn.Close();
        }

        private void DurationTb_TextChanged(object sender, EventArgs e)
        {
            if (AmountTb.Text == "")
            {
                AmountTb.Text = "Rp 0";
            }
            else
            {
                try
                {
                    int Total = Price * Convert.ToInt32(DurationTb.Text);
                    AmountTb.Text = "" + Total;
                }
                catch (Exception Ex)
                {

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

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            reportBooking form = new reportBooking();
            form.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void RoomCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            fetchCost();
        }

        private void BookingsDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            RoomCb.Text = BookingsDGV.SelectedRows[0].Cells[1].Value.ToString();
            CustomerCb.Text = BookingsDGV.SelectedRows[0].Cells[2].Value.ToString();
            BDate.Text = BookingsDGV.SelectedRows[0].Cells[3].Value.ToString();
            DurationTb.Text = BookingsDGV.SelectedRows[0].Cells[4].Value.ToString();
            AmountTb.Text = BookingsDGV.SelectedRows[0].Cells[5].Value.ToString();

            if (AmountTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(BookingsDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }
    }
}

