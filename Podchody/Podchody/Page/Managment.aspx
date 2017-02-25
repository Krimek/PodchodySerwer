<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Managment.aspx.cs" Inherits="Podchody.Page.Managment" MasterPageFile="~/Page/Stalking.Master" %>

<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Drużyny</h3>
    <asp:DropDownList ID="TeamDropDownList" runat="server" OnSelectedIndexChanged="TeamDropDownList_SelectedIndexChanged">
    </asp:DropDownList>
    <asp:DataGrid ID="TeamDataGrid" runat="server">
    </asp:DataGrid>
    <h3>Stacje</h3>
    <asp:DropDownList ID="StationDropDownList" runat="server" >
    </asp:DropDownList>
    <asp:DataGrid ID ="StationDataGrid" runat="server">
    </asp:DataGrid>
    <h3>Zadania specjalne</h3>
    <asp:DropDownList ID="SpecialTaskDropDownList" runat="server" >
    </asp:DropDownList>
    <asp:DataGrid ID ="SpecialTaskDataGrid" runat="server">
    </asp:DataGrid>

</asp:Content>
