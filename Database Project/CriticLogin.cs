using Npgsql;
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
    public partial class CriticLoginForm : Form
    {
        public CriticLoginForm()
        {
            InitializeComponent();
        }

        NpgsqlConnection connection = new NpgsqlConnection("server=localHost; port=5432; Database=project; user ID=postgres; password=pass");

        private void btnLogin_Click(object sender, EventArgs e)
        {
            connection.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("select * from users where username=@p1 and password=@p2 and user_type=2", connection);
            cmd.Parameters.AddWithValue("@p1", txtUsername.Text);
            cmd.Parameters.AddWithValue("@p2", txtPassword.Text);
            NpgsqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                CriticScreen frm = new CriticScreen();
                frm.userID = dr[0].ToString();
                frm.userName = dr[1].ToString();
                frm.userType = 2;
                frm.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Lütfen Bilgilerinizi Kontrol Edin!", "Hatalı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            connection.Close();
        }

        private void CriticLoginForm_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            FirstScreen frm = new FirstScreen();
            frm.Show();
            this.Close();
        }
    }
}
