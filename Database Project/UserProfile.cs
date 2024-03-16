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
    public partial class UserProfile : Form
    {
        public UserProfile()
        {
            InitializeComponent();
        }

        NpgsqlConnection connection = new NpgsqlConnection("server=localHost; port=5432; Database=project; user ID=postgres; password=pass");

        public string userName;
        public string userID;
        public int userType;
        private void UserProfile_Load(object sender, EventArgs e)
        {
            connection.Open();
            NpgsqlCommand command = new NpgsqlCommand("select username,email,birth_date,country,password,review_count,user_type from users where user_id=" + userID , connection);
            NpgsqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                lblUsername.Text = reader[0].ToString();
                lblEmail.Text = reader[1].ToString();
                lblBirthDate.Text = reader[2].ToString();
                lblNation.Text = reader[3].ToString();
                lblPassword.Text = reader[4].ToString();
                lblReviews.Text = reader[5].ToString();
                userType = Convert.ToInt32(reader[6].ToString());
            }
            if (userType == 2)
            {
                btnRequest.Enabled = false;
            }
            connection.Close();
        }

        private void btnRequest_Click(object sender, EventArgs e)
        {
            int reviewsCount = Convert.ToInt16(lblReviews.Text);

            if (reviewsCount > 10)
            {
                NpgsqlCommand command = new NpgsqlCommand("insert into requests (user_id) values (@p1)", connection);
                connection.Open();
                command.Parameters.AddWithValue("@p1", Convert.ToInt16(userID));
                command.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Talebiniz değerlendirilmek üzere yöneticilerimize iletildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Gereken şartları sağlamadığınız için başvurunuzu gerçekleştiremiyoruz.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
