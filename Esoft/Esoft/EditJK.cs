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
    public partial class EditJK : Form
    {
        public EditJK()
        {
            InitializeComponent();
        }

        private void EditJK_Load(object sender, EventArgs e)
        {
            Form1 g = (Form1)this.Owner;
            //MessageBox.Show(g.ID);

            using (SqlConnection con = new SqlConnection(@"Data Source = .\SQLSERVER; Initial Catalog = Esoft; Integrated Security = true"))
            {
                con.Open();
                SqlCommand com = new SqlCommand("SELECT        complexes.name_JK, complexes.town, JK_costs.value_added_JK, JK_costs.JK_construction_costs, JK_status.JK_construction_status FROM            complexes INNER JOIN JK_costs ON complexes.id = JK_costs.id_JK INNER JOIN JK_status ON complexes.id = JK_status.id_JK WHERE complexes.id = "+g.ID+ " and JK_costs.id_JK = " + g.ID + " and JK_status.id_JK = " + g.ID+"", con);

                SqlDataReader dr = com.ExecuteReader();
                int i = 0;
                while (dr.Read())
                {

                textBox1.Text = dr[0].ToString();
                    textBox4.Text = dr[1].ToString();
                    textBox2.Text = dr[2].ToString();
                    textBox3.Text = dr[3].ToString();
                    

                    switch (dr[4].ToString())
                    {
                        case "plan":
                            comboBox1.SelectedIndex = 0;
                            break;
                        case "built":
                            comboBox1.SelectedIndex = 1;
                            break;
                        
                        case "realiz":
                            comboBox1.SelectedIndex = 2;
                            break;
                    }

                    i++;
                }
                con.Close();

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            Form1 g = (Form1)this.Owner;

            using (SqlConnection con = new SqlConnection(@"Data Source = .\SQLSERVER; Initial Catalog = Esoft; Integrated Security = true"))
            {
                try
                {
                    con.Open();


                    string status = "";
                    switch (comboBox1.Text)
                    {
                        case ("План"):
                            status = "plan";
                            break;

                        case ("Строительство"):
                            status = "built";
                            break;

                        case ("Реализация"):
                            status = "realiz";
                            break;
                    }



                    if (status == "" || textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
                    {
                        MessageBox.Show("Пожалуйста, заполните все поля!");
                    }
                    else
                    {
                        try
                        {
                            Convert.ToInt64(textBox2.Text);
                        }
                        catch (OverflowException E)
                        {
                            MessageBox.Show("Коэффициент добавочной стоимости не должен превышать " + Int64.MaxValue.ToString());
                        }

                        try
                        {
                            Convert.ToInt64(textBox3.Text);
                        }
                        catch (OverflowException E)
                        {
                            MessageBox.Show("Затраты на строительство жилищного комплекса не должены превышать " + Int64.MaxValue.ToString());
                        }

                        SqlCommand com = new SqlCommand(" UPDATE [dbo].[JK_status] SET [JK_construction_status] = '"+status+"' WHERE id_JK = " + g.ID + "; UPDATE [dbo].[JK_costs] SET [value_added_JK] = "+textBox2.Text+ ",[JK_construction_costs] = " + textBox3.Text + " WHERE id_JK = " + g.ID + "; UPDATE [dbo].[complexes] SET [name_JK] = '" + textBox1.Text + "',[town] = '" + textBox4.Text + "' WHERE id = " + g.ID + "", con);
                        com.ExecuteNonQuery();
                        MessageBox.Show("Жилой комплекс изменён", "Все прошло успешно!", MessageBoxButtons.OK);
                        con.Close();
                    }

                }
                catch (Exception E)
                {
                    //MessageBox.Show("Произошла ошибка: " + E.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 child = new Form1();
            child.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
