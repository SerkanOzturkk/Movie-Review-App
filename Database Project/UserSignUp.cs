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
    public partial class UserSignUp : Form
    {
        public UserSignUp()
        {
            InitializeComponent();
        }

        NpgsqlConnection connection = new NpgsqlConnection("server=localHost; port=5432; Database=project; user ID=postgres; password=pass");

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            NpgsqlCommand command = new NpgsqlCommand("insert into users (username,email,birth_date,country,password) values (@p1,@p2,@p3,@p4,@p5)", connection);
            connection.Open();
            command.Parameters.AddWithValue("@p1", txtUsername.Text);
            command.Parameters.AddWithValue("@p2", txtEmail.Text);
            command.Parameters.AddWithValue("@p3", DateTime.Parse(mskBirthDate.Text));
            command.Parameters.AddWithValue("@p4", txtCountry.Text);
            command.Parameters.AddWithValue("@p5", txtPassword.Text);
            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Bilgilerinizle giriş yapabilirsiniz.", "Hesabınız Oluşturuldu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UserSignUp_Load(object sender, EventArgs e)
        {

        }
    }
}
