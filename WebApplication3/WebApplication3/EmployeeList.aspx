<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeList.aspx.cs" Inherits="WebApplication3.EmployeeList"
    MasterPageFile="~/Site.Master" %>

<asp:Content ID="Content2" ContentPlaceHolderID="HeaderContent" runat="server">
    <h1>Employee List</h1>
</asp:Content>

<asp:Content ID="HRMainContent" ContentPlaceHolderID="MainContent" runat="server">
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<body>
        <div style="height: 87px">
                <asp:TextBox ID="SearchText" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>         
                <br />
                <br />
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Show All" UseSubmitBehavior="False" Width="80px" />
            
        </div>
        <asp:GridView ID="GridView1" runat="server" Width="100%" CellPadding="4" ForeColor="#333333" GridLines="Horizontal" ShowHeaderWhenEmpty="True" ShowFooter="True" OnRowDeleting="GridView1_RowDeleting" OnSelectedIndexChanging="GridView1_SelectedIndexChanging"  
             AllowPaging="true"  OnPageIndexChanging="GridView1_PageIndexChanging">
                   <pagersettings mode="Numeric"
          position="Bottom"           
          pagebuttoncount="10"/>

        <pagerstyle backcolor="LightBlue"
          height="30px"
          verticalalign="Bottom"
          horizontalalign="Center"/>

            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
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
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:SecondConnectionString %>" SelectCommand="SELECT [Name], [Phone], [IC], [Position] FROM [HRTable]"></asp:SqlDataSource>
    
</body>
</html>
    </asp:Content>
