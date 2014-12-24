<%@ Page Title="Регистрация" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="modelling.WebForm1" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContent" runat="server">

<script type="text/javascript" src="scripts/validate.js" language=javascript>
</script>
<script type="text/javascript" src="scripts/scripts.js" language=javascript>
</script>
    <script type="text/javascript" >
        function check_number(obj) {
            obj = (obj) ? obj : window.obj
            var charCode = (obj.which) ? obj.which : obj.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                status = "В данное поле можно вводить только цифры"
                return false;
            }
            status = \'\';
            return true;
        }
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
                  Логин*: <br />
                  <img src="/images/regSeparator.png" class="regSeparator" />
                       Пароль*:  <br />
                       <img src="/images/regSeparator.png" class="regSeparator" />
                   Подтвердите пароль*: <br />
                   <img src="/images/regSeparator.png" class="regSeparator" />
               
                   Электронная почта*: <br />
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
                            Реквизиты*: <br />
                            <img src="/images/regSeparator.png" class="regSeparator" />
                            Имя компании*:  <br />
                    </div>
                </div>
                <div id="textBoxes">
                <asp:TextBox CssClass="regTextBox" runat=server MaxLength=20  ID=regLogin onkeyup="validateRegistration()" ></asp:TextBox> <br />
                <asp:TextBox runat=server CssClass="regTextBox" MaxLength=20 TextMode=Password ID=regPassword onkeyup   ="validateRegistration()" ></asp:TextBox> <br />
                <asp:TextBox runat=server CssClass="regTextBox" TextMode=Password MaxLength=20  ID=PasswordConfirm onkeyup   ="validateRegistration()"  ></asp:TextBox> <br />
                <asp:TextBox runat=server CssClass="regTextBox" TextMode=Email MaxLength=40 ID=regMail  ></asp:TextBox><br />
                <asp:TextBox runat=server CssClass="regTextBox" MaxLength=20  ID=regName  ></asp:TextBox> <br />
                <asp:TextBox runat=server CssClass="regTextBox" MaxLength=20  ID=regFamily ></asp:TextBox> <br />
                <asp:TextBox runat=server CssClass="regTextBox"  TextMode=Phone ID=regPhone MaxLength=11 onKeyPress="return check_number(event);" onkeyup="validateRegistration()" ></asp:TextBox> <br />
                <asp:TextBox runat=server CssClass="regTextBox" ID=regCity ></asp:TextBox> <br />
                <asp:TextBox runat=server CssClass="regTextBox" ID=regStreet ></asp:TextBox> <br />
                <asp:TextBox runat=server CssClass="regTextBox" ID=regBuilding ></asp:TextBox> <br />
                <asp:CheckBox runat=server CssClass="regTextBox" ID=regForGurFace Name="regForGurFace" OnClick="regGurFace()" onchange="changeForGurFace()"></asp:CheckBox> <br /> 
                 <div style="margin:0; visibility:hidden;" id="companyFields">
                <asp:TextBox runat=server CssClass="regTextBox" MaxLength=20  ID=regRequisites  onkeyup="validateRegistrationGur()"></asp:TextBox> <br />
                <asp:TextBox runat=server CssClass="regTextBox" MaxLength=20  ID=regCompanyName onkeyup="validateRegistrationGur()"></asp:TextBox> <br />
                 </div>

                    <!--<asp:TextBox runat=server CssClass="regTextBox contactFace" ID=contactFace  >
                    </asp:TextBox> <br />        -->
                </div>
                <div id="ofer" style="height: 196px;overflow-y: scroll;width: 523px;">
                    <p>
                        Настоящий документ представляет собой официальное предложение компании «Good Food», именуемого в дальнейшем «Исполнитель», заключить договор подряда на использование автоматизированной системы оформления и обработки заказов на доставку блюд на изложенных ниже условиях. 

1. Термины и определения

1.1.	В настоящем документе и вытекающих или связанным с ним отношениях Сторон применяются следующие термины и определения:

1.1.1.    Публичная оферта / Оферта – текст настоящего документа со всеми приложениями, изменениями и дополнениями к нему, размещенный на Сайте Исполнителя.

1.1.2.    Договор – договор подряда на выполнение работ, заключенный между Исполнителем и Заказчиком на условиях настоящей Оферты.

1.1.3.    Работы включают:

а) работы по оформлению и обработке заказов на доставку еды на основе предоставленных Заказчиком данных;

