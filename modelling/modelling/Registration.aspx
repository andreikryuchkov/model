<%@ Page Title="Регистрация" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="modelling.WebForm1" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContent" runat="server">

<script type="text/javascript" src="scripts/validate.js" language=javascript>
</script>
<script type="text/javascript" src="scripts/scripts.js" language=javascript>
</script>
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <p>Регистрация нового пользователя</p>
    <div id="newUserRegistrationContainer"> 
    <div style="width:90%;"><asp:Label ID="regMessageLog" Text="" runat=server></asp:Label></div>
    <div style="width:90%;"><asp:Label ID="regMessagePass" Text="" runat=server></asp:Label></div>
    <div style="width:90%;"><asp:Label ID="regMessageCompanyName" Text="" runat=server></asp:Label></div>
    <div style="width:90%;"><asp:Label ID="regMessageRequisites" Text="" runat=server></asp:Label></div>
        <asp:LoginView ID="registrationView" runat=server>
            <LoggedInTemplate>
                <p class="attentionMessage">Вы уже авторизованы на сайте! <br /> Необходимо выйти из системы для регистрации. </p>
            </LoggedInTemplate>
            <AnonymousTemplate>
                  <div id="fieldsNames">
                  Логин: <br />
                  <img src="/images/regSeparator.png" class="regSeparator" />
                       Пароль:  <br />
                       <img src="/images/regSeparator.png" class="regSeparator" />
                   Подтвердите пароль: <br />
                   <img src="/images/regSeparator.png" class="regSeparator" />
               
                   Электронная почта: <br />
                   <img src="/images/regSeparator.png" class="regSeparator" />
                    Имя: <!--<asp:Label ID="name" Text="Имя:" runat=server></asp:Label> --><br />
                    <img src="/images/regSeparator.png" class="regSeparator" />
                    Фамилия: <!--<asp:Label ID="familyName" Text="Фамилия:" runat=server></asp:Label>--><br />
                   <img src="/images/regSeparator.png" class="regSeparator" />
                    Контактный телефон: <br />
                    <img src="/images/regSeparator.png" class="regSeparator" />
                    Город: <br />
                    <img src="/images/regSeparator.png" class="regSeparator" />
                    Улица: <br />
                    <img src="/images/regSeparator.png" class="regSeparator" />
                    Дом: <br />
                    Для юр. лиц: <br />
                    <div style="margin:0; visibility:hidden;" id="companyFieldsNames">
                            Реквизиты: <br />
                            <img src="/images/regSeparator.png" class="regSeparator" />
                            Имя компании:  <br />
                    </div>
                </div>
                <div id="textBoxes">
                <asp:TextBox CssClass="regTextBox" runat=server MaxLength=20  ID=regLogin onkeyup="validateForLogin()" ></asp:TextBox> <br />
                <asp:TextBox runat=server CssClass="regTextBox" MaxLength=20 TextMode=Password ID=regPassword onkeyup   ="passwordChanged()" ></asp:TextBox> <br />
                <asp:TextBox runat=server CssClass="regTextBox" TextMode=Password MaxLength=20  ID=PasswordConfirm onkeyup   ="confirmPasswordChanged()"  ></asp:TextBox> <br />
                <asp:TextBox runat=server CssClass="regTextBox" TextMode=Email MaxLength=40 ID=regMail  ></asp:TextBox><br />
                <asp:TextBox runat=server CssClass="regTextBox" MaxLength=20  ID=regName  ></asp:TextBox> <br />
                <asp:TextBox runat=server CssClass="regTextBox" MaxLength=20  ID=regFamily ></asp:TextBox> <br />
                <asp:TextBox runat=server CssClass="regTextBox"  TextMode=Phone ID=regPhone onkeypress="validateForPhone()" ></asp:TextBox> <br />
                <asp:TextBox runat=server CssClass="regTextBox" ID=regCity ></asp:TextBox> <br />
                <asp:TextBox runat=server CssClass="regTextBox" ID=regStreet ></asp:TextBox> <br />
                <asp:TextBox runat=server CssClass="regTextBox" ID=regBuilding ></asp:TextBox> <br />
                <asp:CheckBox runat=server CssClass="regTextBox" ID=regForGurFace Name="regForGurFace" OnClick="regGurFace()" onchange="changeForGurFace()"></asp:CheckBox> <br /> 
                 <div style="margin:0; visibility:hidden;" id="companyFields">
                <asp:TextBox runat=server CssClass="regTextBox" MaxLength=20  ID=regRequisites  onkeyup="validateRequisites()"></asp:TextBox> <br />
                <asp:TextBox runat=server CssClass="regTextBox" MaxLength=20  ID=regCompanyName onkeyup="validateForCompanyName()"></asp:TextBox> <br />
                 </div>

                    <!--<asp:TextBox runat=server CssClass="regTextBox contactFace" ID=contactFace  >
                    </asp:TextBox> <br />        -->
                </div>

                <div style="width:90%;">
                    <asp:Button ID=sendReg OnClick="sendReg_click" runat=server Text="Зарегистрировать!"/> 
                </div>
            </AnonymousTemplate>
        </asp:LoginView>
    </div>
</asp:Content>
