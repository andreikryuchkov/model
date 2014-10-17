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
    public class Adress{
       private int ID;
       private string city;
       private string street;
       private string building;
       public Adress(int ID, string city, string street, string building)
       {
           this.ID = ID;
           this.city = city;
           this.street = street;
           this.building = building;
       }

    }

    public partial class Order : System.Web.UI.Page
    {
        ClassToWorckWhithSQL ctwwSQL = new ClassToWorckWhithSQL();
        List<Adress> adressMassive=new List<Adress>(); 

        protected void Page_Load(object sender, EventArgs e)
        {
            var s = Session["itemsInBag"];
            List<Item> items = (List<Item>)s;
            if (items.Count == 0)
            {
                ((Button)(Ordering.FindControl("orderDelivery"))).Enabled = false;
            }

            ctwwSQL.TextCommand = "select ID, city, street, building from adress where usrID='"+Convert.ToString(Session["userID"])+"';";
            //bool b=ctwwSQL.Reader.Read();
            int i=1;
            //ctwwSQL.Reader.
            while (ctwwSQL.Reader.Read())
            { 
                Adress newAdress=new Adress(Convert.ToInt32(ctwwSQL.Reader[0]),
                    Convert.ToString(ctwwSQL.Reader[1]), Convert.ToString(ctwwSQL.Reader[2]), 
                    Convert.ToString(ctwwSQL.Reader[3]));
                adressMassive.Add(newAdress);
                ListItem listItem = new ListItem(Convert.ToString(ctwwSQL.Reader[1]) + "  " + Convert.ToString(ctwwSQL.Reader[2]) + "  " + Convert.ToString(ctwwSQL.Reader[3]), Convert.ToString(ctwwSQL.Reader[0]));
                ((ListBox)(Ordering.FindControl("adressList"))).Items.Add(listItem);
                i++;
            }
        }

        protected void orderDelivery_click(object sender, EventArgs e)
        {
            string adressID;
            if (((TextBox)(Ordering.FindControl("adressInput"))).Text.Length == 0)
            {
                adressID = ((ListBox)(Ordering.FindControl("adressList"))).SelectedValue;
            }
            else
            {
                ctwwSQL.TextCommand="insert into adress(usrID,city,street,building) values('" +
                    Convert.ToInt32(Session["userID"]) + "','" +
                    ((TextBox)(Ordering.FindControl("cityInput"))).Text + "','" +
                    ((TextBox)(Ordering.FindControl("streetInput"))).Text + "','" +
                    ((TextBox)(Ordering.FindControl("buildingInput"))).Text + "'; Select max(ID) from adress;";
                ctwwSQL.Reader.Read();
                adressID =Convert.ToString(ctwwSQL.Reader[0]);
            }

            var s = Session["itemsInBag"];
            List<Item> items = (List<Item>)s;
            int usrID = Convert.ToInt32(Session["userID"]);
            ctwwSQL.TextCommand = "INSERT INTO ord(statusID,adressID) values (" + 1 + ",'" + adressID + "'); SELECT max(ID) FROM ord WHERE adressID='"+adressID+"';";
            ctwwSQL.Reader.Read();
            int orderID = (int)ctwwSQL.Reader[0];
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