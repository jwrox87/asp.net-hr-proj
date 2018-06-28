<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeList.aspx.cs" Inherits="WebApplication3.EmployeeList"
    MasterPageFile="~/Master Pages/Site.Master" %>

<asp:Content ID="Content2" ContentPlaceHolderID="HeaderContent" runat="server">
    <h1 style="color:#EF7C00">Employee List</h1>
</asp:Content>

<asp:Content ID="HRMainContent" ContentPlaceHolderID="MainContent" runat="server">
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<body>
        <div class="container-fluid">
            Enter search:
                <asp:TextBox ID="SearchText" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>         
                <br />
                <br />
                <%--<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Show All" UseSubmitBehavior="False" Width="80px" />--%>

            <button id="Button1" runat="server" onserverclick="Button1_Click" type="button" style="width:200px">Show All</button>
                
            &nbsp;
            Show Select:
            <asp:CheckBox ID="SelectCheckBox" runat="server"  OnCheckedChanged="SelectCheckBox_CheckedChanged" AutoPostBack="true"/>
            &nbsp;
            Show Delete:
            <asp:CheckBox ID="DeleteCheckBox" runat="server" OnCheckedChanged="DeleteCheckBox_CheckedChanged" AutoPostBack="true"/>

        </div>
    <br />
    <div class="container-fluid">
        <asp:GridView ID="GridView1" runat="server" Width="100%" CellPadding="4" ForeColor="#333333" GridLines="Horizontal" ShowHeaderWhenEmpty="True" ShowFooter="True" OnRowDeleting="GridView1_RowDeleting" OnSelectedIndexChanging="GridView1_SelectedIndexChanging"  
             AllowPaging="true"  OnPageIndexChanging="GridView1_PageIndexChanging" AllowSorting="True" OnSorting="GridView1_Sorting">
                   
            
            
            <pagersettings mode="Numeric"
          position="Bottom"           
          pagebuttoncount="10"/>

        <pagerstyle backcolor="LightBlue"
          height="30px"
          verticalalign="Bottom"
          horizontalalign="Center"/>

            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:CommandField ShowSelectButton="True" Visible="false" />
                <asp:CommandField ShowDeleteButton="True" Visible="false"/>
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
        </div>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:SecondConnectionString %>" SelectCommand="SELECT [Name], [Phone], [IC], [Position] FROM [HRTable]"></asp:SqlDataSource>
    
</body>
</html>
    </asp:Content>
