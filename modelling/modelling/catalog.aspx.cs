using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace modelling
{
   
   
    public partial class Catalog : System.Web.UI.Page
    {
        ClassToWorckWhithSQL ctwwSQL = new ClassToWorckWhithSQL();
        public string formatOutputCategory(string ImgURL, string Description, string Name,int ID)
        {
            string result = "";
            result += "<a href=\"?category="+ID+"\"><div class=\"listItem\">" +
                "<h3>" + Name + "</h3>" +
              "<img class=\"listItemImg\" description=\"" + Description + "\" src=\"" + ImgURL + "\"/>" +
              "<p>" + Description + "</p>";
             result += "</div>";
            return result;
        }

        public string formatOutputItem(string ImgURL, string Description, string Name, int Price)
        {
            string result = "";
            result += "<div class=\"listItem\">" +
                "<h3>" + Name + "</h3>" +
              "<img class=\"listItemImg\" description=\"" + Description + "\" src=\"" + ImgURL + "\"/>" +
              "<p>" + Description + "</p>";
             result+= "<p style=\"Text-decoration:underline;\" >";
             result += Price + " Руб.</p>";
             result+= "</div>";
            return result;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            categoryView.Text = "";
            if ((Request.QueryString["category"]) != null)
            {
                ctwwSQL.TextCommand = "select * from item where categoryID=" + Convert.ToInt32(Request.QueryString["category"]) + ";";
                SqlDataReader reader = ctwwSQL.ExecuteReader;
                while (reader.Read())
                {
                    categoryView.Text += formatOutputItem((string)reader.GetValue(4), (string)reader.GetValue(5), (string)reader.GetValue(1), Convert.ToInt32(reader.GetValue(2)));
                }
            } else {
                ctwwSQL.TextCommand = "select * from category;";
                SqlDataReader reader = ctwwSQL.ExecuteReader;
                while (reader.Read())
                {
                    categoryView.Text += formatOutputCategory(Convert.ToString(reader.GetValue(3)), Convert.ToString(reader.GetValue(4)), Convert.ToString(reader.GetValue(1)), Convert.ToInt32(reader.GetValue(0)));
                }
            }
        }
    }
}