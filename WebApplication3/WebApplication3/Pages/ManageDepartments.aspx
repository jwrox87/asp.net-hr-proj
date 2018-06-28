<%@ Page Title="" Language="C#" MasterPageFile="~/Master Pages/Site.Master" AutoEventWireup="true" CodeBehind="ManageDepartments.aspx.cs" Inherits="WebApplication3.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
    <h1 style="color:#EF7C00">Manage Departments</h1>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

      <asp:ScriptManager ID="ScriptManager1" runat="server"  
        ></asp:ScriptManager>

    <div class="container">
         <asp:UpdatePanel ID="UpdatePanel1" runat="server">
             <ContentTemplate>
       <%-- <asp:Button ID="AddDepBtn" runat="server" Text="Add Department" OnClick="AddDepartmentBtn_Click" CausesValidation="false"/>--%>
                 
                  <button id="AddDepBtn" runat="server" onserverclick="AddDepartmentBtn_Click" type="button" causesvalidation="false"
        style="width:200px;height:auto;background-color:royalblue" class="rounded">Add Department</button>

    <p></p>
    <asp:Panel ID="AddDepPanel" runat="server" Visible ="false" style="margin-left:5px; margin-bottom:5px;">
        
               <%--     <input id="AddDepText" runat="server" type="text" maxlength="50" style="padding-left:2em"/>--%>

           <div class="form-group row">
             
    <label for="colFormLabelLg" class="col-sm-1 col-form-label">Department Title:</label>

             <div class="col-sm-8">
        <input id="AddDepText" class="form-control" placeholder="Enter Department Name"
                        runat="server" type="text" style="padding: 0 7px 2px;"/>

            <button id="AddDepSubmitBtn" runat="server"  onserverclick="AddDepSubmitBtn_Click" class="rounded"
                        type="button" style="margin-left:8px; width:100px;height:35px;padding: 0 7px 2px;" > Add </button>
    
             </div>
             </div>

                          <%--  <asp:Button ID="AddDepSubmitBtn" runat="server" Text="Add" style="margin-left:8px"
            OnClick="AddDepSubmitBtn_Click"/>--%>

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
                 </ContentTemplate>
        </asp:UpdatePanel>
        </div>

</asp:Content>
