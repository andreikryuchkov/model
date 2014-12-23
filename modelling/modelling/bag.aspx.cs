using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace modelling
{
    
    public partial class bag : System.Web.UI.Page
    {
        ClassToWorckWhithSQL ctwwSQL = new ClassToWorckWhithSQL();
        public string formatOutput(List<Item> input)
        {
            string result = "";
            result += "<div id=\"bagList\">";
            foreach (var item in input)
            {
                result += "<div class=\"listItem\">" + "<a href=\"bag.aspx?deleteItem=" + item.id + "\"><img class=\"DeleteItemIcon\" src=\"/images/bagDelete.png\"/></a>" +
                    "<h3>" + item.name + "</h3>" +
                  "<img class=\"listItemImg\" description=\"" + item.id + "\" src=\"" + item.photo + "\"/>";
                result += "<p style=\"Text-decoration:underline;\" >";
                result += item.price + " Руб.</p>";
                result += "</div>";
            }
            result += "</div>";
            return result;
        }

        protected void newOrder_onclick(object sender, EventArgs e)
        {
            /*var s = Session["itemsInBag"];
            List<Item> items = (List<Item>)s;
            //ctwwSQL.TextCommand = "insert into order() values ";
            items.Clear();
            Session["itemsInBag"] = items;
            bagView.Text = "";*/
            Response.Redirect("order.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            var s = Session["itemsInBag"];
            List<Item> items = (List<Item>)s;
            if ((Request.QueryString["addItem"]) != null)
            {
                Item newItem=new Item(Convert.ToInt32(Request.QueryString["addItem"]));
                items.Add(newItem);
                Session["itemsInBag"] = items;
                Response.Redirect("catalog.aspx?added=1");
                return;
            }
            if ((Request.QueryString["deleteItem"]) != null) 
            {
                Item finded = new Item();
                foreach (var it in items)
                {
                    if (it.id == Convert.ToInt32(Request.QueryString["deleteItem"]))
                    {
                        finded = it;
                        break;
                    }
                }
                items.Remove(finded);
                Session["itemsInBag"] = items;
                //return;
            }
            string text = formatOutput(items);
            bagView.Text = text;
            if ((items.Count == 0))
            {
                newOrder.Enabled = false;
            }
            else
            {
                newOrder.Enabled = true;
            }
            
        }
    }
}