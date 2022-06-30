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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            string username = "Delfox";
            string password = "123";



            if (textUser.Text == "" || textPassword.Text == "")
            {
                MessageBox.Show("Semua data wajib diisi !!");
            }
            else if (textUser.Text != username || textPassword.Text != password)
            {
                MessageBox.Show("Username atau password yang anda masukkan salah !!");
            }
            else if (textUser.Text == username && textPassword.Text == password && checkBox1.Checked)
            {
                Dashboard dashboard = new Dashboard();
                this.Hide();
                dashboard.Show();

            }
            else
            {
                MessageBox.Show("Harap setuju Term and Condition");
            }
        }
    }
}
