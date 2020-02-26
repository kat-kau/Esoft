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
            //comboBox1.SelectedIndex = 1;
            /*SELECT        houses_in_complexes.name_JK, house_status.JK_construction_status, houses_in_complexes.town,
            COUNT(*) FROM houses_in_complexes INNER JOIN
                         house_status ON houses_in_complexes.id = house_status.id_JK

                                GROUP BY houses_in_complexes.name_JK, house_status.JK_construction_status, houses_in_complexes.town */


            using (SqlConnection con = new SqlConnection(@"Data Source = 303-17\SQLSERVER; Initial Catalog = Esoft; Integrated Security = true"))
            {
                con.Open();
                SqlCommand com = new SqlCommand("SELECT        houses_in_complexes.name_JK, house_status.JK_construction_status, houses_in_complexes.town, COUNT(*) FROM houses_in_complexes INNER JOIN house_status ON houses_in_complexes.id = house_status.id_JK GROUP BY houses_in_complexes.name_JK, house_status.JK_construction_status, houses_in_complexes.town", con);

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
                    }

                    dataGridView1.Rows[i].Cells[2].Value = dr[2].ToString();
                    dataGridView1.Rows[i].Cells[3].Value = dr[3].ToString();

                    

                    i++;
                }

            }
        }
    }
}
