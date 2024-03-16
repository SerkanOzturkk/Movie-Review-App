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
    public partial class AdminScreen : Form
    {
        public AdminScreen()
        {
            InitializeComponent();
        }

        private void pictureUsers_Click(object sender, EventArgs e)
        {
            AdminAllUsers frm = new AdminAllUsers();
            frm.ShowDialog();
        }

        private void pictureBoxReviews_Click(object sender, EventArgs e)
        {
            AdminAllReviews frm = new AdminAllReviews();
            frm.ShowDialog();
        }

        private void pictureBoxApplications_Click(object sender, EventArgs e)
        {
            AdminAllRequests frm = new AdminAllRequests();
            frm.ShowDialog();
        }

        private void pictureBoxMovies_Click(object sender, EventArgs e)
        {
            AdminAllMovies frm = new AdminAllMovies();
            frm.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            AdminLoginForm frm = new AdminLoginForm();
            frm.Show();
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            AdminAllStars frm = new AdminAllStars();
            frm.ShowDialog();
        }

        private void AdminScreen_Load(object sender, EventArgs e)
        {

        }
    }
}
