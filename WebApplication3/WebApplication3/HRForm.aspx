﻿
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HRForm.aspx.cs" Inherits="WebApplication3.HRForm" 
     MasterPageFile="~/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
    <h1>Add a Employee</h1>
</asp:Content>
   

<asp:Content ID="HRFormMainContent" ContentPlaceHolderID="MainContent" runat="server">
<!DOCTYPE html>
<style type="text/css">
   label {
    display: block;
    float: left;
    width: 60px;
}

div {
    margin-bottom: 2px;
}

.ReqCSS
{
    color: crimson;
}
</style>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>Add a Employee</title>
</head>
<body style="height: 100%">
        <p>   
            <asp:Table ID="Table1" runat="server" Height="142px" Width="490px">
                
                <asp:TableRow>
                    <asp:TableCell> 

                        <label>Name: </label>
                                         
                        <asp:TextBox ID="NameText"  runat="server" MaxLength="20" />
                    
                       <asp:RequiredFieldValidator CssClass ="ReqCSS" runat="server" id="reqName" controltovalidate="NameText" errormessage=" Please enter your name!" ViewStateMode="Inherit" ValidateRequestMode="Inherit" Visible="True" Display="Dynamic" />                
                        <asp:RegularExpressionValidator CssClass ="ReqCSS" runat="server" id ="reqName2" ControlToValidate="NameText" errormessage=" Please enter only letters!" Visible ="true"
                            ValidationExpression="^(?=.*?[A-Za-z])[^0-9]+$" Display="Dynamic" />

                      </asp:TableCell></asp:TableRow><asp:TableRow>
                    <asp:TableCell> 
                        <label>IC No.: </label>
                         <asp:TextBox ID="ICText" runat ="server" MaxLength="9"/>
                     <asp:RegularExpressionValidator ID="ReqIC" runat="server"   
                            CssClass ="ReqCSS"
                            errormessage=" Please enter a valid IC number"
                            ControlToValidate="ICText"    
                            ValidationExpression="^[SFTG]\d{7}[A-Z]$" Display="Dynamic" />
                        </asp:TableCell></asp:TableRow>
                
                <asp:TableRow>
                    <asp:TableCell> 

                        <label>Phone: </label>
                        <asp:TextBox ID="PhoneText" runat ="server" MaxLength="8"/>

                        <asp:RegularExpressionValidator ID="ReqPhone" runat="server"   
                            CssClass ="ReqCSS"
                            errormessage=" Please enter a valid phone number"
                            ControlToValidate="PhoneText"    
                            ValidationExpression="^[89]\d{7}$" Display="Dynamic" />

                    </asp:TableCell>
                </asp:TableRow>
                
                <asp:TableRow>
                    <asp:TableCell>
                        <label>Job Position: </label>                  
                        <asp:DropDownList ID="titleList" runat="server"></asp:DropDownList>
                    </asp:TableCell>
                 </asp:TableRow>

                <asp:TableRow>
                    <asp:TableCell>
                        <label>Job Salary: </label>                  
                        <asp:TextBox ID="JobSalaryText" runat ="server" MaxLength="8"/>
                    </asp:TableCell>
                 </asp:TableRow>

                <asp:TableRow>
                    <asp:TableCell>
                        <label>Department Name: </label>                  
                        <asp:DropDownList ID="DepartmentNameList" runat="server"></asp:DropDownList>
                    </asp:TableCell>
                 </asp:TableRow>

            </asp:Table>

        </p><p>   
            <asp:Label ID="UpdateStatus" runat="server" Text="Label" Visible="False"/></p>
       
        <p></p><p>
           
            <asp:Button ID="AddEmployeeBtn" runat="server" Text="Add Employee"  style="height: 26px" 
                 OnClick="OnClick_AddEmployee"/>
           


        </p>

</body>             
    
</html>
    </asp:Content>