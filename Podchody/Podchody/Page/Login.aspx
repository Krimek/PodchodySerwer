<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Podchody.Page.Login" MasterPageFile="~/Page/Stalking.Master" %>

<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server">
    <div id ="login">
        <asp:Label ID="Label1" runat="server" Text="Login: "></asp:Label>
        <asp:TextBox ID="LoginTextBox" runat="server"></asp:TextBox>
    </div>
    <div id="password">
        <asp:Label ID="Label2" runat="server" Text="Hasło: "></asp:Label>
        <asp:TextBox ID="PasswordTextBox" runat="server" TextMode="Password"></asp:TextBox>
    </div>
    <div id="applyButton">
        <asp:Button ID="Log" runat="server" Text="Zaloguj" OnClick="Log_Click"/>
    </div>
 </asp:Content>
