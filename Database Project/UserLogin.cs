using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Database_Project
{
    public partial class UserLoginForm : Form
    {
        public UserLoginForm()
        {
            InitializeComponent();
        }

        NpgsqlConnection connection = new NpgsqlConnection("server=localHost; port=5432; Database=project; user ID=postgres; password=pass");

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            connection.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("select * from users where username=@p1 and password=@p2 and user_type=1",connection);
            cmd.Parameters.AddWithValue("@p1", txtUsername.Text);
            cmd.Parameters.AddWithValue("@p2", txtPassword.Text);
            NpgsqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                UserScreen frm = new UserScreen();
                frm.userID = dr[0].ToString();
                frm.userName = dr[1].ToString();
                frm.userType = 1;
                frm.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Lütfen Bilgilerinizi Kontrol Edin!", "Hatalı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            connection.Close();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            UserSignUp frm = new UserSignUp();
            frm.ShowDialog();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            FirstScreen frm = new FirstScreen();
            frm.Show();
            this.Close();
        }
    }
}
