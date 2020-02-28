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

namespace Esoft
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source = 303-17\SQLSERVER; Initial Catalog = Esoft; Integrated Security = true"))
            {
                con.Open();
                SqlCommand com = new SqlCommand("SELECT        complexes.name_JK, JK_status.JK_construction_status, complexes.town, COUNT(*) FROM            JK_status INNER JOIN complexes ON JK_status.id_JK = complexes.id INNER JOIN houses_in_complexes ON complexes.id = houses_in_complexes.id_JK GROUP BY complexes.name_JK, JK_status.JK_construction_status, complexes.town, houses_in_complexes.id_JK", con);

                SqlDataReader dr = com.ExecuteReader();
                int i = 0;
                while (dr.Read())
                {

                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[0].Value = dr[0].ToString();
                    

                    switch (dr[1].ToString())
                    {
                        case "built":
                            dataGridView1.Rows[i].Cells[1].Value = "Строительство";
                            break;
                        case "plan":
                            dataGridView1.Rows[i].Cells[1].Value = "План";
                            break;
                        case "realiz":
                            dataGridView1.Rows[i].Cells[1].Value = "Реализация";
                            break;
                    }

                    dataGridView1.Rows[i].Cells[2].Value = dr[2].ToString();
                    dataGridView1.Rows[i].Cells[3].Value = dr[3].ToString();
                    i++;
                    
                }
                con.Close();

            }
            using (SqlConnection con = new SqlConnection(@"Data Source = 303-17\SQLSERVER; Initial Catalog = Esoft; Integrated Security = true"))
            {
                con.Open();
                SqlCommand com = new SqlCommand("SELECT        complexes.name_JK, JK_status.JK_construction_status, complexes.town, COUNT(*) FROM            JK_status INNER JOIN complexes ON JK_status.id_JK = complexes.id INNER JOIN houses_in_complexes ON complexes.id = houses_in_complexes.id_JK GROUP BY complexes.name_JK, JK_status.JK_construction_status, complexes.town, houses_in_complexes.id_JK", con);

                SqlDataReader dr = com.ExecuteReader();
                int i = 0;
                while (dr.Read())
                {
                    comboBox1.Items.Add(dr[0].ToString());
                    i++;
                }
                con.Close();
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           // dataGridView1.Rows.Clear();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Visible = false;
                if (row.Cells[2].Value.ToString() == comboBox1.Text)
                    {
                        row.Visible = true;
                    }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Visible = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddJK form = new AddJK();
            form.Show();
            this.Hide();
        }
    }
}
