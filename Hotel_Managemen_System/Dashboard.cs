﻿using System;
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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
            CountRooms();
            CountCustomers();
            SumAmount();
            GetCustomers();
        }

        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-CRFOF2E;Initial Catalog=HotelManagementSystem;User ID=sa;Password=Zandev");

        private void CountRooms()
        {
            conn.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select count(*) from RoomTbl", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            RoomLbl.Text = dt.Rows[0][0].ToString() + " Rooms";
            conn.Close();
        }

        private void CountCustomers()
        {
            conn.Open();

            SqlDataAdapter sda = new SqlDataAdapter("select count(*) from CustomerTbl", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            CustLbl.Text = dt.Rows[0][0].ToString() + " Customers";
            conn.Close();
        }

        private void SumAmount()
        {
            conn.Open();

            SqlDataAdapter sda = new SqlDataAdapter("select sum(Cost) from BookingTbl", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            BookingLbl.Text = "Rp " + dt.Rows[0][0].ToString();
            conn.Close();
        }

        private void SumDaily()
        {
            conn.Open();

            SqlDataAdapter sda = new SqlDataAdapter("select sum(Cost) from BookingTbl where BookDate='" + BDate.Value.ToString("yyyy//MM//dd").Replace("//", "") + "'", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            DIncomeLbl.Text = "Rp " + dt.Rows[0][0].ToString();
            conn.Close();
        }

        private void GetCustomers()
        {
            conn.Open();

            SqlCommand cmd = new SqlCommand("select * from CustomerTbl", conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("CustId", typeof(int));
            dt.Load(rdr);
            CustomerCb.ValueMember = "CustId";
            CustomerCb.DataSource = dt;

            conn.Close();
        }

        private void SumByCustomer()
        {
            conn.Open();

            SqlDataAdapter sda = new SqlDataAdapter("select sum(Cost) from BookingTbl where Customer='" + CustomerCb.SelectedValue.ToString() + "'", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            IncomeCustomerLbl.Text = "Rp " + dt.Rows[0][0].ToString();
            conn.Close();
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

        private void label6_Click(object sender, EventArgs e)
        {
            Customers form = new Customers();
            form.Show();
            this.Hide();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BDate_ValueChanged(object sender, EventArgs e)
        {
            SumDaily();
        }

        private void CustomerCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SumByCustomer();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }
    }
}