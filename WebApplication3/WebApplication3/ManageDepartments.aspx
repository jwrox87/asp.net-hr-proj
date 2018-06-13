<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageDepartments.aspx.cs" Inherits="WebApplication3.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
    <h1>Manage Departments</h1>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

        <asp:Button ID="AddDepBtn" runat="server" Text="Add Department" OnClick="AddDepartmentBtn_Click"/>
    <p></p>
    <asp:Panel ID="AddDepPanel" runat="server" Visible ="false" style="margin-left:5px; margin-bottom:5px;">
        
        <asp:Table runat="server" >
            <asp:TableRow >
                <asp:TableCell>

                     <label>Department Title:</label>
                </asp:TableCell>
                <asp:TableCell>

                    <input id="AddDepText" runat="server" type="text" maxlength="50" style="padding-left:2em"/>

                </asp:TableCell>
                <asp:TableCell>

                            <asp:Button ID="AddDepSubmitBtn" runat="server" Text="Add" style="margin-left:8px"
            OnClick="AddDepSubmitBtn_Click"/>

                </asp:TableCell>
            </asp:TableRow>

        </asp:Table>
        <p>
        </p>

    </asp:Panel>
   
       <asp:CustomValidator ID="AddDepValidator" runat="server" ErrorMessage="Duplicate Entry"
      Display="Dynamic" ForeColor="Red" ControlToValidate="AddDepText" OnServerValidate="AddDepValidator_ServerValidate"
      ></asp:CustomValidator>
        

  <asp:RegularExpressionValidator runat="server"
          ControlToValidate="AddDepText" ValidationExpression="^(?=.*?[A-Za-z])[^0-9]+$" Display="Dynamic"
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
