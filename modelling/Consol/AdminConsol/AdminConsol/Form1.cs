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
        String dataBaseConnectionString = "Data Source=SYSHCHIPANOV-H;" + "Initial Catalog=DATABASE1.MDF;" + "Integrated Security=True";

        Form2 form2 = new Form2();



        static public Form1 loginForm;
        
        public Form1()
        {
            InitializeComponent();
            loginForm = this;


        }

        private void button2_Click(object sender, EventArgs e)
        {
        
            SqlConnection c = new SqlConnection(dataBaseConnectionString);
            c.Open();
            SqlCommand q = new SqlCommand();
            SqlDataReader reader;

            q.Connection = c;
            q.CommandText = "Select PASSWORD from usr where login = '" + Login.Text + "'";
            reader = q.ExecuteReader();
            reader.Read();
            
            if (!reader.HasRows)
            {
                MessageBox.Show("Logon Failed", "There is no user with this login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Login.Text = "";
                Password.Text = "";
                return;
            }
            String result = reader.GetString(0);
            if (result == Password.Text)
            {

                MessageBox.Show("Succesfully", "Connected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form1.ActiveForm.Hide();
                form2.Show();
            }
            else
            {
                MessageBox.Show("Logon Failed", "Repeat login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Login.Text = "";
                Password.Text = "";
            }
        }

    }
}
