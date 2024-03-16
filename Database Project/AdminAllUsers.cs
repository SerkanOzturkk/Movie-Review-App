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
    public partial class AdminAllUsers : Form
    {
        public AdminAllUsers()
        {
            InitializeComponent();
        }

        NpgsqlConnection connection = new NpgsqlConnection("server=localHost; port=5432; Database=project; user ID=postgres; password=pass");

        private void AdminAllUsers_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter("select user_id,username,email,birth_date,country,user_type from users" , connection);
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //datagridden users bilgileri alma
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtUserID.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtUsername.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtEmail.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            //mskBirthDate.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            txtCountry.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            txtUserType.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //NpgsqlCommand cmd = new NpgsqlCommand("delete from reviews where user_id=@p1", connection);
            NpgsqlCommand cmd = new NpgsqlCommand("call delete_reviews_by_user(@p1)", connection);
            connection.Open();
            cmd.Parameters.AddWithValue("@p1", Convert.ToInt16(txtUserID.Text));
            cmd.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("İncelemeler Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //NpgsqlCommand cmd1 = new NpgsqlCommand("delete from users where user_id=@p1", connection);
            NpgsqlCommand cmd1 = new NpgsqlCommand("call delete_user(@p1)", connection);
            connection.Open();
            cmd1.Parameters.AddWithValue("@p1", Convert.ToInt16(txtUserID.Text));
            cmd1.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Kullanıcı Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //NpgsqlCommand cmd = new NpgsqlCommand("Update users set username=@p1,email=@p2,country=@p4,user_type=@p5 where user_id=@p6", connection);
            NpgsqlCommand cmd = new NpgsqlCommand("call update_user_info(@p1,@p2,@p4,@p5,@p6)", connection);
            connection.Open();
            cmd.Parameters.AddWithValue("@p1", txtUsername.Text);
            cmd.Parameters.AddWithValue("@p2", txtEmail.Text);
            //cmd.Parameters.AddWithValue("@p3", DateTime.Parse(mskBirthDate.Text));
            cmd.Parameters.AddWithValue("@p4", txtCountry.Text);
            cmd.Parameters.AddWithValue("@p5", Convert.ToInt16(txtUserType.Text));
            cmd.Parameters.AddWithValue("@p6", Convert.ToInt16(txtUserID.Text));
            cmd.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Kullanıcı Bilgileri Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter("select user_id,username,email,birth_date,country,user_type from users", connection);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
