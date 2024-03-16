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
    public partial class UserScreen : Form
    {
        public UserScreen()
        {
            InitializeComponent();
        }

        NpgsqlConnection connection = new NpgsqlConnection("server=localHost; port=5432; Database=project; user ID=postgres; password=pass");

        public string userName;
        public string userID;
        public int userType;

        private void UserScreen_Load(object sender, EventArgs e)
        {
            lblName.Text = userName;
            DataTable dt = new DataTable();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter("select id,title,genre,director,year,rating from viewmoviedesc", connection);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            connection.Open();
            DataTable dt1 = new DataTable();
            NpgsqlDataAdapter da1 = new NpgsqlDataAdapter("select id,title,genre,director,year,rating from viewmoviedesc where title like '%" + txtSearch.Text + "%'", connection);
            da1.Fill(dt1);
            connection.Close();
            dataGridView1.DataSource = dt1;

        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           //datagridden film id alma
           int secilen = dataGridView1.SelectedCells[0].RowIndex;
           string titleID = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
           
           MovieDetail frm = new MovieDetail();
           frm.userID= userID;
           frm.userName=userName;
           frm.data = titleID;
           frm.ShowDialog();
           
        }

        private void lblName_Click(object sender, EventArgs e)
        {
            UserProfile frm = new UserProfile();
            frm.userID = userID;
            frm.userName = userName;
            frm.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (userType == 1)
            {
                FirstScreen frm = new FirstScreen();
                frm.Show();
                this.Close();
            }
            
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            lblName.Text = userName;
            DataTable dt = new DataTable();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter("select id,title,genre,director,year,rating from viewmoviedesc", connection);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
