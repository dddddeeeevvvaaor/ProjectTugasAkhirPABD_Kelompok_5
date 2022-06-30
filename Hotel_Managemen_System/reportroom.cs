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
    public partial class reportroom : Form
    {
        public reportroom()
        {
            InitializeComponent();
        }

        private void reportroom_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hotelManagementSystemDataSet.RoomTbl' table. You can move, or remove it, as needed.
            this.roomTblTableAdapter.Fill(this.hotelManagementSystemDataSet.RoomTbl);

            this.reportViewer1.RefreshReport();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            Rooms form = new Rooms();
            form.Show();
            this.Hide();
        }
    }
}
