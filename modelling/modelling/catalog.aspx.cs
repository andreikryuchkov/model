using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Resources;

namespace modelling
{
   
   
    public partial class Catalog : System.Web.UI.Page
    {
        ClassToWorckWhithSQL ctwwSQL = new ClassToWorckWhithSQL();

        public string formatOutputCategory(string ImgURL, string Description, string Name,int ID)
        {
            string result = "";
            result += "<a href=\"?category=" + ID + "\"><div class=\"listItemMenu\">" +
                "<h3>" + Name + "</h3>" +
              "<img class=\"listItemImg\" description=\"" + Description + "\" src=\"" + ImgURL + "\"/>";
             result += "</div></a>";
            return result;
        }

        public string formatOutputItem(string ImgURL, string Description, string Name, int Price, int ID)
        {
            string result = "";
            result += "<a href=\"bag.aspx?addItem=" + ID + "\">" + "<div class=\"listItem\">" +
                "<h3>" + Name + "</h3>" +
              "<img class=\"listItemImg\" description=\"" + Description + "\" src=\"" + ImgURL + "\"/>" +
              "<p>" + Description + "</p>";
             result+= "<p style=\"Text-decoration:underline;\" >";
             result += Price + " Руб.</p>";
             result += "</div></a>";
            return result;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Request.QueryString["added"]) != null)
            {
                String JS = "$(document).ready(function () {alert('товар добавлен в корзину!')});";
                Response.Write(JS);
            }
            categoryView.Text = "";
            if ((Request.QueryString["category"]) != null)
            {
                ctwwSQL.TextCommand = "select * from item where categoryID=" + Convert.ToInt32(Request.QueryString["category"]) + ";";
                while (ctwwSQL.Reader.Read())
                {
                    categoryView.Text += formatOutputItem(ctwwSQL.GetStringValueReader(4), ctwwSQL.GetStringValueReader(5), ctwwSQL.GetStringValueReader(1), Convert.ToInt32(ctwwSQL.Reader.GetValue(2)),Convert.ToInt32(ctwwSQL.Reader.GetValue(0)));
                }
            }
            else
            {
                ctwwSQL.TextCommand = "select * from category;";
                while (ctwwSQL.Reader.Read())
                {
                   // Session("1321")
                    categoryView.Text += formatOutputCategory(ctwwSQL.GetStringValueReader(3), ctwwSQL.GetStringValueReader(4), ctwwSQL.GetStringValueReader(1), Convert.ToInt32(ctwwSQL.Reader.GetValue(0)));
                }
            }
        }
    }
}