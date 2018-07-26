<%@ Page Title="" Language="C#" MasterPageFile="~/Master Pages/Site.Master" AutoEventWireup="true" CodeBehind="EmployeeEdit.aspx.cs" Inherits="WebApplication3.EmployeeEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
    <h1 class="title-visual">Edit Employee</h1>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <style type="text/css">
        .gridview {
            width: 100%;
            word-wrap: break-word;
            table-layout: fixed;
        }
    </style>

    <asp:Panel ID="Panel1" runat="server">

        <br />
        <div class="form-group row content-center col-md-6" style="margin-left:30%"> 

             <label for="RefIDText" class="col-sm-5 col-form-label; font-visual">Enter search: </label>

            <div class="col-sm-8">
   
                <div>
                <input id="RefIDText" class="form-control; inputbox-size" placeholder="Enter search"
                    runat="server" type="text"/>

                <button id="RefIDBtn" runat="server" class="rounded; button-size" type="submit">
                    Submit
                </button>
                    </div>
                <div>
                <asp:CustomValidator ID="RefIDValidator" runat="server" 
                    ErrorMessage="Entry not found"
                    Display="Static" 
                    Class="ReqCSS"
                    ControlToValidate="RefIDText" 
                    ValidateEmptyText="true"
                    OnServerValidate="RefIDValidator_ServerValidate" />

                    <label id="NotificationLabel" runat="server" visible="false" style="align-items: stretch; color: blue;" />
       
                </div>
            </div>
        </div>

    </asp:Panel>
    <p></p>

    <asp:Panel runat="server">
        <div class=" content-center"> 
        <asp:GridView ID="GridView1" runat="server" Width="80%" CellPadding="4" ForeColor="#333333" GridLines="Horizontal" ShowHeaderWhenEmpty="True" ShowFooter="True"
            CssClass="gridview" OnSelectedIndexChanging="GridView1_SelectedIndexChanging">
            <AlternatingRowStyle BackColor="White" />
             <Columns>       
                    <asp:CommandField ShowSelectButton="True" Visible="True" />
                </Columns>
               <FooterStyle BackColor="#003D7C" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#003D7C" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="Transparent" ForeColor="Black" />
                <RowStyle BackColor="#ff9933" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#cccccc" Font-Bold="True" ForeColor="Navy" />
            <SortedAscendingCellStyle BackColor="#FDF5AC" />
            <SortedAscendingHeaderStyle BackColor="#4D0000" />
            <SortedDescendingCellStyle BackColor="#FCF6C0" />
            <SortedDescendingHeaderStyle BackColor="#820000" />
        </asp:GridView>
        </div>
    </asp:Panel>
    <p></p>

    <asp:Panel ID="PanelDetails" runat="server" Wrap="true" Visible="False">
       
        <hr style="margin-top:5%" />

        <div>
            <my:HRUserControl ID="UserControlEdit" runat="server" />
        </div>

        <asp:CustomValidator ID="UploadPicValidator" runat="server" 
            ErrorMessage="Upload in JPG or PNG Format" 
            Display="Dynamic" 
            Class="ReqCSS"
            ControlToValidate='<%= UserControlEdit.InputPicture.ID %>'
            ValidateEmptyText="true"
            OnServerValidate="UploadPicValidator_ServerValidate" />

        <div class=" hrform">
          <div style="margin-left:15%">
                <button id="ApplyChangeBtn" runat="server" onserverclick="ApplyChangeBtn_Click" class="rounded"
                    style="width: 120px">
                    Apply
                </button>
          </div>
        </div>
    </asp:Panel>


</asp:Content>
