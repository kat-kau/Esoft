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
    public partial class AddJK : Form
    {
        public AddJK()
        {
            InitializeComponent();
        }

        private void AddJK_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

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

        private void button3_Click(object sender, EventArgs e)
        {
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

                        SqlCommand com = new SqlCommand(" INSERT INTO [dbo].[complexes] ([name_JK],[town]) VALUES ('" + textBox1.Text + "',  '" + textBox4.Text + "'); INSERT INTO [dbo].[JK_costs] ([value_added_JK],[JK_construction_costs]) VALUES (" + textBox2.Text + ", " + textBox3.Text + "); INSERT INTO [dbo].[JK_status] ([JK_construction_status]) VALUES ('" + status + "');", con);
                        com.ExecuteNonQuery();
                        MessageBox.Show("Жилой комплекс добавлен", "Все прошло успешно!", MessageBoxButtons.OK);
                        con.Close();
                    }

                }
                catch (Exception E)
                {
                    //MessageBox.Show("Произошла ошибка: " + E.Message);
                }
            }
        }

        private void AddJK_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8) e.Handled = true;
        }
    }
}
