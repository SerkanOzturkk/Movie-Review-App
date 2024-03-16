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
    public partial class AdminAllMovies : Form
    {
        public AdminAllMovies()
        {
            InitializeComponent();
        }

        NpgsqlConnection connection = new NpgsqlConnection("server=localHost; port=5432; Database=project; user ID=postgres; password=pass");

        public string selectedMovieID;
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //NpgsqlCommand command = new NpgsqlCommand("insert into movies (title,genre_id,director_id,year,content,rating,movie_image) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7)", connection);
            NpgsqlCommand command = new NpgsqlCommand("call add_movie(@p1,@p2,@p3,@p4,@p5,@p6,@p7)", connection);
            connection.Open();
            command.Parameters.AddWithValue("@p1", txtTitle.Text);
            command.Parameters.AddWithValue("@p2", cmbGenre.SelectedValue);
            command.Parameters.AddWithValue("@p3", cmbDirector.SelectedValue);
            command.Parameters.AddWithValue("@p4", Convert.ToInt16(txtYear.Text));
            command.Parameters.AddWithValue("@p5", txtContent.Text);
            command.Parameters.AddWithValue("@p6", Convert.ToDouble(mskRating.Text));
            command.Parameters.AddWithValue("@p7", txtPoster.Text);
            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Film Eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBoxMovie.ImageLocation = openFileDialog1.FileName;
            txtPoster.Text = openFileDialog1.FileName;
        }

        private void AdminMovies_Load(object sender, EventArgs e)
        {
            //Datagrid
            DataTable dt2 = new DataTable();
            NpgsqlDataAdapter da2 = new NpgsqlDataAdapter("select movie_id,title,year,rating from movies", connection);
            da2.Fill(dt2);
            dataGridView1.DataSource = dt2;

            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);


            //Genres
            connection.Open();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter("select * from genres",connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmbGenre.DisplayMember = "genre_name";
            cmbGenre.ValueMember = "genre_id";
            cmbGenre.DataSource = dt;
            connection.Close();

            //Directors
            connection.Open();
            NpgsqlDataAdapter da1 = new NpgsqlDataAdapter("select * from directors", connection);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            cmbDirector.DisplayMember = "name";
            cmbDirector.ValueMember = "director_id";
            cmbDirector.DataSource = dt1;
            connection.Close();

           

        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            //datagridden veri çekme
            int secilen = dataGridView1 .SelectedCells[0].RowIndex;
            selectedMovieID = dataGridView1.Rows[secilen].Cells[0].Value.ToString();

            connection.Open();
            NpgsqlCommand command = new NpgsqlCommand("select * from movies where movie_id='" + selectedMovieID + "'", connection);
            NpgsqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                txtTitle.Text = reader[1].ToString();
                cmbGenre.SelectedValue = reader[2].ToString();
                cmbDirector.SelectedValue = reader[3].ToString();
                txtYear.Text = reader[4].ToString();
                txtContent.Text = reader[5].ToString();
                mskRating.Text = reader[6].ToString();
                txtPoster.Text = reader[7].ToString();

                pictureBoxMovie.Image = Image.FromFile(reader[7].ToString());

            }
            connection.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //NpgsqlCommand cmd = new NpgsqlCommand("Update movies set title=@p1,genre_id=@p2,director_id=@p3,year=@p4,content=@p5,rating=@p6,movie_image=@p7 where movie_id=@p8", connection);
            NpgsqlCommand cmd = new NpgsqlCommand("call update_movie(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)", connection);
            connection.Open();
            cmd.Parameters.AddWithValue("@p1", txtTitle.Text);
            cmd.Parameters.AddWithValue("@p2", cmbGenre.SelectedValue);
            cmd.Parameters.AddWithValue("@p3", cmbDirector.SelectedValue);
            cmd.Parameters.AddWithValue("@p4", Convert.ToInt16(txtYear.Text));
            cmd.Parameters.AddWithValue("@p5", txtContent.Text);
            cmd.Parameters.AddWithValue("@p6", Convert.ToDouble(mskRating.Text));
            cmd.Parameters.AddWithValue("@p7", txtPoster.Text);
            cmd.Parameters.AddWithValue("@p8", Convert.ToInt16(selectedMovieID));
            cmd.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Film Bilgileri Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //Datagrid
            DataTable dt2 = new DataTable();
            NpgsqlDataAdapter da2 = new NpgsqlDataAdapter("select movie_id,title,year,rating from movies", connection);
            da2.Fill(dt2);
            dataGridView1.DataSource = dt2;

            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }
    }
}
