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
    public partial class CriticScreen : Form
    {
        public CriticScreen()
        {
            InitializeComponent();
        }

        public string userName;
        public string userID;
        public int userType;

        private void pictureBoxMovies_Click(object sender, EventArgs e)
        {
            UserScreen frm = new UserScreen();
            frm.userName = userName;
            frm.userID = userID;
            frm.userType = userType;
            frm.ShowDialog();
        }

        private void CriticScreen_Load(object sender, EventArgs e)
        {

        }

        private void pictureBoxCriticism_Click(object sender, EventArgs e)
        {
            MyCriticisms frm = new MyCriticisms();
            frm.userName = userName;
            frm.userID = userID;
            frm.ShowDialog();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            CriticLoginForm frm = new CriticLoginForm();
            frm.Show();
            this.Close();
        }
    }
}
