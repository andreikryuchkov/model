using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Security;
using System.Security.Cryptography;
using System.Text;

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
            if (((string)r.GetValue(0)) ==  ctwwSQL.GetMD5Hash(((TextBox)HeadLoginView.FindControl("loginPassword")).Text))
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


        protected void forgotPassword(object sender, EventArgs e)
        {
            ctwwSQL.TextCommand = "select mail from usr where login='" + ((TextBox)HeadLoginView.FindControl("loginUsrName")).Text + "';";
            SqlDataReader r;
            r = ctwwSQL.ExecuteReader;
            if (!(r.Read()))
            {
                ((Label)HeadLoginView.FindControl("authInfo")).ForeColor = System.Drawing.Color.Red;
                ((Label)HeadLoginView.FindControl("authInfo")).Text = "Пользователь не найден!";
                return;
            }
            else
            { 
                Random rand= new Random(DateTime.Now.Millisecond);
                string newPwd = ctwwSQL.GetMD5Hash(rand.Next(10000).ToString()).Substring(0, 5);
                string mail = r[0].ToString();
                ctwwSQL.TextCommand = "update usr set password='" + ctwwSQL.GetMD5Hash(newPwd) +
                    "' where login='" + ((TextBox)HeadLoginView.FindControl("loginUsrName")).Text + "';";
                bool res=ctwwSQL.ExecuteNonQuery;
                ctwwSQL.mailTo(newPwd, mail);
                ((Label)HeadLoginView.FindControl("authInfo")).ForeColor = System.Drawing.Color.Red;
                ((Label)HeadLoginView.FindControl("authInfo")).Text = "На вашу почту было отправлено письмо с новым паролем";
            }

        }


        public void exit(object sender, EventArgs e)
        {

            FormsAuthentication.SignOut();
            Session["userID"] = null;
            Response.Redirect("/model/default.aspx");
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            deposit.Text = "";
            if (Session["userID"] != null)
            {
                ctwwSQL.TextCommand = "select companyID from usr where id='" + Session["userID"].ToString() + "';";
                ctwwSQL.Reader.Read();
                if (!(ctwwSQL.Reader.IsDBNull(0)))
                {
                    ctwwSQL.TextCommand = "select deposit from company where ID='" + ctwwSQL.Reader[0].ToString() + "';";
                    ctwwSQL.Reader.Read();
                    deposit.Text = "На Вашем счете: " + ctwwSQL.Reader[0].ToString();
                }
            }
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
