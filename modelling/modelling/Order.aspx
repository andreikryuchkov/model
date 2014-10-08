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
                Введите адрес доставки. Если адрес не указан, доставка будет оформлена на адрес, указанный при регистрации.
            </p>
            <asp:TextBox ID="adressInput" runat=server  CssClass="adressInput"> </asp:TextBox>
            <div class="buttonContainer"> <asp:button ID="orderDelivery" OnClick="orderDelivery_click" runat=server Text="Заказать!" /> </div>
        </LoggedInTemplate>
    </asp:LoginView>
    <asp:Label runat=server ID="orderStatus" ForeColor=Red ></asp:Label>
</asp:Content>
