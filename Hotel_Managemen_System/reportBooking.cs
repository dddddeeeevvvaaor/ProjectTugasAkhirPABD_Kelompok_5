using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel_Managemen_System
{
    public partial class reportBooking : Form
    {
        public reportBooking()
        {
            InitializeComponent();
        }

        private void reportBooking_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hotelManagementSystemDataSet1.BookingTbl' table. You can move, or remove it, as needed.
            this.bookingTblTableAdapter1.Fill(this.hotelManagementSystemDataSet1.BookingTbl);

            this.reportViewer1.RefreshReport();
        }

        private void bunifuButton1_Click_1(object sender, EventArgs e)
        {
            Bookings form = new Bookings();
            form.Show();
            this.Hide();
        }
    }
}
