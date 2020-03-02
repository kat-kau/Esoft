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

        public string ID = "";

        private void Form1_Load(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source = .\SQLSERVER; Initial Catalog = Esoft; Integrated Security = true"))
            {
                con.Open();
                SqlCommand com = new SqlCommand("SELECT        complexes.id, complexes.name_JK, JK_status.JK_construction_status, complexes.town, (SELECT COUNT([id_JK]) from [dbo].houses_in_complexes WHERE  complexes.id = houses_in_complexes.id_JK) FROM            complexes INNER JOIN JK_status ON complexes.id = JK_status.id_JK; ", con);

                SqlDataReader dr = com.ExecuteReader();
                int i = 0;
                while (dr.Read())
                {

                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[0].Value = dr[0].ToString();
                    dataGridView1.Rows[i].Cells[1].Value = dr[1].ToString();

                    switch (dr[2].ToString())
                    {
                        case "built":
                            dataGridView1.Rows[i].Cells[2].Value = "Строительство";
                            break;
                        case "plan":
                            dataGridView1.Rows[i].Cells[2].Value = "План";
                            break;
                        case "realiz":
                            dataGridView1.Rows[i].Cells[2].Value = "Реализация";
                            break;
                    }

                    dataGridView1.Rows[i].Cells[3].Value = dr[3].ToString();
                    dataGridView1.Rows[i].Cells[4].Value = dr[4].ToString();
                    i++;

                }
                con.Close();

            }
            using (SqlConnection con = new SqlConnection(@"Data Source = .\SQLSERVER; Initial Catalog = Esoft; Integrated Security = true"))
            {
                con.Open();
                SqlCommand com = new SqlCommand("SELECT        town FROM            complexes GROUP BY town", con);

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
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Visible = false;
                if (row.Cells[3].Value.ToString() == comboBox1.Text)
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

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //УДАЛЕНИЕ ЖК С ДОМАМИ НЕ РАБОТАЕТ, ТОЛЬКО БЕЗ ДОМОВ. Попытки удалить записи в связанных таблицах успехами не увенчались
            
            string del = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            //MessageBox.Show(del);
            using (SqlConnection con = new SqlConnection(@"Data Source = .\SQLSERVER; Initial Catalog = Esoft; Integrated Security = true"))
            {
                con.Open();

                SqlCommand com = new SqlCommand("DELETE FROM [dbo].[JK_status] WHERE id_JK = " + del + "; DELETE FROM [dbo].[JK_costs] WHERE id_JK = " + del + ";  DELETE FROM [dbo].[complexes] WHERE id = " + del + ";", con);
                com.ExecuteNonQuery();
                con.Close();
            }

            int delet = dataGridView1.SelectedCells[0].RowIndex;
            dataGridView1.Rows.RemoveAt(delet);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {

            try
            {
                ID = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                EditJK g = new EditJK();
                g.Show(this);
                this.Hide();
            }
            catch (Exception E) { }
        }
    }
}
