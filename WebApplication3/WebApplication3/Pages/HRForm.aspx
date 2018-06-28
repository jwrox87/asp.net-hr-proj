﻿
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HRForm.aspx.cs" Inherits="WebApplication3.HRForm" 
     MasterPageFile="~/Master Pages/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
    <h1 style="color:#EF7C00">Add a Employee</h1>
</asp:Content>
   

<asp:Content ID="HRFormMainContent" ContentPlaceHolderID="MainContent" runat="server">
<!DOCTYPE html>
<style type="text/css">
   /*label {
    display: block;
    float: left;
    width: 60px;
}*/

div {
    /*margin-bottom: 2px;*/
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
<body>
   
    <div style="height:100%; overflow:visible; padding-left:40%">
        <p>   
            <asp:Table ID="Table1" runat="server" Height="100%" Width="490px" CellPadding="8">
                
                <asp:TableRow BorderWidth="20px" BorderColor="#F8F8F8">
                    <asp:TableCell> 

                        <label style="width:20%">Name: </label>
                                         
                        <asp:TextBox ID="NameText"  runat="server" MaxLength="20" />
                    
                       <asp:RequiredFieldValidator CssClass ="ReqCSS" runat="server" id="reqName" controltovalidate="NameText" errormessage=" Please enter your name!" ViewStateMode="Inherit" ValidateRequestMode="Inherit" Visible="True" Display="Dynamic"/>                
                        <asp:RegularExpressionValidator CssClass ="ReqCSS" runat="server" id ="reqName2" ControlToValidate="NameText" errormessage=" Please enter only letters!" Visible ="true"
                            ValidationExpression="^(?=.*?[A-Za-z])[^0-9]+$" Display="Dynamic" />

                      </asp:TableCell>

                </asp:TableRow>

                <asp:TableRow BorderWidth="20px" BorderColor="#F8F8F8">
                    <asp:TableCell> 
                        <label style="width:20%">IC No.: </label>
                         <asp:TextBox ID="ICText" runat ="server" MaxLength="9"/>
                     <asp:RegularExpressionValidator ID="ReqIC" runat="server"   
                            CssClass ="ReqCSS"
                            errormessage=" Please enter a valid IC number"
                            ControlToValidate="ICText"    
                            ValidationExpression="^[SFTG]\d{7}[A-Z]$" Display="Dynamic" />
                          <asp:CustomValidator ID="CheckICValidator" runat="server" ErrorMessage="Duplicate Entry"
      Display="Dynamic" ForeColor="Red" ControlToValidate="ICText"
                              OnServerValidate="CheckICValidator_ServerValidate"
      ></asp:CustomValidator>
                        </asp:TableCell>

                </asp:TableRow>
                
                <asp:TableRow BorderWidth="20px" BorderColor="#F8F8F8">
                    <asp:TableCell> 
                        <label style="width:20%">Phone: </label>
                        <asp:TextBox ID="PhoneText" runat ="server" MaxLength="8"/>

                        <asp:RegularExpressionValidator ID="ReqPhone" runat="server"   
                            CssClass ="ReqCSS"
                            errormessage=" Please enter a valid phone number"
                            ControlToValidate="PhoneText"    
                            ValidationExpression="^[89]\d{7}$" Display="Dynamic" />
                        <asp:CustomValidator ID="CheckPhoneValidator" runat="server" ErrorMessage="Duplicate Entry"
      Display="Dynamic" ForeColor="Red" ControlToValidate="PhoneText"
                              OnServerValidate="CheckPhoneValidator_ServerValidate"
      ></asp:CustomValidator>
                    </asp:TableCell>
                </asp:TableRow>
                
                <asp:TableRow BorderWidth="20px" BorderColor="#F8F8F8">
                    <asp:TableCell >
                        <label style="width:20% ">Job Position: </label>                  
                        <asp:DropDownList CssClass="ddl" style="width:50%" ID="titleList" runat="server"></asp:DropDownList>
                    </asp:TableCell> 
                 </asp:TableRow>

                <asp:TableRow BorderWidth="20px" BorderColor="#F8F8F8">
                    <asp:TableCell>
                        <label style="width:20%">Job Salary: </label>            
                        
                        <asp:TextBox style="width:20%" ID="JobSalaryText" runat ="server" MaxLength="8"/>
                    <asp:CompareValidator CssClass="ReqCSS" runat="server" Operator="DataTypeCheck" Type="Integer" 
 ControlToValidate="JobSalaryText" ErrorMessage="Enter numbers only" />
                    </asp:TableCell>
                 </asp:TableRow>

                <asp:TableRow>
                    <asp:TableCell Height="30px">
                        <label style="width:20%">Department Name: </label>                  
                        <asp:DropDownList CssClass="ddl" style="width:50%" ID="DepartmentNameList" runat="server"></asp:DropDownList>
                    </asp:TableCell>
                 </asp:TableRow>

                <asp:TableRow>
                    <asp:TableCell Height="90px">
                        <label style="width:20%">Profile Picture: </label>                  
                        <asp:FileUpload ID="FileUpload1" runat="server" />
                       

                           <asp:CustomValidator ID="UploadPicValidator" runat="server" ErrorMessage="Upload in JPG or PNG Format"
      Display="Dynamic" ForeColor="Red" ControlToValidate="FileUpload1" ValidateEmptyText="true"
                              OnServerValidate="UploadPicValidator_ServerValidate"
      ></asp:CustomValidator>
                        </asp:TableCell>
                 </asp:TableRow>

            </asp:Table>

        </p>
       
    <p>   
            <asp:Label ID="UpdateStatus" runat="server" Text="Label" Visible="False"/></p>
       
        <p></p><p>
           
<%--            <asp:Button ID="AddEmployeeBtn" runat="server" Text="Add Employee"  style="height: 26px" 
                 OnClick="OnClick_AddEmployee"/>--%>

            <button id="AddEmployeeBtn" runat="server" onserverclick="OnClick_AddEmployee" type="button" style="width:200px">
                Add Employee
                </button>
        </p>

        </div>

</body>             
    
</html>
    </asp:Content>