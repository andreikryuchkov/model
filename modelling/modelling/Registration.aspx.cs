using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Drawing;
using System.Net.Mail;
using System.Net;

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
                    //regMessage.ForeColor = Color.Red;
                    return false;
                }
                return true;
            }
            else
            {
                //regMessage.Text = "Поля с паролем должны быть заполнены!";
                //regMessage.ForeColor = Color.Red;
                return false;
            }
        }

        private bool ConfirmLogin()
        {
            if (LoginTextBox.Text == "")
            {
                //regMessage.ForeColor = Color.Red;
                //regMessage.Text = "Поле Логин не может быть пустым!";
                return false;
            }
            if ((int)ctwwSQL.Reader.GetValue(0) != 0)
            {
                //regMessage.ForeColor = Color.Red;
                regMessageLog.Text = "Пользователь с таким логином уже существует!";
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
            string companyID;
            if (((CheckBox)registrationView.FindControl("regForGurFace")).Checked)
            {
                ctwwSQL.TextCommand = "insert into Company(requisites,name) values('" +
                    ((TextBox)registrationView.FindControl("regRequisites")).Text + "','" +
                    ((TextBox)registrationView.FindControl("regCompanyName")).Text + "'); Select IDENT_CURRENT('company');";
                ctwwSQL.Reader.Read();
                companyID = "'"+Convert.ToString(ctwwSQL.Reader[0])+"'";
                ctwwSQL.Reader.Close();
            }
            else
            {
                companyID = "NULL";
            }


            ctwwSQL.TextCommand = "insert into usr(login,password,mail,name,family,companyID) values('" +
                    ((TextBox)registrationView.FindControl("regLogin")).Text + "','" +
                    ctwwSQL.GetMD5Hash(((TextBox)registrationView.FindControl("regPassword")).Text) + "','" +
                    ((TextBox)registrationView.FindControl("regmail")).Text + "','" +
                    ((TextBox)registrationView.FindControl("regName")).Text + "','" +
                    ((TextBox)registrationView.FindControl("regfamily")).Text + "'," +
                    companyID + "); Select IDENT_CURRENT('usr');";
            ctwwSQL.Reader.Read();
            string usrID = Convert.ToString(ctwwSQL.Reader[0]);
            ctwwSQL.Reader.Close();

            ctwwSQL.TextCommand= "insert into Adress(usrID,city,street,building) values('" +
                    usrID + "','" +
                    ((TextBox)registrationView.FindControl("regCity")).Text + "','" +
                    ((TextBox)registrationView.FindControl("regStreet")).Text + "','" +
                    ((TextBox)registrationView.FindControl("regBuilding")).Text + "');";

            ctwwSQL.TextCommand = "insert into phone(usrID,phone) values('" +
                    usrID + "','" +
                    ((TextBox)registrationView.FindControl("regPhone")).Text + "');";
            registrationView.Visible = false;

            ctwwSQL.mailTo("Поздравляем с регистрацией",((TextBox)registrationView.FindControl("regmail")).Text);
            regMessageLog.Text = "На указанную Вами почту выслано письмо. <a href=default.aspx>Возврат на главную.</a>";
            // .Text = "На указанную Вами почту выслано письмо подтверждения регистрации ";
            return;
        }

       
        //03.10.14 	

        //SendMail("smtp.mail.ru", "black_flower_power@mail.ru", "black1488", Mail.Text, "Поздравляем с регистрацией", "Поздравляем с регистрацией");

    }
}