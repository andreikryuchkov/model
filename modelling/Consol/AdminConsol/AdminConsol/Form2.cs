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

namespace AdminConsol
{
    public partial class Form2 : Form
    {
        private DataGridView dataGridView1 = new DataGridView(); 
        private BindingSource bindingSource1 = new BindingSource();
        private SqlDataAdapter dataAdapter = new SqlDataAdapter();
        public Form2()
        {

            dataGridView1.Dock = DockStyle.Fill;
            InitializeComponent();
        }

        private void Form2_Load(object sender, System.EventArgs e)
        {
            // Bind the DataGridView to the BindingSource
            // and load the data from the database.
            dataGridView1.DataSource = bindingSource1;
            GetData("select o.ID, city,street,house,u.name,family,mail,phone,c.name,property from [DATABASE1.MDF].[dbo].[Ord] o, [DATABASE1.MDF].[dbo].[Address] A, [DATABASE1.MDF].[dbo].[usr] u, [DATABASE1.MDF].[dbo].[Phone] p, [DATABASE1.MDF].[dbo].[Company] c where StatusID = 1 and  A.[ID] = o.AddressID and u.ID = A.usrID and p.usrID = u.ID and c.ID = u.CompanyID");
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1.loginForm.Close();
        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {

        }

        private void addNewCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void deleteCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        private void GetData(string selectCommand)
        {
            try
            {
                // Specify a connection string. Replace the given value with a 
                // valid connection string for a Northwind SQL Server sample
                // database accessible to your system.
                String connectionString =
                    "Data Source=SYSHCHIPANOV-H;" + "Initial Catalog=DATABASE1.MDF;" + "Integrated Security=True";

                // Create a new data adapter based on the specified query.
                dataAdapter = new SqlDataAdapter(selectCommand, connectionString);

                // Create a command builder to generate SQL update, insert, and
                // delete commands based on selectCommand. These are used to
                // update the database.
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

                // Populate a new data table and bind it to the BindingSource.
                DataTable table = new DataTable();
                table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                dataAdapter.Fill(table);
                bindingSource1.DataSource = table;

                // Resize the DataGridView columns to fit the newly loaded content.
                dataGridView1.AutoResizeColumns(
                    DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
            }
            catch (SqlException)
            {
                MessageBox.Show("To run this example, replace the value of the " +
                   "connectionString variable with a connection string that is " +
                    "valid for your system.");
            }
        }
    }
}

