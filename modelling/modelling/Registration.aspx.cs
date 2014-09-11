using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace modelling
{
    public partial class WebForm1 : Page
    {
        ClassToWorckWhithSQL ctwwSQL = new ClassToWorckWhithSQL();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void sendReg_click(object sender, EventArgs e)
        {
            ctwwSQL.TextCommand = "select count(*) from usr where login='" +
                ((TextBox)registrationView.FindControl("regLogin")).Text + "';";
            ctwwSQL.Reader.Read();
            if ((int)ctwwSQL.Reader.GetValue(0) != 0)
            {
                regMessage.Text = "Пользователь с таким логином уже существует!";
                ctwwSQL.Reader.Close();
                return;
            }

            ctwwSQL.TextCommand = "insert into usr(login,password,mail,name,family,phone,adress) values('" +
                ((TextBox)registrationView.FindControl("regLogin")).Text+"','"+
                ((TextBox)registrationView.FindControl("regPassword")).Text + "','"+
                ((TextBox)registrationView.FindControl("regmail")).Text+"','"+
                ((TextBox)registrationView.FindControl("regName")).Text+"','"+
                ((TextBox)registrationView.FindControl("regfamily")).Text+"','"+
                ((TextBox)registrationView.FindControl("regPhone")).Text +"','"+
                ((TextBox)registrationView.FindControl("regAdress")).Text + "');"
                ;
            ctwwSQL.SqlCommand.ExecuteNonQuery();
            registrationView.Visible = false;
            regMessage.Text = "На указанную Вами почту выслано письмо подтверждения регистрации. <a href=default.aspx>Возврат на главную.</a>"; 
            // .Text = "На указанную Вами почту выслано письмо подтверждения регистрации ";
            return;
        }
    }
}