using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Odbc;
using System.Data.Sql;
using System.Data.SqlClient;

namespace AdminConsol
{
    public partial class Form1 : Form
    {

        String dataBaseConnectionStringAdmin = "Data Source=SYSHCHIPANOV-H;" + "Initial Catalog=DATABASE1.MDF;" + "Integrated Security=True";

        
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Login.Text == "Admin")
            {
                SqlCommand q = new SqlCommand();
                SqlConnection c = new SqlConnection(dataBaseConnectionStringAdmin);
                c.Open();
                q.Connection = c;
                MessageBox.Show("Succesfully", "Connected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //q.CommandText
            }
        }

    }
}
