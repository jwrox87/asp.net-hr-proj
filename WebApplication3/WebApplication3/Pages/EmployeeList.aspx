<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeList.aspx.cs" Inherits="WebApplication3.EmployeeList"
    MasterPageFile="~/Master Pages/Site.Master" %>

<asp:Content ID="Content2" ContentPlaceHolderID="HeaderContent" runat="server">
    <h1 class="title-visual">Employee List</h1>
</asp:Content>

<asp:Content ID="HRMainContent" ContentPlaceHolderID="MainContent" runat="server">
    <!DOCTYPE html>
    <html xmlns="http://www.w3.org/1999/xhtml">
    <body>
        <div class="container-fluid" style="padding-left:35%">
            <br />
           <label for="SearchText" class="col-sm-5 col-form-label; font-visual">Enter search: </label>
             <div class="col-sm-8">
                <asp:TextBox ID="SearchText" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
                 </div>

            <div style="margin-right:auto">
            <button id="Button1" runat="server" onserverclick="Button1_Click" type="button" class="rounded; button-size">Show All</button>

            &nbsp;
            Show Select:
            <asp:CheckBox ID="SelectCheckBox" runat="server" OnCheckedChanged="SelectCheckBox_CheckedChanged" AutoPostBack="true" />
            &nbsp;
            Show Delete:
            <asp:CheckBox ID="DeleteCheckBox" runat="server" OnCheckedChanged="DeleteCheckBox_CheckedChanged" AutoPostBack="true" />
            </div>
        </div>
        <hr />
        <br />
        <div class="container-fluid">
            <asp:GridView ID="GridView1" runat="server" Width="100%" CellPadding="4" ForeColor="#333333" GridLines="None" ShowHeaderWhenEmpty="True" ShowFooter="True" OnRowDeleting="GridView1_RowDeleting" OnSelectedIndexChanging="GridView1_SelectedIndexChanging"
                AllowPaging="true" OnPageIndexChanging="GridView1_PageIndexChanging" AllowSorting="True" OnSorting="GridView1_Sorting" CssClass="table" AutoGenerateColumns="true">

                <PagerSettings Mode="Numeric"
                    Position="Bottom"
                    PageButtonCount="10" />

                <PagerStyle BackColor="LightBlue"
                    Height="30px"
                    VerticalAlign="Bottom"
                    HorizontalAlign="Center" />

                <AlternatingRowStyle BackColor="White" />
                <Columns>       
                    <asp:CommandField ShowSelectButton="True" Visible="false" />
                    <asp:CommandField ShowDeleteButton="True" Visible="false" />
                </Columns>
                <FooterStyle BackColor="#003D7C" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#003D7C" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="Transparent" ForeColor="Black" />
                <RowStyle BackColor="#ff9933" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#EF7C00" Font-Bold="True" ForeColor="Navy" />
<%--                <SortedAscendingCellStyle BackColor="#FDF5AC" CssClass="sortasc" ForeColor="White"/>
                <SortedAscendingHeaderStyle BackColor="#4D0000" CssClass="sortasc" ForeColor="White" Font-Underline="true"/>
                <SortedDescendingCellStyle BackColor="#FCF6C0" CssClass="sortdesc" ForeColor="White" />
                <SortedDescendingHeaderStyle BackColor="#820000" CssClass="sortdesc"  ForeColor="White"/>--%>
            </asp:GridView>
        </div>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:SecondConnectionString %>" SelectCommand="SELECT [Name], [Phone], [IC], [Position] FROM [HRTable]"></asp:SqlDataSource>

    </body>
    </html>
</asp:Content>
