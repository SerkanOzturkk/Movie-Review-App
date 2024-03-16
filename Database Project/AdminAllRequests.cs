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
    public partial class AdminAllRequests : Form
    {
        public AdminAllRequests()
        {
            InitializeComponent();
        }

        NpgsqlConnection connection = new NpgsqlConnection("server=localHost; port=5432; Database=project; user ID=postgres; password=pass");

        private void AdminAllRequests_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter("select * from viewuserrequests", connection);
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //datagridden users bilgileri alma
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtRequestID.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtUserID.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtUsername.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            txtReviewCount.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
        }

        private void btnUsersReviews_Click(object sender, EventArgs e)
        {

            AdminUsersReviews frm = new AdminUsersReviews();
            frm.userID = txtUserID.Text;
            frm.userName = txtUsername.Text;
            frm.ShowDialog();
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            //NpgsqlCommand cmd = new NpgsqlCommand("Update users set user_type=2 where user_id=@p1", connection);
            NpgsqlCommand cmd = new NpgsqlCommand("call update_user_type(@p1) ", connection);
            connection.Open();
            cmd.Parameters.AddWithValue("@p1", Convert.ToInt16(txtUserID.Text));
            cmd.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Kullanıcı Tipi Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //NpgsqlCommand cmd1 = new NpgsqlCommand("delete from requests where user_id=@p1", connection);
            NpgsqlCommand cmd1 = new NpgsqlCommand("call delete_requests_by_user(@p1)", connection);
            connection.Open();
            cmd1.Parameters.AddWithValue("@p1", Convert.ToInt16(txtUserID.Text));
            cmd1.ExecuteNonQuery();
            connection.Close();
            //MessageBox.Show("Yorumunuz Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            //NpgsqlCommand cmd1 = new NpgsqlCommand("delete from requests where user_id=@p1", connection);
            NpgsqlCommand cmd1 = new NpgsqlCommand("call delete_requests_by_user(@p1)", connection);
            connection.Open();
            cmd1.Parameters.AddWithValue("@p1", Convert.ToInt16(txtUserID.Text));
            cmd1.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Kullanıcı Talebi Reddedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter("select * from viewuserrequests", connection);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
