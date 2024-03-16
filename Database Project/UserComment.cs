using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Database_Project
{
    public partial class UserComment : Form
    {
        public UserComment()
        {
            InitializeComponent();
        }

        NpgsqlConnection connection = new NpgsqlConnection("server=localHost; port=5432; Database=project; user ID=postgres; password=pass");

        public string data1;
        public string movieTitle;
        public string userName;
        public string userID;
        private void UserComment_Load(object sender, EventArgs e)
        {
            lblMovieName.Text = movieTitle;
     
            //Yorumlar
            DataTable dt = new DataTable();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter("select type,name,comment,rating,date_posted from viewusercomments where id='" + data1 + "'", connection);
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
                NpgsqlCommand command = new NpgsqlCommand("insert into reviews (movie_id,user_id,review_text,rating,date_posted) values (@p1,@p2,@p3,@p4,@p5)", connection);
                connection.Open();
                command.Parameters.AddWithValue("@p1", Convert.ToInt16(data1));
                command.Parameters.AddWithValue("@p2", Convert.ToInt16(userID));
                command.Parameters.AddWithValue("@p3", txtUserComment.Text);
                command.Parameters.AddWithValue("@p4", Convert.ToDouble(mskRating.Text));
                command.Parameters.AddWithValue("@p5", DateTime.Now);
                command.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Düşüncelerinizi artık diğer insanlar da görebilecek :)", "Yorumunuz Kaydedildi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            lblMovieName.Text = movieTitle;

            //Yorumlar
            DataTable dt = new DataTable();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter("select type,name,comment,rating,date_posted from viewusercomments where id='" + data1 + "'", connection);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
