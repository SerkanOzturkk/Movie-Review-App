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
    public partial class MyCriticisms : Form
    {
        public MyCriticisms()
        {
            InitializeComponent();
        }

        NpgsqlConnection connection = new NpgsqlConnection("server=localHost; port=5432; Database=project; user ID=postgres; password=pass");

        public string userName;
        public string userID;
        public string movieID;
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void MyCriticisms_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter("select type,name,id,title,comment,rating,date_posted from viewusercomments where user_id='" + userID + "'", connection);
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //datagridden yorum,rating,film adı alma
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtCriticComment.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            mskRating.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            movieID = dataGridView1.Rows[secilen].Cells[2].Value.ToString();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            NpgsqlCommand cmd = new NpgsqlCommand("delete from reviews where user_id=@p1 and movie_id=@p2", connection);
            connection.Open();
            cmd.Parameters.AddWithValue("@p1", Convert.ToInt16(userID));
            cmd.Parameters.AddWithValue("@p2", Convert.ToInt16(movieID));
            cmd.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Yorumunuz Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            NpgsqlCommand cmd = new NpgsqlCommand("Update reviews set review_text=@p1,rating=@p2,date_posted=@p3 where user_id=@p4 and movie_id=@p5", connection);
            connection.Open();
            cmd.Parameters.AddWithValue("@p1", txtCriticComment.Text);
            cmd.Parameters.AddWithValue("@p2", Convert.ToDouble(mskRating.Text));
            cmd.Parameters.AddWithValue("@p3", DateTime.Now);
            cmd.Parameters.AddWithValue("@p4", Convert.ToInt16(userID));
            cmd.Parameters.AddWithValue("@p5", Convert.ToInt16(movieID));
            cmd.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Yorumunuz Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter("select type,name,id,title,comment,rating,date_posted from viewusercomments where user_id='" + userID + "'", connection);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
