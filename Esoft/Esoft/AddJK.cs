﻿using System;
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
                con.Open();
                SqlCommand com = new SqlCommand(" INSERT INTO [dbo].[complexes] ([name_JK],[town]) VALUES ('"+textBox1.Text+"',  'aaaa'); INSERT INTO [dbo].[JK_costs] ([value_added_JK],[JK_construction_costs]) VALUES (5555, 5555); INSERT INTO [dbo].[JK_status] ([JK_construction_status]) VALUES ('plan');", con);
                com.ExecuteNonQuery();
                MessageBox.Show("Жилой комплекс добавлен", "Все прошло успешно!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                con.Close();
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
    }
}
