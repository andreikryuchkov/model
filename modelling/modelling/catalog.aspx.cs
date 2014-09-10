using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace modelling
{
    public class Item
    {
        private string imgURL { get; set; }
        private string description { get; set; }
        private string name { get; set; }
        private int price { get; set; }
        public Item(string Img, string Description, string Name, int Price)
        {
            imgURL = Img;
            description = Description;
            name = Name;
            price = Price;
        }
        public string formatOutput()
        {
            string result = "";
            result += "<div class=\"listItem\">" +
                "<h3></h3>" +
              "<img class=\"listItemImg\" description=\"" + description + "\" src=\"" + imgURL + "\"/>" +
              "<p>" + description + "</p>" +
              "<p style=\"Text-decoration:underline;\" >" + price + " Руб.</p>" +
            "</div>";
            return result;
        }
    }
    public partial class Catalog : System.Web.UI.Page
    {
        ClassToWorckWhithSQL ctwwSQL = new ClassToWorckWhithSQL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Request.QueryString["category"]) != null)
            {
                categoryView.Text = "";
                ctwwSQL.TextCommand = "select * from item where categoryID=" + Request.QueryString["category"] + ";";
                SqlDataReader reader = ctwwSQL.ExecuteReader;
                while (reader.Read())
                {
                    Item newItem = new Item((string)reader.GetValue(4), (string)reader.GetValue(5), (string)reader.GetValue(1), Convert.ToInt32(reader.GetValue(2)));
                    categoryView.Text += newItem.formatOutput();
                }
            } else { 

            
            }
        }
    }
}