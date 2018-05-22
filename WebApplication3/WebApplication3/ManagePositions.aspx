<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManagePositions.aspx.cs" Inherits="WebApplication3.WebForm2" %>

<%@ Register Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
    <h1>Manage Positions</h1>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Button ID="AddPositionBtn" runat="server" Text="Add Position" OnClick="AddPositionBtn_Click"/>
    <p></p>
    <asp:Panel ID="AddPosPanel" runat="server" Visible ="false" style="margin-left:100px; margin-bottom:50px;">
         
        <label style="padding-right:2em">Job Title:</label>
        <input id="AddPositionText" runat="server" type="text" style="padding-left:2em"/>
        <p>
        </p>
        <input id="AddDepartmentText" runat="server" type="text" />
        <asp:Button ID="AddPosSubmitBtn" runat="server" Text="Add" style="margin-left:8px"
            OnClick="AddPosSubmitBtn_Click"/>

    </asp:Panel>
   
        <asp:CustomValidator ID="AddPosValidator" runat="server" ErrorMessage="Duplicate Entry"
      Display="Dynamic" ForeColor="Red" ControlToValidate="AddPositionText" OnServerValidate="AddPosValidator_ServerValidate"
      ></asp:CustomValidator>

  <asp:RegularExpressionValidator runat="server"
          ControlToValidate="AddPositionText" ValidationExpression="^(?=.*?[A-Za-z])[^0-9]+$" Display="Dynamic"
           ErrorMessage="Please enter only letters" ForeColor="Red">
      </asp:RegularExpressionValidator> 

    <p></p>
    <asp:GridView ID="GridView1" runat="server" Width="70%"
        CellPadding="4" ForeColor="#333333" GridLines="Horizontal" ShowHeaderWhenEmpty="True" ShowFooter="True" OnRowDeleting="GridView1_RowDeleting">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:CommandField ShowDeleteButton="True" />
            </Columns>
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <SortedAscendingCellStyle BackColor="#FDF5AC" />
            <SortedAscendingHeaderStyle BackColor="#4D0000" />
            <SortedDescendingCellStyle BackColor="#FCF6C0" />
            <SortedDescendingHeaderStyle BackColor="#820000" />

    </asp:GridView>

</asp:Content>
