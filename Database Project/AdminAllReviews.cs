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
    public partial class AdminAllReviews : Form
    {
        public AdminAllReviews()
        {
            InitializeComponent();
        }

        NpgsqlConnection connection = new NpgsqlConnection("server=localHost; port=5432; Database=project; user ID=postgres; password=pass");

        private void AdminAllReviews_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter("select review_id,user_id,review_text,rating,date_posted from reviews", connection);
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //datagridden users bilgileri alma
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtReviewID.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtUserID.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtReviewText.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            txtRating.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            mskDatePosted.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //NpgsqlCommand cmd = new NpgsqlCommand("Update reviews set review_text=@p1 where review_id=@p2", connection);
            NpgsqlCommand cmd = new NpgsqlCommand("call update_review_text(@p1,@p2)", connection);
            connection.Open();
            cmd.Parameters.AddWithValue("@p1", txtReviewText.Text);
            cmd.Parameters.AddWithValue("@p2", Convert.ToInt16(txtReviewID.Text));
            cmd.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("İnceleme Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //NpgsqlCommand cmd = new NpgsqlCommand("delete from reviews where review_id=@p1", connection);
            NpgsqlCommand cmd = new NpgsqlCommand("call delete_review(@p1)", connection);
            connection.Open();
            cmd.Parameters.AddWithValue("@p1", Convert.ToInt16(txtReviewID.Text));
            cmd.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("İnceleme Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter("select review_id,user_id,review_text,rating,date_posted from reviews", connection);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
