using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace modelling
{
    public partial class Order : System.Web.UI.Page
    {
        ClassToWorckWhithSQL ctwwSQL = new ClassToWorckWhithSQL();
        protected void Page_Load(object sender, EventArgs e)
        {
            var s = Session["itemsInBag"];
            List<Item> items = (List<Item>)s;
            if (items.Count == 0)
            {
                ((Button)(Ordering.FindControl("orderDelivery"))).Enabled = false;
            }
        }

        protected void orderDelivery_click(object sender, EventArgs e)
        {
            var s = Session["itemsInBag"];
            List<Item> items = (List<Item>)s;
            int usrID = Convert.ToInt32(Session["userID"]);
            ctwwSQL.TextCommand="SELECT Adress FROM usr WHERE ID="+usrID+";";
            SqlDataReader reader=ctwwSQL.ExecuteReader;
            reader.Read();
            string adress;
            if (((TextBox)(Ordering.FindControl("adressInput"))).Text.Length==0)
                adress=Convert.ToString(reader.GetValue(0));
            else 
                adress=((TextBox)(Ordering.FindControl("adressInput"))).Text;
            ctwwSQL.TextCommand = "INSERT INTO ord(usr,adress) values ("+usrID+",'"+adress+"');";
            ctwwSQL.TextCommand = "SELECT max(ID) FROM ord WHERE usr=" + usrID + ";";
            reader = ctwwSQL.ExecuteReader;
            reader.Read();
            int orderID = (int)reader.GetValue(0);
            foreach (Item iter in items)
            {
                ctwwSQL.TextCommand = "INSERT INTO itemOrdered(ord,item) values (" + orderID + "," + iter.id + ");";
            }
            items.Clear();
            Session["itemsInBag"] = items;
            orderStatus.Text = "Ваш заказ принят!";
        }
    }
}