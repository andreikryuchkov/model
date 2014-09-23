<%@ Page Title="Регистрация" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="modelling.WebForm1" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContent" runat="server">

<script type="text/javascript" src="scripts/validate.js" language=javascript>
    
</script>
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <p>Регистрация нового пользователя</p>
    <div id="newUserRegistrationContainer"> 
    <div style="width:90%;"><asp:Label ID="regMessage" Text="" runat=server></asp:Label></div>
        <asp:LoginView ID="registrationView" runat=server>
            <LoggedInTemplate>
                <p class="attentionMessage">Вы уже авторизованы на сайте! <br /> Необходимо выйти из системы для регистрации. </p>
            </LoggedInTemplate>
            <AnonymousTemplate>
                  <div>
                  Логин: <br />
                  <img src="/images/regSeparator.png" class="regSeparator" />
                       Пароль:  <br />
                       <img src="/images/regSeparator.png" class="regSeparator" />
                   Подтвердите пароль: <br />
                   <img src="/images/regSeparator.png" class="regSeparator" />
               
                   Электронная почта: <br />
                   <img src="/images/regSeparator.png" class="regSeparator" />
                    Имя: <br />
                    <img src="/images/regSeparator.png" class="regSeparator" />
                   Фамилия: <br />
                   <img src="/images/regSeparator.png" class="regSeparator" />
                    Контактный телефон: <br />
                    <img src="/images/regSeparator.png" class="regSeparator" />
                    Адрес: <br />
                </div>
                <div id="textBoxes">
                <asp:TextBox CssClass="regTextBox" runat=server MaxLength=20  ID=regLogin onkeyup="validateForLogin()" ></asp:TextBox> <br />
                <asp:TextBox runat=server CssClass="regTextBox" MaxLength=20 TextMode=Password ID=regPassword onkeyup   ="passwordChanged()" ></asp:TextBox> <br />
                <asp:TextBox runat=server CssClass="regTextBox" TextMode=Password MaxLength=20  ID=PasswordConfirm onkeyup   ="confirmPasswordChanged()"  ></asp:TextBox> <br />
                <asp:TextBox runat=server CssClass="regTextBox" TextMode=Email MaxLength=20 ID=regMail  ></asp:TextBox><br />
                <asp:TextBox runat=server CssClass="regTextBox" MaxLength=20  ID=regName  ></asp:TextBox> <br />
                <asp:TextBox runat=server CssClass="regTextBox" MaxLength=20  ID=regFamily ></asp:TextBox> <br />
                   <asp:TextBox runat=server CssClass="regTextBox"  TextMode=Phone ID=regPhone ></asp:TextBox> <br />
                    <asp:TextBox runat=server CssClass="regTextBox" ID=regAdress ></asp:TextBox> <br />                </div>

                <div style="width:90%;">
                    <asp:Button ID=sendReg OnClick="sendReg_click" runat=server Text="Зарегистрировать!"/> 
                </div>
            </AnonymousTemplate>
        </asp:LoginView>
    </div>
</asp:Content>
