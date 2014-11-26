using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminConsol
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
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
    }
}
