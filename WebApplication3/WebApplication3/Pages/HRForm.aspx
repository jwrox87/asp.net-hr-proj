<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HRForm.aspx.cs" Inherits="WebApplication3.HRForm"
    MasterPageFile="~/Master Pages/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
    <h1 class="title-visual">Add a Employee</h1>
</asp:Content>

<asp:Content ID="HRFormMainContent" ContentPlaceHolderID="MainContent" runat="server">
    <!DOCTYPE html>

    <html>
    <head>
        <title>Add a Employee</title>
    </head>
    <body>

        <div>
            <my:HRUserControl ID="UserControl" runat="server" />           
        </div>

        <div class=" hrform">

            <asp:TextBox runat="server" ID="dummytext" Visible="false" />

            <asp:CustomValidator ID="CheckICValidator" runat="server" 
                ErrorMessage="Duplicate Entry"
                Display="Dynamic" 
                Class="ReqCSS"
                ControlToValidate="dummytext"
                OnServerValidate="CheckICValidator_ServerValidate" />  

            <asp:CustomValidator ID="CheckPhoneValidator" runat="server" 
                ErrorMessage="Duplicate Entry"
                Display="Dynamic"  
                Class="ReqCSS"
                ControlToValidate="dummytext"
                OnServerValidate="CheckPhoneValidator_ServerValidate"/>

          
            <asp:CustomValidator ID="UploadPicValidator" runat="server" 
                ErrorMessage="Upload in JPG or PNG Format"
                Display="Dynamic" 
                Class="ReqCSS"
                ControlToValidate="dummytext" 
                ValidateEmptyText="true"
                OnServerValidate="UploadPicValidator_ServerValidate"/>

<%--           xxxxxxxx
            xxxxx--%>

            <p>
                <asp:Label ID="UpdateStatus" runat="server" Text="Label" Visible="False" />
            </p>

            <p></p>

            <p>
                <button id="AddEmployeeBtn" runat="server" onserverclick="OnClick_AddEmployee" type="button" style="width: 200px">
                    Add Employee</button>
            </p>

        </div>


    </body>

    </html>

</asp:Content>