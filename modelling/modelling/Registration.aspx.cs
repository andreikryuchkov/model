using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Drawing;

namespace modelling
{
    public partial class WebForm1 : Page
    {
        ClassToWorckWhithSQL ctwwSQL = new ClassToWorckWhithSQL();
        TextBox PasswordTextBox;
        TextBox PasswordRepeatTextBox;
        TextBox LoginTextBox;
        Button ButtonReg;

        #region [ Property ]
        
        private string password;
        public string Password 
        {
            get { return password; }
            set 
            {
                if (value != password) 
                {
                    password = value;
                }
            }
        }

        private string passwordRepeat;
        public string PasswordRepeat
        {
            get { return passwordRepeat; }
            set
            {
                if (value != passwordRepeat)
                {
                    passwordRepeat = value;
                }
            }
        }

        #endregion [ Property ]

        protected void Page_Load(object sender, EventArgs e)
        {
            PasswordTextBox = (TextBox)registrationView.FindControl("regPassword");
            PasswordRepeatTextBox = (TextBox)registrationView.FindControl("PasswordConfirm");
            ButtonReg = (Button)registrationView.FindControl("sendReg");
            LoginTextBox = (TextBox)registrationView.FindControl("regLogin");
        }

        protected void Password_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).ID == "regPassword") 
            {
                Password = ((TextBox)sender).Text;
            }
            if (((TextBox)sender).ID == "PasswordConfirm") 
            {
                PasswordRepeat = ((TextBox)sender).Text;
            }
            if (!ConfirmPasswords())
            {
                ButtonReg.Enabled = false;
            }
            else 
            {
                ButtonReg.Enabled = true; ;
            }
        }

        private bool ConfirmPasswords()
        {
            if (PasswordTextBox != null || PasswordRepeatTextBox != null)
            {
                if (PasswordTextBox.Text != PasswordRepeatTextBox.Text)
                {
                    //regMessage.Text = "Пароли не совпадают!";
                    regMessage.ForeColor = Color.Red;
                    return false;
                }
                return true;
            }
            else
            {
                //regMessage.Text = "Поля с паролем должны быть заполнены!";
                regMessage.ForeColor = Color.Red;
                return false;
            }
        }

        private bool ConfirmLogin() 
        {
            if (LoginTextBox.Text == "") 
            {
                regMessage.ForeColor = Color.Red;
                regMessage.Text = "Поле Логин не может быть пустым!";
                return false;
            }
            if ((int)ctwwSQL.Reader.GetValue(0) != 0)
            {
                regMessage.ForeColor = Color.Red;
                regMessage.Text = "Пользователь с таким логином уже существует!";
                return false;
            }
            return true;
        }

        protected void sendReg_click(object sender, EventArgs e)
        {
            ctwwSQL.TextCommand = "select count(*) from usr where login='" +
                ((TextBox)registrationView.FindControl("regLogin")).Text + "';";
            ctwwSQL.Reader.Read();

            if (!ConfirmLogin())
            {
                ctwwSQL.Reader.Close();
                return;
            }

            if (!ConfirmPasswords()) 
            {
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