б) работы по оформлению и обработке заказов на доставку еды на основе данных, представленных на Сайте Исполнителя; 

в) иные работы и/или услуги, сопутствующие выполнению работ, предусмотренных в пп. «а» и «б» настоящего пункта, или  носящие подготовительный характер.


1.1.4.    Акцепт Оферты - полное и безоговорочное принятие Оферты путем совершения Заказчиком действий, указанных в  настоящей Оферте, создающее Договор между Заказчиком и Исполнителем.

1.1.5.    Заказчик – лицо, способное совершить Акцепт Оферты (применительно к порядку заключения Договора) либо совершившее Акцепт Оферты (применительно к исполнению  заключенного Договора.

1.1.6.    Сайт Исполнителя / Сайт - автоматизированная информационная система, доступная в сети Интернет.

1.1.7.    Личный кабинет – персональный раздел Сайта, к которому Заказчик получает доступ после прохождения регистрации и/или авторизации на Сайте. Личный кабинет предназначен для хранения персональной информации Заказчика, оформления Заказов, просмотра статистической информации о совершенных Заказах, стадии их выполнения, текущем состоянии Лицевого счета, и получения уведомлений. 


1.1.8.    Лицевой счет – информация о внесенных Заказчиком и списанных в рамках исполнения Договоров денежных средствах в счет оплаты выполняемых Работ по указанным Договорам. Доступ к Лицевому счету предоставляется Заказчику с использованием его Личного кабинета. 

1.1.9.    Заказ – выполнение Заказчиком действий, перечисленных на соответствующей странице Сайта, необходимых для оформления отдельного Договора.


2.    Предмет Договора

2.1.    Исполнитель обязуется выполнять Работы на основании размещенных Заказов, а Заказчик принимать и оплачивать Работы на условиях настоящей Оферты.

2.2.    Наименование и состав Работ, сроки и стоимость их выполнения, а также прочие необходимые условия Договора определяются на основании сведений и материалов, предоставленных Заказчиком при оформлении Заказа. 

2.3.    Обязательным условием выполнения Исполнителем Работ является безоговорочное принятие и  соблюдение Заказчиком,  применяемых к отношениям сторон по Договору требований и положений, определенных ниже:

•	Заказ может быть принят и обработан Исполнителем только после регистрации Заказчика, принятия правил Публичной Оферты и его согласия на обработку персональных данных;
•	Заказ может состоять только из представленных в действующем на момент заказа меню товаров и услуг;
•	Оплата заказа Заказчиком может осуществляться строго в соответствии с действующим на момент оформления заказа прайс-листом;
•	Передача заказа Заказчику может осуществляться после полной оплаты заказа.


3.    Права и обязанности сторон Договора

•	Заказ может быть принят и обработан Исполнителем только после регистрации Заказчика, принятия правил Публичной Оферты и его согласия на обработку персональных данных;
•	Заказ может состоять только из представленных в действующем на момент заказа меню товаров и услуг;
•	Оплата заказа Заказчиком может осуществляться строго в соответствии с действующим на момент оформления заказа прайс-листом;
•	Передача заказа Заказчику может осуществляться после полной оплаты заказа.



4.    Порядок приемки-передачи работ
•	Для того чтобы иметь возможность сделать заказ на сайте Исполнителя, Заказчик должен пройти регистрацию, в которой ему необходимо заполнить все обязательные для заполнения поля, принять условия Публичной Оферты и подписать соглашение на обработку персональных данных Исполнителем;
•	При принятии заказа, сделанного Заказчиком на сайте Исполнителя, Исполнитель должен: отослать письмо с подтверждением заказа на электронную почту Заказчика, указанную при регистрации;
•	Заказчик должен оплатить полную стоимость, предоставленных Исполнителем услуг.


5.    Акцепт Оферты и заключение Договора

Заказчик в полной мере обязуется выполнять обязательства, предписанные ему в данной Публичной Оферте для получения заказа. Исполнитель в полной мере обязуется выполнять обязательства, предписанные ему в данной Публичной Оферте для обработки и оформления заказа.



                    </p>
                </div>
                <br>
                Я согласен с договором* <asp:CheckBox runat="server" onchange="validateRegistration()" ID="regOfer" />
                <div style="width:90%;">
                    <br>
                    <asp:Button ID=sendReg OnClick="sendReg_click" runat=server Text="Зарегистрировать!" /> 
                </div>
            </AnonymousTemplate>
        </asp:LoginView>
    </div>
</asp:Content>
