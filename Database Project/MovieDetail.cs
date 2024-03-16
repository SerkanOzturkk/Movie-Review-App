using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Database_Project
{
    public partial class MovieDetail : Form
    {
        public MovieDetail()
        {
            InitializeComponent();
        }

        NpgsqlConnection connection = new NpgsqlConnection("server=localHost; port=5432; Database=project; user ID=postgres; password=pass");


        public string data;
        public string userName;
        public string userID;
        private void MovieDetail_Load(object sender, EventArgs e)
        {  
          //film bilgileri
          lblMovieName.Text = data;
          connection.Open();
            NpgsqlCommand command = new NpgsqlCommand("select * from viewmoviedesc where id='" + data + "'", connection);
            NpgsqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                lblMovieName.Text = reader[0].ToString();
                lblGenre.Text= reader[1].ToString();
                lblDirector.Text = reader[2].ToString();
                lblYear.Text = reader[4].ToString();
                lblRating.Text = reader[5].ToString();
                txtContent.Text = reader[6].ToString();
                pictureMovie.Image = Image.FromFile(reader[7].ToString());
               
            }
            connection.Close();

            connection.Open();
            NpgsqlCommand command1 = new NpgsqlCommand("select name from viewstars where id='" + data + "'", connection);
            NpgsqlDataReader reader1 = command1.ExecuteReader();
            while (reader1.Read())
            {
                lblStars.Text= lblStars.Text + reader1[0].ToString() + "\n";
            }
            connection.Close() ;


        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblMovieName_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void txtContent_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //diğer forma id taşınması
            UserComment frm = new UserComment();
            frm.userName = userName;
            frm.userID = userID;
            frm.data1 = data;
            frm.movieTitle = lblMovieName.Text;
            frm.ShowDialog();

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            lblMovieName.Text = data;
            connection.Open();
            NpgsqlCommand command = new NpgsqlCommand("select * from viewmoviedesc where id='" + data + "'", connection);
            NpgsqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                lblMovieName.Text = reader[0].ToString();
                lblGenre.Text = reader[1].ToString();
                lblDirector.Text = reader[2].ToString();
                lblYear.Text = reader[4].ToString();
                lblRating.Text = reader[5].ToString();
                txtContent.Text = reader[6].ToString();
                pictureMovie.Image = Image.FromFile(reader[7].ToString());

            }
            connection.Close();
        }
    }
}
