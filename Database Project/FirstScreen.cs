using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Database_Project
{
    public partial class FirstScreen : Form
    {
        public FirstScreen()
        {
            InitializeComponent();
        }

        private void pictureBoxUser_Click(object sender, EventArgs e)
        {
            UserLoginForm frm = new UserLoginForm();
            frm.Show();
            this.Hide();
        }

        private void pictureBoxCritic_Click(object sender, EventArgs e)
        {
            CriticLoginForm frm = new CriticLoginForm();
            frm.Show();
            this.Hide();
        }

        private void pictureBoxAdmin_Click(object sender, EventArgs e)
        {
            AdminLoginForm frm = new AdminLoginForm();
            frm.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FirstScreen_Load(object sender, EventArgs e)
        {

        }
    }
}
