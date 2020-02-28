using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            Application.OpenForms[0].Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            /*
             INSERT INTO [dbo].[complexes]
           ([name_JK]
           ,[town])
     VALUES
           ('aaaa', 
           'aaaa')
GO

INSERT INTO [dbo].[JK_costs]
           ([value_added_JK]
           ,[JK_construction_costs])
     VALUES
           (5555, 
           5555)
GO

INSERT INTO [dbo].[JK_status]
           ([JK_construction_status])
     VALUES
           ('plan')
GO

    */
        }
    }
}
