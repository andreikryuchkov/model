using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace AdminConsol
{
    public partial class Form2 : Form
    {
        static String dataBaseConnectionString = "Data Source=SYSHCHIPANOV-H;" + "Initial Catalog=DATABASE1.MDF;" + "Integrated Security=True";
        SqlConnection conn = new SqlConnection(dataBaseConnectionString);

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, System.EventArgs e)
        {
            //conn.Open();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Close();
            Form1.loginForm.Close();
        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {

        }

        private void addNewCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            DepositPanel.Visible = true;
            DepositPanel.Location = OrderPanel.Location;
            OrderPanel.Visible = false;
            ItemsPanel.Visible = false;
            CategoryPanel.Visible = false;
        }

        private void toolStripDropDownButton3_Click(object sender, EventArgs e)
        {
            OrderPanel.Visible = true;
            DepositPanel.Visible = false;
            ItemsPanel.Visible = false;
            CategoryPanel.Visible = false;
        }

        private void toolStripDropDownButton2_Click(object sender, EventArgs e)
        {
            ItemsPanel.Visible = true;
            ItemsPanel.Location = OrderPanel.Location;
            OrderPanel.Visible = false;
            DepositPanel.Visible = false;
            CategoryPanel.Visible = false;
        }


        private void toolStripButton1_Click_2(object sender, EventArgs e)
        {
            CategoryPanel.Visible = true;
            CategoryPanel.Location = OrderPanel.Location;
            ItemsPanel.Visible = false;
            OrderPanel.Visible = false;
            DepositPanel.Visible = false;
        }

        private void RefreshOrdersList_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select  o.ID, city, street, house, u.id ,u.name, family, mail,CompanyID  from [dbo].[Ord] o, [dbo].[Address] A, usr u where StatusID = 1 and  A.[ID] = o.AddressID and u.ID = A.usrID", conn);
            Object[] allData  = new Object[100];
            NewOrdersList.Items.Clear();
            conn.Open();
            SqlDataReader dataReader = cmd.ExecuteReader();
            if (dataReader.HasRows)
            {
                NewOrdersList.BeginUpdate();
                while (dataReader.Read())
                {
                    dataReader.GetSqlValues(allData);
                    NewOrdersList.Items.Add("OrderID " + allData[0].ToString() + " CITY " + allData[1].ToString() + " Street " + allData[2].ToString() + " House " + allData[3].ToString() + " UserID " + allData[4].ToString() + " User Name " + allData[5].ToString() + " LastName " + allData[6].ToString() + " mail " + allData[7].ToString() + " CompanyID " + allData[8].ToString());
                }
                NewOrdersList.EndUpdate();
                
            }
            MessageBox.Show("Order list refreshed", "The orders list is refreshed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            conn.Close();

        }

        private void ShowUserPhone_Click(object sender, EventArgs e)
        {
            if (UserID.Text.ToString() == "")
            {
                MessageBox.Show("User ID is null", "Enter user ID", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            String command = "select phone from phone where usrID = " + UserID.Text.ToString();
            SqlCommand cmd = new SqlCommand(command, conn);
            conn.Open();
            SqlDataReader dataReader = cmd.ExecuteReader();
            dataReader.Read();
            if (dataReader.HasRows)
            {
                String result = dataReader.GetString(0);
                UserPhone.Text = result;
            }
            else
            {
                MessageBox.Show("No Phone", "This user has no contact phone", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
            conn.Close();
        }

        private void ShowOrderItems_Click(object sender, EventArgs e)
        {
            if (OrderID.Text.ToString() == "")
            {
                MessageBox.Show("Order ID is null", "Enter order ID", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            String command = "select name, price, [description] from [Item], [ItemOrdered] where [ItemOrdered].ItemID = [Item].ID and [ItemOrdered].OrdID = " + OrderID.Text.ToString();
            SqlCommand cmd = new SqlCommand(command, conn);
            Object[] allData = new Object[100];
            OrderItemsList.Items.Clear();
            conn.Open();
            SqlDataReader dataReader = cmd.ExecuteReader();
            if (dataReader.HasRows)
            {
                OrderItemsList.BeginUpdate();
                while (dataReader.Read())
                {
                    dataReader.GetSqlValues(allData);
                    OrderItemsList.Items.Add("Name: " + allData[0].ToString() + " Price: " + allData[1].ToString() + " Description: " + allData[2].ToString() );
                }
                OrderItemsList.EndUpdate();

            }
            MessageBox.Show("The order items list is refreshed", "Order items list", MessageBoxButtons.OK, MessageBoxIcon.Information);
            conn.Close();
        }

        private void ConfirmOrder_Click(object sender, EventArgs e)
        {
            if (ConfirmOrderId.Text.ToString() == "")
            {
                MessageBox.Show("Enter order ID to confirm", "Order ID is null ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            String command = "UPDATE [dbo].[Ord] SET [StatusID] = 2 WHERE ID = " + ConfirmOrderId.Text.ToString();
            SqlCommand cmd = new SqlCommand(command, conn);          
            conn.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Order status updated", "Order status", MessageBoxButtons.OK, MessageBoxIcon.Information);
            conn.Close();
        }

        private void RefuseOrder_Click(object sender, EventArgs e)
        {
            if (RefuseOrderId.Text.ToString() == "")
            {
                MessageBox.Show("Enter order ID to confirm", "Order ID is null ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            String command = "UPDATE [dbo].[Ord] SET [StatusID] = 5 WHERE ID = " + RefuseOrderId.Text.ToString();
            SqlCommand cmd = new SqlCommand(command, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Order status updated", "Order status", MessageBoxButtons.OK, MessageBoxIcon.Information);
            conn.Close();
        }

        private void FinishOrder_Click(object sender, EventArgs e)
        {
            if (FinishOrderId.Text.ToString() == "")
            {
                MessageBox.Show("Enter order ID to confirm", "Order ID is null ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            String command = "UPDATE [dbo].[Ord] SET [StatusID] = 4 WHERE ID = " + FinishOrderId.Text.ToString();
            SqlCommand cmd = new SqlCommand(command, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Order status updated", "Order status", MessageBoxButtons.OK, MessageBoxIcon.Information);
            conn.Close();
        }

        private void ShowDeposit_Click(object sender, EventArgs e)
        {
            if (Company.Text.ToString() == "")
            {
                MessageBox.Show("Enter company ID", "Company ID Is null ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            String command = "Select [deposit] from company where  ID =" + Company.Text.ToString();
            SqlCommand cmd = new SqlCommand(command, conn);
            conn.Open();
            SqlDataReader dataReader = cmd.ExecuteReader();
            dataReader.Read();
            if (dataReader.HasRows)
            {
                String result = dataReader.GetDecimal(0).ToString();
                DepositOld.Text = result;
            }
            else
            {
                MessageBox.Show("There is no company with such ID", "No company", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
            conn.Close();
        }

        private void AddToDeposit_Click(object sender, EventArgs e)
        {
            if (DepositNew.Text.ToString() == "")
            {
                MessageBox.Show("Enter value to add", "Deposit is null Is", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            String commandPart = DepositNew.Text.ToString();
            commandPart = commandPart.Replace(",", ".");
            commandPart = commandPart.Replace(" ", "0");

            
            String command = "UPDATE [dbo].[Company] SET [Deposit] = [Deposit] +  " + commandPart + " WHERE ID = " + Company.Text.ToString();
            SqlCommand cmd = new SqlCommand(command, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Deposit updated", "Deposit status", MessageBoxButtons.OK, MessageBoxIcon.Information);
            conn.Close();
        }

        private void AddItem_Click(object sender, EventArgs e)
        {
            if ((ItemName.Text.ToString() == "") || (ItemPrice.Text.ToString() == "") || (ItemPhotoLink.Text.ToString() == "") || (ItemCategory.Text.ToString() == "") || (ItemDescription.Text.ToString() == ""))
            {
                MessageBox.Show("Some fields are empty", "Empty fields", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            String checkComm = "select * from category where id = " + ItemCategory.Text.ToString();
            SqlCommand chkcmd = new SqlCommand(checkComm, conn);
            conn.Open();
            SqlDataReader reader = chkcmd.ExecuteReader();
            reader.Read();
            if (!reader.HasRows)
            {
                MessageBox.Show("Wrong category ID", "Add failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn.Close();
                return;
            }
            conn.Close();
            String command = "INSERT INTO [dbo].[Item] ([name],[price],[categoryID],[photo],[description]) VALUES ('" + ItemName.Text.ToString() + "' ,"+ ItemPrice.Text.ToString() +" ,'" +ItemCategory.Text.ToString()+ "' ,'" +ItemPhotoLink.Text.ToString()+"' ,'"+ ItemDescription.Text.ToString()+"')";
            SqlCommand cmd = new SqlCommand(command, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("New Item added", "Item Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
            conn.Close();
        }

        private void DeleteItem_Click(object sender, EventArgs e)
        {
            if (ItemID.Text.ToString() == "")
            {
                MessageBox.Show("Enter Item ID", "Item ID is null Is", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //-----
            String checkComm = "select * from item where id = " + ItemID.Text.ToString();
            SqlCommand chkcmd = new SqlCommand(checkComm, conn);
            conn.Open();
            SqlDataReader reader = chkcmd.ExecuteReader();
            reader.Read();
            if (!reader.HasRows)
            {
                MessageBox.Show("Wrong item ID", "Delete failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn.Close();
                return;
            }
            conn.Close();
            //-----
            String command = "Delete from item WHERE ID = " + ItemID.Text.ToString();
            SqlCommand cmd = new SqlCommand(command, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Item deleted", "Item Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
            conn.Close();        
        }

        private void ChengeItem_Click(object sender, EventArgs e)
        {
            if ((ItemID.Text.ToString() == "") && (ItemName.Text.ToString() == "") && (ItemPrice.Text.ToString() == "") && (ItemPhotoLink.Text.ToString() == "") && (ItemDescription.Text.ToString() == ""))
            {
                MessageBox.Show("All Fields are empty", "Empty fields", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //-----
            String checkComm = "select * from item where id = " + ItemID.Text.ToString();
            SqlCommand chkcmd = new SqlCommand(checkComm, conn);
            conn.Open();
            SqlDataReader reader = chkcmd.ExecuteReader();
            reader.Read();
            if (!reader.HasRows)
            {
                MessageBox.Show("Wrong item ID", "Change failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn.Close();
                return;
            }
            conn.Close();
            //-----
            if (ItemID.Text.ToString() == "")
            {
                MessageBox.Show("Enter Item ID", "Item ID is null Is", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            String command = "UPDATE [dbo].[Item] SET";
            if (ItemName.Text.ToString() != "")
            {
                command += " Name ='" + ItemName.Text.ToString() + "'";
            }
            if (ItemPrice.Text.ToString() != "")
            {
                command += " ,Price =" + ItemPrice.Text.ToString();
            }
            if (ItemPhotoLink.Text.ToString() != "")
            {
                command += " ,Photo ='" + ItemPhotoLink.Text.ToString() + "'";
            }
            if (ItemDescription.Text.ToString() != "")
            {
                command += " ,Description ='" + ItemDescription.Text.ToString()+"'";
            }
            command += " where ID = " + ItemID.Text.ToString();
            SqlCommand cmd = new SqlCommand(command, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Item changed", "Item Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
            conn.Close();
        }

        private void AddCategory_Click(object sender, EventArgs e)
        {
            if ((CategoryName.Text.ToString() == "")|| (CategoryPhotoLink.Text.ToString() == "")  || (CategoryDescription.Text.ToString() == ""))
            {
                MessageBox.Show("Some fields are empty", "Empty fields", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            String command = "INSERT INTO [dbo].[Category] ([name],[photo],[description]) VALUES ('" + CategoryName.Text.ToString() + "' ,'" + CategoryPhotoLink.Text.ToString() + "' ,'" + CategoryDescription.Text.ToString() + "')";
            SqlCommand cmd = new SqlCommand(command, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("New Category added", "Category Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
            conn.Close();

        }

        private void DeleteCategory_Click(object sender, EventArgs e)
        {
            if (CategoryID.Text.ToString() == "")
            {
                MessageBox.Show("Enter Category ID", "Category ID is null Is", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //-----
            String checkComm = "select * from category where id = " + CategoryID.Text.ToString();
            SqlCommand chkcmd = new SqlCommand(checkComm, conn);
            conn.Open();
            SqlDataReader reader = chkcmd.ExecuteReader();
            reader.Read();
            if (!reader.HasRows)
            {
                MessageBox.Show("Wrong category ID", "Delete failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn.Close();
                return;
            }
            conn.Close();
            //-----
            String command = "Delete from Category WHERE ID = " + CategoryID.Text.ToString();
            SqlCommand cmd = new SqlCommand(command, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Category deleted", "Category Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
            conn.Close();
        }

        private void ChengeCategory_Click(object sender, EventArgs e)
        {

            if (CategoryID.Text.ToString() == "")
            {
                MessageBox.Show("Enter Category ID", "Category ID is null Is", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //-----
            String checkComm = "select * from category where id = " + CategoryID.Text.ToString();
            SqlCommand chkcmd = new SqlCommand(checkComm, conn);
            conn.Open();
            SqlDataReader reader = chkcmd.ExecuteReader();
            reader.Read();
            if (!reader.HasRows)
            {
                MessageBox.Show("Wrong category ID", "Change failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn.Close();
                return;
            }
            conn.Close();
            //-----
            if ((CategoryName.Text.ToString() == "") && (CategoryPhotoLink.Text.ToString() == "") && (CategoryDescription.Text.ToString() == ""))
            {
                MessageBox.Show("All Fields are empty", "Empty fields", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (CategoryID.Text.ToString() == "")
            {
                MessageBox.Show("Enter Category ID", "Category ID is null Is", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            String command = "UPDATE [dbo].[Category] SET";
            if (CategoryName.Text.ToString() != "")
            {
                command += " Name ='" + CategoryName.Text.ToString() + "'";
            }
            if (CategoryPhotoLink.Text.ToString() != "")
            {
                command += " ,Photo ='" + CategoryPhotoLink.Text.ToString() + "'";
            }
            if (CategoryDescription.Text.ToString() != "")
            {
                command += " ,Description ='" + CategoryDescription.Text.ToString() + "'";
            }
            command += " where ID = " + CategoryID.Text.ToString();
            SqlCommand cmd = new SqlCommand(command, conn);
            conn.Open();
            Int32 count = cmd.ExecuteNonQuery();           
            if (count > 0)
            {
                MessageBox.Show("Category changed", "Category Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn.Close();
            }
            else
            {
                MessageBox.Show("No Category changed ID is wrong", "Category Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn.Close();
            }
        }

        private void ShowItems_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SELECT [ID] ,[name] ,[price] ,[categoryID] ,[description] FROM [DATABASE1.MDF].[dbo].[Item]", conn);
            Object[] allData = new Object[100];
            CategoryList.Items.Clear();
            conn.Open();
            SqlDataReader dataReader = cmd.ExecuteReader();
            if (dataReader.HasRows)
            {
                ItemsList.BeginUpdate();
                while (dataReader.Read())
                {
                    dataReader.GetSqlValues(allData);
                    ItemsList.Items.Add("ID " + allData[0].ToString() + " NAME " + allData[1].ToString() + " Price " + allData[2].ToString() + " categoryID " + allData[3].ToString());
                }
                ItemsList.EndUpdate();

            }
            MessageBox.Show("Items list refreshed", "The items list is refreshed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            conn.Close();
        }

        private void ShowCategory_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SELECT [ID] ,[name] FROM [DATABASE1.MDF].[dbo].[category]", conn);
            Object[] allData = new Object[100];
            CategoryList.Items.Clear();
            conn.Open();
            SqlDataReader dataReader = cmd.ExecuteReader();
            if (dataReader.HasRows)
            {
                CategoryList.BeginUpdate();
                while (dataReader.Read())
                {
                    dataReader.GetSqlValues(allData);
                    CategoryList.Items.Add("ID " + allData[0].ToString() + " NAME " + allData[1].ToString());
                }
                CategoryList.EndUpdate();

            }
            MessageBox.Show("Category list refreshed", "The category list is refreshed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            conn.Close();
        }

        private void ShowCompany_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SELECT [ID] ,[name], [deposit], [property] FROM [DATABASE1.MDF].[dbo].[Company]", conn);
            Object[] allData = new Object[100];
            CompanyList.Items.Clear();
            conn.Open();
            SqlDataReader dataReader = cmd.ExecuteReader();
            if (dataReader.HasRows)
            {
                CompanyList.BeginUpdate();
                while (dataReader.Read())
                {
                    dataReader.GetSqlValues(allData);
                    CompanyList.Items.Add("ID " + allData[0].ToString() + " NAME " + allData[1].ToString() + " deposit " + allData[2].ToString() + " property " + allData[3].ToString());
                }
                CompanyList.EndUpdate();

            }
            MessageBox.Show("Company list refreshed", "The Company list is refreshed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            conn.Close();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            AddPanel.Visible = true;
            lbl_CategoryID.Visible = false;
            CategoryID.Visible = false;
            AddCategory.Visible = true;
            DeleteCategory.Visible = false;
            ChangeCategory.Visible = false;

        }

        private void Delete_Click(object sender, EventArgs e)
        {
            AddPanel.Visible = false;
            lbl_CategoryID.Visible = true;
            CategoryID.Visible = true;
            AddCategory.Visible = false;
            DeleteCategory.Visible = true;
            ChangeCategory.Visible = false;
        }

        private void Change_Click(object sender, EventArgs e)
        {
            AddPanel.Visible = true;
            lbl_CategoryID.Visible = true;
            CategoryID.Visible = true;
            AddCategory.Visible = false;
            DeleteCategory.Visible = false;
            ChangeCategory.Visible = true;
        }

        private void Add1_Click(object sender, EventArgs e)
        {
            AddPanel2.Visible = true;
            lbl_Item.Visible = false;
            ItemID.Visible = false;
            DeleteItem.Visible = false;
            ChengeItem.Visible = false;
            AddItem.Visible = true;
        }

        private void Delete2_Click(object sender, EventArgs e)
        {
            AddPanel2.Visible = false;
            lbl_Item.Visible = true;
            ItemID.Visible = true;
            DeleteItem.Visible = true;
            ChengeItem.Visible = false;
            AddItem.Visible = false;
        }

        private void Change2_Click(object sender, EventArgs e)
        {
            AddPanel2.Visible = true;
            lbl_Item.Visible = true;
            ItemID.Visible = true;
            DeleteItem.Visible = false;
            ChengeItem.Visible = true;
            AddItem.Visible = false;
        }
               
    }
}

