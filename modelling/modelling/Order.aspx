<%@ Page Title="Оформление заказа" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Order.aspx.cs" Inherits="modelling.Order" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:LoginView ID="Ordering" runat=server >
        <AnonymousTemplate>
            <p>Вы не авторизованы на сайте, необходимо войти в систему или пройти <a href="/registration.aspx" >регистрацию. </a> </p>
        </AnonymousTemplate>
        <LoggedInTemplate>
            <p style="width:30%; display:inline-block;" > 
               Выберите адрес из списка или введите новый:
            </p>
            <asp:ListBox ID="adressList" runat=server  CssClass="adressInput"> </asp:ListBox>
            <p style="width:30%; display:inline-block;" > 
               Новый адрес:
            </p>
            <div style="display: inline-block; width: 69%;">
            <p style="width:50px;">Город: </p><asp:TextBox ID="cityInput" runat=server  CssClass="adressInput"> </asp:TextBox> <br />
            <p style="width:50px;">Улица: </p> <asp:TextBox ID="streetInput" runat=server  CssClass="adressInput"> </asp:TextBox> <br />
            <p style="width:50px;">Дом: </p> <asp:TextBox ID="buildingInput" runat=server  CssClass="adressInput"> </asp:TextBox> <br />
            </div>
            <div class="buttonContainer"> <asp:button ID="orderDelivery" OnClick="orderDelivery_click" runat=server Text="Заказать!" /> </div>
        </LoggedInTemplate>
    </asp:LoginView>
    <asp:Label runat=server ID="orderStatus" ForeColor=Red ></asp:Label>
</asp:Content>
