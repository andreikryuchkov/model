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
   
    public partial class SiteMaster : MyMasterPage 
    {
        
        protected void EnterTheSystem(object sender, EventArgs e)
        {
            //SqlConnection c = new SqlConnection();
            SqlCommand q = new SqlCommand();
            q = baseConnect();
            TextBox t = ((TextBox)HeadLoginView.FindControl("loginUsrName"));
            q.CommandText = "select password from usr where login='" + ((TextBox)HeadLoginView.FindControl("loginUsrName")).Text + "';";
            SqlDataReader r;
            r = q.ExecuteReader();
            if (!(r.Read()))
            {
                ((Label)HeadLoginView.FindControl("authInfo")).ForeColor = System.Drawing.Color.Red;
                ((Label)HeadLoginView.FindControl("authInfo")).Text = "Неверная пара логин/пароль! Повторите ввод.";
                return;
            }
            if (((string)r.GetValue(0)) ==  ((TextBox)HeadLoginView.FindControl("loginPassword")).Text)
            {
                FormsAuthentication.SetAuthCookie(((TextBox)HeadLoginView.FindControl("loginUsrName")).Text, false);
                FormsAuthentication.RedirectFromLoginPage(((TextBox)HeadLoginView.FindControl("loginUsrName")).Text, false);
                //c.Close();
                
                
                //HeadLoginView.ViewStateMode =
                return;
            }
            ((Label)HeadLoginView.FindControl("authInfo")).ForeColor = System.Drawing.Color.Red;
            ((Label)HeadLoginView.FindControl("authInfo")).Text = "Неверная пара логин/пароль! Повторите ввод.";
            

        }


        protected void Page_Load(object sender, EventArgs e)
        {
            Categories.Items.Clear();
            SqlCommand command = baseConnect();
            command.CommandText = "select * from category where parrentCategory is NULL;";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                MenuItem newItem = new MenuItem();
                newItem.Text = (string)reader.GetValue(1);
                newItem.NavigateUrl="/catalog.aspx?category="+reader.GetValue(0).ToString();
                Categories.Items.Add(newItem);
            }
          
        }

       
    }
}
