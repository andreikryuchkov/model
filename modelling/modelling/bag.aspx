<%@ Page Title="Корзина" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="bag.aspx.cs" Inherits="modelling.bag" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
 <asp:Label ID='bagView' runat=server Text=""></asp:Label>

<div class="buttonContainer"> 
    <asp:Button ID="newOrder" runat=server OnClick="newOrder_onclick" Text="Оформить заказ" />
    </div>
</asp:Content>
