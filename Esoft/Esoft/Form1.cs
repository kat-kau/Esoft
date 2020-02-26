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
                SqlCommand com = new SqlCommand("SELECT  PlayerInTeam.ShirtNumber, Player.Name, Position.Name AS Expr1, Player.DateOfBirth, Player.College, Player.JoinYear, PlayerInTeam.Salary " +
                                                "FROM Player INNER JOIN PlayerInTeam ON Player.PlayerId = PlayerInTeam.PlayerId INNER JOIN Position ON Player.PositionId = Position.PositionId INNER JOIN Team ON PlayerInTeam.TeamId = Team.TeamId " +
                                                "where Team.TeamName ='" + g.nameteam + "' and PlayerInTeam.SeasonId = '3' ", con);

                SqlDataReader dr = com.ExecuteReader();
                int i = 0;
                while (dr.Read())
                {

                    dataGridView1.Rows.Add();
                    TimeSpan exp = new TimeSpan();
                    dataGridView1.Rows[i].Cells[0].Value = dr[0].ToString();
                    dataGridView1.Rows[i].Cells[1].Value = dr[1].ToString();
                    dataGridView1.Rows[i].Cells[2].Value = dr[2].ToString();
                    dataGridView1.Rows[i].Cells[3].Value = dr[3].ToString();
                    dataGridView1.Rows[i].Cells[4].Value = dr[4].ToString();
                    exp = DateTime.Now - Convert.ToDateTime(dr[5]);
                    dataGridView1.Rows[i].Cells[5].Value = exp.Days / 365;
                    dataGridView1.Rows[i].Cells[6].Value = dr[6].ToString();


                 /*   switch (dr[2].ToString())
                    {
                        case "Center":
                            dataGridView3.Rows.Add();
                            dataGridView3.Rows[i1].Cells[0].Value = dr[1].ToString();
                            i1++;
                            break;
                        case "SmallForward":
                            dataGridView5.Rows.Add();
                            dataGridView5.Rows[i2].Cells[0].Value = dr[1].ToString();
                            i2++;
                            break;
                        case "PowerForward":
                            dataGridView6.Rows.Add();
                            dataGridView6.Rows[i3].Cells[0].Value = dr[1].ToString();
                            i3++;
                            break;
                        case "ShootingGuard":
                            dataGridView7.Rows.Add();
                            dataGridView7.Rows[i4].Cells[0].Value = dr[1].ToString();
                            i4++;
                            break;
                        case "PointGuard":
                            dataGridView4.Rows.Add();
                            dataGridView4.Rows[i5].Cells[0].Value = dr[1].ToString();
                            i5++;
                            break;
                    } */

                    i++;
                }

            }
        }
    }
}
