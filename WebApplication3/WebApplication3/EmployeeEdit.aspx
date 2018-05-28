<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmployeeEdit.aspx.cs" Inherits="WebApplication3.EmployeeEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
<h1>Edit Employee</h1>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <style type="text/css">
.gridview {
    width: 100%; 
    word-wrap:break-word;
    table-layout: fixed;
}
    </style>

    <asp:Panel ID="Panel1" runat="server">
    <asp:Table ID="Table1" runat="server">

        <asp:TableRow>
            <asp:TableCell>
                Enter reference id:
                <input id="RefIDText" type="text" runat="server" />

                <asp:Button ID="RefIDBtn" runat="server" Text="Submit" UseSubmitBehavior ="true" />

                <asp:CustomValidator ID="RefIDValidator" runat="server" ErrorMessage="Entry not found"
      Display="Static" ForeColor="Red" ControlToValidate="RefIDText" ValidateEmptyText ="true"
                              OnServerValidate="RefIDValidator_ServerValidate"
      ></asp:CustomValidator>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
         </asp:Panel>
        <p></p>

    <asp:Panel runat="server" >
  <asp:GridView ID="GridView1" runat="server" Width="100%" CellPadding="4" ForeColor="#333333" GridLines="Horizontal" ShowHeaderWhenEmpty="True" ShowFooter="True" 
            CssClass="gridview"  >
            <AlternatingRowStyle BackColor="White" />
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
        </asp:Panel>
    <p></p>


    <asp:Panel ID="PanelDetails" runat="server" Wrap="true" Visible="False">
        <asp:Table ID="TableDetails" runat="server" Font-Size="Larger" CellPadding="15" CellSpacing="10" Width="80%"
         GridLines="Both">

        <asp:TableRow>
            <asp:TableCell>
                Name: <input id="inputName" runat="server" readonly="readonly" style="background-color:grey" />
            </asp:TableCell>
            <asp:TableCell>
                IC: <input id="inputIC" runat="server" readonly="readonly" style="background-color:grey" />
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow> 
            <asp:TableCell>
                Phone: <input id="inputPhone" runat="server" />
                <p></p>
                <asp:RegularExpressionValidator ID="ReqPhone" runat="server"   
                 errormessage=" Please enter a valid phone number"
                 ControlToValidate="inputPhone"    
                 ValidationExpression="^[89]\d{7}$" Display="Dynamic" ForeColor="Red" />
            </asp:TableCell>
        </asp:TableRow>

          <asp:TableRow>
             <asp:TableCell>
                Job Position: <asp:DropDownList id="ddlJP" runat="server" />
            </asp:TableCell>
            <asp:TableCell>
                Job Salary: <input id="inputJS" runat="server" />
                <p></p>
       <asp:CompareValidator runat="server" Operator="DataTypeCheck" Type="Integer" 
            ControlToValidate="inputJS" ErrorMessage="Enter numbers only" ForeColor="Red"  Display="Dynamic"/>
            </asp:TableCell>
          </asp:TableRow>
          
          <asp:TableRow>
               <asp:TableCell>
                Department Name: <asp:DropDownList id="ddlDN" runat="server" />
               </asp:TableCell>
          </asp:TableRow>

          <asp:TableRow>
               <asp:TableCell>
               Profile Picture: <asp:FileUpload runat="server" id="fileuploadPP"/>
               
       <asp:CustomValidator ID="UploadPicValidator" runat="server" ErrorMessage="Upload in JPG or PNG Format"
      Display="Dynamic" ForeColor="Red" ControlToValidate="fileuploadPP" ValidateEmptyText="true"
          OnServerValidate="UploadPicValidator_ServerValidate"
      ></asp:CustomValidator>
               
               </asp:TableCell>
          </asp:TableRow>

          <asp:TableRow>
               <asp:TableCell>
                   <asp:Button ID="ApplyChangeBtn" runat="server" Text="Apply" OnClick="ApplyChangeBtn_Click" />
               </asp:TableCell>
          </asp:TableRow>

          <asp:TableRow>
              <asp:TableCell HorizontalAlign="Left">
                    <label  id="NotificationLabel" runat="server" Visible ="false" style=" align-items:stretch; color:deepskyblue; "/>
              </asp:TableCell>
          </asp:TableRow>

       </asp:Table>
    </asp:Panel>


</asp:Content>
