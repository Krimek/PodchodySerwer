<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Team.aspx.cs" Inherits="Podchody.Page.Team" MasterPageFile="~/Page/Stalking.Master" %>

<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="idLabel" runat="server" Text="Id: "></asp:Label><br />
    <asp:Label ID="nameLabel" runat="server" Text="Nazwa druzyny: "></asp:Label><br />
    <asp:Label ID="startTimeLabel" runat="server" Text="Czas startu: "></asp:Label><br />
    <asp:Label ID="finishTimeLabel" runat="server" Text="Czas mety: "></asp:Label><br />
    <asp:Label ID="amountHintLabel" runat="server" Text="Ilosc podpowiedzi: "></asp:Label><br />
    <asp:Label ID="amountFullHintLabel" runat="server" Text="Ilosc pelnych podpowiedzi: "></asp:Label><br />
    <asp:Label ID="currentStationLabel" runat="server" Text="Aktualna stacja: "></asp:Label><br />
    <asp:Label ID="scoreLabel" runat="server" Text="Punkty: "></asp:Label><br />
</asp:Content>