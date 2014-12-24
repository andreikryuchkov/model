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
            //((ListBox)(Ordering.FindControl("adressList"))).Items.Clear();
            if ((items.Count == 0))
            {
               // ((Button)(Ordering.FindControl("orderDelivery"))).Enabled = false;
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
            var s = Session["itemsInBag"];
            List<Item> items = (List<Item>)s;
            int usrID = Convert.ToInt32(Session["userID"]);

            ctwwSQL.TextCommand = "select companyID from usr where id='" + Session["userID"].ToString() + "';";
            ctwwSQL.Reader.Read();
            if (!(ctwwSQL.Reader.IsDBNull(0)))
            {
                int companyID = Convert.ToInt32(ctwwSQL.Reader[0]);
                ctwwSQL.TextCommand = "select deposit from company where ID='" + ctwwSQL.Reader[0].ToString() + "';";
                ctwwSQL.Reader.Read();
                double price=0;
                foreach(Item iter in items)
                {
                    price+=iter.price;
                }
                if (Convert.ToDouble(ctwwSQL.Reader[0]) < price)
                {
                    String JS = "<script type=\"text/javascript\" src=\"scripts/jquery-1.4.1.js\" language=javascript></script> <script language=\"javascript\"  type=\"text/javascript\"> $(document).ready(function () {alert('На Вашем счете не хватает средств!');}); </script>";
                    Response.Write(JS);
                    return;
                }
                else 
                {
                    ctwwSQL.TextCommand = "update company set deposit='"+(Convert.ToDouble(ctwwSQL.Reader[0])-price)+"' where ID="+companyID+";";
                }
            }

            if ((((TextBox)(Ordering.FindControl("cityInput"))).Text.Length == 0))
            {
                adressID = ((ListBox)(this.Ordering.FindControl("adressList"))).SelectedValue;
                if (adressID == "")
                {
                    ((ListBox)(Ordering.FindControl("adressList"))).Items.Clear();
                    return;
                }
            }
            else
            {
                string command = "insert into adress(usrID,city,street,building) values('" +
                    Convert.ToInt32(Session["userID"]) + "','" +
                    ((TextBox)(Ordering.FindControl("cityInput"))).Text + "','" +
                    ((TextBox)(Ordering.FindControl("streetInput"))).Text + "','" +
                    ((TextBox)(Ordering.FindControl("buildingInput"))).Text + "'); Select IDENT_CURRENT('adress');";
                ctwwSQL.TextCommand = command;
                ctwwSQL.Reader.Read();
                adressID = Convert.ToString(ctwwSQL.Reader[0]);
            }

            ctwwSQL.TextCommand = "INSERT INTO ord(statusID,adressID) values ('" + 1 + "','" + adressID + "'); Select IDENT_CURRENT('ord');";
//            ctwwSQL.TextCommand = "INSERT INTO ord(statusID,adressID) values ( 1 ,'" + adressID + "'); Select IDENT_CURRENT('ord');";
            ctwwSQL.Reader.Read();
            string orderID = ctwwSQL.Reader[0].ToString();
            foreach (Item iter in items)
            {
                ctwwSQL.TextCommand = "INSERT INTO itemOrdered(ordID,itemID) values (" + orderID + "," + iter.id + ");";
            }
            items.Clear();
            Session["itemsInBag"] = items;
            Ordering.Visible = false;
            orderStatus.Text = "Ваш заказ принят!";
            ((ListBox)(Ordering.FindControl("adressList"))).Items.Clear();

        }
    }
}


