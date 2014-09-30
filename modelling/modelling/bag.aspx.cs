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
                
                result += "<a href=\"bag.aspx?addItem=" + ID + "\">" + "<div class=\"listItem\">" +
                    "<h3>" + item.name + "</h3>" +
                  "<img class=\"listItemImg\" description=\"" + item.id + "\" src=\"" + item.photo + "\"/>";
                result += "<p style=\"Text-decoration:underline;\" >";
                result += item.price + " Руб.</p>";
                result += "</div></a>";
            }
            result += "</div>";
            return result;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Request.QueryString["addItem"]) != null)
            {
                Item newItem=new Item(Convert.ToInt32(Request.QueryString["addItem"]));
                var s=Session["itemsInBag"];
                List<Item> items = (List<Item>)s;
                items.Add(newItem);
                Session["itemsInBag"] = items;
                
            }
            else
            { 
                var s=Session["itemsInBag"];
                List<Item> items = (List<Item>)s;
                string text = formatOutput(items);
                bagView.Text = text;
            }
        }
    }
}