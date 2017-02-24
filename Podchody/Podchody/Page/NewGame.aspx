﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewGame.aspx.cs" Inherits="Podchody.Page.NewStalking" MasterPageFile="~/Page/Stalking.Master"%>

<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Uzupełnij poniższe pola aby rozpocząć grę.</h2>
    <div>
        <asp:Label runat="server" ID="amountStationLabel" Text="Wprowadź ilość stacji" />
        <asp:TextBox runat="server" ID="amountStationTextBox" MaxLength="2" Width="30"/>
    </div>
    <div>
        <asp:Label runat="server" ID="amountSpecialTaskLabel" Text="Wprowadź ilość zadań specjalnych" />
        <asp:TextBox runat="server" ID="amountSpecialTaskTextBox" MaxLength="2" Width="30"/>
    </div>
    <div>
        <asp:Label runat="server" ID="penaltyHintLabel" Text="Kara za podpowiedź" />
        <asp:TextBox runat="server" ID="penaltyHintTextBox" MaxLength="2" Width="30"/>
    </div>
    <div>
        <asp:Label runat="server" ID="penaltyNextPlaceLabel" Text="Kara za wskazanie następnego miejsca" />
        <asp:TextBox runat="server" ID="penaltyNextPlaceTextBox" MaxLength="2" Width="30"/>
    </div>
    
    <asp:Button runat="server" ID="applyButton" Text="Dalej" />

    <div id = "PropertiesStalking" runat = "server"></div>
    <div id = "Station" runat = "server"> </div>
    <div id = "SpecialTask" runat = "server"></div>
</asp:Content>
