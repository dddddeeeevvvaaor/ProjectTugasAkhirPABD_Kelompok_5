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
    public partial class reportTypes : Form
    {
        public reportTypes()
        {
            InitializeComponent();
        }

        private void reportTypes_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hotelManagementSystemDataSet.TYpeTbl' table. You can move, or remove it, as needed.
            this.tYpeTblTableAdapter.Fill(this.hotelManagementSystemDataSet.TYpeTbl);

            this.reportViewer1.RefreshReport();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            Types form = new Types();
            form.Show();
            this.Hide();
        }
    }
}
