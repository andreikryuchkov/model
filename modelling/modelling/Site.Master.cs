using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Security;
using System.Security.Cryptography;

namespace modelling
{
   
    public partial class SiteMaster : MasterPage 
    {
        ClassToWorckWhithSQL ctwwSQL = new ClassToWorckWhithSQL();

        protected void EnterTheSystem(object sender, EventArgs e)
        {
            ctwwSQL.TextCommand = "select password,ID from usr where login='" + ((TextBox)HeadLoginView.FindControl("loginUsrName")).Text + "';";
            SqlDataReader r;
            r = ctwwSQL.ExecuteReader;
            if (!(r.Read()))
            {
                ((Label)HeadLoginView.FindControl("authInfo")).ForeColor = System.Drawing.Color.Red;
                ((Label)HeadLoginView.FindControl("authInfo")).Text = "Неверная пара логин/пароль! Повторите ввод.";
                return;
            }
            if (((string)r.GetValue(0)) ==  ((TextBox)HeadLoginView.FindControl("loginPassword")).Text)
            {
                Session.Add("userID", r.GetValue(1));
                int a = Convert.ToInt32( Session["userID"]);
                FormsAuthentication.SetAuthCookie(((TextBox)HeadLoginView.FindControl("loginUsrName")).Text, false);
                FormsAuthentication.RedirectFromLoginPage(((TextBox)HeadLoginView.FindControl("loginUsrName")).Text, false);
                return;
            }
            ((Label)HeadLoginView.FindControl("authInfo")).ForeColor = System.Drawing.Color.Red;
            ((Label)HeadLoginView.FindControl("authInfo")).Text = "Неверная пара логин/пароль! Повторите ввод.";
            

        }


        protected void Page_Load(object sender, EventArgs e)
        {
           /* Categories.Items.Clear();
            ctwwSQL.TextCommand = "select * from category where parrentCategory is NULL;";
            while (ctwwSQL.Reader.Read())                                                            !!!!ЗАПОЛНЕНИЕ МЕНЮ!!!!
            {
                MenuItem newItem = new MenuItem();
                newItem.Text = ctwwSQL.GetStringValueReader(1);
                newItem.NavigateUrl = "/catalog.aspx?category=" + ctwwSQL.GetStringValueReader(0);
                Categories.Items.Add(newItem);
            }*/
          
        }

       
    }
}
